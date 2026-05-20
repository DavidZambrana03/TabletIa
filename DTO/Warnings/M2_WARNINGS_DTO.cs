namespace WhiteFlexo
{
    public class M2_WARNINGS_DTO
    {
        // Module Start Warnings
        public bool bModuleNotRdyToStart { get; set; }
        public bool bEPBPrimer { get; set; }
        public bool bEPBPrimerInside { get; set; }
        public bool bPrimerTankLowLevel { get; set; }
        public bool bWasteTankFull { get; set; }
        public bool bWaterTankLowLevel { get; set; }
        public bool bDryerDoorOpen { get; set; }
        public bool bCoatingDoorOpen { get; set; }
        public bool bHmiDoorOpen { get; set; }
        public bool bChillRollDriveWarning { get; set; }
        public bool bAniloxDriveWarning { get; set; }
        public bool bPrimerSystemStopped { get; set; }
        public bool bSleeveChangeActive { get; set; }
        public bool bChillRollFanProtected { get; set; }
        public bool bSelfCleanHartingDisconnected { get; set; }
    }
}
