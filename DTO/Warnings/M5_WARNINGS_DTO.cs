using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteFlexo
{
    public class M5_WARNINGS_DTO
    {
        public bool bModuleNotredyToStart { get; set; }

        public bool bEPBWhiteUnit { get; set; }
        public bool bInfeedFanProtection { get; set; }
        public bool bDrumFanProtection { get; set; }
        public bool bChillRollFanProtection { get; set; }
        public bool bOutFeedFanProtection { get; set; }
        public bool bImpExhPowerSupplyFanProtect1 { get; set; }
        public bool bImpExhPowerSupplyFanProtect2 { get; set; }

        public bool bPbPowerProtection { get; set; }

        public bool bLeftFrontalDoorOpen { get; set; }
        public bool bCentralFrontalDoorOpen { get; set; }
        public bool bRightFrontalDoorOpen { get; set; }
        public bool bCornerFrontalDoorOpen { get; set; }
        public bool bLateralDoorOpenDown { get; set; }
        public bool bLateralDoorOpenUp { get; set; }
        public bool bOvenGatesOpen { get; set; }
        public bool bBackDoor { get; set; }
        public bool bDrumTcNotInOperation { get; set; }
        public bool bInfeedMotorDriveWarning { get; set; }
        public bool bCentralDrumMotorDriveWarning { get; set; }
        public bool bM5ChillRollMotorDriveWarning { get; set; }
        public bool bOutfeedMotorDriveWarning { get; set; }
        public bool bSpeedMatchMotorDriveWarning { get; set; }

        public bool[] bPrintBarMotorDriveWarning { get; set; }
        public bool[] bCrossBeamMotorDriveWarning { get; set; }

        //public bool[] bPrintBarRegisterError { get; set; }


    }
}
