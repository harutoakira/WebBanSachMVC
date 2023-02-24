using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Data;
using QuanLyThuVien.Method;
using QuanLyThuVien.Models;
using System.Diagnostics;

namespace QuanLyThuVien.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly BookDBContext _context;
        public HomeController(ILogger<HomeController> logger, BookDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            CategorySingleton.Instance.Init(_context);
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