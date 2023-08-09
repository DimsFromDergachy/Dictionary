var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


var GetWord = async (string word) => {
    HttpClient httpClient = new()
    {
        BaseAddress = new Uri($"https://ru.wiktionary.org"),
    };
    var result = await httpClient.GetAsync($"/wiki/{word}");
    return await result.Content.ReadAsStringAsync();
};

app.MapGet("/{word:alpha}", async (string word) => {
    var result = await GetWord(word);
    return $"Hello {result}";
});

app.Run();
