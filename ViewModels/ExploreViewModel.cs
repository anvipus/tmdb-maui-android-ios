using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Config;
using MyMauiApp.Models;
using MyMauiApp.Services;

namespace MyMauiApp.ViewModels
{
    public partial class ExploreViewModel : ObservableObject
    {
        private readonly IMovieApiService _movieApiService;

        public ExploreViewModel(IMovieApiService movieApiService)
        {
            _movieApiService = movieApiService;
            NavigateToSearchCommand = new AsyncRelayCommand(OnNavigateToSearchAsync);

            // Load data saat ViewModel dibuat
            LoadMoviesCommand = new AsyncRelayCommand(LoadMoviesAsync);
            LoadMoviesCommand.ExecuteAsync(null);
        }

        public IAsyncRelayCommand NavigateToSearchCommand { get; }
        public IAsyncRelayCommand LoadMoviesCommand { get; }

        [ObservableProperty]
        private ObservableCollection<Movie> popularMovies = new();

        [ObservableProperty]
        private ObservableCollection<Movie> nowPlayingMovies = new();

        public async Task LoadMoviesAsync()
        {
            var queryParams = new Dictionary<string, string>
            {
                { "language", "en-US" },
                { "page", "1" }
            };

            var popularResponse = await _movieApiService.GetPopularMoviesAsync(queryParams);
            var nowPlayingResponse = await _movieApiService.GetNowPlayingMoviesAsync(queryParams);

            if (popularResponse?.Results != null)
                PopularMovies = new ObservableCollection<Movie>(popularResponse.Results);
            else
                Console.WriteLine("❌ PopularMovies empty or null");

            if (nowPlayingResponse?.Results != null)
                NowPlayingMovies = new ObservableCollection<Movie>(nowPlayingResponse.Results);
            else
                Console.WriteLine("❌ NowPlayingMovies empty or null");
        }

        private async Task OnNavigateToSearchAsync()
        {
            await Shell.Current.GoToAsync("search");
        }
    }
}