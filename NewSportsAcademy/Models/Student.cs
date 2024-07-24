using System;
using System.ComponentModel.DataAnnotations;

namespace NewSportsAcademy.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        public string MedicalInformation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Fixture> Fixtures { get; set; } // Navigation property
    }
}
