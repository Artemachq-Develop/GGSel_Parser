using Newtonsoft.Json;

namespace GGSel_Parser;

public partial class Form1 : Form
{
    #region Fields

    private readonly Parser _parser = new Parser();
    private readonly List<GameInfo> _gameInfoSaveList = new List<GameInfo>();
    private int _hoveredIndex = -1;

    #endregion

    #region Constructor
    public Form1()
    {
        InitializeComponent();
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
        HandleListBoxTooltip(sender as ListBox, e);
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
            MessageBox.Show($"Ошибка сохранения данных: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        checkButton.Text = isParsing ? "Парсинг..." : "Проверить цены";
    }

    private void ClearResults()
    {
        lowPriceListBox.Items.Clear();
    }

    private string GetSelectedUrlOrDefault()
    {
        return linksListBox.SelectedItem?.ToString()
            ?? "https://ggsel.net/catalog/helldivers-2-keys-steam";
    }

    private void DisplayParsingResults(List<GameProduct> products)
    {
        if (products.Count == 0)
        {
            DisplayNoProductsFound();
            return;
        }

        DisplayProductsHeader(products.Count);
        DisplayProductsList(products);
        DisplayStatistics(products);
    }

    private void DisplayNoProductsFound()
    {
        lowPriceListBox.Items.Add("❌ Товары не найдены");
        MessageBox.Show("На странице не найдено товаров.",
            "Результат парсинга", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void DisplayProductsHeader(int count)
    {
        lowPriceListBox.Items.Add($"Найдено товаров: {count}");
        lowPriceListBox.Items.Add("═══════════════════════════");
    }

    private void DisplayProductsList(List<GameProduct> products)
    {
        foreach (var product in products)
        {
            string displayName = TruncateProductName(product.Name, Settings.MaxProductNameLength);

            lowPriceListBox.Items.Add(displayName);
            lowPriceListBox.Items.Add($"  💰 {product.Price:F0} ₽  |  📊 Продаж: {product.SalesCount}  |  🛒 {product.SellerName}");
            lowPriceListBox.Items.Add("───────────────────");
        }
    }

    private void DisplayStatistics(List<GameProduct> products)
    {
        var mostPopular = products.OrderByDescending(p => p.SalesCount).First();

        lowPriceListBox.Items.Add("═══════════════════════════");
        lowPriceListBox.Items.Add("📈 СТАТИСТИКА:");
        lowPriceListBox.Items.Add($"💸 Минимальная цена: {products.Min(p => p.Price):F0} ₽");
        lowPriceListBox.Items.Add($"💰 Максимальная цена: {products.Max(p => p.Price):F0} ₽");
        lowPriceListBox.Items.Add($"📊 Средняя цена: {products.Average(p => p.Price):F0} ₽");
        lowPriceListBox.Items.Add($"🔥 Всего продаж: {products.Sum(p => p.SalesCount):N0}");
        lowPriceListBox.Items.Add($"⭐ Лидер продаж: {mostPopular.SalesCount} шт. ({mostPopular.Name} - {mostPopular.Price})");
    }

    private void HandleParsingError(Exception ex)
    {
        string errorMessage = $"Ошибка: {ex.Message}";

        MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void HandleListBoxTooltip(ListBox listBox, MouseEventArgs e)
    {
        if (listBox == null)
            return;

        int newHoveredIndex = listBox.IndexFromPoint(e.Location);

        if (_hoveredIndex == newHoveredIndex)
            return;

        _hoveredIndex = newHoveredIndex;

        if (IsValidListBoxIndex(listBox, _hoveredIndex))
        {
            ShowTooltip(listBox);
        }
        else
        {
            HideTooltip(listBox);
        }
    }

    private bool IsValidListBoxIndex(ListBox listBox, int index)
    {
        return index >= 0 && index < listBox.Items.Count;
    }

    private void ShowTooltip(ListBox listBox)
    {
        string tooltipText = listBox.Items[_hoveredIndex].ToString();
        toolTip1.Active = false;
        toolTip1.SetToolTip(listBox, tooltipText);
        toolTip1.Active = true;
    }

    private void HideTooltip(ListBox listBox)
    {
        toolTip1.Hide(listBox);
    }
    #endregion
}