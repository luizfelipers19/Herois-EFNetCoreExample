using EFCore.Domain;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase

    {

        public readonly HeroiContexto _context ;

       public ValuesController(HeroiContexto contexto)
       {
        _context = contexto;
       }




        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero};
            //using(var contexto = new HeroiContexto())
            //
            //{
             _context.Herois.Add(heroi);
             //contexto.Add(heroi);
             _context.SaveChanges();
            //}
               
           
            return Ok();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
