using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProgrammationConformit.Models;
using TestProgrammationConformit.Repository;
using TestProgrammationConformit.Wrapper;

namespace TestProgrammationConformit
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private readonly IEvenementRepository evenementRepository;
        private readonly ICommentaireRepository commentaireRepository;

        public CommentaireController(IEvenementRepository evenementRepository, ICommentaireRepository commentaireRepository)  {
            this.evenementRepository = evenementRepository;
            this.commentaireRepository = commentaireRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(commentaireRepository.getAll());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Commentaire commentaire = commentaireRepository.getById(id);
            if (commentaire == null)
            {
                return NotFound();
            }
            return Ok(new Response<Commentaire>(commentaire));
        }

        // POST api/<controller>
        [HttpPost("{id}/evenement")]
        public IActionResult Post(int id, [FromBody] Commentaire commentaire)
        {
            Evenement evenement = evenementRepository.getById(id);
            if (evenement == null)
            {
                return NotFound();
            }
            if (commentaire == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            commentaire.EvenementId = id;
           // commentaire.Evenement = evenement;

            bool created = commentaireRepository.create(commentaire);
            if (!created)
                return StatusCode(500, ModelState);
            return Ok(new Response<Commentaire>(commentaire));

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Commentaire commentaire)
        {
            if (commentaire == null)
            {
                return BadRequest(ModelState);
            }
            if (id <= 0)
            {

                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            commentaire.id = id;

            bool result = commentaireRepository.update(commentaire);
            if (!result)
                return StatusCode(500, ModelState);

            return Ok(new Response<Commentaire>(commentaire));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            bool result = commentaireRepository.deleteById(id);
            if (!result)
                return StatusCode(500, ModelState);
            return Ok(id);
        }



    }
}
