using Microsoft.AspNetCore.Mvc;
using PhamSonHai_223630687.Models;

namespace PhamSonHai_223630687.Components
{
    public class LoaihangMenuViewComponent : ViewComponent
    {
        private readonly QLTaiSanContext _db;
        public LoaihangMenuViewComponent(QLTaiSanContext db) { _db = db; }
        public IViewComponentResult Invoke()
        {
            return View(_db.LoaiHangs.ToList());
        }
    }
}