using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    public static List<ProjectUserViewModel> loggedInUsers = new List<ProjectUserViewModel>();

    public IActionResult Index()
    {
        ViewData["Title"] = "Project Page";
        ViewData["Layout"] = "_ProjectLayout";

        ViewBag.CartItemCount = 2;
        ViewBag.LoggedInUsers = loggedInUsers;

        return View();
    }

    public IActionResult Login()
    {
        ViewData["Title"] = "Login Page";
        ViewData["Layout"] = "_ProjectLayout";

        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Login(ProjectUserViewModel model)
    {
        loggedInUsers.Add(new ProjectUserViewModel
        {
            Name = model.Name ?? "Unknown",
            Email = model.Email,
            Password = model.Password
        });

        return RedirectToAction("Index");
    }

    public IActionResult Register()
    {
        ViewData["Title"] = "Register Page";
        ViewData["Layout"] = "_ProjectLayout";

        return View(new ProjectUserViewModel());
    }

    [HttpPost]
    public IActionResult Register(ProjectUserViewModel model)
    {
        loggedInUsers.Add(new ProjectUserViewModel
        {
            Name = model.Name,
            Lastname = model.Lastname,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        });

        return RedirectToAction("Index");
    }
}