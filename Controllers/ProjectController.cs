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
    // public static List<ProjectUserViewModel> registerUsers = new();
    public static List<ProjectUserViewModel> loginUsers = new();

    public IActionResult Index()
    {
        // ViewBag.RegisterUsers = registerUsers;
        ViewBag.LoginUsers = loginUsers;
        return View();
    }

    // ================= REGISTER =================

    public IActionResult Register()
    {
        // return View(new ProjectUserViewModel());
        return View();
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
        var user = (from u in _db.Projectusers 
        select new ProjectUserViewModel 
        { Id = u.Id, 
        Name = u.Name, 
        Lastname = u.Lastname, 
        Email = u.Email, 
        Password = u.Password, 
        PhoneNumber = u.PhoneNumber}
        ).ToList();
        return View(user);
    }
    public IActionResult AddUserList()
    {
        return View(new ProjectUserViewModel());
    }
    
    [HttpPost]
    public IActionResult AddUserList(ProjectUserViewModel data)
    {
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
    
    public IActionResult EditUser(int UID)
    {
        var user = (from u in _db.Projectusers where u.Id == UID select u).FirstOrDefault();
        if (user != null)
        {
            var model = new ProjectUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber
            };
            return View(model);
        }
        return RedirectToAction("UserList", "Project");
    }
    
    [HttpPost]
    public IActionResult EditUser(ProjectUserViewModel data)
    {
        var user = (from u in _db.Projectusers where u.Id == data.Id select u).FirstOrDefault();
        if (user != null)
        {
            user.Name = data.Name;
            user.Lastname = data.Lastname;
            user.Password = data.Password;
            user.Email = data.Email;
            user.PhoneNumber = data.PhoneNumber;
            _db.Update(user);
            _db.SaveChanges();
        }
        return RedirectToAction("UserList", "Project");
    }
    
    public IActionResult DeleteUser(int UID)
    {
        var user = (from u in _db.Projectusers where u.Id == UID select u).FirstOrDefault();
        if (user != null)
        {
            _db.RemoveRange(user);
            _db.SaveChanges();
        }
        return RedirectToAction("UserList", "Project");
    }
}
