using System.Threading.Tasks;
using System.Timers;
using WhiteFlexo;
using Timer = System.Timers.Timer;

namespace WhiteFlexo
{
    public class ReadDTOService
    {
        private readonly OpcUaClient _opcClient;
        private readonly Timer _updateTimer;

        public M5_PLC_TO_HMI_DTO M5_PLC_TO_HMI_DTO { get; private set; } = new();
        public M0_PLC_TO_HMI_DTO M0_PLC_TO_HMI_DTO { get; private set; } = new();
        public M1_PLC_TO_HMI_DTO M1_PLC_TO_HMI_DTO { get; private set; } = new();
        public M2_PLC_TO_HMI_DTO M2_PLC_TO_HMI_DTO { get; private set; } = new();
        public M4_PLC_TO_HMI_DTO M4_PLC_TO_HMI_DTO { get; private set; } = new();
        public M7_PLC_TO_HMI_DTO M7_PLC_TO_HMI_DTO { get; private set; } = new();
        public M5_HMI_TO_PLC_DTO M5_HMI_TO_PLC_DTO { get; private set; } = new();
        public M0_HMI_TO_PLC_DTO M0_HMI_TO_PLC_DTO { get; private set; } = new();
        public M1_HMI_TO_PLC_DTO M1_HMI_TO_PLC_DTO { get; private set; } = new();
        public M2_HMI_TO_PLC_DTO M2_HMI_TO_PLC_DTO { get; private set; } = new();
        public M4_HMI_TO_PLC_DTO M4_HMI_TO_PLC_DTO { get; private set; } = new();
        public M7_HMI_TO_PLC_DTO M7_HMI_TO_PLC_DTO { get; private set; } = new();
        // Add more DTOs as needed
        //Add Alarm DTOs
        public M0_ALARMS_DTO M0_ALARMS_DTO { get; private set; } = new();
        public M1_ALARMS_DTO M1_ALARMS_DTO { get; private set; } = new();
        public M2_ALARMS_DTO M2_ALARMS_DTO { get; private set; } = new();
        public M4_ALARMS_DTO M4_ALARMS_DTO { get; private set; } = new();
        public M5_ALARMS_DTO M5_ALARMS_DTO { get; private set; } = new();
        public M7_ALARMS_DTO M7_ALARMS_DTO { get; private set; } = new();
        //Add Warning DTOs
        public M0_WARNINGS_DTO M0_WARNINGS_DTO { get; private set; } = new();
        public M1_WARNINGS_DTO M1_WARNINGS_DTO { get; private set; } = new();
        public M2_WARNINGS_DTO M2_WARNINGS_DTO { get; private set; } = new();
        public M4_WARNINGS_DTO M4_WARNINGS_DTO { get; private set; } = new();
        public M5_WARNINGS_DTO M5_WARNINGS_DTO { get; private set; } = new();
        public M7_WARNINGS_DTO M7_WARNINGS_DTO { get; private set; } = new();


        public event EventHandler<Tuple<Alarm,bool>> AlarmUpdated; // UI listens for updates

        public ReadDTOService(OpcUaClient opcClient)
        {
            _opcClient = opcClient;
            // Poll data every 1 second (adjust as needed)
            //_updateTimer = new Timer(1000);
            //_updateTimer.Elapsed += (s, e) => RefreshData();
            //_updateTimer.Start();
            RefreshData();
            _opcClient.AlarmChanged += _opcClient_AlarmChanged;
        }

        private void _opcClient_AlarmChanged(object? sender, Tuple<Alarm, bool> e)
        {
            AlarmUpdated?.Invoke(this, e);   
        }

        public async void RefreshData()
        {
            while (true)
            {
                if (!_opcClient.IsConnected) await Task.Delay(1000);
                else break;
            }
            _opcClient.CreateDTOSubscription(M0_PLC_TO_HMI_DTO, "ns=2;s=Application.M0_PLC_TO_HMI_DTO.");
            _opcClient.CreateDTOSubscription(M1_PLC_TO_HMI_DTO, "ns=2;s=Application.M1_PLC_TO_HMI_DTO.");
            _opcClient.CreateDTOSubscription(M2_PLC_TO_HMI_DTO, "ns=2;s=Application.M2_PLC_TO_HMI_DTO.");
            _opcClient.CreateDTOSubscription(M4_PLC_TO_HMI_DTO, "ns=2;s=Application.M4_PLC_TO_HMI_DTO.");
            _opcClient.CreateDTOSubscription(M5_PLC_TO_HMI_DTO, "ns=2;s=Application.M5_PLC_TO_HMI_DTO.");
            _opcClient.CreateDTOSubscription(M7_PLC_TO_HMI_DTO, "ns=2;s=Application.M7_PLC_TO_HMI_DTO.");
            _opcClient.CreateDTOSubscription(M5_HMI_TO_PLC_DTO, "ns=2;s=Application.M5_HMI_TO_PLC_DTO.");
            _opcClient.CreateDTOSubscription(M0_HMI_TO_PLC_DTO, "ns=2;s=Application.M0_HMI_TO_PLC_DTO.");
            _opcClient.CreateDTOSubscription(M2_HMI_TO_PLC_DTO, "ns=2;s=Application.M2_HMI_TO_PLC_DTO.");
            //Add subscriptions for alarms
            _opcClient.CreateDTOSubscription(M0_ALARMS_DTO, "ns=2;s=Application.M0_ALARMS_DTO.");
            _opcClient.CreateDTOSubscription(M1_ALARMS_DTO, "ns=2;s=Application.M1_ALARMS_DTO.");
            _opcClient.CreateDTOSubscription(M2_ALARMS_DTO, "ns=2;s=Application.M2_ALARMS_DTO.");
            _opcClient.CreateDTOSubscription(M4_ALARMS_DTO, "ns=2;s=Application.M4_ALARMS_DTO.");
            _opcClient.CreateDTOSubscription(M5_ALARMS_DTO, "ns=2;s=Application.M5_ALARMS_DTO.");
            _opcClient.CreateDTOSubscription(M7_ALARMS_DTO, "ns=2;s=Application.M7_ALARMS_DTO.");
            //Add subscriptions for warnings
            _opcClient.CreateDTOSubscription(M0_WARNINGS_DTO, "ns=2;s=Application.M0_WARNINGS_DTO.");
            _opcClient.CreateDTOSubscription(M1_WARNINGS_DTO, "ns=2;s=Application.M1_WARNINGS_DTO.");
            _opcClient.CreateDTOSubscription(M2_WARNINGS_DTO, "ns=2;s=Application.M2_WARNINGS_DTO.");
            _opcClient.CreateDTOSubscription(M4_WARNINGS_DTO, "ns=2;s=Application.M4_WARNINGS_DTO.");
            _opcClient.CreateDTOSubscription(M5_WARNINGS_DTO, "ns=2;s=Application.M5_WARNINGS_DTO.");
            _opcClient.CreateDTOSubscription(M7_WARNINGS_DTO, "ns=2;s=Application.M7_WARNINGS_DTO.");
        }

    }
}
