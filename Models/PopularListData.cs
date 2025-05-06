using System.Collections.Generic;
using System.Text.Json.Serialization;
using MyMauiApp.Models;

namespace MyMauiApp.Models
{
    public class PopularListData
    {
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        [JsonPropertyName("results")]
        public List<Movie>? Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int? TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }
    }
}