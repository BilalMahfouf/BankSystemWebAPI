using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Person
{
    public  class PersonDTO
    {

        public string NationalNo { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfbirth { get; set; }

        public byte Gender { get; set; }

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Email { get; set; }

        public int NationalityCountryID { get; set; }

        public string? ImagePath { get; set; }



        public PersonDTO( string nationalNo, string firstName, string lastName
            , DateTime dateOfbirth, byte gender, string address, string phone,
            string? email, int nationalityCountryID, string? imagePath)
        {
            NationalNo = nationalNo;
            FirstName = firstName;
            LastName = lastName;
            DateOfbirth = dateOfbirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;

        }
        public PersonDTO() { }
    }
}
