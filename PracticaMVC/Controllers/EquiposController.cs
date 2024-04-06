using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class EquiposController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;

        public EquiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }


        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);

            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            return View();
        }
    }
}
