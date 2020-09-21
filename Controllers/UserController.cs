using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApi.Model; 
using DogApi.Tool;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogApi.Controllers
{
    
    [Route("api/User")]
    [ApiController]
    //[EnableCors("chr")]
    public class UserController : ControllerBase
    {
        private readonly DogApi.BLL.UsersBll bll = new DogApi.BLL.UsersBll();
        // GET: api/User
        
        [HttpGet]
        public IEnumerable<UsersModel> Get()
        {
            return bll.GetModelList(""); 
        }

        // GET: api/User/5
        [HttpGet("{userName}", Name = "GetUser")]
        public UsersModel Get(string userName)
        {
            return bll.GetModel(userName); 
        }

        // POST: api/User
        [HttpPost]
        public bool Post([FromBody] UsersModel value)
        {
            return bll.Add(value);
        }

        // PUT: api/User/5
        [HttpPut]
        public bool Put([FromBody] UsersModel value)
        {
            return bll.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{userName}")]
        public bool Delete(string userName)
        {
            return bll.Delete(userName);
        }
    }
}
