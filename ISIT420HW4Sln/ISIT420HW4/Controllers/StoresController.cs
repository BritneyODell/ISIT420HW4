using System;
using System.Collections.Generic;
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
            try
            {
                var allCities = from store in storesModel.StoreTables
                                select new { store.City };

                return Ok(allCities.ToList());
            }
            catch (Exception)
            {
                return Ok(0);
            }
        }

        [HttpGet]
        public IHttpActionResult GetMarkups()
        {
            try
            {
                var markups = from order in storesModel.Orders 
                              where order.pricePaid > 13
                              group new { order.storeID, order.pricePaid, order.StoreTable.City, order.StoreTable.State } by order.storeID into groups
                              orderby groups.Count() descending
                              select groups;

                List<SomeClass> aList = new List<SomeClass>();

                foreach (var item in markups)
                {
                    aList.Add(new SomeClass(item.Key, item.ToArray()[0].City, item.ToArray()[0].State, item.Count())); //"finding" the other properties of each item was difficult
                }

                return Ok(aList);
            }
            catch (Exception)
            {
                return Ok(0);
            }
        }

        class SomeClass
        {
            public SomeClass(int id1, string city1, string state1, int count1)
            {
                storeID = id1;
                city = city1;
                state = state1;
                count = count1;
            }

            public int storeID { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public int count { get; set; }
        }
    }
}