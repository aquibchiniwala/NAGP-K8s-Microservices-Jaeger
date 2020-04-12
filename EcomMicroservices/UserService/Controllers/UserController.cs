using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserService.DBContext;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            UserDBContext users = new UserDBContext("server=mysql.default.svc.cluster.local;port=3306;database=mysql;uid=root;password=password");
            string output = "";
            foreach (User user in users.GetUsers())
            {
                output+= JsonConvert.SerializeObject(user)+"\n";
            }

            return output;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            UserDBContext users = new UserDBContext("server=mysql.default.svc.cluster.local;port=3306;database=mysql;uid=root;password=password");
            string output = "";
            foreach (User user in users.GetUsers())
            {
                output += JsonConvert.SerializeObject(user) + "\n";
            }

            return output;
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
