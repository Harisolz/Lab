
using BTH5.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTH5.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly SchoolContext _context;

        public MajorViewComponent(SchoolContext context)
        {
            _context = context;
        }

        // ==========================================
        // HIỂN THỊ DANH SÁCH CHUYÊN NGÀNH
        // ==========================================
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // 1. Lấy danh sách chuyên ngành từ SQL Server
            var majors = await _context.Majors
                .AsNoTracking()
                .OrderBy(m => m.MajorName)
                .ToListAsync();

            // 2. Lấy MajorID từ URL
            int? selectedMajorId = null;

            string? majorIdValue =
                HttpContext.Request.Query["majorId"].ToString();

            if (int.TryParse(majorIdValue, out int id))
            {
                selectedMajorId = id;
            }

            // 3. Lưu chuyên ngành đã chọn
            ViewBag.SelectedMajorId = selectedMajorId;

            // 4. Truyền dữ liệu sang RenderMajor.cshtml
            return View("RenderMajor", majors);
        }
    }
}
