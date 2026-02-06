using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSI402.Models;
using CSI402.ViewModels;
using System.Data.Common;

namespace CSI402.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Test1()
    {
        return View();
    }
        public IActionResult Test2()
    {
        return View();
    }

    public IActionResult Assessment()
    {
        String name = "Chonlakorn Bualuang",
        classroom = "05-0904",
        educationYear = "3",
        favLanguage = "HTML,CSS,JavaScript";

        ViewBag.Name = name;
        ViewBag.Classroom = classroom;
        ViewBag.EducationYear = educationYear;
        ViewBag.FavLanguage = favLanguage;

        int W1 = 4, W2 = 9, W3 = 4, W4 = 2, W5 = 4,
            W6 = 4, W7 = 4, W8 = 4, W9 = 4, W10 = 9;

        int totalScore = W1 + W2 + W3 + W4 + W5 + W6 + W7 + W8 + W9 + W10;
        ViewBag.TotalScore = totalScore;

        if (totalScore >= 80)
        {
            ViewBag.Grade = "A";
        }
        else if (totalScore >= 76)
        {
            ViewBag.Grade = "B+";
        }
        else if (totalScore >= 70)
        {
            ViewBag.Grade = "B";
        }
        else if (totalScore >= 66)
        {
            ViewBag.Grade = "C+";
        }
        else if (totalScore >= 60)
        {
            ViewBag.Grade = "C";
        }
        else if (totalScore >= 56)
        {
            ViewBag.Grade = "D+";
        }
        else if (totalScore >= 50)
        {
            ViewBag.Grade = "D";
        }
        else
        {
            ViewBag.Grade = "F";
        }

        if (ViewBag.Grade == "F")
        {
            // if grade is F, show works score that are less than 5 and show string the work number
            List<string> lowScores = new List<string>();

            if (W1 < 5) lowScores.Add("W1 = " + W1);
            if (W2 < 5) lowScores.Add("W2 = " + W2);
            if (W3 < 5) lowScores.Add("W3 = " + W3);
            if (W4 < 5) lowScores.Add("W4 = " + W4);
            if (W5 < 5) lowScores.Add("W5 = " + W5);
            if (W6 < 5) lowScores.Add("W6 = " + W6);
            if (W7 < 5) lowScores.Add("W7 = " + W7);
            if (W8 < 5) lowScores.Add("W8 = " + W8);
            if (W9 < 5) lowScores.Add("W9 = " + W9);
            if (W10 < 5) lowScores.Add("W10 = " + W10);
            ViewData["LowScores"] = lowScores;
        }
        else
        {
            ViewData["LowScores"] = null;
        }
        return View();
    }

    public IActionResult Lab5()
    {
        // var user = new LabUserViewModel();
        // user.UserId = "65075070";
        // user.Name = "Kunakorn";
        // user.Lastname = "Khamchaoren";
        // user.Age = 24;
        // user.Address = "123/45 Moo 6, T. Bangna, A. Bangna, Bangkok 10260";
        // user.Weight = 82M;
        // user.Height = 175.5M;
        // var user = new List<LabUserViewModel>{
        //     new LabUserViewModel{
        //         UserId = "65075070",
        //         Name = "Kunakorn",
        //         Lastname = "Khamchaoren",
        //         Age = 24,
        //         Address = "5678 Bangkok 10260",
        //         Weight = 82M,
        //         Height = 175.5M,
        //     },
        //     new LabUserViewModel{
        //         UserId = "2222",
        //         Name = "B",
        //         Lastname = "BB",
        //         Age = 24,
        //         Address = "bb22",
        //         Weight = 82M,
        //         Height = 175.5M,
        //     },
        //     new LabUserViewModel{
        //         UserId = "333",
        //         Name = "c",
        //         Lastname = "cc",
        //         Age = 24,
        //         Address = "cc33",
        //         Weight = 82M,
        //         Height = 175.5M,
        //     }
            
        // };
        // return View(user);
        return View();
    }
    [HttpPost]
    public IActionResult Lab5(LabUserViewModel data)
    {
        string a,b,c;
        a= data.UserId;
        b= data.Name;
        c= data.Lastname;

        @ViewBag.UserId = a;
        @ViewBag.Name = b;
        @ViewBag.Lastname = c;

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
