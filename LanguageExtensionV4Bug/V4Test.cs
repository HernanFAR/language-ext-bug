using LanguageExt;
using LanguageExt.Common;

namespace LanguageExtensionV4Bug;

public class V4Test
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