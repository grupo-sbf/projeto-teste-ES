
using System.ComponentModel.DataAnnotations;

namespace teste.Models
{
    public class Endereco
    {
        [Key]
        public int id { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }

        public int? pessoaId { get; set; }
        public virtual Pessoa pessoa { get; set; }

    }
}