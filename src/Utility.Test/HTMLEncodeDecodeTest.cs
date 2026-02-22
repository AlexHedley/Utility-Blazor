using Bunit;
using Xunit;

using Utility.Components.HTMLEncodeDecode;

namespace Utility.Test;

public class HTMLEncodeDecodeTest : BunitContext
{
    public HTMLEncodeDecodeTest()
    {}

    [Fact]
    public void CanEncode()
    {
        var decoded = "&lt;html&gt;&lt;body&gt;&lt;h1&gt;Hello&lt;/h1&gt;&lt;/body&gt;&lt;/html&gt;";
        var encoded = string.Empty;
        
        var cut = Render<HTMLEncodeDecode>(parameters => parameters
            .Add(p => p.Decoded, decoded)
            .Add(p => p.Encoded, encoded)
        );
        
        cut.FindAll("button")[0].Click();

        var converted = "<html><body><h1>Hello</h1></body></html>";
        HTMLEncodeDecode htmlEncodeDecode = cut.Instance;
        Assert.Equal(htmlEncodeDecode.Encoded, converted);
    }
    
    // [Fact]
    public void CanDecode()
    {
        var decoded = string.Empty;
        var encoded = "<html><body><h1>Hello</h1></body></html>";
        
        var cut = Render<HTMLEncodeDecode>(parameters => parameters
            .Add(p => p.Decoded, decoded)
            .Add(p => p.Encoded, encoded)
        );
        
        cut.FindAll("button")[2].Click();

        var converted = "&lt;html&gt;&lt;body&gt;&lt;h1&gt;Hello&lt;/h1&gt;&lt;/body&gt;&lt;/html&gt;";
        HTMLEncodeDecode htmlEncodeDecode = cut.Instance;
        Assert.Equal(htmlEncodeDecode.Decoded, converted);
    }
}