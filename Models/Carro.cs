using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProjetoGaragemIdentity.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }
        public string Descricao { get; set; }
    }
}
