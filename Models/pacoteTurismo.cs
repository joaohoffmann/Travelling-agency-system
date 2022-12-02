using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividade02.Models
{
    public class pacoteTurismo
    {
        public int id {get;set;}
        public string nome {get;set;}
        public string origem {get;set;}
        public string destino {get;set;}
        public string atrativos {get;set;}
        public DateTime saida {get;set;}
        public DateTime retorno {get;set;}

    }
}