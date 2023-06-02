using Bunit;
using Utility.Components.HexToRGB;
using Xunit;

namespace Utility.Test;

public class ColourConverter : TestContext
{
    public ColourConverter()
    {
    }
    
    // [Fact]
    public void MarkdownShouldConvertWhenClicked()
    {
        var cut = RenderComponent<HexToRGB>();
        cut.Find("button").Click();

        string markupRed = "";
        string markupGreen = "";
        string markupBlue = "";
        
        cut.FindAll("input")[1].MarkupMatches(markupRed);
        cut.FindAll("input")[2].MarkupMatches(markupGreen);
        cut.FindAll("input")[3].MarkupMatches(markupBlue);
    }
}