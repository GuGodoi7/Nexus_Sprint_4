using System.ComponentModel.DataAnnotations;

public class UsuarioRequest
{
    [Required(ErrorMessage = "O campo 'Nome do Usuário' é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo 'Nome do Usuário' deve ter entre 3 e 100 caracteres")]
    public string NomeUsuario { get; set; }

    [Required(ErrorMessage = "O campo 'CPF' é obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo 'CPF' deve ter 11 caracteres")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O campo 'Email' é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo 'Email' não é um endereço de email válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo 'Telefone' é obrigatório")]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "O campo 'Telefone' deve ter entre 10 e 15 caracteres")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo 'Password' é obrigatório")]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "O campo 'Password' deve ter entre 5 e 15 caracteres")]
    public string Password { get; set; }
}
