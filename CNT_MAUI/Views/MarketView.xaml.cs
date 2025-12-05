using CNT_MAUI.ViewModels;

namespace CNT_MAUI.Views;

public partial class MarketView : ContentPage
{
    public MarketView(LookupDataTypeViewModel viewModel)
    {
        InitializeComponent();

        this.BindingContext = viewModel;
    }
}