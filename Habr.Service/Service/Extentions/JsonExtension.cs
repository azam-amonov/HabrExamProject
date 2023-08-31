using Newtonsoft.Json;
namespace Habr.Service.Service.Extentions;



public static class JsonExtension
{
    private static string ToJson<T>(this T obj) =>
                    JsonConvert.SerializeObject(obj, Formatting.Indented);

    private static T FromJson<T>(this string json) =>
                    JsonConvert.DeserializeObject<T>(json);

    public static async Task<T> ReadJsonFromFileAsync<T>(this string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            return json.FromJson<T>();
        }
        else
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }
    }

    public static async Task WriteToFileFromJsonAsync<T>(this T source, string filePath)
    {
        var json = source.ToJson();
        await File.WriteAllTextAsync(filePath, json);
    }
}
