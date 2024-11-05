using Curricularizacao.Data;
using Curricularizacao.Models;
using Microsoft.EntityFrameworkCore;

namespace Curricularizacao.Models
{
    public class DataRepository
    {
        private readonly CurricularizacaoContext _context;

        public DataRepository(CurricularizacaoContext context)
        {
            _context = context;
        }

        // Propriedade para acesso a alunos
        public IQueryable<Aluno> Alunos => _context.Alunos;

        // Propriedade para acesso a professores
        public IQueryable<Professor> Professores => _context.Professores;

        // Propriedade para acesso a atividades
        public IQueryable<Atividade> Atividades => _context.Atividades;

        // Propriedade para acesso a matrículas, incluindo alunos e atividades
        public IQueryable<Matricula> Matriculas => _context.Matriculas
            .Include(m => m.Aluno)      // Inclui informações do aluno
            .Include(m => m.Atividade);  // Inclui informações da atividade

        // Método para adicionar um aluno
        public void AddAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        // Método para atualizar um aluno
        public void UpdateAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        // Método para remover um aluno
        public void RemoveAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        // Método para adicionar um professor
        public void AddProfessor(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        // Método para atualizar um professor
        public void UpdateProfessor(Professor professor)
        {
            _context.Professores.Update(professor);
            _context.SaveChanges();
        }

        // Método para remover um professor
        public void RemoveProfessor(Professor professor)
        {
            _context.Professores.Remove(professor);
            _context.SaveChanges();
        }

        // Método para adicionar uma atividade
        public void AddAtividade(Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            _context.SaveChanges();
        }

        // Método para atualizar uma atividade
        public void UpdateAtividade(Atividade atividade)
        {
            _context.Atividades.Update(atividade);
            _context.SaveChanges();
        }

        // Método para remover uma atividade
        public void RemoveAtividade(Atividade atividade)
        {
            _context.Atividades.Remove(atividade);
            _context.SaveChanges();
        }

        // Método para adicionar uma matrícula
        public void AddMatricula(Matricula matricula)
        {
            _context.Matriculas.Add(matricula);
            _context.SaveChanges();
        }

        // Método para atualizar uma matrícula
        public void UpdateMatricula(Matricula matricula)
        {
            _context.Matriculas.Update(matricula);
            _context.SaveChanges();
        }

        // Método para remover uma matrícula
        public void RemoveMatricula(Matricula matricula)
        {
            _context.Matriculas.Remove(matricula);
            _context.SaveChanges();
        }
    }
}
