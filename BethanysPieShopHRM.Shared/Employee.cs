using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BethanysPieShopHRM.Shared
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string PhoneNumber { get; set; }
        public bool Smoker { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        [StringLength(1000, ErrorMessage = "Comment length can't exceed 1000 characters.")]
        public string Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public IEnumerable<EmployeeBenefit> EmployeeBenefits { get; set; }

        public EmployeeModel ToModel()
        {
            return new EmployeeModel
            {
                EmployeeId = EmployeeId,
                CountryId = CountryId,
                MaritalStatus = MaritalStatus,
                BirthDate = BirthDate,
                City = City,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                PhoneNumber = PhoneNumber,
                Smoker = Smoker,
                Street = Street,
                Zip = Zip,
                JobCategoryId = JobCategoryId,
                Comment = Comment,
                ExitDate = ExitDate,
                JoinedDate = JoinedDate,
                HasPremiumBenefits = EmployeeBenefits != null 
                    && EmployeeBenefits.Any(b => b.Benefit.Premium)
            };
        }
    }
}
