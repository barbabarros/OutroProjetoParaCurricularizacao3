using Microsoft.AspNetCore.Mvc;
using Curricularizacao.Models;
using Curricularizacao;

namespace Curricularizacao.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly DataRepository _dataRepository;

        public ProfessorController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            var professores = _dataRepository.Professores.ToList();
            return View(professores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.AddProfessor(professor);
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        public IActionResult Edit(int id)
        {
            var professor = _dataRepository.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return NotFound();
            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateProfessor(professor);
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        public IActionResult Delete(int id)
        {
            var professor = _dataRepository.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return NotFound();
            return View(professor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var professor = _dataRepository.Professores.FirstOrDefault(p => p.Id == id);
            if (professor != null)
            {
                _dataRepository.RemoveProfessor(professor);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var professor = _dataRepository.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return NotFound();
            return View(professor);
        }
    }
}
