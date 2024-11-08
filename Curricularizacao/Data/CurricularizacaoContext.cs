using Microsoft.EntityFrameworkCore;
using Curricularizacao.Models;

namespace Curricularizacao.Data
{
    public class CurricularizacaoContext(DbContextOptions<CurricularizacaoContext> options) : DbContext(options)
    {
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Professor>? Professores { get; set; }
        public DbSet<Atividade>? Atividades { get; set; }
        public DbSet<Matricula>? Matriculas { get; set; }
    }
}
