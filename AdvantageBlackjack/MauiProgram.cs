using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;
using AdvantageBlackjack.Pages;
using Firebase.Auth.Repository;

namespace AdvantageBlackjack
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

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyAH9mE1D6_-RxtXX6fVYZU0dLe2gefmFUw",
                AuthDomain = "ap-blackjack.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
                UserRepository = new FileUserRepository("APBlackjack")
            }));

            builder.Services.AddSingleton<SignInPage>();
            builder.Services.AddSingleton<SignInViewModel>();
            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<SignUpViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();



            return builder.Build();
        }
    }
}
