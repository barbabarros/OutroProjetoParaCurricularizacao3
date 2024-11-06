using Microsoft.AspNetCore.Mvc;
using Curricularizacao.Models;
using Curricularizacao;

namespace Curricularizacao.Controllers
{
    public class AlunoController : Controller
    {
        private readonly DataRepository _dataRepository;

        public AlunoController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            var alunos = _dataRepository.Alunos.ToList();
            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.AddAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public IActionResult Edit(int id)
        {
            var aluno = _dataRepository.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public IActionResult Delete(int id)
        {
            var aluno = _dataRepository.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound();
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno = _dataRepository.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                _dataRepository.RemoveAluno(aluno);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var aluno = _dataRepository.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return NotFound();
            return View(aluno);
}
}
}