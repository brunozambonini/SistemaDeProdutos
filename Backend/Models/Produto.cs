using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Backend.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite um nome válido.")]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite um preço válido.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Preco { get; set; }
    }
}
