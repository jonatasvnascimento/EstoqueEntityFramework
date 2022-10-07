using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueEntityFramework.Model
{
    class Produto
    {
        [Key]
        public int Idproduto { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public double Preco { get; set; }
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
