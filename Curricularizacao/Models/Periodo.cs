using System;
using System.ComponentModel.DataAnnotations;

namespace Curricularizacao.Controllers;

public class Periodo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Descricao { get; set; } = string.Empty;
}
