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
    //[EnableCors("chr")]
    [Route("api/Dog")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DogApi.BLL.DogBll bll = new DogApi.BLL.DogBll();
        // GET: api/Dog
        [HttpGet]
        public IEnumerable<DogModel> Get(string userName)
        {
            return bll.GetModelList("userName = '" + userName + "'");
        }

        // GET: api/Dog/5
        [HttpGet("{id}", Name = "GetDog")]
        public DogModel Get(int id)
        {
            return bll.GetModel(id);
        }

        // POST: api/Dog
        [HttpPost]
        public bool Post([FromBody] DogModel value)
        {
            return bll.Add(value);
        }

        // PUT: api/Dog/5
        [HttpPut]
        public bool Put([FromBody] DogModel value)
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
