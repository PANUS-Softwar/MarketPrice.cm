using TTEK_MAUI.Models;
using TTEK_MAUI.PageModels;

namespace TTEK_MAUI.Pages
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