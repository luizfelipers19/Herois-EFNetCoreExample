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
    public class HeroiController : ControllerBase
    {

        private readonly IEFCoreRepository _repo;
        //private readonly HeroiContexto _context;

        public HeroiController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<HeroiController>
        [HttpGet]
        public async Task <IActionResult>  Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois(false);
                return Ok(herois);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }


            
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id, false);
                return Ok(heroi);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/<HeroiController>
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
            //[FromBody] string value
        {

            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Added Hero");
                }
               
                
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não salvou");

        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            return Ok();


        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            var heroi = await _repo.GetHeroiById(id);
                    if (heroi != null)
                    {
                        _repo.Delete(heroi);
            
                        if(await _repo.SaveChangeAsync())
                         {
                             return Ok("Herói deletado");
                        }

                    }

            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Heroi Não Encontrado");

            

        }
    }
}
