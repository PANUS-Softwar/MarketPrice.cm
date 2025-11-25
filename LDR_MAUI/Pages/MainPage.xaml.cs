using LDR_MAUI.Models;
using LDR_MAUI.PageModels;

namespace LDR_MAUI.Pages
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