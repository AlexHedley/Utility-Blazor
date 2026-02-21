using Bunit;
using Utility.Components.MarkdownConverter;
using Xunit;

using Utility.Pages;

namespace Utility.Test;

public class MarkdownConverterTest: BunitContext
{
    public MarkdownConverterTest()
    {
    }

    [Fact]
    public void CheckDefaultConversion()
    {
        var html = "<html><body><h1>Hello</h1></body></html>";
        
        var cut = Render<MarkdownConverter>(parameters => parameters
            .Add(p => p.HTML, html)
        );
        cut.Find("button").Click();
        
        string markup = "<textarea id=\"markdown\" class=\"form-control\" rows=\"5\" placeholder=\"# Hello\" value=\"# Hello\"></textarea>";
        cut.FindAll("textarea")[1].MarkupMatches(markup);
    }
    
    [Fact]
    public void HTMLShouldConvertToMarkdownWhenClicked()
    {
        // html = "&lt;html&gt;&lt;body&gt;&lt;h1&gt;Hello&lt;/h1&gt;&lt;/body&gt;&lt;/html&gt;";
        var html = "<html><body><h1>Hello</h1></body></html>";
        var markdown = "# Hello";

        var cut = Render<MarkdownConverter>(parameters => parameters
            .Add(p => p.HTML, html)
            .Add(p => p.Markdown, markdown)
        );
        cut.Find("button").Click();
        
        MarkdownConverter markdownConverter = cut.Instance;
        Assert.Equal(markdownConverter.HTML, html);
        Assert.Equal(markdownConverter.Markdown, markdown);
    }
    
    [Fact]
    public void EncodedHTMLShouldConvertToMarkdownWhenClicked()
    {
        var html = "&lt;html&gt;&lt;body&gt;&lt;h1&gt;Hello&lt;/h1&gt;&lt;/body&gt;&lt;/html&gt;";
        // var html = "<html><body><h1>Hello</h1></body></html>";
        var markdown = "# Hello";

        var cut = Render<MarkdownConverter>(parameters => parameters
            .Add(p => p.HTML, html)
            .Add(p => p.Markdown, markdown)
        );
        cut.Find("button").Click();
        
        MarkdownConverter markdownConverter = cut.Instance;
        // Assert.Equal(markdownConverter.HTML, html);
        Assert.Equal(markdownConverter.Markdown, markdown);
    }
}