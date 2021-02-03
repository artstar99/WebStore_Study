using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebStore_Study.Interfaces.Contracts;


namespace WebStore_Study.ServiceHosting.Controllers
{
    [Route(ApiRoutes.Version1.Values)]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private static readonly List<string> values = Enumerable
            .Range(1, 10)
            .Select(i => $"Value{i:00}")
            .ToList();
        // GET: api/<ValuesController>
        
        [HttpGet(ApiRoutes.Version1.Values)]
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= values.Count)
                return NotFound();

            return values[id];
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0)
                return BadRequest();
            if (id >= values.Count)
                return NotFound();
            values[id] = value;
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= values.Count)
                return NotFound();

            values.RemoveAt(id);
            return Ok();

        }
    }
}
