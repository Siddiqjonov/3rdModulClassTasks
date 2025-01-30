using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WorkWithHttpClient;

public class MusicCrudApiBroker
{
    private HttpClient _httpClient;
    private string _baseUrl;
    public MusicCrudApiBroker()
    {
        _httpClient = new HttpClient();
        _baseUrl = "https://localhost:7158/api/music";
        Add();
        GetAll();
    }
    public void GetAll()
    {
        string url = $"{_baseUrl}/getAllMusic";

        HttpResponseMessage response = _httpClient.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();
        HttpContent responseContent = response.Content;
        string content = responseContent.ReadAsStringAsync().Result; // music Json

        JsonSerializerOptions options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        var music = JsonSerializer.Deserialize<Music[]>(content, options);
        foreach(var m in music)
        {
            Console.WriteLine(m);
        }
    }
    public void Add()
    {
        //var url = $"{_baseUrl}/addMusic";


        //var json = JsonSerializer.Serialize(music);
        //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        //var response = _httpClient.PostAsync(url, content).Result;
        //response.EnsureSuccessStatusCode();

        //var responseContent = response.Content.ReadAsStringAsync().Result;
        var url = $"{_baseUrl}/addMusic";
        var music = new Music()
        {
            Name = "gfggdfgdfg",
            MB = 4.8,
            AuthorName = "gfdg Jo'gdfgdfg",
            Description = "gdfgggdg",
            QuentityLikes = 4599
        };

        var json = JsonSerializer.Serialize(music);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


        var response = _httpClient.PostAsync("https://localhost:7158/api/music/addMusic", content).Result;
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(responseContent);
    }
}
