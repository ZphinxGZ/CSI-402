using Microsoft.AspNetCore.Mvc;
using CSI402.ViewModels;
using CSI402.Models.Db;

namespace CSI402.Controllers;

public class ProjectController : Controller
{
    private readonly Csi402dbContext _db;
    public ProjectController(Csi402dbContext db)
    {
        _db = db;
    }
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
    public IActionResult Register(ProjectUserViewModel data)
    {
        // registerUsers.Add(model);
        var u = new Projectuser();
        u.Id = data.Id;
        u.Name = data.Name;
        u.Lastname = data.Lastname;
        u.Password = data.Password;
        u.Email = data.Email;
        u.PhoneNumber = data.PhoneNumber;
        _db.Add(u);
        _db.SaveChanges();

        return RedirectToAction("UserList", "Project");
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
        return View();
    }
    public IActionResult AddUserList()
    {
        return View();
    }
}
