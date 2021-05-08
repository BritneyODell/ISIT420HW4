using System.Linq;
using System.Web.Http;

namespace ISIT420HW4.Controllers
{
    public class StoresController : ApiController
    {
        NodeOrders500Entities storesModel = new NodeOrders500Entities();

        [HttpGet]
        public IHttpActionResult GetAllStoreCities()
        {
            var allCities = from store in storesModel.StoreTables
                            select new { store.City };

            return Ok(allCities.ToList());
        }
    }
}