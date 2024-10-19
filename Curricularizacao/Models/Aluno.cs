using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.SignalR;

namespace Curricularizacao.Models;

public class Aluno
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Endereco { get; set; } = string.Empty;

    public Cidade? cidade { get; set; }

    [Required]
    [Range(011,099)]
    public int Ddd { get; set; }

    [Required]
    [Range(011,099)]
    public int Telefone { get; set; }

    [StringLength(100)]
    public string NomePai { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string NomeMae { get; set; } = string.Empty;


    [StringLength(50)]
    public string DocumentoRGAluno { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string DocumentoCpfAluno { get; set; } = string.Empty;


    [StringLength(50)]
    public string DocumentoRGMae { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string DocumentoCpfMae { get; set; } = string.Empty;


    [StringLength(50)]
    public string DocumentoRGPai { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string DocumentoCpfPai { get; set; } = string.Empty;

    [Required]
    public DateTime DataNascimento { get; set; }

    public bool EstaMatriculado { get; set; }

    public bool EstaOk { get; set; }
}
