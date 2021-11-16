
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ProjetoGaragemIdentity.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public Cliente Cliente{ get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }
        public Funcionario Funcionario { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Funcionarios { get; set; }
        public Carro Carro { get; set; }
        [NotMapped]
        public virtual List<SelectListItem> Carros { get; set; }
        public string Descricao { get; set; }
    }
}
