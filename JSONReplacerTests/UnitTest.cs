using JSONReplacer;
namespace JSONReplacerTests;

public class JsonReplacerTests
{

    [Test]
    public void Replace_EmptyJson_ReturnsSameJson()
    {
        string payload = "{}";
        string expected = "{}";
        string actual = JsonReplacer.Replace(payload, "", "");

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Replace_JsonWithNoMatch_ReturnsSameJson()
    {
        string payload = "{\"dog\": 0}";
        string expected = "{\"dog\": 0}";
        string actual = JsonReplacer.Replace(payload, "cat", "");

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Replace_JsonWithOneMatch_ReturnsOneReplacement()
    {
        string payload = "{\"dog\": 0}";
        string expected = "{\"cat\": 0}";
        string actual = JsonReplacer.Replace(payload, "dog", "cat");

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Replace_JsonWithMultipleMatches_ReturnsMultipleReplacements()
    {
        string payload = "{\"dog\": 0, \"dog\": 1}";
        string expected = "{\"cat\": 0, \"cat\": 1}";
        string actual = JsonReplacer.Replace(payload, "dog", "cat");

        Assert.That(expected, Is.EqualTo(actual));
    }


    [Test]
    public void Replace_JsonExactMatch_ReturnsOneReplacement()
    {
        string payload = "{\"dog\": 0, \"dog \": 1}";
        string expected = "{\"cat\": 0, \"dog \": 1}";
        string actual = JsonReplacer.Replace(payload, "\"dog\"", "\"cat\"");

        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void Replace_NestedJson_ReturnsMultipleReplacements()
    {
        string payload = "{\"dog\": 0, \"cat\": {\"cat\": {\"dog\": 0}}}";
        string expected = "{\"cat\": 0, \"cat\": {\"cat\": {\"cat\": 0}}}";
        string actual = JsonReplacer.Replace(payload, "\"dog\"", "\"cat\"");

        Assert.That(expected, Is.EqualTo(actual));
    }
}