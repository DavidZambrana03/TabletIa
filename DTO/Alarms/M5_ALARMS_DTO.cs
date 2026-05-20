using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteFlexo
{
    public class M5_ALARMS_DTO
    {
        public bool bGasBurnerAlarm { get; set; }
        public bool bMaxTempExceeded { get; set; }
        public bool bGasBurnerSafetyPressureAlarm { get; set; }
        public bool bGasBurnerTempDiscrepancy { get; set; }
        public bool bGasBurnerFailOnStart { get; set; }
        public bool bOvenGateDoorsAlarm { get; set; }

        // Additional properties to be added to UI
        public bool bImpulsionFan1DriveAlarm { get; set; }
        public bool bImpulsionFan2DriveAlarm { get; set; }
        public bool bExhaustFan1DriveAlarm { get; set; }
        public bool bExhaustFan2DriveAlarm { get; set; }

        public bool bDrumTcGeneralAlarm { get; set; }
        public bool bDrumTcMaxTempAlarm { get; set; }

        public bool bM5PrintingUnitWebBrake { get; set; }
        public bool bInfeedMotorDriveAlarm { get; set; }
        public bool bCentralDrumMotorDriveAlarm { get; set; }
        public bool bM5ChillRollMotorDriveAlarm { get; set; }
        public bool bOutfeedMotorDriveAlarm { get; set; }
        public bool bSpeedMatchMotorDriveAlarm { get; set; }
        public bool [] bPrintBarMotorDriveAlarm { get; set; }
        public bool [] bCrossBeamMotorDriveAlarm { get; set; }
        public bool bMarkSensorMotorDriveAlarm { get; set; }
    }

}
