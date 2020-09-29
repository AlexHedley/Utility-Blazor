using Bunit;
using System;
using Xunit;

using Utility_Blazor.Pages;

namespace Utility_Blazor.Test
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public void CounterShouldIncrementWhenClicked()
        {
            // Arrange: render the Counter.razor component
            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            var cut = RenderComponent<Counter>();
            cut.Find("button").Click();

            // Assert: first find the <p> element, then verify its content
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}
