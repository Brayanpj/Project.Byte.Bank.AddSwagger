using System.ComponentModel.DataAnnotations;

namespace Project.Byte.Bank;

public class UsuarioKey
{
    [Key]
    [Required(ErrorMessage = "O Id do usuário é obrigatório")]
    [Range(0, 50, ErrorMessage = "O Id do usuário não pode exceder 2 caracteres")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
    [StringLength(30, ErrorMessage = "O Nome Completo não pode exceder 30 caracteres")]
    public string? NomeCompleto { get; set; }
    public int Idade { get; set; }
    public string? Genêro { get; set; }
    public int Cpf { get; set; }
    public long DataDeNascimento { get; set; }
}
