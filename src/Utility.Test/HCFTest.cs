using Bunit;
using Xunit;

using Utility.Components.HCF;

namespace Utility.Test;

public class HCFTest : BunitContext
{
    public HCFTest()
    {}

    // [Fact]
    public void HiddenCharacterFinderShouldFindHiddenCharacters()
    {
        var cut = Render<HCF>();
        // string markup = "";
        // cut.FindAll("input")[0].MarkupMatches(markup);
    }
}