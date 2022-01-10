using Bunit;
using reactr.Blazor.Unit.Tests.Helpers;
using System.Linq;
using Xunit;

namespace bUnitBugHunt.Tests
{
    public class UnitTest1 : TestContext
    {
        
        public UnitTest1()
        {
            BlazoriseConfig.AddBootstrapProviders(Services);

            JSInterop.Mode = JSRuntimeMode.Loose;
            BlazoriseConfig.JSInterop.AddUtilities(JSInterop);
        }  

        [Fact]
        public void Test1()
        {
            var cut = RenderComponent<Client.Pages.Index>();

            // Filter the entries to get 1
            cut.Find("[aria-label='Search Name']").Input("First");
            cut.WaitForState(() => cut.FindAll("[aria-label='RemoveButton']").Count == 1);

            // Click the remove button
            cut.Find("[aria-label='RemoveButton']").Click();
            cut.WaitForState(() => cut.FindAll("[aria-label='RemoveButton']").Count == 0);
        }
    }
}