using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.ATMConsoleApp.Features.Account
{
    public class AccountDto
    {
        public AccountDto(string id, string name, string mobileNo,string passsword,decimal balance) {
            ID = id;
            Name = name;
            MobileNo = mobileNo;           
            Password = passsword;
            Balance = balance;
        }
        public string ID { get;set;  }
        public string Name { get; set; }
        public string MobileNo { get;set; }        
        public string Password { get;set; }
        public decimal Balance {  get;set; }
    }

    public class CreateAccountRequestDto
    {
        public CreateAccountRequestDto(string name,string mobileNo, string password, string confirmPassword)
        {
            Name = name;
            MobileNo = mobileNo;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
        public string Name { get; set; }
        public string MobileNo { get;set; }
        public string Password { get;set; } 
        public string ConfirmPassword { get;set;  }

    }
    public class ResponseDto
    {
        public bool IsSuccess { get;set; }
        public string Message { get; set; } = "";
    }
}
