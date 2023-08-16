using NUnit.Framework;
using TestNinja.Mocking;
using Moq;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_When_Called_DeleteEmployeeFromDb() 
        {
            var service = new Mock<IEmployeeService>();
            var controller = new EmployeeController(service.Object); 
            
            controller.DeleteEmployee(1);

            service.Verify(s => s.DeleteEmployee(1));
        }
    }
}
