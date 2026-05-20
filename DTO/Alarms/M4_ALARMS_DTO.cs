namespace WhiteFlexo
{
    public class M4_ALARMS_DTO
    {
        public bool bGasBurnerAlarm { get; set; }
        public bool bMaxTempExceeded { get; set; }
        public bool bGasBurnerSafetyPressureAlarm { get; set; }
        public bool bGasBurnerTempDiscrepancy { get; set; }
        public bool bGasBurnerFailOnStart { get; set; }

        public bool bOvenGateDoorsAlarm { get; set; }

        //TODO add to UI
        public bool bImpulsionFan1DriveAlarm { get; set; }
        public bool bImpulsionFan2DriveAlarm { get; set; }
        public bool bExhaustFan1DriveAlarm { get; set; }
        public bool bExhaustFan2DriveAlarm { get; set; }

        public bool bDrumTcGeneralAlarm { get; set; }
        public bool bDrumTcMaxTempAlarm { get; set; }

        public bool bM4PrintingUnitWebBrake { get; set; }
        public bool bInfeedMotorDriveAlarm { get; set; }
        public bool bCentralDrumMotorDriveAlarm { get; set; }
        public bool bM4ChillRollMotorDriveAlarm { get; set; }
        public bool bOutfeedMotorDriveAlarm { get; set; }
        public bool bSpeedMatchMotorDriveAlarm { get; set; }
        public bool[] bPrintBarMotorDriveAlarm { get; set; } 
        public bool[] bCrossBeamMotorDriveAlarm { get; set; }
        public bool bPinningMaxTempAlarm { get; set; }
        public bool bPinningSolidStateRelayAlarm { get; set; }
        public bool bPinningPressureSwitchsAlarm { get; set; }



    }

}
