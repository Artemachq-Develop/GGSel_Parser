using GGSel_Parser;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

public class Parser
{
    private readonly HttpClient _httpClient;

    public Parser()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
    }

    public async Task<List<GameProduct>> ParseProductsAsync(string url)
    {
        var products = new List<GameProduct>();

        try
        {
            string html = await _httpClient.GetStringAsync(url);

            if (string.IsNullOrEmpty(html))
            {
                throw new Exception("Пустой ответ от сервера");
            }

            // Ищем полные JSON объекты товаров
            var jsonPattern = @"\{""id_goods"":\d+,.*?""sort"":\[[^\]]+\]\}";
            var matches = Regex.Matches(html, jsonPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match match in matches)
            {
                try
                {
                    string jsonString = match.Value;

                    // Парсим JSON объект товара
                    using var doc = JsonDocument.Parse(jsonString);
                    var root = doc.RootElement;

                    var product = new GameProduct();

                    // Извлекаем название товара
                    if (root.TryGetProperty("name", out var nameElement))
                    {
                        product.Name = nameElement.GetString() ?? "Неизвестный товар";
                    }

                    // Извлекаем количество продаж
                    if (root.TryGetProperty("cnt_sell", out var cntSellElement))
                    {
                        product.SalesCount = cntSellElement.GetInt32();
                    }

                    // Извлекаем имя продавца
                    if (root.TryGetProperty("seller_name", out var sellerElement))
                    {
                        product.SellerName = sellerElement.GetString() ?? "Неизвестный продавец";
                    }

                    // Извлекаем цену в рублях (приоритет price_wmr)
                    decimal priceRub = 0;

                    if (root.TryGetProperty("price_wmr", out var priceWmrElement))
                    {
                        if (decimal.TryParse(priceWmrElement.GetString(), out priceRub))
                        {
                            product.PriceRub = priceRub;
                        }
                    }

                    /*// Если нет цены в рублях, конвертируем из долларов
                    if (priceRub == 0 && root.TryGetProperty("price_wmz", out var priceWmzElement))
                    {
                        if (decimal.TryParse(priceWmzElement.GetString(), out decimal priceUsd))
                        {
                            product.PriceRub = priceUsd * 95; // Конвертация в рубли
                        }
                    }

                    // Если нет цены в долларах, конвертируем из евро
                    if (priceRub == 0 && root.TryGetProperty("price_wme", out var priceWmeElement))
                    {
                        if (decimal.TryParse(priceWmeElement.GetString(), out decimal priceEur))
                        {
                            product.PriceRub = priceEur * 105; // Конвертация в рубли
                        }
                    }*/

                    // Добавляем товар только если есть цена
                    if (product.PriceRub > 0 && !string.IsNullOrEmpty(product.Name))
                    {
                        products.Add(product);
                    }
                }
                catch (JsonException)
                {
                    // Пропускаем некорректный JSON
                    continue;
                }
            }

            // Сортируем по цене (от дешевых к дорогим)
            return products.OrderBy(p => p.PriceRub).ToList();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Ошибка сети: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка парсинга: {ex.Message}");
        }
    }

    // Оставляем старый метод для совместимости
    public async Task<List<decimal>> ParsePricesAsync(string url)
    {
        var products = await ParseProductsAsync(url);
        return products.Select(p => p.PriceRub).ToList();
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}