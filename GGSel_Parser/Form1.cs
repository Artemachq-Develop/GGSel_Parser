using Newtonsoft.Json;
using System.Windows.Forms;

namespace GGSel_Parser;

public partial class Form1 : Form
{
    #region Fields

    private readonly TooltipElement _tooltipElement;

    private readonly Parser _parser = new Parser();
    private readonly List<GameInfo> _gameInfoSaveList = new List<GameInfo>();

    #endregion

    #region Constructor
    public Form1()
    {
        InitializeComponent();

        _tooltipElement = new TooltipElement(toolTip1);

        LoadData();
    }
    #endregion

    #region Event Handlers
    private void addLinksButton_Click(object sender, EventArgs e)
    {
        AddGameInfoToList();
    }

    private void addToolStripMenuItem_Click(object sender, EventArgs e)
    {
        AddGameInfoToList();
    }

    private void removeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        RemoveSelectedGameInfo();
    }

    private async void checkButton_Click(object sender, EventArgs e)
    {
        await ParseSelectedGameAsync();
    }

    private void linksListBox_MouseMove(object sender, MouseEventArgs e)
    {
        _tooltipElement.HandleListBoxTooltip(sender as ListBox, e);
    }
    #endregion

    #region Game Info Management
    private void AddGameInfoToList()
    {
        var gameInfo = CreateGameInfoItem();
        if (gameInfo != null)
        {
            _gameInfoSaveList.Add(gameInfo);
            linksListBox.Items.Add(gameInfo.ToString());
            SaveData();
        }
    }

    private void RemoveSelectedGameInfo()
    {
        if (linksListBox.SelectedItem == null)
            return;

        int selectedIndex = linksListBox.SelectedIndex;

        if (selectedIndex >= 0 && selectedIndex < _gameInfoSaveList.Count)
        {
            _gameInfoSaveList.RemoveAt(selectedIndex);
            linksListBox.Items.RemoveAt(selectedIndex);
            SaveData();
        }
    }

    private GameInfo? CreateGameInfoItem()
    {
        using var gameForm = new GameInfoForm();
        return gameForm.ShowDialog() == DialogResult.OK
            ? gameForm.GameInfo
            : null;
    }

    #endregion

    #region Data Persistence
    public void SaveData()
    {
        try
        {
            string json = JsonConvert.SerializeObject(_gameInfoSaveList, Formatting.Indented);
            File.WriteAllText(Settings.DataFileName, json);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Data saving error: {ex.Message}",
                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public void LoadData()
    {
        try
        {
            if (!File.Exists(Settings.DataFileName))
                return;

            string data = File.ReadAllText(Settings.DataFileName);
            var loadedData = JsonConvert.DeserializeObject<List<GameInfo>>(data);

            if (loadedData != null)
            {
                _gameInfoSaveList.AddRange(loadedData);
                PopulateLinksListBox();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Data upload exception: {ex.Message}",
                "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void PopulateLinksListBox()
    {
        linksListBox.Items.Clear();
        foreach (var gameInfo in _gameInfoSaveList)
        {
            linksListBox.Items.Add(gameInfo.ToString());
        }
    }
    #endregion

    #region Parsing Logic
    private async Task ParseSelectedGameAsync()
    {
        try
        {
            SetParsingState(true);
            ClearResults();

            string url = GetSelectedUrlOrDefault();
            var products = await _parser.ParseProductsAsync(url);

            DisplayParsingResults(products);
        }
        catch (Exception ex)
        {
            HandleParsingError(ex);
        }
        finally
        {
            SetParsingState(false);
        }
    }

    private void SetParsingState(bool isParsing)
    {
        checkButton.Enabled = !isParsing;
        checkButton.Text = isParsing ? "Parsing..." : "Check prices";
    }

    private void ClearResults()
    {
        lowPriceListBox.Items.Clear();
    }

    private string GetSelectedUrlOrDefault()
    {
        return _gameInfoSaveList[linksListBox.SelectedIndex].Link
            ?? Settings.DefaultUrl;
    }

    private void DisplayParsingResults(List<GameProduct> products)
    {
        if (products.Count == 0)
        {
            DisplayNoProductsFound();
            return;
        }

        DisplayStatistics(products);

        DisplayProductsHeader(products.Count);
        DisplayProductsList(products);
    }

    private void DisplayNoProductsFound()
    {
        lowPriceListBox.Items.Add("❌ No products found");
        MessageBox.Show("No products found on the page.",
            "The result of parsing", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void DisplayProductsHeader(int count)
    {
        lowPriceListBox.Items.Add($"Products found: {count}");
        lowPriceListBox.Items.Add("═══════════════════════════");
    }

    private void DisplayProductsList(List<GameProduct> products)
    {
        foreach (var product in products)
        {
            string displayName = TruncateProductName(product.Name, Settings.MaxProductNameLength);

            lowPriceListBox.Items.Add(displayName);
            lowPriceListBox.Items.Add($"  💰 {product.Price:F0} ₽  |  📊 Sales: {product.SalesCount}  |  🛒 {product.SellerName}");
            lowPriceListBox.Items.Add("───────────────────");
        }
    }

    private void DisplayStatistics(List<GameProduct> products)
    {
        var mostPopular = products.OrderByDescending(p => p.SalesCount).First();

        lowPriceListBox.Items.Add("═══════════════════════════");
        lowPriceListBox.Items.Add("📈 Statistic:");
        lowPriceListBox.Items.Add($"💸 Min Price: {products.Min(p => p.Price):F0} ₽");
        lowPriceListBox.Items.Add($"💰 Max Price: {products.Max(p => p.Price):F0} ₽");
        lowPriceListBox.Items.Add($"📊 Average Price: {products.Average(p => p.Price):F0} ₽");
        lowPriceListBox.Items.Add($"🔥 All sales: {products.Sum(p => p.SalesCount):N0}");
        lowPriceListBox.Items.Add($"⭐ Sales leader: x{mostPopular.SalesCount}. ({mostPopular.Name} - {mostPopular.Price})");
        lowPriceListBox.Items.Add("═══════════════════════════");
    }

    private void HandleParsingError(Exception ex)
    {
        string errorMessage = $"Exception: {ex.Message}";

        MessageBox.Show(errorMessage, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        lowPriceListBox.Items.Add($"❌ {errorMessage}");
    }
    #endregion

    #region Utility Methods
    private static string TruncateProductName(string name, int maxLength)
    {
        return name.Length > maxLength
            ? name.Substring(0, maxLength - 3) + "..."
            : name;
    }

    #endregion
}