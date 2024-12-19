using System.ComponentModel.DataAnnotations;

namespace CategoriasMVC.Models
{
    public class CategoriaViwerModel
    {
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "O nome da categoria e obrigatorio")]

        public string Nome { get; set; }
        [Required]
        [Display(Name = "Imagem")]
        public string? ImagemUrl { get; set; }
    }
}
