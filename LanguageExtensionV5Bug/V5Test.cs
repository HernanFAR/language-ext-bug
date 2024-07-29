using LanguageExt.Common;
using System.Diagnostics.Contracts;

namespace LanguageExtensionV5Bug;

public class V5Test
{
    public sealed record NotFoundWithoutFailure(string Message)
        : Expected(Message, 404)
    {
        [Pure]
        public override string ToString() => $"{Message}";
    }

    public sealed record NotFoundWithFailure(string Message)
        : Expected(Message, 404);

    [Fact]
    public void TestWithoutFailure()
    {
        // Arrange
        Error expected = new NotFoundWithoutFailure("Name");

        // Act
        var act = $"Expected: {expected}";

        Assert.NotNull(act);
    }

    [Fact]
    public void TestWithFailure()
    {
        // Arrange
        Error expected = new NotFoundWithFailure("Name");

        // Act
        var act = $"Expected: {expected}";

        Assert.NotNull(act);
    }
}