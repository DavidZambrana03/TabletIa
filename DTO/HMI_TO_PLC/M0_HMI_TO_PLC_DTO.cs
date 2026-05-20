namespace WhiteFlexo
{
    public class M0_HMI_TO_PLC_DTO
    {
        public short iUserLevel { get; set; }
        public float rMachineSpeedSP { get; set; }
        public bool bResetAlarms { get; set; }
        public bool bRecipeDownloaded { get; set; }
        public bool bMachineIsPrinting { get; set; }
        public bool bImageReadyToPrint { get; set; }
        public int diPrintFrequency { get; set; }
        public bool bM2EnableModule { get; set; }
        public bool bM4EnableModule { get; set; }
        public bool bM5EnableModule { get; set; }
        public float rActualFormat { get; set; }


        public void SetMinMaxValues(string name, out float MinValuePopup, out float MaxValuePopup)
        {
            switch (name)
            {
                case nameof(rMachineSpeedSP):
                    MinValuePopup = 0;
                    MaxValuePopup = 75;
                    break;
                default:
                    MinValuePopup = 0;
                    MaxValuePopup = 0;
                    break;
            }
        }
    }
}
