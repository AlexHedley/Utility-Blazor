using Bunit;
using Shouldly;
using Xunit;

using Utility.Components.HCF;

namespace Utility.Test;

public class HCFTest : BunitContext
{
    public HCFTest()
    {}

    [Fact]
    public void HiddenCharacterFinderRenders()
    {
        var cut = Render<HCF>();
        cut.Find("textarea").ShouldNotBeNull();
        cut.Find("button").ShouldNotBeNull();
    }

    [Fact]
    public void ShowButton_WithInput_RendersOutput()
    {
        var cut = Render<HCF>();
        cut.Find("textarea").Change("Hello");
        cut.Find("button").Click();
        cut.Find(".output").ShouldNotBeNull();
    }

    [Fact]
    public void HtmlChar_AsciiChar_ReturnsCorrectDesc()
    {
        // 'S' is ASCII 83 = 0x53
        var result = HCFService.HtmlChar("S");
        result.ShouldContain("83");
        result.ShouldContain("0x53");
    }

    [Fact]
    public void HtmlChar_NonBreakingSpace_ReturnsCodePoint()
    {
        // U+00A0 non-breaking space, code point = 160
        var result = HCFService.HtmlChar("\u00A0");
        result.ShouldContain("&#160;");
        result.ShouldContain("\\u00A0");
        result.ShouldContain("U+00A0");
    }

    [Fact]
    public void HtmlChar_Tab_ReturnsSymbolSpan()
    {
        var result = HCFService.HtmlChar("\t");
        result.ShouldContain("symbol");
    }

    [Fact]
    public void HtmlChar_RegularLetter_ReturnsAnchorSpan()
    {
        var result = HCFService.HtmlChar("a");
        result.ShouldContain("S2Tooltip anchor");
        result.ShouldNotContain("hex");
    }

    [Fact]
    public void HtmlChar_HiddenUnicodeChar_ReturnsHexSpan()
    {
        // U+200B zero-width space is a non-printable, non-regular character
        var result = HCFService.HtmlChar("\u200B");
        result.ShouldContain("hex S2Tooltip anchor");
        result.ShouldContain("U+200B");
    }

    [Fact]
    public void Text2Html_CountsAsciiCharsAndBytes()
    {
        // "ab" = 2 ASCII chars = 2 UTF-8 bytes
        var (html, chars, bytes) = HCFService.Text2Html("ab");
        chars.ShouldBe(2);
        bytes.ShouldBe(2);
    }

    [Fact]
    public void Text2Html_MultibyteCounts()
    {
        // U+00A0 = 1 character, 2 UTF-8 bytes
        var (html, chars, bytes) = HCFService.Text2Html("\u00A0");
        chars.ShouldBe(1);
        bytes.ShouldBe(2);
    }

    [Fact]
    public void Text2Html_OutputWrappedInOutputDiv()
    {
        var (html, _, _) = HCFService.Text2Html("x");
        html.ShouldStartWith("<div class='output'>");
        html.ShouldEndWith("</div>\n");
    }
}
