using System;

using Bunit;
using Utility.Components.GuidGenerator;
using Xunit;

using Utility.Pages;

namespace Utility.Test
{
    public class GuidGeneratorTest : BunitContext
    {
        public GuidGeneratorTest()
        {
        }

        [Fact]
        public void ZeroGuidShouldExist()
        {
            var cut = Render<GuidGenerator>();
            string markup = "<input type=\"text\" id=\"guidZero\" name=\"guidZero\" class=\"form-control\" placeholder=\"00000000-0000-0000-0000-000000000000\" readonly=\"\" value=\"00000000-0000-0000-0000-000000000000\" >";
            cut.FindAll("input")[0].MarkupMatches(markup);
        }

        // [Fact]
        // public void ZeroGuidShouldCopyToClipboard()
        // {
        //     var cut = Render<GuidGenerator>();
        //     cut.Find("button").Click();
        // }
        
        [Fact]
        public void ZeroGuidShouldRemoveDashesWhenClicked()
        {
            var cut = Render<GuidGenerator>();
            cut.FindAll("input")[1].Change(true);  //chkRemoveDashesZero
            string markup = "<input type=\"text\" id=\"guidZero\" name=\"guidZero\" class=\"form-control\" placeholder=\"00000000-0000-0000-0000-000000000000\" readonly=\"\" value=\"00000000000000000000000000000000\" >";
            cut.FindAll("input")[0].MarkupMatches(markup); //guidZero
        }

        [Fact]
        public void ZeroGuidShouldAddBracesWhenClicked()
        {
            var cut = Render<GuidGenerator>();
            cut.FindAll("input")[2].Change(true);  //chkAddBracesZero
            string markup = "<input type=\"text\" id=\"guidZero\" name=\"guidZero\" class=\"form-control\" placeholder=\"00000000-0000-0000-0000-000000000000\" readonly=\"\" value=\"{00000000-0000-0000-0000-000000000000}\">";
            cut.FindAll("input")[0].MarkupMatches(markup); //guidZero
        }
        
        // [Fact]
        // public void NewGuidShouldExist()
        // {
        //     var cut = Render<GuidGenerator>();
        //     string markup = "<input type=\"text\" id=\"newGuid\" name=\"newGuid\" class=\"form-control\" placeholder=\"00000000-0000-0000-0000-000000000000\" readonly=\"\">";
        //     cut.FindAll("input")[3].MarkupMatches(markup); //newGuid
        // }
        
        // [Fact]
        // public void NewGuidShouldRemoveDashesWhenClicked()
        // {
        //     var cut = Render<GuidGenerator>();
        //     cut.FindAll("input")[4].Change(true); //chkRemoveDashes
        //     string markup = "<input type=\"text\" id=\"newGuid\" name=\"newGuid\" class=\"form-control\" placeholder=\"00000000-0000-0000-0000-000000000000\" readonly=\"\">";
        //     cut.FindAll("input")[3].MarkupMatches(markup); // newGuid
        // }
        
        // [Fact]
        // public void NewGuidShouldCopyToClipboard()
        // {
        //     var cut = Render<GuidGenerator>();
        //     cut.Find("button").Click();
        // }

        [Fact]
        public void MultipleDefaultIsFive()
        {
            var cut = Render<GuidGenerator>();
            string markup = "<input type=\"number\" class=\"form-control\" id=\"guidCount\" name=\"guidCount\" value=\"5\">";
            cut.FindAll("input")[7].MarkupMatches(markup); // guidCount
        }
        
        // [Fact]
        // public void MultipleClickShouldGenerateFive()
        // {
        //     var cut = Render<GuidGenerator>();
        //     cut.FindAll("button")[3].Click();
        //     string markup = "<textarea id=\"guids\" class=\"form-control\" value=\"\"  ></textarea>";
        //     cut.FindAll("textarea")[0].MarkupMatches(markup); // guids
        // }
        
        // [Fact]
        // public void MulitpleGuidShouldCopyToClipboard()
        // {
        //     var cut = Render<GuidGenerator>();
        //     cut.FindAll("button")[4].Click();
        // }
        
        [Fact]
        public void MultipleDeleteShouldBeEmpty()
        {
            var cut = Render<GuidGenerator>();
            cut.FindAll("button")[5].Click();
            string markup = "<textarea id=\"guids\" class=\"form-control\" rows=\"5\" value=\"\"></textarea>";
            cut.FindAll("textarea")[0].MarkupMatches(markup); // guids
        }
        
        // cut.FindAll("input")[6].Change(true); //chkRemoveDashesMultiple
    }
}