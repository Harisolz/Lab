
using Microsoft.AspNetCore.Mvc;
using BTH4.Models;

namespace BTH4.Controllers
{
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public StudentController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // Danh sách sinh viên mẫu
        private static readonly List<Student> listStudents = new()
        {
            new Student
            {
                Id = 1,
                Name = "Nguyen Van An",
                Email = "an@gmail.com",
                Branch = Branch.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "Ha Noi",
                DateOfBirth = new DateTime(2004, 1, 10),
                Score = 8.5
            },

            new Student
            {
                Id = 2,
                Name = "Tran Thi Binh",
                Email = "binh@gmail.com",
                Branch = Branch.BE,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "Hai Phong",
                DateOfBirth = new DateTime(2004, 5, 20),
                Score = 7.8
            },

            new Student
            {
                Id = 3,
                Name = "Le Van Cuong",
                Email = "cuong@gmail.com",
                Branch = Branch.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = "Nam Dinh",
                DateOfBirth = new DateTime(2003, 8, 15),
                Score = 9.0
            }
        };

        // GET: /Admin/Student/List
        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        // GET: /Admin/Student/Add
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        // POST: /Admin/Student/Add/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            Student student,
            IFormFile? imageFile)
        {
            // Kiểm tra file ảnh
            if (imageFile != null && imageFile.Length > 0)
            {
                string[] allowedExtensions =
                {
                    ".jpg", ".jpeg", ".png", ".webp"
                };

                string extension = Path
                    .GetExtension(imageFile.FileName)
                    .ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError(
                        "imageFile",
                        "Chỉ chấp nhận JPG, JPEG, PNG hoặc WEBP.");
                }

                if (imageFile.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError(
                        "imageFile",
                        "Dung lượng ảnh tối đa là 5 MB.");
                }
            }

            // Validation theo Lab 3
            if (!ModelState.IsValid)
            {
                return View("Create", student);
            }

            // Tạo ID mới
            student.Id = listStudents.Count == 0
                ? 1
                : listStudents.Max(s => s.Id) + 1;

            // Upload ảnh đại diện
            if (imageFile != null && imageFile.Length > 0)
            {
                string webRoot = _environment.WebRootPath
                    ?? Path.Combine(
                        _environment.ContentRootPath,
                        "wwwroot");

                string uploadFolder = Path.Combine(
                    webRoot,
                    "images");

                Directory.CreateDirectory(uploadFolder);

                string extension = Path
                    .GetExtension(imageFile.FileName)
                    .ToLowerInvariant();

                string fileName =
                    $"{Guid.NewGuid()}{extension}";

                string filePath = Path.Combine(
                    uploadFolder,
                    fileName);

                await using (var stream = new FileStream(
                    filePath,
                    FileMode.CreateNew))
                {
                    await imageFile.CopyToAsync(stream);
                }

                student.ImagePath = "/images/" + fileName;
            }

            // Bài lab chỉ quản lý danh sách sinh viên,
            // không lưu mật khẩu dạng văn bản thuần.
            student.Password = null;

            // Thêm sinh viên vào danh sách
            listStudents.Add(student);

            // Quay về danh sách
            return RedirectToAction(nameof(Index));
        }
    }
}
