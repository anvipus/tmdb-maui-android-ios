using System.Collections.Generic;
using System.Threading.Tasks;
using MyMauiApp.Models;

namespace MyMauiApp.Services
{
    public interface IMovieApiService
    {
        Task<PopularListData?> GetPopularMoviesAsync(Dictionary<string, string> queryParams);
        Task<PopularListData?> GetNowPlayingMoviesAsync(Dictionary<string, string> queryParams);
    }
}