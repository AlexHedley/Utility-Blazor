using System;

using Bunit;
using Xunit;

using Utility_Blazor.Pages;

namespace Utility_Blazor.Test
{
    public class UrlEncodeTest : TestContext
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
            var cut = RenderComponent<UrlEncode>();
            cut.Find("button").Click();

            string markup = "<input id=\"urlDecode\" name=\"urlDecode\" class=\"form-control\" value=\"http%3A%2F%2Fwww.alexhedley.com\" >";

            // Assert: first find the <p> element, then verify its content
            cut.FindAll("input")[1].MarkupMatches(markup);
        }

        [Fact]
        public void UrlShouldDeccodeWhenClicked()
        {
            // Arrange: render the Counter.razor component
            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            var cut = RenderComponent<UrlEncode>();
            cut.FindAll("button")[1].Click();

            //string markup = "<input id=\"urlEncode\" name=\"urlEncode\" class=\"form-control\" value=\"http://www.alexhedley.com\" >";
            string markup = "<input id=\"urlEncode\" name=\"urlEncode\" class=\"form-control\" value=\"\" >";

            // Assert: first find the <p> element, then verify its content
            cut.FindAll("input")[0].MarkupMatches(markup);
        }
    }
}
