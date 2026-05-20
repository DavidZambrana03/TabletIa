namespace WhiteFlexo
{
    public class M2_ALARMS_DTO
    {
        // ALARMS
        public bool bPrimerTankEmpty { get; set; }
        public bool bChillRollDriveAlarm { get; set; }
        public bool bAniloxDriveAlarm { get; set; }
        public bool bPrimerWebBreak { get; set; }
        public bool bPrimerTrayFull { get; set; }

        public bool bSolidStateRelayFansPowerSupply { get; set; }
        public bool bSolidStateRelayError { get; set; }
        public bool bPressureSwitchError { get; set; }
        public bool bMaxTemperatureExceeded { get; set; }
        public bool bDryingSystemPIDError { get; set; }
        public bool bImpulsionBlowerDriveAlarm { get; set; }
        public bool bExhaustBlowerDriveAlarm { get; set; }
        public bool bHeatingGroupRelayAlarm { get; set; }
    }
}
