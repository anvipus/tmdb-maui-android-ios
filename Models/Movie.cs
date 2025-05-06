using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SQLite;

namespace MyMauiApp.Models
{
    [SQLite.Table("movies")]
    public class Movie
    {
        [JsonPropertyName("adult")]
        public bool? Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string? BackdropPath { get; set; }

        [PrimaryKey]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonPropertyName("original_title")]
        public string? OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double? Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; } = "";

        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("video")]
        public bool? Video { get; set; }

        [JsonPropertyName("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public double? VoteCount { get; set; }
        
        [Ignore]
        public string PosterUrl => $"https://media.themoviedb.org/t/p/w220_and_h330_face{PosterPath}";
    }
}