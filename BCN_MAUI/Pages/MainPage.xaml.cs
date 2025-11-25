using BCN_MAUI.Models;
using BCN_MAUI.PageModels;

namespace BCN_MAUI.Pages
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