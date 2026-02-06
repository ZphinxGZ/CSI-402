using Microsoft.AspNetCore.Mvc;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Home Page";
        ViewData["Layout"] = "_ProjectLayout";

        ViewBag.CartItemCount = 2;

        return View();
    }
}