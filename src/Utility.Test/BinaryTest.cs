using Bunit;

using Utility.Components.Binary;

namespace Utility.Test;

public class BinaryTest : TestContext
{
    public BinaryTest()
    {
    }
    
    // [Fact]
    public void BinaryShouldConvertWhenClicked()
    {
        var cut = RenderComponent<Binary>();
        cut.Find("button").Click();

        string markup = "";
        
        cut.FindAll("textarea")[1].MarkupMatches(markup);
    }
}