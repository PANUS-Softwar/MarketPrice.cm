using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ATAN_MAUI;

public partial class HomePage : ContentPage
{
    public ObservableCollection<CommodityModel> CommodityList { get; set; }
    public ICommand SubmitBidCommand { get; }

    public HomePage()
    {
        InitializeComponent();
        SubmitBidCommand = new Command<CommodityModel>(OnSubmitBid);

        CommodityList = new ObservableCollection<CommodityModel>
        {
            new CommodityModel
            {
                Name = "Maize",
                BidPrice = "450",
                AskPrice = "480",
                OtherPrices = new ObservableCollection<string> { "430", "420", "400" }
            },
            new CommodityModel
            {
                Name = "Beans",
                BidPrice = "800",
                AskPrice = "820",
                OtherPrices = new ObservableCollection<string> { "780", "760", "750" }
            }
        };

        CommodityListView.ItemsSource = CommodityList;
    }

    private void OnSubmitBid(CommodityModel commodity)
    {
        if (string.IsNullOrEmpty(commodity.UserEnteredPrice))
        {
            DisplayAlert("Error", "Please enter a price before submitting your bid/offer.", "OK");
            return;
        }

        _ = DisplayAlert("Error", "Please enter a price before submitting your bid/offer.", "OK");
    }

    // SEARCH
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var filtered = CommodityList
            .Where(c => c.Name.ToLower().Contains(e.NewTextValue.ToLower()))
            .ToList();

        CommodityListView.ItemsSource = filtered;
    }

    // SUBMIT BID/OFFER
    //private void OnSubmitBidClicked(object sender, EventArgs e)
    //{
    //    if (PriceEntry.Text != null)
    //    {
    //        DisplayAlert("Bid Submitted", $"Price Entered: {PriceEntry.Text}", "OK");
    //    }
    //}



    // BOTTOM NAVIGATION
    private async void GoHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HomePage));
    }

    private async void GoActivities(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ActivitiesPage));
    }

    private async void GoSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}

public class CommodityModel
{
    public string? Name { get; set; }
    public string? BidPrice { get; set; }
    public string? AskPrice { get; set; }
    public ObservableCollection<string>? OtherPrices { get; set; }
    public string? UserEnteredPrice { get; set; }
}
