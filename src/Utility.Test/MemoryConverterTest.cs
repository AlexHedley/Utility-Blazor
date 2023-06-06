using Bunit;
using Xunit;

using Utility.Components.MemoryConverter;

namespace Utility.Test;

public class MemoryConverterTest: TestContext
{
    public MemoryConverterTest()
    {
    }
    
    [Fact]
    public void MemoryShouldConvertWhenClicked()
    {
        var cut = RenderComponent<MemoryConverter>();
        
        cut.FindAll("button")[1].Click();
        string markup = "<input id=\"output\" class=\"form-control\" placeholder=\"KB / MB / GB / TB / PB / EB / ZB / YB\" readonly=\"readonly\" value=\"1.0 KB\">";
        cut.FindAll("input")[1].MarkupMatches(markup);

        MemoryConverter memoryConverter = cut.Instance;
        Assert.Equal(memoryConverter.Input, 1030);
        Assert.Equal(memoryConverter.Output, "1.0 KB");
    }
}