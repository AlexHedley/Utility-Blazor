using Bunit;
using Utility.Components.HexToRGB;
using Xunit;

namespace Utility.Test;

public class ColourConverterTest : BunitContext
{
    public ColourConverterTest()
    {
    }
    
    // [Fact]
    public void MarkdownShouldConvertWhenClicked()
    {
        var cut = Render<HexToRGB>();
        cut.Find("button").Click();

        string markupRed = "";
        string markupGreen = "";
        string markupBlue = "";
        
        cut.FindAll("input")[1].MarkupMatches(markupRed);
        cut.FindAll("input")[2].MarkupMatches(markupGreen);
        cut.FindAll("input")[3].MarkupMatches(markupBlue);
    }
}