using System;
using System.ComponentModel.DataAnnotations;

namespace Curricularizacao.Models;

public class Atividade
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    [Range(1, 100)]
    public int QuantidadeMaximaAlunos {  get; set; }

}
