using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        public ActionResult ListBook()
        {
            ViewBag.Title = "ListBook Page";

            return View();
        }

        public ActionResult NewBook()
        {
            ViewBag.Title = "NewBook Page";

            return View();
        }
    }
}
