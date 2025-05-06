using MyMauiApp.Views;
using MyMauiApp.ViewModels;
using Microsoft.Maui.Controls;

namespace MyMauiApp;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; }

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        Services = serviceProvider;

        // Ambil ViewModel dari DI
        var exploreViewModel = serviceProvider.GetRequiredService<ExploreViewModel>();

        // ⚠️ Shell tidak bisa pakai Content dengan constructor berparameter.
        // Jadi kita hindari pakai ShellContent dan langsung atur halaman root-nya saja:
        MainPage = new NavigationPage(new ExploreScreen(exploreViewModel))
        {
            BarBackgroundColor = Colors.White,
            BarTextColor = Colors.Black
        };
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(MainPage);
    }
}