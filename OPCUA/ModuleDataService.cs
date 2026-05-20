using System.Collections.ObjectModel;
using System.Timers;
using Timer = System.Timers.Timer;

namespace WhiteFlexo
{
    public class ModuleDataService
    {
        private readonly ReadDTOService _readDTOService;
        private readonly Timer _updateTimer;

        public ObservableCollection<ModuleData> ModulesList { get; private set; } = new();

        public ModuleDataService(ReadDTOService readDTOService)
        {
            _readDTOService = readDTOService;

            // Poll every second
            _updateTimer = new Timer(1000);
            _updateTimer.Elapsed += (s, e) => RefreshModules();
            _updateTimer.Start();
        }

        private void RefreshModules()
        {
            ModulesList.Clear();


            ModulesList.Add(new ModuleData
            {
                ModuleName = "Unwinder",
                Tension = _readDTOService.M1_PLC_TO_HMI_DTO?.rUnwTensionPV ?? 0,
                ModuleStatus = "Not Ready",
                ModuleImage = "resources/M1.jpg",
                DTO = _readDTOService.M1_PLC_TO_HMI_DTO
            });

            ModulesList.Add(new ModuleData
            {
                ModuleName = "Primer",
                Tension = (float)Math.Round(_readDTOService.M2_PLC_TO_HMI_DTO?.rChillRollTensionPV ?? 0,1),
                ModuleStatus = "Emergency",
                ModuleImage = "resources/M2.jpg",
                DTO = _readDTOService.M2_PLC_TO_HMI_DTO

            });
            ModulesList.Add(new ModuleData
            {
                ModuleName = "Print unit",
                Tension = (float)Math.Round( _readDTOService.M4_PLC_TO_HMI_DTO?.rModuleTensionFeedback ?? 0f, 1),
                ModuleStatus = "Not Ready",
                ModuleImage = "resources/M4.jpg",
                DTO = _readDTOService.M4_PLC_TO_HMI_DTO
            });

            ModulesList.Add(new ModuleData
            {
                ModuleName = "White flexo",
                Tension = (float)Math.Round(_readDTOService.M5_PLC_TO_HMI_DTO?.rModuleTensionFeedback ?? 0,1),
                ModuleStatus = "Not Ready",
                ModuleImage = "resources/M5.jpg",
                DTO = _readDTOService.M5_PLC_TO_HMI_DTO
            });
            ModulesList.Add(new ModuleData
            {
                ModuleName = "Rewinder",
                Tension = (float)Math.Round(_readDTOService.M7_PLC_TO_HMI_DTO?.rRewTensionPV ?? 0,1),
                ModuleStatus = "Not Ready",
                ModuleImage = "resources/M7.jpg",
                DTO = _readDTOService.M7_PLC_TO_HMI_DTO
            });
        }
    }
}

