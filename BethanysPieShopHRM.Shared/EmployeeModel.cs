using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BethanysPieShopHRM.Shared
{
    public class EmployeeModel: ITableModel
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

        public bool ShowBenefits { get; set; }
        public bool HasPremiumBenefits { get; set; }
        public bool HighLightRow 
        { 
            get 
            {
                return HasPremiumBenefits;
            } 
        }

        public bool ShowChildTemplate
        {
            get
            {
                return ShowBenefits;
            }
        }

        public void UpdateEntity(Employee entity)
        {
            entity.CountryId = CountryId;
            entity.MaritalStatus = MaritalStatus;
            entity.BirthDate = BirthDate;
            entity.City = City;
            entity.Email = Email;
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.Gender = Gender;
            entity.PhoneNumber = PhoneNumber;
            entity.Smoker = Smoker;
            entity.Street = Street;
            entity.Zip = Zip;
            entity.JobCategoryId = JobCategoryId;
            entity.Comment = Comment;
            entity.ExitDate = ExitDate;
            entity.JoinedDate = JoinedDate;
        }
    }
}
