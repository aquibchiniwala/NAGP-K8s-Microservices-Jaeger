using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AggregatorService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            string stringResponse = "";
            string userUrl = "http://user-service.default.svc.cluster.local/user/1";
            string orderUrl = "http://order-service.default.svc.cluster.local/orders/1";


            HttpWebRequest userRequest = CreateRequest(HttpMethod.Get, userUrl);

            using (HttpWebResponse response = (HttpWebResponse)userRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        stringResponse = myStreamReader.ReadToEnd();
                    }
                }

                userRequest = null;
            }

            HttpWebRequest orderRequest = CreateRequest(HttpMethod.Get, orderUrl);

            using (HttpWebResponse response = (HttpWebResponse)orderRequest.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        stringResponse +=",\n"+ myStreamReader.ReadToEnd();
                    }
                }

                orderRequest = null;
            }

            return stringResponse;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            {
                string stringResponse = "";
                string userUrl = "http://user-service.default.svc.cluster.local/user/1";
                string orderUrl = "http://order-service.default.svc.cluster.local/orders/1";


                HttpWebRequest userRequest = CreateRequest(HttpMethod.Get, userUrl);

                using (HttpWebResponse response = (HttpWebResponse)userRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            stringResponse = myStreamReader.ReadToEnd();
                        }
                    }

                    userRequest = null;
                }

                HttpWebRequest orderRequest = CreateRequest(HttpMethod.Get, orderUrl);

                using (HttpWebResponse response = (HttpWebResponse)orderRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            stringResponse += ",\n" + myStreamReader.ReadToEnd();
                        }
                    }

                    orderRequest = null;
                }

                return stringResponse;
            }
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

        private HttpWebRequest CreateRequest(HttpMethod method, string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = method.ToString().ToUpper();

            return request;
        }
    }
}
