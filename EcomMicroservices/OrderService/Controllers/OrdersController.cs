using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OrderService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {

            List<Order> orders = new List<Order>() {
            new Order {
                orderId = 1,
                orderAmount = 250,
                orderDate = "14-Apr-2020"
            },
            new Order {
                orderId = 2,
                orderAmount = 450,
                orderDate = "15-Apr-2020"
            }
            };

            return JsonConvert.SerializeObject(orders);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {

            List<Order> orders = new List<Order>() {
            new Order {
                orderId = 1,
                orderAmount = 250,
                orderDate = "14-Apr-2020"
            },
            new Order {
                orderId = 2,
                orderAmount = 450,
                orderDate = "15-Apr-2020"
            }
            };

            return JsonConvert.SerializeObject(orders);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

public class Order
{
    public int orderId { get; set; }
    public int orderAmount { get; set; }
    public string orderDate { get; set; }
}