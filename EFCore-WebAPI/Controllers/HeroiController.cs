﻿using EFCore.Domain;
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
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContexto _context;

        public HeroiController(HeroiContexto contexto)
        {
            _context = contexto;
        }

        // GET: api/<HeroiController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }


            
        }

        // GET api/<HeroiController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<HeroiController>
        [HttpPost]
        public ActionResult Post()
            //[FromBody] string value
        {

            try
            {
                var heroi = new Heroi
                {
                    Nome = "Homem de Ferro",
                    Armas = new List<Arma>
                    {
                        new Arma {Nome = "Mac 3"},
                        new Arma {Nome = "Mac 5"}
                    }

                };
                _context.Herois.Add(heroi);
                _context.SaveChanges();


                return Ok("Bazinga");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

        }

        // PUT api/<HeroiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HeroiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
