
using System;
using System.ComponentModel.DataAnnotations;

namespace BTH4.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100, MinimumLength = 4,
            ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [RegularExpression(
            @"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(8,
            ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9\s]).{8,}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn ngành học")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        [Range(0.0, 10.0,
            ErrorMessage = "Điểm phải nằm trong khoảng 0 đến 10")]
        public double? Score { get; set; }

        // Thuộc tính ảnh đại diện từ Lab 1
        public string? ImagePath { get; set; }
    }
}
