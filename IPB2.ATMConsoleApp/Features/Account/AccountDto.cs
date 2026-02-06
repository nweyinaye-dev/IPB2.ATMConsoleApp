namespace IPB2.ATMConsoleApp.Features.Account
{
    public class AccountDto
    {
        public AccountDto(string id, string name, string mobileNo,string passsword,decimal balance = 0) {
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
    public class LoginAccountRequestDto
    {
        public LoginAccountRequestDto(string mobileNo, string password)
        {
            MobileNo = mobileNo;
            Password = password;
        }
        public string MobileNo { get; set; }
        public string Password { get; set; }

    }
    public class DepositRequestDto {
        public DepositRequestDto(decimal amount, string mobileNo)
        {
            Amount = amount;
            MobileNo = mobileNo;
        }
        public string MobileNo { get;set; }
        public decimal Amount { get; set; }

    }
    public class GetBalanceRequestDto
    {
        public GetBalanceRequestDto(string mobileNo)
        {
            MobileNo = mobileNo;
        }
        public string MobileNo { get;set; }
    }
    public class WithdrawRequestDto
    {
        public WithdrawRequestDto(string mobileNo,decimal amount) { 
            MobileNo = mobileNo;
            Amount = amount;
        }
        public string MobileNo { get; set; }
        public decimal Amount { get; set; }
       
    }
    public class ResponseDto
    {
        public bool IsSuccess { get;set; }
        public string Message { get; set; } = "";
    }
}
