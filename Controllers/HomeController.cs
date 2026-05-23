using System.Web.Mvc;

namespace ProyectoTema3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Si no está logueado, redirigir a login
            if (Session["UsuarioLogueado"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
