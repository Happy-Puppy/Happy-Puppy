using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogApi.Controllers
{
    [Route("api/Activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly DogApi.BLL.ActivityBll bll = new DogApi.BLL.ActivityBll();
        // GET: api/Activity
        [HttpGet]
        public IEnumerable<ActivityModel> Get(string userName)
        {
            return bll.GetModelList("username = '"+userName+"'");
        }

        // GET: api/Activity/5
        [HttpGet("{id}", Name = "GetActivity")]
        public ActivityModel Get(int id)
        {
            return bll.GetModel(id);
        }

        // POST: api/Activity
        [HttpPost]
        public bool Post([FromBody] ActivityModel value)
        {
            return bll.Add(value);
        }

        // PUT: api/Activity/5
        [HttpPut]
        public bool Put([FromBody] ActivityModel value)
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
