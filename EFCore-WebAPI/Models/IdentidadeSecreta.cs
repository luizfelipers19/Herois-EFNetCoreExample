using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_WebAPI.Models
{
    public class IdentidadeSecreta
    {
        public int Id { get; set; }

        public string NomeReal { get; set; }

        public int HeroiId { get; set; }

        //relacionamento um pra um
        public Heroi Heroi { get; set; }

    }
}
