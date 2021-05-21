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
        private readonly IEFCoreRepository _repo;

        // private readonly HeroiContexto _context;

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
            // _context = contexto;
        }

        // GET: api/<BatalhaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repo.GetAllBatalhas(false);
                return Ok(batalhas);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }


           
        }

        // GET api/<BatalhaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id, false);

                return Ok(batalha);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }



        }

        // POST api/<BatalhaController>
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                //_context.SaveChanges();

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Add");
                }
                
               // return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não salvou");
        }

        // PUT api/<BatalhaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            return Ok();
           
        }

        // DELETE api/<BatalhaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);

                if (batalha != null)
                {
                    _repo.Delete(batalha);


                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Batalha Deletada");
                    }

                    
                }

               // return Ok("não encontrado");

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Batalha Não encontrada");

        }
    }
}
