using Bunit;

using Utility.Components.Binary;

namespace Utility.Test;

public class BinaryTest : BunitContext
{
    public BinaryTest()
    {
    }
    
    // [Fact]
    public void BinaryShouldConvertWhenClicked()
    {
        var cut = Render<Binary>();
        cut.Find("button").Click();

        string markup = "";
        
        cut.FindAll("textarea")[1].MarkupMatches(markup);
    }
}