using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProgrammationConformit
{
    [Route("api/[controller]")]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementRepository evenement;
        public EvenementController(IEvenementRepository evenement ) => this.evenement = evenement;

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(evenement.getAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Evenement ev =  evenement.getById(id);
            if (ev == null)
            {
                return NotFound();
            }
            return Ok(ev);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Evenement ev)
        {
            if (ev == null) {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            bool created =  evenement.create(ev);
            if (!created)
                return StatusCode(500, ModelState);

            return Ok(ev);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Evenement ev)
        {
            if (ev == null)
            {
                return BadRequest(ModelState);
            }
            if (id <= 0) {

                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ev.id = id;

            bool result = evenement.update(ev);
            if (!result)
                return StatusCode(500, ModelState);

            return Ok(ev);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            bool result = evenement.deleteById(id);
            if (!result)
                return StatusCode(500, ModelState);
            return Ok(id);
        }
    }
}
