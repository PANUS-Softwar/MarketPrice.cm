using CNT_MAUI.Models;
using CNT_MAUI.PageModels;

namespace CNT_MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}