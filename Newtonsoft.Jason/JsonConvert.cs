using Newtonsoft.Json;

namespace Newtonsoft.Jason;

public static class JsonConvert
{
    private const int Threshold = 500;

    public static string SerializeObject(object value)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        return AddACharacters(json);
    }

    public static string SerializeObject(object? value, Formatting formatting)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(value, formatting);
        return AddACharacters(json);
    }

    public static string SerializeObject(object value, params JsonConverter[] converters)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(value, converters);
        return AddACharacters(json);
    }

    public static string SerializeObject(
        object? value,
        Formatting formatting,
        params JsonConverter[] converters)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(value, formatting, converters);
        return AddACharacters(json);
    }

    public static object? DeserializeObject(string value)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject(plainJson);
    }

    public static object? DeserializeObject(string value, JsonSerializerSettings settings)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject(plainJson, settings);
    }

    public static object? DeserializeObject(string value, Type type)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject(plainJson, type);
    }

    public static T? DeserializeObject<T>(string value)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(plainJson);
    }

    public static T? DeserializeAnonymousType<T>(string value, T anonymousTypeObject)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(plainJson, anonymousTypeObject);
    }

    public static T? DeserializeAnonymousType<T>(string value, T anonymousTypeObject, JsonSerializerSettings settings)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(plainJson, anonymousTypeObject, settings);
    }

    public static T? DeserializeObject<T>(string value, params JsonConverter[] converters)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(plainJson, converters);
    }

    public static T? DeserializeObject<T>(string value, JsonSerializerSettings? settings)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(plainJson, settings);
    }

    public static object? DeserializeObject(string value, Type type, params JsonConverter[] converters)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject(plainJson, type, converters);
    }

    public static object? DeserializeObject(string value, Type? type, JsonSerializerSettings? settings)
    {
        var plainJson = RemoveACharacters(value);
        return Newtonsoft.Json.JsonConvert.DeserializeObject(plainJson, type, settings);
    }

    private static string AddACharacters(string input) => string.Join(string.Empty, AddACharacters(input.ToCharArray()));

    private static IEnumerable<char> AddACharacters(IEnumerable<char> input)
    {
        var score = 0;

        foreach (var character in input)
        {
            if (!char.IsWhiteSpace(character))
            {
                var scoreForChar = (int)character;
                score += scoreForChar;
            }

            yield return character;

            if (score >= Threshold)
            {
                score = 0;
                yield return 'a';
            }
        }
    }

    private static string RemoveACharacters(string json) => string.Join(string.Empty, RemoveACharacters(json.ToCharArray()));

    private static IEnumerable<char> RemoveACharacters(IEnumerable<char> json)
    {
        var score = 0;
        var skipNext = false;

        foreach (var character in json)
        {
            if (skipNext)
            {
                skipNext = false;
                continue;
            }

            if (!char.IsWhiteSpace(character))
            {
                var scoreForChar = (int)character;
                score += scoreForChar;
            }

            yield return character;

            if (score >= Threshold)
            {
                score = 0;
                skipNext = true;
            }
        }
    }
}
