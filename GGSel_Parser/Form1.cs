using System.Windows.Forms;

namespace GGSel_Parser;

public partial class Form1 : Form
{
    private Parser _parser;

    public Form1()
    {
        InitializeComponent();
        _parser = new Parser();
    }

    private void addLinksButton_Click(object sender, EventArgs e)
    {
        //AddElementToLinksList();

        using (GameInfoForm gameForm = new GameInfoForm())
        {
            if (gameForm.ShowDialog() == DialogResult.OK)
            {
                // Получаем созданный объект GameInfo
                GameInfo newGame = gameForm.GameInfo;

                // Используем данные (например, добавляем в список)
                linksListBox.Items.Add(newGame.ToString());
            }
        }
    }

    private async void checkButton_Click(object sender, EventArgs e)
    {
        try
        {
            checkButton.Enabled = false;
            checkButton.Text = "Парсинг...";
            lowPriceListBox.Items.Clear();

            string? url = linksListBox.SelectedItem != null
                ? linksListBox.SelectedItem.ToString()
                : "https://ggsel.net/catalog/helldivers-2-keys-steam";

            List<GameProduct> products = await _parser.ParseProductsAsync(url);

            if (products.Count > 0)
            {
                // Заголовок
                lowPriceListBox.Items.Add($"Найдено товаров: {products.Count}");
                lowPriceListBox.Items.Add("═══════════════════════════");

                // Показываем топ-15 самых дешевых товаров
                var topCheapest = products.Take(products.Count).ToList();
                foreach (var product in topCheapest)
                {
                    // Обрезаем длинные названия для лучшего отображения
                    string displayName = product.Name.Length > 50
                        ? product.Name.Substring(0, 47) + "..."
                        : product.Name;

                    lowPriceListBox.Items.Add($"{displayName}");
                    lowPriceListBox.Items.Add($"  💰 {product.Price:F0} ₽  |  📊 Продаж: {product.SalesCount}  |  🛒 {product.SellerName}");
                    lowPriceListBox.Items.Add("───────────────────");
                }

                // Статистика
                lowPriceListBox.Items.Add("═══════════════════════════");
                lowPriceListBox.Items.Add("📈 СТАТИСТИКА:");
                lowPriceListBox.Items.Add($"💸 Минимальная цена: {products.Min(p => p.Price):F0} ₽");
                lowPriceListBox.Items.Add($"💰 Максимальная цена: {products.Max(p => p.Price):F0} ₽");
                lowPriceListBox.Items.Add($"📊 Средняя цена: {products.Average(p => p.Price):F0} ₽");
                lowPriceListBox.Items.Add($"🔥 Всего продаж: {products.Sum(p => p.SalesCount):N0}");

                // Самый популярный товар
                var mostPopular = products.OrderByDescending(p => p.SalesCount).First();
                lowPriceListBox.Items.Add($"⭐ Лидер продаж: {mostPopular.SalesCount} шт. ({mostPopular.Name} - {mostPopular.Price})");
            }
            else
            {
                lowPriceListBox.Items.Add("❌ Товары не найдены");
                MessageBox.Show("На странице не найдено товаров.",
                    "Результат парсинга", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lowPriceListBox.Items.Add($"❌ Ошибка: {ex.Message}");
        }
        finally
        {
            checkButton.Enabled = true;
            checkButton.Text = "Проверить цены";
        }
    }
}