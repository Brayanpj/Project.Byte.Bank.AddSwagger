using System.ComponentModel.DataAnnotations;

namespace Pro.Infra.Dtos
{
    public class CreateUsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Id do usuário é obrigatório")]
        [StringLength(2, ErrorMessage = "O Id do usuário não pode exceder 2 caracteres")]
        public string? NomeCompleto { get; set; }
        [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
        [Range(1, 30, ErrorMessage = "O Nome Completo não pode exceder 30 caracteres")]
        public int Idade { get; set; }
        public string? Genêro { get; set; }
        public int Cpf { get; set; }
        public long DataDeNascimento { get; set; }
    }
}
