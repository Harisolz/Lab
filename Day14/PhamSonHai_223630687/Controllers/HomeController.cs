using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PhamSonHai_223630687.Models;
using System.Diagnostics;

namespace PhamSonHai_223630687.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _context;
        public HomeController(QLNhaSachContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.TheLoai = await _context.TheLoais
                .AsNoTracking()
                .ToListAsync();
            ViewBag.DanhSachSach = await _context.Saches
                .Where(s => s.Gia != null && s.Gia >= 100)
                .AsNoTracking()
                .ToListAsync();
            return View();
        }
        