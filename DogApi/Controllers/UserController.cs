using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApi.Models;
using DogApi.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<UserClass> Get()
        {
            string lst = dbUserTool.getuserList() ;
            return UserClass.getListUser(lst.Substring(0, lst.Length - 1).Replace("\t", " ").Replace("\r", "").Split('\n')); 
        }

        // GET: api/User/5
        [HttpGet("{userName}", Name = "Get")]
        public UserClass Get(string userName)
        {
            return UserClass.getOneUser(dbUserTool.getOneUser(userName));
        }

        // POST: api/User
        [HttpPost]
        public string Post([FromBody] UserClass value)
        {
            return dbUserTool.addOneUser(value);
        }

        // PUT: api/User/5
        [HttpPut]
        public string Put([FromBody] UserClass value)
        {
            return dbUserTool.updateOneUser(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{userName}")]
        public string Delete(string userName)
        {
            return dbUserTool.deleteOneUser(userName);
        }
    }
}
