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
    [Route("api/DogType")]
    [ApiController]
    public class DogTypeController : ControllerBase
    {
        private readonly DogApi.BLL.DogTypeBll bll = new DogApi.BLL.DogTypeBll();
        // GET: api/DogType
        [HttpGet]
        public IEnumerable<DogTypeModel> Get()
        {
            return bll.GetModelList("");
        }

        // GET: api/DogType/5
        [HttpGet("{id}", Name = "GetDogType")]
        public DogTypeModel Get(int id)
        {
            return bll.GetModel(id);
        }

        // POST: api/DogType
        [HttpPost]
        public bool Post([FromBody] DogTypeModel value)
        {
            return bll.Add(value);
        }

        // PUT: api/DogType/5
        [HttpPut]
        public bool Put([FromBody] DogTypeModel value)
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
