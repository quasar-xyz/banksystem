using System.Diagnostics;
using BankSystem.Data;
using BankSystem.Data.TABLES;
using Microsoft.AspNetCore.Mvc;
using BankSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _roleManager = roleManager;
    }

  
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}