using Microsoft.AspNetCore.Mvc;

namespace NewsGator.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
