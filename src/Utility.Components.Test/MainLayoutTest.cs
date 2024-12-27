using System.Threading.Tasks;

using Bunit;
using Xunit;

using Utility.Shared;

namespace Utility.Test
{
    public class MainLayoutTest : TestContext
    {
        // [Fact]
        public async Task SavesNameToLocalStorage()
        {
            // Arrange
            const string inputName = "John Smith";
            var localStorage = this.AddBlazoredLocalStorage();
            var cut = RenderComponent<MainLayout>();

            // Act
            cut.Find("#Name").Change(inputName);
            cut.Find("#NameButton").Click();

            // Assert
            var name = await localStorage.GetItemAsync<string>("name");

            Assert.Equal(inputName, name);
        }
    }
}
