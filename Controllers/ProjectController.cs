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

    public IActionResult UserList()
    {
        var users = new List<ProjectUserViewModel>
        {
            new ProjectUserViewModel { Name = "John", Lastname = "Doe", Email = "john.doe@example.com", Password = "pass1234", PhoneNumber = 612345001 },
            new ProjectUserViewModel { Name = "Jane", Lastname = "Smith", Email = "jane.smith@example.com", Password = "pwd5678", PhoneNumber = 612345002 },
            new ProjectUserViewModel { Name = "Alice", Lastname = "Brown", Email = "alice.brown@example.com", Password = "alice2026", PhoneNumber = 612345003 },
            new ProjectUserViewModel { Name = "Bob", Lastname = "Johnson", Email = "bob.johnson@example.com", Password = "bobsecure", PhoneNumber = 612345004 },
            new ProjectUserViewModel { Name = "Charlie", Lastname = "Lee", Email = "charlie.lee@example.com", Password = "charliepw", PhoneNumber = 612345005 }
        };

        return View(users);
    }
}
