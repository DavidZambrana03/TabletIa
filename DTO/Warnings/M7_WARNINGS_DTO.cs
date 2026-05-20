namespace WhiteFlexo
{
    public class M7_WARNINGS_DTO
    {
        // Module Start Warnings
        public bool bModuleNotRdyToStart { get; set; }
        public bool bRewMotorStopped { get; set; }
        public bool bRewArmsOpen { get; set; }
        public bool bNipRollMotorDrivaWarning { get; set; }
        public bool bRewMotorDriveWarning { get; set; }
        public bool bRewAutomaticStop { get; set; }
        public bool bEPBRewinder { get; set; }
        public bool bRewNipNotClosed { get; set; }
    }
}
