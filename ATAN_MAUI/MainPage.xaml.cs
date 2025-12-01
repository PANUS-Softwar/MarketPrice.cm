namespace ATAN_MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else if (count == 30)
                count = 0;
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }


        // Navigate to HomePage
        private async void OnGetStartedClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
    }
}
