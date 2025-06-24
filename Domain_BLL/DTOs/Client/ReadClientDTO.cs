using Domain_BLL.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Client
{
    public class ReadClientDTO
    {
        public int ClientID { get; set; }

        public int PersonID { get; set; }

        public string AccountNumber { get; set; } = null!;

        public string PinCode { get; set; } = null!;

        public decimal Balance { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public  ReadPersonDTO Person { get; set; } = null!;

        public ReadClientDTO(int clientID, int personID, string accountNumber
            , string pinCode, decimal balance, bool isActive, DateTime createdAt
            , DateTime updatedAt, ReadPersonDTO person)
        {
            ClientID = clientID;
            PersonID = personID;
            AccountNumber = accountNumber;
            PinCode = pinCode;
            Balance = balance;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Person = person;
        }
    }
}
