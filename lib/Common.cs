using Newtonsoft.Json;
using System.IO;

namespace Hangry.Lib;

public static class Common
{
    public static T DeserializeFromJSon<T>(string filePath, Func<string, Stream> fileReader)
    {
        using Stream fileStream = fileReader(filePath);
        using StreamReader reader = new(fileStream);
        using JsonTextReader jsonReader = new(reader);
        var jsonSerializer = new Newtonsoft.Json.JsonSerializer();
        T val = jsonSerializer.Deserialize<T>(jsonReader);
        return val;
    }

    public static Func<string, Stream> FileReader = ((path) =>
    {
        return FileSystem.Current.OpenAppPackageFileAsync(path).Result;
    });
}