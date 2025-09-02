using System;

namespace GGSel_Parser
{
    [Serializable]
    internal class GameInfo
    {
        public string? Name { get; set; } = "Null Name";
        public string? Link { get; set; } = "Null Link";

        public override string ToString()
        {
            return $"{Name} - {Link}";
        }
    }
}
