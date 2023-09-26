using Bunit;
using Xunit;

using Utility.Components.TimerControl;

namespace Utility.Test;

public class TimerControlTest : TestContext
{
    public TimerControlTest() {}
    
    // [Fact]
    public void TimerControlShouldStart()
    {
        string input = "5m 00s";
        string expectedInput = "";
        var cut = RenderComponent<TimerControl>(parameters => parameters
            .Add(p => p.Input, input)
        );
        
        cut.FindAll("button")[0].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);
    
        TimerControl timerControl = cut.Instance;
        Assert.Equal(timerControl.Input, input);
    }

    // [Fact]
    public void TimerControlShouldStop()
    {
        
    }
}