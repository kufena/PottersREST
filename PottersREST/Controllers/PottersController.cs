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
            return (new PottersDelegate(backEnd, new URLHelper(HttpContext))).GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return (new PottersDelegate(backEnd, new URLHelper(HttpContext))).GetById(id);
        }

        [HttpGet("{id}/pots")] //, Name = GetPotsByPotter)]
        public string[] GetPotsByPotter(int id)
        {

            return (new PotsDelegate(backEnd, new URLHelper(HttpContext))).getPotsByPotterId(id);
        }

        // GET: api/Pots/5
        [HttpGet("{id}/pots/{potid}", Name = "GetPotForPotter")]
        public string GetPotForPotter(int id, int potid)
        {

            return (new PotsDelegate(backEnd, new URLHelper(HttpContext))).getPotById(potid);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            int? newid = (new PottersDelegate(backEnd, new URLHelper(HttpContext))).CreatePotter(value);
            HttpContext.Response.Headers.Add(
                new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Location",
                new Microsoft.Extensions.Primitives.StringValues("https://localhost:5001/potters/potters/" + newid)));
        }

        // POST: api/Pots
        [HttpPost("{id}/pots")]
        public void PostPot(int id, [FromBody] string value)
        {
            int? newid = (new PotsDelegate(backEnd, new URLHelper(HttpContext))).createPot(value);
            if (newid != null)
            {
                var poturl = (new URLHelper(HttpContext)).buildPotURL((int)newid);
                HttpContext.Response.Headers.Add(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("Location",
                    new Microsoft.Extensions.Primitives.StringValues(poturl)));
            }
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