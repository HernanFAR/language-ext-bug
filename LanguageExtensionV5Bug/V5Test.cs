using LanguageExt.Common;

namespace LanguageExtensionV5Bug;

public class V5Test
{
    public sealed record NotFound(string Message) : Expected(Message, 404);

    [Fact]
    public void Test()
    {
        // Arrange
        Error expected = new NotFound("Name");

        // Act
        var act = $"Expected: {expected}";

        Assert.NotNull(act);
    }
}