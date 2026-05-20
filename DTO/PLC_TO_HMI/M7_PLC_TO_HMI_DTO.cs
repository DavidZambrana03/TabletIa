namespace WhiteFlexo
{
    public class M7_PLC_TO_HMI_DTO
    {
        public float rRewDiameterPV { get; set; }
        public float rTaperTensionPV { get; set; }
        public float rTaperPressurePV { get; set; }
        public float rDiameterOffsetTaperPV { get; set; }
        public bool bRewDirection { get; set; }
        public float rLayonPressurePV { get; set; }
        public short iTapperType { get; set; }
        public bool bRewMeterAcusticSignal { get; set; }
        public bool bRewMeterStop { get; set; }
        public float rRewMeterStopPV { get; set; }
        public bool bRewDiameterAcusticSignal { get; set; }
        public bool bRewDiameterStop { get; set; }
        public float rRewDiameterStopPV { get; set; }
        public float rRewTensionPV { get; set; }
        public float rRewCoreSize { get; set; }
        public bool bRewDancerCalibrated { get; set; }
        public bool bRewDancerNotCalibrated { get; set; }
        public bool bRewDancerCalibrationFail { get; set; }
        public short iRewDancerPercentage { get; set; }
        public bool bRewMinDiameterCalibrationFail { get; set; }
        public bool bRewMaxDiameterCalibrationFail { get; set; }
    }

}
