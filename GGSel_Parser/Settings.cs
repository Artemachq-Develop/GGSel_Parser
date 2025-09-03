namespace GGSel_Parser
{
    public static class Settings
    {
        public const string DataFileName = "LinksSave.json";

        public const string DefaultUrl = "https://ggsel.net/catalog/helldivers-2-keys-steam";
        public static int MaxProductNameLength { get; set; } = 50;
        public static bool EnableTooltips { get; set; } = true;

        public static ProgramPrice ProgramPrice;
    }
    public enum ProgramPrice
    {
        Rub,
        Usd,
        Eur
    }
}
