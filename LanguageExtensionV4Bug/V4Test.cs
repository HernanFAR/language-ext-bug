using LanguageExt;
using LanguageExt.Common;

namespace LanguageExtensionV4Bug;

public class V4Test
{
    public sealed record CustomExpected(string Message, int Code, string Another)
        : Expected(Message, Code);

    [Fact]
    public void Test()
    {
        // Arrange
        var      expected = new CustomExpected("Name", 100, "This is loss");
        Eff<int> effect   = Eff<int>.Fail(expected);

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