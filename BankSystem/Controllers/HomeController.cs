using System.Diagnostics;
using BankSystem.Data;
using BankSystem.Data.Identity;
using BankSystem.Data.TABLES;
using Microsoft.AspNetCore.Mvc;
using BankSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
        RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _logger = logger;
        _context = context;
        _roleManager = roleManager;
    }
    
    [Authorize(Roles = "Support")]
    [HttpGet]
    public async Task<IActionResult> DeleteClient()
    {
        var allUsers = await _userManager.Users.ToListAsync();


        var clientUsers = new List<ApplicationUser>();
        foreach (var user in allUsers)
        {
            if (await _userManager.IsInRoleAsync(user, "Client"))
            {
                clientUsers.Add(user);
            }
        }
        return View(clientUsers);
    }

    [Authorize(Roles = "Support")]
    [HttpPost]
    public async Task<IActionResult> DeleteClient(string userId)
    {
        var client = await _userManager.FindByIdAsync(userId);
        
        await _userManager.DeleteAsync(client);
        TempData["SuccessMessage"] = "Client successfully deleted.";
        return RedirectToAction("DeleteClient");
    }

    [Authorize(Roles = "Support")]
    [HttpGet]
    public async Task<IActionResult> CreateCard()
    {
        var allUsers = await _userManager.Users.ToListAsync();


        var clientUsers = new List<ApplicationUser>();
        foreach (var user in allUsers)
        {
            if (await _userManager.IsInRoleAsync(user, "Client"))
            {
                clientUsers.Add(user);
            }
        }

        ViewBag.ClientUsers = clientUsers;
        return View();
    }
    
    [Authorize(Roles = "Support")]
    [HttpPost]
    public async Task<IActionResult> CreateCard(string userId)
    {
        var client = await _userManager.FindByIdAsync(userId);


        var card = new Card
        {
            CardId = Guid.NewGuid(),
            CardNumber = new Random().Next(10000000, 99999999).ToString(),
            Pin = new Random().Next(1000, 9999).ToString(),
            AccountId = client.Id,
        };


        _context.Cards.Add(card);
        await _context.SaveChangesAsync();


        TempData["SuccessMessage"] = $"Card successfully created and assigned to {client.Name} {client.Surname}.";
        return RedirectToAction("CreateCard");
    }

    [Authorize(Roles = "Support")]
    [HttpGet]
    public async Task<IActionResult> ViewClients()
    {
        var allUsers = await _userManager.Users.ToListAsync();


        var clientsWithBalances = new List<ApplicationUser>();

        foreach (var user in allUsers)
        {
            if (await _userManager.IsInRoleAsync(user, "Client"))
            {
                var client = new ApplicationUser()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Balance = 0
                };
                clientsWithBalances.Add(client);
            }
        }

        return View(clientsWithBalances);
    }

    [Authorize(Roles = "Client")]
    public async Task<IActionResult> AccountBalance()
    {
        var clientId = _userManager.GetUserId(User);
        var client = await _context.Users.FindAsync(clientId);
        
        ViewBag.Balance = client.Balance;
        return View();
    }
    
    [Authorize(Roles = "Client")]
    public async Task<IActionResult> TransactionHistory()
    {
        var clientId = _userManager.GetUserId(User);
        var transactions = await _context.Transactions
            .Where(t => t.AccountId == clientId)
            .OrderByDescending(t => t.Date)
            .ToListAsync();

        return View(transactions);
    }

    [Authorize(Roles = "Client")]
    [HttpPost]
    public async Task<IActionResult> CreatePayment(string accountNumber, string bankCode, int amount, string variableSymbol)
    {
        
        var userId = _userManager.GetUserId(User);

        var newTransaction = new Transaction
        {
            AccountId = userId,
            AccountNumber = accountNumber,
            BankCode = bankCode,
            Amount = amount,
            VariableSymbol = variableSymbol,
            Date = DateTime.UtcNow
        };

        _context.Transactions.Add(newTransaction);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Payment order created successfully.";
        return RedirectToAction("TransactionHistory");
    }

    [Authorize(Roles = "Client")] 
    public IActionResult NewPayment()
    {
        return View(); 
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