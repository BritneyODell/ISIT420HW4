using System;
using System.Linq;
using System.Web.Http;

namespace ISIT420HW4.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetEmpTotal(string employeeName)
        {
            NodeOrders500Entities ordersModel = new NodeOrders500Entities();

            try
            {
                var nameSplit = employeeName.Split(' ');

                var firstName = nameSplit[0];
                var lastName = nameSplit[1];

                var soldTotal = (from employee in ordersModel.SalesPersonTables
                                 from order in ordersModel.Orders
                                 where employee.FirstName == firstName
                                 && employee.LastName == lastName
                                 && order.salesPersonID == employee.salesPersonID
                                 select order.pricePaid).Sum();

                return Ok(soldTotal);
            }
            catch (Exception)
            {
                return Ok(0);
            }
        }

        [HttpGet]
        public IHttpActionResult GetCityTotal(string storeCity)
        {
            NodeOrders500Entities ordersModel = new NodeOrders500Entities();

            try
            {
                var soldTotal = (from store in ordersModel.StoreTables
                                 from order in ordersModel.Orders
                                 where store.City == storeCity
                                 && order.storeID == store.storeID
                                 select order.pricePaid).Sum();

                return Ok(soldTotal);
            }
            catch (Exception)
            {
                return Ok(0);
            }
        }
    }
}