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
        return View();
    }

    // ================= REGISTER =================

    public IActionResult Register()
    {
        ViewBag.Users = registerUsers;
        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Register(ProjectUserViewModel model)
    {
        registerUsers.Add(model);

        ViewBag.Users = registerUsers;
        return View(new ProjectUserViewModel());
    }

    // ================= LOGIN =================

    public IActionResult Login()
    {
        ViewBag.Users = loginUsers;
        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Login(ProjectUserViewModel model)
    {
        loginUsers.Add(model);

        ViewBag.Users = loginUsers;
        return View(new ProjectUserViewModel());
    }
}
