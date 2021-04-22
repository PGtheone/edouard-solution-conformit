using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Payload;
using TestProgrammationConformit.Repository;
using TestProgrammationConformit.Wrapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProgrammationConformit
{
    [Route("api/[controller]")]
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementRepository evenementRepository;
        public EvenementController(IEvenementRepository evenementRepository) => this.evenementRepository = evenementRepository;

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationPayload filter)
        {
            var validFilter = new PaginationPayload(filter.PageNumber, filter.PageSize);
            return Ok(evenementRepository.getAll(validFilter));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Evenement evenement = evenementRepository.getById(id);
            if (evenement == null)
            {
                return NotFound();
            }
            return Ok(new Response<Evenement>(evenement));
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Evenement evenement)
        {
            if (evenement == null) {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            bool created = evenementRepository.create(evenement);
            if (!created)
                return StatusCode(500, ModelState);

            return Ok(new Response<Evenement>(evenement));

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Evenement evenement)
        {
            if (evenement == null)
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
            evenement.id = id;

            bool result = evenementRepository.update(evenement);
            if (!result)
                return StatusCode(500, ModelState);

            return Ok(new Response<Evenement>(evenement));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            bool result = evenementRepository.deleteById(id);
            if (!result)
                return StatusCode(500, ModelState);
            return Ok(id);
        }
    }
}
