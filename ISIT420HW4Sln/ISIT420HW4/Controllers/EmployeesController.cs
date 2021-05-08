using System.Linq;
using System.Web.Http;

namespace ISIT420HW4.Controllers
{
    public class EmployeesController : ApiController
    {
        NodeOrders500Entities employeeModel = new NodeOrders500Entities();

        [HttpGet]
        public IHttpActionResult GetAllEmployeeNames()
        {
            var allEmployees = from employee in employeeModel.SalesPersonTables
                               select new { employee.FirstName, employee.LastName };

            return Ok(allEmployees.ToList());
        }
    }
}