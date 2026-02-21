using System.Threading.Tasks;

using Blazored.LocalStorage;
using Bunit;
using Xunit;

using Utility.Shared;

namespace Utility.Test
{
    //ILocalStorageService localStorage;

    public class MainLayoutTest : BunitContext
    {
        // [Fact]
        public async Task SavesNameToLocalStorage()
        {
            // Arrange
            const string inputName = "John Smith";
            //var localStorage = this.AddBlazoredLocalStorage();
            var cut = Render<MainLayout>();

            // Act
            cut.Find("#Name").Change(inputName);
            cut.Find("#NameButton").Click();

            // Assert
            //var name = await localStorage.GetItemAsync<string>("name");

            //Assert.Equal(inputName, name);
        }
    }
}
