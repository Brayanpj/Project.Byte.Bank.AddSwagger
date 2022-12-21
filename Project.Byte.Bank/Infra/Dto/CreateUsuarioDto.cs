using System.ComponentModel.DataAnnotations;

namespace Project.Byte.Bank;
public class CreateUsuarioDto
{

    [Required(ErrorMessage = "O campo NomeCompleto é obrigatório")]
    [StringLength(30, ErrorMessage = "O campo NomeCompleto não pode exceder 30 caracteres")]
    public string? NomeCompleto { get; set; }
    public int Idade { get; set; }
    public string? Genêro { get; set; }
    public string Cpf { get; set; }
    public DateTime DataDeNascimento { get; set; }

}

