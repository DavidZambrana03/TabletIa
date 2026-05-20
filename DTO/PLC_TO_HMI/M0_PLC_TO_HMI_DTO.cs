namespace WhiteFlexo
{
    public class M0_PLC_TO_HMI_DTO

    {
        public float rMachineSpeedFeedback { get; set; }
        public short iMachineState { get; set; }

        public float rMachineProducedMeters { get; set; }
        public float rMachineTotalMeters { get; set; }
        public float rMachineWasteMeters { get; set; }
        public bool bMachineResetButton { get; set; }

    }
}
