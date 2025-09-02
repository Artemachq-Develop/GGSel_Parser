using GGSel_Parser;
using System.Text.Json;
using System.Text.RegularExpressions;

internal class Parser
{
    private readonly HttpClient _httpClient;

    /* ---- CONST ---- */

    private const string pattern_wmrPrice = "price_wmr";
    private const string pattern_wmzPrice = "price_wmz";
    private const string pattern_wmePrice = "price_wme";

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

                    #region PriceParse

                        if (Settings.ProgramPrice == ProgramPrice.Rub)
                        {
                            if (root.TryGetProperty(pattern_wmrPrice, out var priceWmrElement))
                            {
                                if (double.TryParse(priceWmrElement.GetString(), out double priceRub))
                                {
                                    product.Price = priceRub;
                                }
                            }
                        }

                        if (Settings.ProgramPrice == ProgramPrice.Usd)
                        {
                            if (root.TryGetProperty(pattern_wmzPrice, out var priceWmzElement))
                            {
                                if (double.TryParse(priceWmzElement.GetString(), out double priceUsd))
                                {
                                    product.Price = priceUsd * 95; // Конвертация в рубли
                                }
                            }
                        }


                        if (Settings.ProgramPrice == ProgramPrice.Eur)
                        {
                            if (root.TryGetProperty(pattern_wmePrice, out var priceWmeElement))
                            {
                                if (double.TryParse(priceWmeElement.GetString(), out double priceEur))
                                {
                                    product.Price = priceEur * 105; // Конвертация в рубли
                                }
                            }
                        }

                    #endregion

                    // Добавляем товар только если есть цена
                    if (product.Price > 0 && !string.IsNullOrEmpty(product.Name))
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
            return products.OrderBy(p => p.Price).ToList();
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

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}