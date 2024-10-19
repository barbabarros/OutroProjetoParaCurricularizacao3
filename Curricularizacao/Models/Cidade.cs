using System;
using System.ComponentModel.DataAnnotations;

namespace Curricularizacao.Models;

public class Cidade
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    public Uf? Uf { get; set; }
}
