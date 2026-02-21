using Bunit;
using Xunit;

using Utility.Components.UrlEncode;

namespace Utility.Test
{
    public class UrlEncodeTest : BunitContext
    {
        public UrlEncodeTest()
        {
        }

        [Fact]
        public void UrlShouldEncodeWhenClicked()
        {
            // Arrange: render the Counter.razor component
            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            var cut = Render<UrlEncode>();
            cut.Find("button").Click();

            string markup = "<input id=\"urlDecode\" name=\"urlDecode\" class=\"form-control\" placeholder=\"http%3A%2F%2Fwww.alexhedley.com\" value=\"http%3A%2F%2Fwww.alexhedley.com\" >";

            // Assert: first find the <p> element, then verify its content
            cut.FindAll("input")[1].MarkupMatches(markup);
        }

        [Fact]
        public void UrlShouldDecodeWhenClicked()
        {
            // Arrange: render the Counter.razor component
            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            var cut = Render<UrlEncode>();
            cut.FindAll("button")[1].Click();

            //string markup = "<input id=\"urlEncode\" name=\"urlEncode\" class=\"form-control\" value=\"http://www.alexhedley.com\" >";
            string markup = "<input id=\"urlEncode\" name=\"urlEncode\" class=\"form-control\" placeholder=\"http://www.alexhedley.com\" value=\"\" >";

            // Assert: first find the <p> element, then verify its content
            cut.FindAll("input")[0].MarkupMatches(markup);
        }
    }
}
