using System.Text.Json.Serialization;

namespace ToDoListApp.Data
{
    public class FavouriteQuote
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}