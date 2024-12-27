using Bunit;

using Utility.Components.MD5Converter;

namespace Utility.Test;

public class MD5ConverterTest: TestContext
{
    public MD5ConverterTest()
    {
    }
    
    // [Fact]
    public void StringShouldConvertWhenClicked()
    {
        var cut = RenderComponent<MD5Converter>();
        cut.Find("button").Click();

        // string markup = "<textarea id=\"markdown\" class=\"form-control\" rows=\"5\" value=\"# Hello\"></textarea>";
        //
        // cut.FindAll("textarea")[1].MarkupMatches(markup);
    }
}