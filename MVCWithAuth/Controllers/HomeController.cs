using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCWithAuth.Data;
using MVCWithAuth.DomainObjects;
using MVCWithAuth.Models;
using NETCore.MailKit.Core;

namespace MVCWithAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService, ApplicationDbContext context)
        {
            _logger = logger;
            _emailService = emailService;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var tour = new Tour() { Name = "Test Tour" };
            await _context.Set<Tour>().AddAsync(tour);
            await _context.SaveChangesAsync();
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
}
