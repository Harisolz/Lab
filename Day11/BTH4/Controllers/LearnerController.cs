
using BTH4.Data;
using BTH4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BTH4.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext _context;

        public LearnerController(SchoolContext context)
        {
            _context = context;
        }

        // ==========================================
        // 1. READ - DANH SÁCH NGƯỜI HỌC
        // GET: /Learner
        // ==========================================
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var learners = await _context.Learners
                .Include(l => l.Major)
                .AsNoTracking()
                .ToListAsync();

            return View(learners);
        }

        // ==========================================
        // 2. CREATE - HIỂN THỊ FORM THÊM
        // GET: /Learner/Create
        // ==========================================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadMajors();

            return View(new Learner
            {
                EnrollmentDate = DateTime.Today
            });
        }

        // ==========================================
        // 3. CREATE - LƯU NGƯỜI HỌC MỚI
        // POST: /Learner/Create
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FirstMidName,LastName,EnrollmentDate,MajorID")]
            Learner learner)
        {
            ModelState.Remove(nameof(Learner.Major));

            if (!await _context.Majors
                .AnyAsync(m => m.MajorID == learner.MajorID))
            {
                ModelState.AddModelError(
                    nameof(Learner.MajorID),
                    "Vui lòng chọn ngành học hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                await LoadMajors(learner.MajorID);
                return View(learner);
            }

            _context.Learners.Add(learner);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Thêm người học thành công!";

            return RedirectToAction(nameof(Index));
        }

        // ==========================================
        // 4. EDIT - HIỂN THỊ FORM SỬA
        // GET: /Learner/Edit/1
        // ==========================================
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var learner = await _context.Learners
                .FindAsync(id.Value);

            if (learner == null)
                return NotFound();

            await LoadMajors(learner.MajorID);

            return View(learner);
        }

        // ==========================================
        // 5. EDIT - LƯU THÔNG TIN ĐÃ SỬA
        // POST: /Learner/Edit/1
        // ==========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("LearnerID,FirstMidName,LastName,EnrollmentDate,MajorID")]
            Learner learner)
        {
            if (id != learner.LearnerID)
                return NotFound();

            ModelState.Remove(nameof(Learner.Major));

            if (!await _context.Majors
                .AnyAsync(m => m.MajorID == learner.MajorID))
            {
                ModelState.AddModelError(
                    nameof(Learner.MajorID),
                    "Ngành học không hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                await LoadMajors(learner.MajorID);
                return View(learner);
            }

            var existingLearner = await _context.Learners
                .FindAsync(id);

            if (existingLearner == null)
                return NotFound();

            existingLearner.FirstMidName = learner.FirstMidName;
            existingLearner.LastName = learner.LastName;
            existingLearner.EnrollmentDate = learner.EnrollmentDate;
            existingLearner.MajorID = learner.MajorID;

            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Cập nhật người học thành công!";

            return RedirectToAction(nameof(Index));
        }

        // ==========================================
        // 6. DELETE - HIỂN THỊ XÁC NHẬN XÓA
        // GET: /Learner/Delete/1
        // ==========================================
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var learner = await _context.Learners
                .Include(l => l.Major)
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    l => l.LearnerID == id.Value);

            if (learner == null)
                return NotFound();

            return View(learner);
        }

        // ==========================================
        // 7. DELETE - XÁC NHẬN XÓA
        // POST: /Learner/Delete/1
        // ==========================================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await _context.Learners
                .FindAsync(id);

            if (learner == null)
                return NotFound();

            bool hasEnrollments = await _context.Enrollments
                .AnyAsync(e => e.LearnerID == id);

            if (hasEnrollments)
            {
                TempData["Error"] =
                    "Không thể xóa người học đã đăng ký học phần.";

                return RedirectToAction(nameof(Index));
            }

            _context.Learners.Remove(learner);
            await _context.SaveChangesAsync();

            TempData["Success"] =
                "Xóa người học thành công!";

            return RedirectToAction(nameof(Index));
        }

        // ==========================================
        // 8. LOAD DANH SÁCH NGÀNH HỌC
        // ==========================================
        private async Task LoadMajors(int? selectedId = null)
        {
            var majors = await _context.Majors
                .AsNoTracking()
                .ToListAsync();

            ViewBag.Majors = new SelectList(
                majors,
                "MajorID",
                "MajorName",
                selectedId);
        }
    }
}
