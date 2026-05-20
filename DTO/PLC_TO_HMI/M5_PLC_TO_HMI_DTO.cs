using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteFlexo
{
    public class M5_PLC_TO_HMI_DTO
    {
        public short[] iPbState { get; set; }
        public short[] iCbState { get; set; }
        public float[] rPcTorques { get; set; } = new float[2];
        public float[] rAxTorques { get; set; } =new float[2];
        public float rModuleTensionFeedback { get; set; }
        public bool bOvenGateClosed { get; set; }
        public bool bSmartPrintEnabled { get; set; }
        //public bool bNixkaComunicationOk { get; set; }
        public float rProdTempOvenPv { get; set; }
        public bool bDrumTempControlInOp { get; set; }
        public float rDrumTempControlPV { get; set; }
        //public float rOpticalSensorPosPV { get; set; }
        public short iPreImpulsionFanPV_1 { get; set; }
        public short iCleanSequenceTimeLeft { get; set; }
        public short iPreExhaustFanPV_1 { get; set; }
        public short iProdImpulsionFanPV_1 { get; set; }
        public short iProdExhaustFanPV_1 { get; set; }
        public short iPreImpulsionFanPV_2 { get; set; }
        public short iPreExhaustFanPV_2 { get; set; }
        public short iProdImpulsionFanPV_2 { get; set; }
        public float rFlexoActualFormat { get; set; }
        public short iProdExhaustFanPV_2 { get; set; }
        public bool bAxPcSelector { get; set; }
        public bool bIsManualAdjust { get; set; }
        public float rManualAdjustStepPV { get; set; }
        public short iFlexoPosState { get; set; }
        public short iFlexoSelfCleanState { get; set; }
        public float rAxPos_CS { get; set; }
        public float rAxPos_MS { get; set; }
        public float rPcPos_CS { get; set; }
        public float rMarkSensorPositionFeedback { get; set; }
        public float rDrBladePressureMs { get; set; }
        public float rDrBladePressureCs { get; set; }
        public float rPcPos_MS { get; set; }
        public bool bWhiteFlexoStarted { get; set; }
        public ushort uiLvlWhiteTank { get; set; }
        public ushort uiLvlWaterTank { get; set; }
        public ushort uiLvlWasteTank { get; set; }

        //public float rDancerTensionFeedback { get; set; }
    }

}
