using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

namespace LanguageExtensionV5Bug;

public class V5Test
{
    public sealed record CustomExpected(string Message, int Code, string Another)
        : Expected(Message, Code);

    [Fact]
    public void Test()
    {
        // Arrange
        var expected = new CustomExpected("Name", 100, "This is loss");
        Eff<int> effect = liftEff<int>(() => expected);

        // Act
        Fin<int> fin = effect.Run();

        // Assert
        fin.Match(_ => Assert.True(false),
                  error =>
                  {
                      Assert.Equal(error.Code, expected.Code);
                      Assert.Equal(error.Message, expected.Message);

                      var fail = (CustomExpected)error;
                      Assert.Equal(fail.Another, expected.Another);
                  });

    }
}