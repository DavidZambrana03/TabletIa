using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

// Note: Removed unused using statements for clarity.
// Add them back if they are used elsewhere in your project.

namespace WhiteFlexo
{
    public class OpcUaClient
    {
        private readonly string serverUrl = "opc.tcp://192.168.10.1";
        private Session session;
        private readonly ApplicationConfiguration _config;
        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            private set
            {
                if (_isConnected == value) return;
                _isConnected = value;
                ConnectionStatusChanged?.Invoke();
            }
        }
        private readonly ApplicationInstance application;
        private CancellationTokenSource _mainCts;
        public event EventHandler<Tuple<Alarm, bool>> AlarmChanged;
        public event Action ConnectionStatusChanged;
        // Reconnection settings
        private const int ReconnectIntervalSeconds = 15;
        private Timer _reconnectTimer;
        private readonly List<Action> _recreateSubscriptionActions = new List<Action>();
        private readonly object _subscriptionLock = new object();

        public OpcUaClient()
        {
            _mainCts = new CancellationTokenSource();
            application = CreateApplicationConfiguration();

            // Start the connection maintenance task
            Task.Run(MaintainConnectionAsync, _mainCts.Token);
        }

        private async Task MaintainConnectionAsync()
        {
            Log.Information("Connection maintenance task started.");
            while (!_mainCts.IsCancellationRequested)
            {
                try
                {
                    // If session is not connected, try to connect
                    if (session == null || !session.Connected)
                    {
                        _isConnected = false;
                        Log.Information("OPC UA Client disconnected. Attempting to reconnect...");

                        // Try to connect immediately
                        await ConnectAsync();

                        // Wait only if it's still not connected
                        if (session == null || !session.Connected)
                        {
                            Log.Information($"Reconnection failed. Waiting {ReconnectIntervalSeconds} seconds before retrying...");
                            await Task.Delay(TimeSpan.FromSeconds(ReconnectIntervalSeconds), _mainCts.Token);
                        }
                    }
                    else
                    {
                        // If connected, update the flag and wait briefly
                        _isConnected = true;
                        await Task.Delay(1000, _mainCts.Token); // Short delay to prevent a tight loop
                    }
                }
                catch (TaskCanceledException)
                {
                    Log.Warning("Connection maintenance task was canceled.");
                    break;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred in the connection maintenance task.");
                    await Task.Delay(TimeSpan.FromSeconds(ReconnectIntervalSeconds), _mainCts.Token);
                }
            }
            Log.Information("Connection maintenance task stopped.");
        }


        private ApplicationInstance CreateApplicationConfiguration()
        {
            return new ApplicationInstance
            {
                ApplicationType = ApplicationType.Client,
                ConfigSectionName = "OpcUaClientWF"
            };
        }

