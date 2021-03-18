using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace teste.Models
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}