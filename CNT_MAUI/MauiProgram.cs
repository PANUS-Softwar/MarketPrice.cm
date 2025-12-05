using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;
using CNT_MAUI.Services;
using CNT_MAUI.ViewModels;
using CNT_MAUI.Views;

namespace CNT_MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("DMSerifText-Regular.ttf", "DMSerifTextRegular");
                    fonts.AddFont("Domine-Regular.ttf", "DomineRegular");
                })
                .ConfigureServices();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddHttpClient<ILookupDataTypeService, LookupDataTypeService>(client =>
            {
                client.BaseAddress = new Uri("http://10.0.2.2:5015/");

            });

            builder.Services.AddTransient<LookupDataTypeViewModel>();

            builder.Services.AddTransient<MarketView>();

            return builder;
        }
    }
}
