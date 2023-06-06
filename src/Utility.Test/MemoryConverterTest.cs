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

        string markup = "<input id=\"output\" class=\"form-control\" value=\"1.0 KB\">";
        
        cut.FindAll("input")[1].MarkupMatches(markup);
    }
}