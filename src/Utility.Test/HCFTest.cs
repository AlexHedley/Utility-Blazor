using Bunit;
using Xunit;

using Utility.Components.HCF;

namespace Utility.Test;

public class HCFTest : TestContext
{
    public HCFTest()
    {}

    // [Fact]
    public void HiddenCharacterFinderShouldFindHiddenCharacters()
    {
        var cut = RenderComponent<HCF>();
        // string markup = "";
        // cut.FindAll("input")[0].MarkupMatches(markup);
    }
}