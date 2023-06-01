using Bunit;
using Xunit;

using Utility.Pages;

namespace Utility.Test;

public class MarkdownTest: TestContext
{
    public MarkdownTest()
    {
    }
    
    [Fact]
    public void MarkdownShouldConvertWhenClicked()
    {
        var cut = RenderComponent<Markdown>();
        cut.Find("button").Click();

        string markup = "<textarea id=\"markdown\" class=\"form-control\" rows=\"5\" value=\"# Hello\"></textarea>";
        
        cut.FindAll("textarea")[1].MarkupMatches(markup);
    }
}