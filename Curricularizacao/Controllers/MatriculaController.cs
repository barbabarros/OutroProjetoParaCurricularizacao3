using Microsoft.AspNetCore.Mvc;
using Curricularizacao.Models;
using Curricularizacao;

namespace Curricularizacao.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly DataRepository _dataRepository;

        public MatriculaController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            var matriculas = _dataRepository.Matriculas.ToList();
            return View(matriculas);
        }

        public IActionResult Create()
        {
            var alunos = _dataRepository.Alunos.ToList();
            var atividades = _dataRepository.Atividades.ToList();

            ViewBag.Alunos = alunos;
            ViewBag.Atividades = atividades;

            ViewBag.MatriculasPorAtividade = atividades.ToDictionary(
                a => a.Id,
                a => _dataRepository.Matriculas.Count(m => m.AtividadeId == a.Id)
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                var aluno = _dataRepository.Alunos.FirstOrDefault(a => a.Id == matricula.AlunoId);
                if (aluno == null || !aluno.Ativo)
                {
                    ModelState.AddModelError("", "Não é possível matricular um aluno inativo.");
                }
                else
                {
                    var alunoMatriculado = _dataRepository.Matriculas
                        .Any(m => m.AlunoId == matricula.AlunoId && m.AtividadeId == matricula.AtividadeId);

                    if (alunoMatriculado)
                    {
                        ModelState.AddModelError("", "Este aluno já está matriculado nesta atividade.");
                    }
                    else
                    {
                        var atividade = _dataRepository.Atividades
                            .FirstOrDefault(a => a.Id == matricula.AtividadeId);

                        if (atividade != null && atividade.MaxParticipantes > 0)
                        {
                            var numeroMatriculados = _dataRepository.Matriculas
                                .Count(m => m.AtividadeId == matricula.AtividadeId);

                            if (numeroMatriculados >= atividade.MaxParticipantes)
                            {
                                ModelState.AddModelError("", "Não há vagas disponíveis para essa atividade.");
                            }
                            else
                            {
                                _dataRepository.AddMatricula(matricula);
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
            }

            ViewBag.Alunos = _dataRepository.Alunos.ToList();
            ViewBag.Atividades = _dataRepository.Atividades.ToList();
            return View(matricula);
        }

        public IActionResult Edit(int id)
        {
            var matricula = _dataRepository.Matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula == null) return NotFound();

            ViewBag.Alunos = _dataRepository.Alunos.ToList();
            ViewBag.Atividades = _dataRepository.Atividades.ToList();
            return View(matricula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateMatricula(matricula);
                return RedirectToAction("Index");
            }
            return View(matricula);
        }

        public IActionResult Delete(int id)
        {
            var matricula = _dataRepository.Matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula == null) return NotFound();
            return View(matricula);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var matricula = _dataRepository.Matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula != null)
            {
                _dataRepository.RemoveMatricula(matricula);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var matricula = _dataRepository.Matriculas.FirstOrDefault(m => m.Id == id);
            if (matricula == null) return NotFound();
            return View(matricula);
        }
    }
}
