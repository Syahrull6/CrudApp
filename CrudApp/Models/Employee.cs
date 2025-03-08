using System;
using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department wajib diisi")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary wajib diisi")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary harus lebih dari 0")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }
    }
}