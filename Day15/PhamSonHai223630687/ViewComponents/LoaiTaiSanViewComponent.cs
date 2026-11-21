using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhamSonHai223630687.Models;
namespace PhamSonHai223630687.ViewComponents
{
    public class LoaiTaiSanViewComponent : ViewComponent
    {
        private readonly QLTaiSanContext _context;
        public LoaiTaiSanViewComponent(QLTaiSanContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ds = await _context.LoaiTaiSans
                .AsNoTracking()
                .ToListAsync();
       
            return View(ds);
        }
    }
}
