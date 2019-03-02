using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PottersBackEnd;
using PottersREST.Delegates;

namespace PottersREST.Controllers
{
    [Route("potters/[controller]")]
    //[Route("potters")]
    [ApiController]
    public class PottersController : ControllerBase
    {
        
        IPotsAndPotters backEnd;

        public PottersController(IPotsAndPotters ipap)
        {
            backEnd = ipap;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return (new PottersDelegate(backEnd)).GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return (new PottersDelegate(backEnd)).GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            int? newid = (new PottersDelegate(backEnd)).CreatePotter(value);
            HttpContext.Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Location",
    new Microsoft.Extensions.Primitives.StringValues("https://localhost:5001/potters/potters/" + newid)));
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