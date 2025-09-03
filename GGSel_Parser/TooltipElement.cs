namespace GGSel_Parser
{
    internal class TooltipElement
    {
        private readonly ToolTip _toolTip;
        private readonly TooltipSettings _settings;
        private int _hoveredIndex = -1;

        public TooltipElement(ToolTip existingToolTip = null, TooltipSettings settings = null)
        {
            _toolTip = existingToolTip ?? new ToolTip();
            _settings = settings ?? new TooltipSettings();
            ApplySettings();
        }

        private void ApplySettings()
        {
            _toolTip.AutoPopDelay = _settings.AutoPopDelay;
            _toolTip.InitialDelay = _settings.InitialDelay;
            _toolTip.ReshowDelay = _settings.ReshowDelay;
            _toolTip.ShowAlways = _settings.ShowAlways;
        }

        internal void HandleListBoxTooltip(ListBox listBox, MouseEventArgs e)
        {
            if (listBox == null)
                return;

            int newHoveredIndex = listBox.IndexFromPoint(e.Location);

            if (_hoveredIndex == newHoveredIndex)
                return;

            _hoveredIndex = newHoveredIndex;

            (IsValidListBoxIndex(listBox, _hoveredIndex) ? (Action)(() => ShowTooltip(listBox)) : () => HideTooltip(listBox))();
        }

        private bool IsValidListBoxIndex(ListBox listBox, int index)
        {
            return index >= 0 && index < listBox.Items.Count;
        }

        private void ShowTooltip(ListBox listBox)
        {
            string tooltipText = listBox.Items[_hoveredIndex].ToString();
            _toolTip.Active = false;
            _toolTip.SetToolTip(listBox, tooltipText);
            _toolTip.Active = true;
        }

        private void HideTooltip(ListBox listBox)
        {
            _toolTip.Hide(listBox);
        }
    }

    public class TooltipSettings
    {
        public int AutoPopDelay { get; set; } = 5000;
        public int InitialDelay { get; set; } = 1000;
        public int ReshowDelay { get; set; } = 500;
        public bool ShowAlways { get; set; } = true;
        public int MaxTooltipLength { get; set; } = 200;
    }
}
