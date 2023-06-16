using Bunit;
using Xunit;

using Utility.Components.JWTDebugger;

namespace Utility.Test;

public class JWTDebuggerTest : TestContext
{
    public JWTDebuggerTest() {}

    // [Fact]
    // public void StringShouldDecode()
    // {
    //     string input = "QWxleEhlZGxleQ==";
    //     string output = string.Empty;
    //     string expectedOutput = "AlexHedley";
    //     
    //     var cut = RenderComponent<JWTDebugger>(parameters => parameters
    //         .Add(p => p.Input, input)
    //         .Add(p => p.Output, output)
    //     );
    //     
    //     cut.FindAll("button")[0].Click();
    //     // string markup = "";
    //     // cut.FindAll("input")[1].MarkupMatches(markup);
    //
    //     JWTDebugger jwtDebugger = cut.Instance;
    //     Assert.Equal(base64.Input, input);
    //     Assert.Equal(base64.Output, expectedOutput);
    // }

}