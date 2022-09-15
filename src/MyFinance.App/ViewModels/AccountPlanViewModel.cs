using System.ComponentModel.DataAnnotations;

namespace MyFinance.App.ViewModels
{
    public class AccountPlanViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1, ErrorMessage = "O campo {0} precisa ter apenas 1 caracter", MinimumLength = 1)]
        public string? Type { get; set; }
    }
}
