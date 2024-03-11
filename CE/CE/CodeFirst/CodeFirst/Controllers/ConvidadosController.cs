using Microsoft.AspNetCore.Mvc;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace CodeFirst.Controllers
{
    public class ConvidadosController : Controller
    {
        private static IList<Convidado> convidados = new List<Convidado>();


        public ActionResult Index()
        {
            return View(convidados.OrderBy(cat => cat.Id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            convidados.Add(convidado);
            convidado.Id = convidados.Select(cat => cat.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(convidados.Where(cat => cat.Id == id).First());
        }

        [HttpPost]
        public IActionResult Edit(Convidado categoria)
        {
            convidados.Remove(convidados.Where(cat => cat.Id == categoria.Id).First());
            convidados.Add(categoria);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            return View(convidados.Where(cat => cat.Id == id).First());
        }

        public IActionResult Delete(int id)
        {
            return View(convidados.Where(cat => cat.Id == id).First());
        }

        [HttpPost]
        public IActionResult Delete(Convidado categoria)
        {
            convidados.Remove(convidados.Where(cat => cat.Id == categoria.Id).First());

            return RedirectToAction("Index");

        }

        public IActionResult ListarConvidados()
        {
            var convidadosConfirmados = convidados.Where(c => c.comparecimento).ToList();
            return View(convidadosConfirmados);
        }
    

    }
}
