using Bunit;
using Xunit;

using Utility.Components.LuhnChecker;

namespace Utility.Test;

public class LuhnCheckerTest : BunitContext
{
    public LuhnCheckerTest()
    {}
    
    [Fact]
    public void CheckLuhnWithInvalidShouldReturnFalse()
    {
        string input = "1";
        bool valid = false;
        
        var cut = Render<LuhnChecker>(parameters => parameters
            .Add(p => p.check, input)
            .Add(p => p.valid, valid)
        );
        
        cut.FindAll("button")[1].Click();
        
        LuhnChecker luhnChecker = cut.Instance;
        Assert.Equal(luhnChecker.valid, valid);
    }
    
    [Fact]
    public void CheckLuhnWithValidShouldReturnTrue()
    {
        string input = "378282246310005";
        bool valid = true;
        
        var cut = Render<LuhnChecker>(parameters => parameters
            .Add(p => p.check, input)
            .Add(p => p.valid, valid)
        );
        
        cut.FindAll("button")[1].Click();
        
        LuhnChecker luhnChecker = cut.Instance;
        Assert.Equal(luhnChecker.valid, valid);
    }
}