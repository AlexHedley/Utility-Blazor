using Bunit;
using Xunit;

using Utility.Components.UrlSplitter;

namespace Utility.Test
{
    public class UrlSplitterTest : TestContext
    {
        private readonly string _defaultUrl;
        
        public UrlSplitterTest()
        {
            _defaultUrl = "https://www.alexhedley.com/path?query=this&param=that";
        }

        [Fact]
        public void UrlShouldContainAUrl()
        {
            var cut = RenderComponent<UrlSplitter>(parameters => parameters
                .Add(p => p.Path, _defaultUrl)
            );

            var path = "https://www.alexhedley.com/path?query=this&param=that";
            string markup = $"<input type=\"text\" id=\"path\" name=\"path\" class=\"form-control\" value=\"{path}\" >";
            cut.FindAll("input")[0].MarkupMatches(markup);
        }
        
        [Fact]
        public void UrlShouldSplitWhenClicked()
        {
            var cut = RenderComponent<UrlSplitter>(parameters => parameters
                .Add(p => p.Path, _defaultUrl)
            );
            cut.Find("button").Click();
            
            var url = "https://www.alexhedley.com/path?query=this&param=that";
            string markup = $"<input type=\"text\" id=\"path\" name=\"path\" class=\"form-control\" value=\"{url}\" >";
            cut.FindAll("input")[0].MarkupMatches(markup);

            var hostname = "www.alexhedley.com";
            markup = $"<input type=\"text\" class=\"form-control\" placeholder=\"hostname\" aria-label=\"hostname\" id=\"hostname\" name=\"hostname\" disabled=\"\" value=\"{hostname}\">";
            cut.FindAll("input")[1].MarkupMatches(markup);
            
            var path = "/path";
            markup = $"<input type=\"text\" class=\"form-control\" placeholder=\"pathname\" aria-label=\"pathname\" id=\"pathname\" name=\"pathname\" disabled=\"\" value=\"{path}\">";
            cut.FindAll("input")[2].MarkupMatches(markup);
        }
    }
}