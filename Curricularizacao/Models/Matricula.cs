using System;
using System.ComponentModel.DataAnnotations;


namespace Curricularizacao.Models;

public class Matricula
{
    [Key]
    public int Id { get; set; }

    public Aluno? Aluno { get; set; }
    public int AlunoId { get; set; }

    public Turma? Turma { get; set; }
    
}
