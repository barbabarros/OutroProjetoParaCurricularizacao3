using System;
using System.ComponentModel.DataAnnotations;

namespace Curricularizacao.Models;

public class Monitor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Endereco { get; set; } = string.Empty;

    [Required]
    [Range(011,099)]
    public int Ddd { get; set; }

    [Required]
    [Range(011,099)]
    public int Telefone { get; set; }

    [StringLength(50)]
    public string DocumentoRGMonitor { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string DocumentoCpfMonitor { get; set; } = string.Empty;

    [Required]
    public DateTime DataNascimento { get; set; }

    public bool EstaAtivo { get; set; }
}
