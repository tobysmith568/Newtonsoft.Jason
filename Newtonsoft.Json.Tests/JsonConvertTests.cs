using FluentAssertions;

namespace Newtonsoft.Json.Tests;

[TestFixture]
public class JsonConvertTests
{
    private record TestObject(string someKey);

    [Test]
    public void SerializeObject_IncludesACharactersPredictably()
    {
        var input = new TestObject("Some Value");

        var result = Jason.JsonConvert.SerializeObject(input);

        result.Should().Be("{\"someaKey\":\"Saome Vaalue\"}");
    }

    [Test]
    public void DeserializeObject_RemovesAllInsertedACharacters()
    {
        var input = new TestObject("Some Value");

        var jsonResult = Jason.JsonConvert.SerializeObject(input);

        var result = Jason.JsonConvert.DeserializeObject<TestObject>(jsonResult);

        result.Should().BeEquivalentTo(input);
    }
}