        public async Task<bool> ConnectAsync()
        {
            // Si ya está conectado, no hacemos nada.
            if (session != null && session.Connected)
            {
                return true;
            }

            try
            {
                Log.Information($"Connecting to OPC UA Server at {serverUrl}...");

                var certificateValidator = new CertificateValidator();
                certificateValidator.CertificateValidation += (sender, eventArgs) =>
                {
                    if (ServiceResult.IsGood(eventArgs.Error) || eventArgs.Error.StatusCode == StatusCodes.BadCertificateUntrusted)
                    {
                        eventArgs.Accept = true;
                    }
                    else
                    {
                        throw new Exception($"Certificate validation failed: {eventArgs.Error.StatusCode}");
                    }
                };

                ApplicationConfiguration config = new ApplicationConfiguration
                {
                    ApplicationName = "OPCUAClient",
                    ApplicationType = ApplicationType.Client,
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        ApplicationCertificate = new CertificateIdentifier
                        {
                            StoreType = "Directory",
                            StorePath = @"%LocalApplicationData%/OPCFoundation/CertificateStores/MachineDefault"
                        },
                        TrustedIssuerCertificates = new CertificateTrustList
                        {
                            StoreType = "Directory",
                            StorePath = @"%LocalApplicationData%/OPCFoundation/CertificateStores/UA Certificate Authorities"
                        },
                        TrustedPeerCertificates = new CertificateTrustList
                        {
                            StoreType = "Directory",
                            StorePath = @"%LocalApplicationData%/OPCFoundation/CertificateStores/UA Applications"
                        },
                        RejectedCertificateStore = new CertificateTrustList
                        {
                            StoreType = "Directory",
                            StorePath = @"%LocalApplicationData%/OPCFoundation/CertificateStores/RejectedCertificates"
                        },
                        AutoAcceptUntrustedCertificates = true,
                        RejectSHA1SignedCertificates = false,
                        MinimumCertificateKeySize = 2048
                    },
                    TransportQuotas = new TransportQuotas { OperationTimeout = 30000 },
                    ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                    DisableHiResClock = false
                };

                await config.Validate(ApplicationType.Client);
                ApplicationInstance appInstance = new ApplicationInstance { ApplicationConfiguration = config };
                await appInstance.CheckApplicationInstanceCertificate(false, 2048);

                var endpoint = CoreClientUtils.SelectEndpoint(serverUrl, useSecurity: false);
                var endpointConfiguration = EndpointConfiguration.Create(config);
                var configuredEndpoint = new ConfiguredEndpoint(null, endpoint, endpointConfiguration);

                session = await Session.Create(
                    config,
                    configuredEndpoint,
                    false,
                    "OPCUAClient",
                    60000,
                    new UserIdentity(),
                    null
                );

                session.KeepAlive += Session_KeepAlive;
                this.IsConnected = session.Connected;
                Log.Information($"Successfully connected to OPC UA Server: {serverUrl}");
                RecreateSubscriptions();
                return session.Connected;
            }
            catch (Exception ex)
            {
                Log.Error($"OPC UA Connection Failed: {ex.Message}");
                if (session != null)
                {
                    session.Close();
                    session = null;
                }
                this.IsConnected = false;

                return false;
            }
        }
        /// <summary>
        /// Event handler for the session's KeepAlive event.
        /// This is the primary way to detect if the connection has been lost.
        /// </summary>
        private void Session_KeepAlive(ISession sender, KeepAliveEventArgs e)
        {
            if (ServiceResult.IsBad(e.Status))
            {
                Log.Warning($"Connection lost to server. Status: {e.Status}. Will attempt to reconnect.");
                _isConnected = false;
                sender.KeepAlive -= Session_KeepAlive;
                var oldSession = session;
                session = null;
                oldSession?.CloseAsync();
            }
        }
        /// <summary>
        /// Manually disconnects from the server and stops the reconnection attempts.
        /// </summary>
        public void Disconnect()
        {
            Log.Information("Disconnecting from OPC UA Server...");

            // Stop the maintenance task
            _mainCts?.Cancel();

            if (session != null)
            {
                // Unsubscribe from event before closing
                session.KeepAlive -= Session_KeepAlive;
                session.Close();
                session = null;
            }

            _isConnected = false;
            Log.Information("Disconnected from OPC UA Server.");
        }

        // ... all your other methods (CreateDTOSubscription, WriteToPlc, etc.) remain the same ...
        #region Other Methods
        public void CreateSubscription(Session session, List<string> nodeIds)
        {
            if (session == null || !session.Connected)
            {
                Console.WriteLine("OPC UA session is not connected.");
                return;
            }

            // Create a new subscription
            Subscription subscription = new Subscription(session.DefaultSubscription)
            {
                PublishingInterval = 1000, // 1-second interval
                KeepAliveCount = 10,
                LifetimeCount = 30,
                MaxNotificationsPerPublish = 10,
                PublishingEnabled = true,
                Priority = 1
            };

            // Create monitored items for each node ID
            List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

            foreach (var nodeId in nodeIds)
            {
                MonitoredItem item = new MonitoredItem(subscription.DefaultItem)
                {
                    StartNodeId = nodeId,
                    AttributeId = Attributes.Value,
                    SamplingInterval = 1000,
                    QueueSize = 1,
                    DiscardOldest = true
                };
                monitoredItems.Add(item);
            }

            // Add monitored items to the subscription
            subscription.AddItems(monitoredItems);
            session.AddSubscription(subscription);
            subscription.Create();
        }
        private Dictionary<uint, Tuple<string, string>> _clientHandleToDisplayName = new();


        /// <summary>
        /// Método público que los clientes llaman. Ahora guarda la acción de creación y la ejecuta.
        /// </summary>
        public void CreateDTOSubscription<T>(T dtoInstance, string baseNodeId) where T : class, new()
        {
            // Guarda la acción en la lista para poder llamarla de nuevo tras una reconexión
            lock (_subscriptionLock)
            {
                _recreateSubscriptionActions.Add(() => CreateAndMonitorDto(dtoInstance, baseNodeId));
            }

            // Ejecuta la creación por primera vez
            CreateAndMonitorDto(dtoInstance, baseNodeId);
        }

        /// <summary>
        /// Este método privado contiene LA MISMA LÓGICA QUE TENÍAS EN TU CreateDTOSubscription ORIGINAL.
        /// </summary>
        private void CreateAndMonitorDto<T>(T dtoInstance, string baseNodeId) where T : class, new()
        {
            if (session == null || !session.Connected)
            {
                Log.Warning($"Cannot create subscription for {typeof(T).Name}. Session is not connected.");
                return;
            }

            try
            {
                var subscription = new Subscription(session.DefaultSubscription)
                {
                    PublishingInterval = 1000,
                    KeepAliveCount = 10,
                    LifetimeCount = 20,
                    MaxNotificationsPerPublish = 10,
                    PublishingEnabled = true,
                    Priority = 1
                };

                var monitoredItems = new List<MonitoredItem>();
                var propertyMap = new Dictionary<NodeId, System.Reflection.PropertyInfo>();

                foreach (var property in typeof(T).GetProperties())
                {
                    string nodeIdString = $"{baseNodeId}{property.Name}";
                    NodeId nodeId = new NodeId(nodeIdString);
                    propertyMap[nodeId] = property; // Guardar referencia a la propiedad para las actualizaciones

                    var item = new MonitoredItem(subscription.DefaultItem)
                    {
                        StartNodeId = nodeId,
                        AttributeId = Attributes.Value,
                        SamplingInterval = 500, // Un muestreo más rápido puede ser útil
                        QueueSize = 1,
                        DiscardOldest = true
                    };

                    // Este es el manejador de eventos que actualiza tu objeto DTO cuando llega un nuevo valor
                    item.Notification += (monitoredItem, args) =>
                    {
                        if (args.NotificationValue is MonitoredItemNotification notification)
                        {
                            if (propertyMap.TryGetValue(monitoredItem.StartNodeId, out var propToUpdate))
                            {
                                try
                                {
                                    // Convierte el valor recibido al tipo de la propiedad y lo asigna
                                    var convertedValue = Convert.ChangeType(notification.Value.Value, propToUpdate.PropertyType);
                                    propToUpdate.SetValue(dtoInstance, convertedValue);
                                }
                                catch (Exception ex)
                                {
                                    Log.Error(ex, $"Failed to set property {propToUpdate.Name} on DTO {typeof(T).Name}");
                                }
                            }
                        }
                    };
                    monitoredItems.Add(item);
                }

                subscription.AddItems(monitoredItems);
                session.AddSubscription(subscription);
                subscription.Create();

                // Asigna la devolución de llamada para alarmas/advertencias
                if (dtoInstance.GetType().Name.Contains("WARNING") || dtoInstance.GetType().Name.Contains("ALARM"))
                {
                    // Es importante registrar los handles DESPUÉS de llamar a subscription.Create()
                    foreach (var item in subscription.MonitoredItems)
                    {
                        // Extrae el nombre de la propiedad del NodeId
                        var propertyName = item.StartNodeId.Identifier.ToString().Split('.').LastOrDefault() ?? "Unknown";
                        _clientHandleToDisplayName[item.ClientHandle] = new Tuple<string, string>(dtoInstance.GetType().Name, propertyName);
                    }
                    subscription.FastDataChangeCallback = (sub, changes, _) => DataChangedMethod(sub, changes);
                }

                Log.Information($"Subscription created successfully for DTO {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Failed to create subscription for DTO {typeof(T).Name}.");
            }
        }
        private void RecreateSubscriptions()
        {
            if (!_recreateSubscriptionActions.Any())
            {
                return;
            }

            Log.Information("Re-creating subscriptions after reconnection...");

            List<Action> actionsToRun;
            lock (_subscriptionLock)
            {
                actionsToRun = new List<Action>(_recreateSubscriptionActions);
            }

            foreach (var createAction in actionsToRun)
            {
                try
                {
                    createAction();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while re-creating a subscription.");
                }
            }
            Log.Information("Finished re-creating subscriptions.");
        }
        private void DataChangedMethod(Subscription sub, DataChangeNotification changes)
        {
            foreach (var item in changes.MonitoredItems)
            {
                if (_clientHandleToDisplayName.TryGetValue(item.ClientHandle, out var alarmName))
                {
                    var value = item.Value.Value;

                    if (value is bool isActive)
                    {
                        EmitAlarm(alarmName.Item1, alarmName.Item2, isActive, "");
                    }
                    else if (value is bool[] boolArray)
                    {
                        for (int i = 0; i < boolArray.Length; i++)
                        {
                            EmitAlarm(alarmName.Item1, alarmName.Item2, boolArray[i], $" {i + 1}");
                        }
                    }
                }
            }
        }

        private void EmitAlarm(string type, string baseName, bool isActive, string suffix)
        {
            var fullName = baseName + suffix;

            var alarm = new Alarm
            {
                Date = DateTime.Now,
                AlarmType = GetStringName(type),
                Description = GetStringName(fullName),
                IsWarning = type.Contains("WARNINGS"),
                AlarmName = fullName
            };

            AlarmChanged?.Invoke(this, new Tuple<Alarm, bool>(alarm, isActive));
        }

        private string GetStringName(string name)
        {
            // Replace with your actual resource manager logic
            return name; // Placeholder
        }

        public object? ReadFromPlc(string nodeId)
        {
            if (session == null || !_isConnected) return null;

            try
            {
                var value = session.ReadValue(new NodeId("ns=2;s=Application." + nodeId));
                return value?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading {nodeId}: {ex.Message}");
                return null;
            }
        }

        public void WriteToPlc(string nodeId, object value)
        {
            if (session == null || !_isConnected) return;

            try
            {
                var nodeIdFull = new NodeId("ns=2;s=Application." + nodeId);
                var dataTypeId = session.ReadValue(nodeIdFull).WrappedValue.TypeInfo.BuiltInType;
                object convertedValue = ConvertToExpectedType(value, dataTypeId);

                var nodeToWrite = new WriteValue
                {
                    NodeId = nodeIdFull,
                    AttributeId = Attributes.Value,
                    Value = new DataValue(new Variant(convertedValue))
                };

                session.Write(null, new WriteValueCollection { nodeToWrite }, out StatusCodeCollection status, out _);

                if (StatusCode.IsBad(status[0]))
                {
                    Console.WriteLine($"Failed to write. Status: {status[0]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to {nodeId}: {ex.Message}");
            }
        }

        private object ConvertToExpectedType(object value, BuiltInType expectedType)
        {
            try
            {
                return expectedType switch
                {
                    BuiltInType.Int16 => Convert.ToInt16(value),
                    BuiltInType.UInt16 => Convert.ToUInt16(value),
                    BuiltInType.Int32 => Convert.ToInt32(value),
                    BuiltInType.UInt32 => Convert.ToUInt32(value),
                    BuiltInType.Int64 => Convert.ToInt64(value),
                    BuiltInType.UInt64 => Convert.ToUInt64(value),
                    BuiltInType.Float => Convert.ToSingle(value),
                    BuiltInType.Double => Convert.ToDouble(value),
                    BuiltInType.Boolean => Convert.ToBoolean(value),
                    BuiltInType.String => Convert.ToString(value),
                    BuiltInType.Byte => Convert.ToByte(value),
                    BuiltInType.SByte => Convert.ToSByte(value),
                    BuiltInType.DateTime => Convert.ToDateTime(value),
                    _ => throw new InvalidOperationException($"Unsupported target type: {expectedType}")
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Type conversion failed ({expectedType}): {ex.Message}");
                return value;
            }
        }
        #endregion
    }
}