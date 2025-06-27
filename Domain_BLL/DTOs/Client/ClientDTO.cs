using Domain_BLL.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Client
{
    public class ClientDTO
    {

        public int PersonID { get; set; }

        public string AccountNumber { get; set; } = null!;

        public string PinCode { get; set; } = null!;

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

       

        public ClientDTO( int personID, string accountNumber
            , string pinCode, decimal balance, bool isActive)
        {
            PersonID = personID;
            AccountNumber = accountNumber;
            PinCode = pinCode;
            Balance = balance;
            IsActive = isActive;
           
        }
    }
}
