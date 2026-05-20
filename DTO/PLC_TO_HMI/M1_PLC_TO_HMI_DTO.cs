namespace WhiteFlexo
{
    public class M1_PLC_TO_HMI_DTO
    {
        public float rUnwTensionPV { get; set; }
        public float rUnwDiameterPV { get; set; }
        public float rMaterialWidth { get; set; }
        public float rMaterialThicknessPV { get; set; }
        public bool bUnwDirection { get; set; }
        public float rUnwCoreSize { get; set; }
        public float rTreaterPowerPV { get; set; }
        public float rTreaterDosePV { get; set; }
        public short iTreaterMode { get; set; }
        public short iMaterialType { get; set; }
        public bool bTreaterEnabled { get; set; }
        public bool bTreaterActivated { get; set; }
        public float rTreaterPropMinPower { get; set; }
        public float rTreaterPropMaxPower { get; set; }
        public float rTreaterPorpMinSpeed { get; set; }
        public float rTreaterPropMaxSpeed { get; set; }
        public bool bUnwDiameterAcusticSignal { get; set; }
        public bool bUnwDiameterStop { get; set; }
        public float rUnwDiameterStopPV { get; set; }
        public bool bSpliceDetectorOk { get; set; }
        public bool bSpliceInProgress { get; set; }
        public bool bUnwDancerCalibrated { get; set; }
        public bool bUnwDancerCalibrationFail { get; set; }
        public bool bUnwDancerNotCalibrated { get; set; }
        public short iDancerActualPercentage { get; set; }
        public bool bUnwMinDiameterCalibrationFail { get; set; }
        public bool bUnwMaxDiameterCalibrationFail { get; set; }
    }

}
