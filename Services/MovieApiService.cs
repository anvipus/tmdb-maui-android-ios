using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using MyMauiApp.Models;
using MyMauiApp.Config; // untuk AppConstants

namespace MyMauiApp.Services
{
    public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient _httpClient;

        public MovieApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(AppConstants.BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AppConstants.ApiKey);
        }

        public async Task<PopularListData?> GetPopularMoviesAsync(Dictionary<string, string> queryParams)
        {
            return await GetMovieListAsync("movie/popular", queryParams);
        }

        public async Task<PopularListData?> GetNowPlayingMoviesAsync(Dictionary<string, string> queryParams)
        {
            return await GetMovieListAsync("movie/now_playing", queryParams);
        }

        private async Task<PopularListData?> GetMovieListAsync(string endpoint, Dictionary<string, string> queryParams)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint + ToQueryString(queryParams));
            var response = await _httpClient.SendAsync(request);
            
            Console.WriteLine("📤 Request Headers:");
            foreach (var header in request.Headers)
            {
                Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
            }
            
            var queryString = ToQueryString(queryParams);
            var fullUrl = $"{_httpClient.BaseAddress}{endpoint}{queryString}";
            Console.WriteLine($"🌐 Calling URL: {fullUrl}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PopularListData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private string ToQueryString(Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return "";

            var list = new List<string>();
            foreach (var pair in parameters)
            {
                list.Add($"{Uri.EscapeDataString(pair.Key)}={Uri.EscapeDataString(pair.Value)}");
            }

            return "?" + string.Join("&", list);
        }
    }
}
