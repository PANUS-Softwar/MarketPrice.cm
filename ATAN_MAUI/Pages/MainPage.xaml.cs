using ATAN_MAUI.Models;
using ATAN_MAUI.PageModels;

namespace ATAN_MAUI.Pages
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