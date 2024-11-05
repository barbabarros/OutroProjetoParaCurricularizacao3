namespace Curricularizacao.Models;

    public class Matricula
    {
        public int Id { get; set; }
        public int AtividadeId { get; set; }
        public Atividade? Atividade { get; set; }
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        public DateTime DataMatricula { get; set; } = DateTime.Now;
    }

