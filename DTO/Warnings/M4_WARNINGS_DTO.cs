namespace WhiteFlexo
{
    public class M4_WARNINGS_DTO
    {
        public bool bModuleNotReadyToStart { get; set; }

        public bool bEPBPrintingUnit { get; set; }
        public bool bInfeedFanProtection { get; set; }
        public bool bDrumFanProtection { get; set; }
        public bool bChillRollFanProtection { get; set; }
        public bool bOutFeedFanProtection { get; set; }
        public bool bImpExhPowerSupplyFanProtect1 { get; set; }
        public bool bImpExhPowerSupplyFanProtect2 { get; set; }

        public bool bLeftFrontalDoorOpen { get; set; }
        public bool bCentralFrontalDoorOpen { get; set; }
        public bool bRightFrontalDoorOpen { get; set; }
        public bool bOvenGatesOpen { get; set; }
        public bool bLateralDoor1Open { get; set; }
        public bool bLateralDoor2Open { get; set; }

        public bool bInfeedMotorDriveWarning { get; set; }
        public bool bCentralDrumMotorDriveWarning { get; set; }
        public bool bM4ChillRollMotorDriveWarning { get; set; }
        public bool bOutfeedMotorDriveWarning { get; set; }
        public bool bSpeedMatchMotorDriveWarning { get; set; }
        public bool[] bPrintBarMotorDriveWarning { get; set; }
        public bool[] bCrossBeamMotorDriveWarning { get; set; } 

        public bool[] bPrintBarRegisterError { get; set; } 

        public bool bPuPanLevelWarning { get; set; }

        public bool bDrumTcNotInOperation { get; set; }
    }

}
