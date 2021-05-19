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
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            //linq method
            //a listagem abaixo também funciona
           //  var listHeroi =  _context.Herois.Where(h => h.Nome.Contains(nome)).ToList();


            //deixando essa listagem ativa, pois se assemelha mais a sintaxe do SQL
            //linq query sintax
            var listHeroi = (from heroi in _context.Herois where heroi.Nome.Contains(nome) select heroi).ToList();
            return Ok(listHeroi);
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

        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            _context.AddRange(
                new Heroi { Nome = "Capitão América" },
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viúva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Arqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
            );
            _context.SaveChanges();

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
        // DELETE api/values/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {

            var heroi = _context.Herois
                                .Where(x => x.Id == id)
                                .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();

        }
    }
}
