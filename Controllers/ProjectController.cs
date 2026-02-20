using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    // list แยกกัน
    public static List<ProjectUserViewModel> registerUsers = new();
    public static List<ProjectUserViewModel> loginUsers = new();

    public IActionResult Index()
    {
        ViewBag.RegisterUsers = registerUsers;
        ViewBag.LoginUsers = loginUsers;
        return View();
    }

    // ================= REGISTER =================

    public IActionResult Register()
    {
        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Register(ProjectUserViewModel model)
    {
        registerUsers.Add(model);

        return View(new ProjectUserViewModel());
    }

    // ================= LOGIN =================

    public IActionResult Login()
    {
        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Login(ProjectUserViewModel model)
    {
        loginUsers.Add(model);

        return View(new ProjectUserViewModel());
    }
}
