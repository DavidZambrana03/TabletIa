namespace WhiteFlexo
{
    public class M2_PLC_TO_HMI_DTO
    {
        public float rDoctorBladeOpSidePressurePV { get; set; }
        public float rDoctorBladeTransSidePressurePV { get; set; }
        public float rCoatingSleeveOpSidePressurePV { get; set; }
        public float rCoatingSleeveTransSidePressurePV { get; set; }
        public float rCoatingTensionPV { get; set; }
        public float rChillRollTensionPV { get; set; }
        public float rChillRollNipPressurePV { get; set; }
        public short iImpulsionBlowerPV { get; set; }
        public short iPreImpulsionBlowerPV { get; set; }
        public short iProdImpulsionBlowerPV { get; set; }
        public short iExhaustBlowerPV { get; set; }
        public short iPreExhaustBlowerPV { get; set; }
        public short iProdExhaustBlowerPV { get; set; }
        public short iPeristalticPumpPV { get; set; }
        public float rTunnelTempPV { get; set; }
        public float rPreTunnelTempPV { get; set; }
        public float rProdTunnelTempPV { get; set; }
        public bool bCoatingSleeveNipAutoManFedbk { get; set; }
        public bool bCoatingSleeveClosed { get; set; }
        public bool bDoctorBladeClosed { get; set; }
        public bool bCleaningStarted { get; set; }
        public bool bDryiningDoctorBladeStarted { get; set; }
        public bool bPrimerRecirculationStarted { get; set; }
        public bool bSleeveChangeActive { get; set; }
        public uint udiCleaningEmptyTimePV { get; set; }
        public uint udiCleaningRecircTimePV { get; set; }
        public uint udiCleaningFillWaterTimePV { get; set; }

        public uint udiSleeveChangeTimePV { get; set; }
        public int iCleaningEmptyTimeTotal { get; set; }
        public int iCleaningRecircTimeTotal { get; set; }
        public int iCleaningFillWaterTimeTotal { get; set; }
        public int iSleeveChangeTimeTotal { get; set; }
        public short iCleaningCyclesPV { get; set; }
        public short iCleaningTotalCycles { get; set; }
        public short iDriyngSystState { get; set; }
        public short iPrimerApplicationState { get; set; }
        public bool bPrimerStarted { get; set; }
        public ushort uiLvlPrimerTank { get; set; }
        public ushort uiLvlWaterTank { get; set; }
        public ushort uiLvlWasteTank { get; set; }
    }

}
