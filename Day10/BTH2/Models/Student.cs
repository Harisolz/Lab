using System;

namespace BTH2.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public Branch Branch { get; set; }

        public Gender Gender { get; set; }

        public bool IsRegular { get; set; }

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}