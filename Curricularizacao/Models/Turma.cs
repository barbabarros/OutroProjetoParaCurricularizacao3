using System;
using System.ComponentModel.DataAnnotations;
using Curricularizacao.Controllers;

namespace Curricularizacao.Models;

public class Turma
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    public Periodo? periodo { get; set; }

    public Atividade? Atividade { get; set; }
}
