using Microsoft.Extensions.Logging;
using WineApp.Services;
using WineApp.ViewModels;
using WineApp.Views;

namespace WineApp
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<IHomeViewModel, HomeViewModel>();

            builder.Services.AddTransient<INavigationService, NavigationService>();

            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<IDetailsViewModel, DetailsViewModel>();

            builder.Services.AddTransient<WinePage>();
            builder.Services.AddTransient<IWineViewModel, WineViewModel>();

            return builder.Build();
        }
    }
}
