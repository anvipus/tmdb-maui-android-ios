using CommunityToolkit.Mvvm.DependencyInjection;
using MyMauiApp.ViewModels;

namespace MyMauiApp.Views
{
    public partial class ExploreScreen : ContentPage
    {
        private readonly ExploreViewModel _viewModel;

        // Constructor tanpa parameter untuk ShellContent
        public ExploreScreen() : this(
            Ioc.Default.GetService<ExploreViewModel>() 
            ?? throw new NullReferenceException("ExploreViewModel not resolved"))
        {
        }

        // Constructor dengan parameter (untuk DI manual jika diperlukan)
        public ExploreScreen(ExploreViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            BindingContext = _viewModel;

            Loaded += OnPageLoaded;
        }

        private async void OnPageLoaded(object? sender, EventArgs e)
        {
            Loaded -= OnPageLoaded;
            await _viewModel.LoadMoviesAsync();
        }
    }
}