using Bunit;
using Utility.Components.Regex;
using Xunit;

namespace Utility.Test;

public class RegexFromStringTest: TestContext
{
    public RegexFromStringTest() {}

    //[Fact]
    public void RegexFromString_EmptyString_EmptyString()
    {
        var cut = RenderComponent<RegexFromString>();
        cut.FindAll("button")[0].Click();
        
        RegexFromString regexFromString = cut.Instance;
        Assert.Equal(regexFromString.Output, string.Empty);
    }
}