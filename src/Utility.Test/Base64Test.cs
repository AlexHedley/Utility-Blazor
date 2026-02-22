using Bunit;
using Utility.Components.Base64;
using Xunit;

namespace Utility.Test;

public class Base64Test : BunitContext
{
    public Base64Test() {}

    [Fact]
    public void StringShouldDecode()
    {
        string input = "QWxleEhlZGxleQ==";
        string output = string.Empty;
        string expectedOutput = "AlexHedley";
        
        var cut = Render<Base64>(parameters => parameters
            .Add(p => p.Input, input)
            .Add(p => p.Output, output)
        );
        
        cut.FindAll("button")[0].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);

        Base64 base64 = cut.Instance;
        Assert.Equal(base64.Input, input);
        Assert.Equal(base64.Output, expectedOutput);
    }
    
    [Fact]
    public void StringShouldSkipOnEmptyDecode()
    {
        string input = "";
        string output = string.Empty;
        string expectedOutput = "";
        
        var cut = Render<Base64>(parameters => parameters
            .Add(p => p.Input, input)
            .Add(p => p.Output, output)
        );
        
        cut.FindAll("button")[0].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);

        Base64 base64 = cut.Instance;
        Assert.Equal(base64.Input, input);
        Assert.Equal(base64.Output, expectedOutput);
    }
    
    [Fact]
    public void StringShouldEncode()
    {
        string input = string.Empty;
        string output = "AlexHedley";
        string expectedInput = "QWxleEhlZGxleQ==";
        
        var cut = Render<Base64>(parameters => parameters
            .Add(p => p.Input, input)
            .Add(p => p.Output, output)
        );
        
        cut.FindAll("button")[2].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);

        Base64 base64 = cut.Instance;
        Assert.Equal(base64.Input, expectedInput);
        Assert.Equal(base64.Output, output);
    }
    
    [Fact]
    public void StringShouldSkipOnEmptyEncode()
    {
        string input = "";
        string output = string.Empty;
        string expectedOutput = "";
        
        var cut = Render<Base64>(parameters => parameters
            .Add(p => p.Input, input)
            .Add(p => p.Output, output)
        );
        
        cut.FindAll("button")[2].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);

        Base64 base64 = cut.Instance;
        Assert.Equal(base64.Input, input);
        Assert.Equal(base64.Output, expectedOutput);
    }
}