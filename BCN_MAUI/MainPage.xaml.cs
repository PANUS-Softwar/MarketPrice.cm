using System.Collections.ObjectModel;
using System.Net.Http.Json;  

namespace BCN_MAUI;

public partial class MainPage : ContentPage
{
    // 1. The Data Container (The "Dough")
    public ObservableCollection<ListingItem> RealData { get; set; } = new();

    // 2. The API Tools
    private readonly HttpClient _httpClient;

    // *** CHANGE THIS URL TO MATCH YOUR SWAGGER URL ***
    private readonly string _baseUrl = "https://localhost:7001";

    public MainPage()
    {
        InitializeComponent();

        // 3. Connect the Screen to the Data
        RecentList.ItemsSource = RealData;

        // 4. Setup the HTTP Client
        // We use this "Handler" trick to ignore SSL errors on localhost (common issue)
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
        _httpClient = new HttpClient(handler);

        // 5. Fetch the Data!
        LoadDataFromApi();
    }

    private async void LoadDataFromApi()
    {
        try
        {
            // A. Get the Counts (Bids vs Asks)
            // Endpoint: GET /Stats/counts
            var stats = await _httpClient.GetFromJsonAsync<MarketStats>($"{_baseUrl}/Stats/counts");

            if (stats != null)
            {
                LblBids.Text = stats.Bids.ToString();
                LblAsks.Text = stats.Asks.ToString();
            }

            // B. Get the Recent Listings
            // Endpoint: GET /Stats/recent
            var items = await _httpClient.GetFromJsonAsync<List<ListingItem>>($"{_baseUrl}/Stats/recent");

            RealData.Clear(); // Empty the list

            if (items != null)
            {
                foreach (var item in items)
                {
                    RealData.Add(item); // Add the real items from the database
                }
            }
        }
        catch (Exception ex)
        {
            // If something goes wrong (like the API is offline)
            await DisplayAlert("Error", $"Is the API running? {ex.Message}", "OK");

            // Set fallback text
            LblBids.Text = "-";
            LblAsks.Text = "-";
        }
    }
}

// --- DATA MODELS (Must match the API JSON) ---

public class MarketStats
{
    public int Bids { get; set; }
    public int Asks { get; set; }
}

public class ListingItem
{
    public string Name { get; set; }
    public string Location { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; } // "Bid" or "Ask"

    // Color Logic: Blue for Bid, Green for Ask
    public Color TypeColor => Type == "Bid" ? Color.FromArgb("#2196F3") : Color.FromArgb("#4CAF50");
}