using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogApi.Model;
using Microsoft.AspNetCore.Cors;

namespace DogApi.Controllers
{ 
    [Route("api/Friend")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly DogApi.BLL.FriendBll bll = new DogApi.BLL.FriendBll();
        // GET: api/Friend
        [HttpGet]
        public IEnumerable<FriendModel> Get(string userName)
        {
            return bll.GetModelList("userName = '" + userName + "'");
        }

        // GET: api/Friend/5
        [HttpGet("{id}", Name = "GetFriend")]
        public FriendModel Get(int id)
        {
            return bll.GetModel(id);
        }

        // POST: api/Friend
        [HttpPost]
        public bool Post([FromBody] FriendModel value)
        {
            return bll.Add(value);
        }

        // PUT: api/Friend/5
        [HttpPut]
        public bool Put([FromBody] FriendModel value)
        {
            return bll.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return bll.Delete(id);
        }
    }
}
