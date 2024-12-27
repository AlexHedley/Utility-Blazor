using BlazorMonaco;
using Bunit;
using Xunit;

using Utility.Components.SQLContains;

namespace Utility.Test;

public class SQLContainsTest : TestContext
{
    public SQLContainsTest()
    {
    }
    
    [Fact]
    public void SQLShouldCreateWhenClicked()
    {
        string field = "FIELD";
        string input = "a" + System.Environment.NewLine + "b" + System.Environment.NewLine + "c";
        string output = string.Empty;
        
        var cut = RenderComponent<SQLContains>(parameters => parameters
            .Add(p => p.Field, field)
            .Add(p => p.Input, input)
            .Add(p => p.Output, output)
        );
        
        cut.FindAll("button")[3].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);
        
        SQLContains sqlContains = cut.Instance;
        Assert.Equal(sqlContains.Field, field);
        Assert.Equal(sqlContains.Input, input);
        Assert.Equal(sqlContains.Output, "CONTAINS (FIELD, a) OR CONTAINS (FIELD, b) OR CONTAINS (FIELD, c)");
    }
    
    [Fact]
    public void SQLShouldCreateWithWildcardWhenClicked()
    {
        string field = "FIELD";
        string input = "a" + System.Environment.NewLine + "b" + System.Environment.NewLine + "c";
        string output = string.Empty;
        
        var cut = RenderComponent<SQLContains>(parameters => parameters
            .Add(p => p.Field, field)
            .Add(p => p.Input, input)
            .Add(p => p.Output, output)
        );
        
        cut.FindAll("input")[1].Change(true);  //chkIncludeWildcard
        cut.FindAll("button")[3].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);
        
        SQLContains sqlContains = cut.Instance;
        Assert.Equal(sqlContains.Field, field);
        Assert.Equal(sqlContains.Input, input);
        Assert.Equal(sqlContains.Output, "CONTAINS (FIELD, *a*) OR CONTAINS (FIELD, *b*) OR CONTAINS (FIELD, *c*)");
    }
}