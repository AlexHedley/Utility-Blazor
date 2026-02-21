using Bunit;
using Xunit;

using Utility.Components.Stopwatch;

namespace Utility.Test;

public class StopwatchTest : BunitContext
{
    public StopwatchTest() {}
    
    // [Fact]
    public void StopwatchShouldStart()
    {
        string input = "";
        string expectedInput = "";
        
        
        var cut = Render<Stopwatch>(parameters => parameters
            .Add(p => p.Input, input)
        );
        
        cut.FindAll("button")[0].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);
    
        Stopwatch stopwatch = cut.Instance;
        Assert.Equal(stopwatch.Input, input);
    }

    // [Fact]
    public void StopwatchShouldStop()
    {
        
    }
}