using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoCoreAppWithDocker.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAppSettings _appSettings;

        public ValuesController(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = new List<string>(){
                "Value1",
                "Value2",
                _appSettings.EnvKey
            };

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
