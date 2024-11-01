using System.ComponentModel.DataAnnotations;

public class ProdutoRequest
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo 'Nome' deve ter entre 1 e 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo 'Preço' é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O campo 'Preço' deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "O campo 'Stock' é obrigatório")]
    [Range(0, int.MaxValue, ErrorMessage = "O campo 'Stock' não pode ser negativo")]
    public int Stock { get; set; }

    [StringLength(500, ErrorMessage = "O campo 'Descrição' deve ter no máximo 500 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo 'Categoria' é obrigatório")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo 'Categoria' deve ter entre 1 e 100 caracteres")]
    public string Categoria { get; set; }
}
