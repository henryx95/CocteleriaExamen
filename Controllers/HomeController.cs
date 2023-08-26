using CoctelesExamen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CoctelesExamen.Servicios;
using Newtonsoft.Json;
using System.Web;

namespace CoctelesExamen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CoctelAbstract margarita = new CoctelGratis();
            string mensaje = margarita.Preparar();
            ViewBag.Mensaje = mensaje;
            return View();
        }
        public IActionResult Favoritos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Cocteles(string textbuscar)
        {
            CoctelAPI nuevo = new CoctelAPI();
            Task<List<Coctel>> taskList = nuevo.ListaPorCoctel(textbuscar);
            List<Coctel> cocteles = await taskList;
            return View(cocteles);
        }
        [HttpPost]
        public async Task<JsonResult> ObtieneDetalle(string valor)
        {
            CoctelAPI nuevo = new CoctelAPI();
            Task<List<Coctel>> taskList = nuevo.ListaPorId(valor);
            List<Coctel> cocteles = await taskList;
            return Json(new { Foto = cocteles[0].strDrinkThumb.ToString(), Categoria = cocteles[0].strCategory.ToString() });
        }
    }
}