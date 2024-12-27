using Bunit;
using Xunit;

using Utility.Components.JWTDebugger;

namespace Utility.Test;

public class JWTDebuggerTest : TestContext
{
    public JWTDebuggerTest() {}

    [Fact]
    public void JwtTokenShouldDecode()
    {
        string input = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        string expectedHeader = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";
        string expectedPayload = "{\"sub\":\"1234567890\",\"name\":\"John Doe\",\"iat\":1516239022}";
        string exptectedSignature = "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        
        var cut = RenderComponent<JWTDebugger>(parameters => parameters
            .Add(p => p.Input, input)
        );
        
        cut.FindAll("button")[0].Click();
        // string markup = "";
        // cut.FindAll("input")[1].MarkupMatches(markup);
    
        JWTDebugger jwtDebugger = cut.Instance;
        Assert.Equal(jwtDebugger.Input, input);
        Assert.Equal(jwtDebugger.Header, expectedHeader);
        Assert.Equal(jwtDebugger.Payload, expectedPayload);
        Assert.Equal(jwtDebugger.Signature, exptectedSignature);
    }

}