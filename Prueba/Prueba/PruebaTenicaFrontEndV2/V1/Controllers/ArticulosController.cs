using Microsoft.AspNetCore.Mvc;

namespace PruebaTenicaFrontEndV2.V1.Controllers
{
    public class ArticulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
