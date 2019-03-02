using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PottersREST.Delegates;
using PottersBackEnd;

namespace PottersREST.Controllers
{
    [Route("pots/[controller]")]
    [ApiController]
    public class PotsController : ControllerBase
    {

        IPotsAndPotters backEnd;

        public PotsController(IPotsAndPotters ipap)
        {
            backEnd = ipap;
        }

        // GET: api/Pots
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { };
        }

        // GET: api/Pots/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return (new PotsDelegate(backEnd)).getPotById(id);
        }

        // POST: api/Pots
        [HttpPost]
        public void Post([FromBody] string value)
        {
            int? newid = (new PotsDelegate(backEnd)).createPot(value);
            HttpContext.Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Location",
                new Microsoft.Extensions.Primitives.StringValues("https://localhost:5001/pots/pots/" + newid)));
        }

        // PUT: api/Pots/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
