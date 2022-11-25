using System.ComponentModel.DataAnnotations;

namespace Pro.Infra.Dtos
{
    public class UpdateUsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Id do usuário é obrigatório")]
        [StringLength(50, ErrorMessage = "O Id do usuário não pode exceder 2 caracteres")]
        public string? NomeCompleto { get; set; }
        [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
        [Range(1, 30, ErrorMessage = "O campo Nome Completo não pode exceder 30 caracteres")]
        public int Idade { get; set; }
        public string? Gênero { get; set; }
        public int Cpf { get; set; }
        [Required(ErrorMessage = "O campo Cpf é obrigatório")]
        [Range(1, 30, ErrorMessage = "O campo Cpf não pode exceder 30 caracteres")]
        public long DataDeNascimento { get; set; }

    }
}
