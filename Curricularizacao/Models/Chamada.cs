using System;
using System.ComponentModel.DataAnnotations;

namespace Curricularizacao.Models;

public class Chamada
{
    [Key]
    public int Id { get; set; }

    public Turma? Turma { get; set; }
}
