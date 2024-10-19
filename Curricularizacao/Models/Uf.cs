using System;
using System.ComponentModel.DataAnnotations;

namespace Curricularizacao.Models;

public class Uf
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
}
