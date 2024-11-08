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
            ViewBag.Alunos = _dataRepository.Alunos.ToList();
            ViewBag.Atividades = _dataRepository.Atividades.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.AddMatricula(matricula);
                return RedirectToAction("Index");
            }
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
