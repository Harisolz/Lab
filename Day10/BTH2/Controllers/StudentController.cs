using Microsoft.AspNetCore.Mvc;
using BTH2.Models;

namespace BTH2.Controllers
{
    public class StudentController : Controller
    {
        // Action hiển thị danh sách sinh viên
        public IActionResult Index()
        {
            // Khởi tạo danh sách sinh viên mẫu
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = 101,
                    Name = "Hải Nam",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "nam@g.com"
                },

                new Student()
                {
                    Id = 102,
                    Name = "Minh Tú",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2019",
                    Email = "tu@g.com"
                },

                new Student()
                {
                    Id = 103,
                    Name = "Hoàng Phong",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "A1-2020",
                    Email = "phong@g.com"
                },

                new Student()
                {
                    Id = 104,
                    Name = "Xuân Mai",
                    DateOfBirth = new DateTime(2001, 1, 1),
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2021",
                    Email = "mai@g.com"
                }
            };

            // Truyền danh sách sang View
            return View(students);
        }
    }
}