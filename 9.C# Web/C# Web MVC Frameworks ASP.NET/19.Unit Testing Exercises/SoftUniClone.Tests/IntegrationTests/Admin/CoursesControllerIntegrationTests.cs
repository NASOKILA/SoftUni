using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftUniClone.Web;
using System.Threading.Tasks;

namespace SoftUniClone.Tests.IntegrationTests.Admin
{
    [TestClass]
    public class CoursesControllerIntegrationTests
    {
        [TestMethod]
        public async Task CoursesCOntroller_WithInvalidModel_ShoudReturnValidationMessage()
        {
            var factory = new WebApplicationFactory<Startup>();

            var client = factory.CreateDefaultClient();

            var result = await client.GetAsync("/admin/courses/create");

            string resultContent = await result.Content.ReadAsStringAsync();
        }
    }
}
