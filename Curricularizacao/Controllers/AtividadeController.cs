using Microsoft.AspNetCore.Mvc;
using Curricularizacao.Models;
using Curricularizacao;

namespace Curricularizacao.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly DataRepository _dataRepository;

        public AtividadeController(DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            var atividades = _dataRepository.Atividades.ToList();
            return View(atividades);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.AddAtividade(atividade);
                return RedirectToAction("Index");
            }
            return View(atividade);
        }

        public IActionResult Edit(int id)
        {
            var atividade = _dataRepository.Atividades.FirstOrDefault(a => a.Id == id);
            if (atividade == null) return NotFound();
            return View(atividade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateAtividade(atividade);
                return RedirectToAction("Index");
            }
            return View(atividade);
        }

        public IActionResult Delete(int id)
        {
            var atividade = _dataRepository.Atividades.FirstOrDefault(a => a.Id == id);
            if (atividade == null) return NotFound();
            return View(atividade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var atividade = _dataRepository.Atividades.FirstOrDefault(a => a.Id == id);
            if (atividade != null)
            {
                _dataRepository.RemoveAtividade(atividade);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var atividade = _dataRepository.Atividades.FirstOrDefault(a => a.Id == id);
            if (atividade == null) return NotFound();
            return View(atividade);
 }
}
}