using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {

        private readonly HeroiContexto _context;

        public BatalhaController(HeroiContexto contexto)
        {
            _context = contexto;
        }

        // GET: api/<BatalhaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }


           
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BatalhaController>
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {
                _context.Batalhas.Add(model);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }


        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {

            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(b => b.Id == id) != null)
                {
                    _context.Batalhas.Update(model);
                    _context.SaveChanges();
                    return Ok("Bazinga");
                }

                return Ok("Não encontrado!");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
