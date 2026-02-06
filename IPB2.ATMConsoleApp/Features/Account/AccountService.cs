using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.ATMConsoleApp.Features.Account
{
    public class AccountService
    {
        private List<AccountDto> _accountList = new List<AccountDto>();
        
        public ResponseDto CreateAccount(CreateAccountRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new ResponseDto { IsSuccess = false, Message = "Name is required." };
            }
            if (string.IsNullOrWhiteSpace(request.MobileNo))
            {
                return new ResponseDto { IsSuccess = false, Message = "Mobile No is required." };
            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return new ResponseDto { IsSuccess = false, Message = "Password is required." };
            }
            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                return new ResponseDto { IsSuccess = false, Message = "Confirm password is required." };
            }
            if(request.Password != request.ConfirmPassword) 
            { 
                return new ResponseDto { IsSuccess = false, Message = "Password and confirm password doesn't match." };
            }
            var IsExitAccoount = _accountList.Any(x => x.MobileNo == request.MobileNo);
            if (IsExitAccoount) {
                return new ResponseDto { IsSuccess = false, Message = "Your mobile No  already exits." };
            }

            var newAccount = new AccountDto(
                    Guid.NewGuid().ToString(),
                    request.Name.Trim(),
                    request.MobileNo.Trim(),
                    request.Password,
                    0
            );
            _accountList.Add(newAccount);
            return new ResponseDto { IsSuccess = true, Message = "Account created successfully." };
        }
        
        public ResponseDto LoginAccount(LoginAccountRequestDto requset) {

            if (string.IsNullOrWhiteSpace(requset.MobileNo)) { return new ResponseDto { IsSuccess = false,Message = "Mobile is required." };}
            if (string.IsNullOrWhiteSpace(requset.Password)) { return new ResponseDto { IsSuccess = false, Message = "Password is required." }; }
             
            var account = _accountList.FirstOrDefault(x => x.MobileNo == requset.MobileNo.Trim());

            if(account == null) return new ResponseDto { IsSuccess = false, Message = "Account not found." };
            if(account.Password != requset.Password) return new ResponseDto { IsSuccess = false, Message = "Invalid password." };

            return new ResponseDto
            {
                IsSuccess = true,
                Message = "Login successfully."
            };
        }
        
        public ResponseDto Deposit(DepositRequestDto request)
        {
            if(request.Amount <= 0)
            {
                return new ResponseDto { IsSuccess = false, Message = "Amount must be greater than 0." };
            }
            var account = _accountList.FirstOrDefault(x => x.MobileNo == request.MobileNo);
            if(account == null) return new ResponseDto { IsSuccess = false, Message = "Account not found." };
            
            account.Balance += request.Amount;
            return new ResponseDto { IsSuccess = true, Message = $"Deposit successfully.Your current balance is {account.Balance}." };
        }
        public ResponseDto GetBalance(GetBalanceRequestDto request)
        {
            var account = _accountList.FirstOrDefault(x => x.MobileNo == request.MobileNo.Trim());
            if (account == null) return new ResponseDto { IsSuccess = false, Message = "Account no found." };

            return new ResponseDto { IsSuccess = true, Message = $"Your current balance is {account.Balance}." };
        }
        public ResponseDto Withdraw(WithdrawRequestDto request)
        {
            if (request.Amount <= 0) return new ResponseDto { IsSuccess = false, Message = "Amount must be greater than 0." };

            var account = _accountList.FirstOrDefault(x => x.MobileNo == request.MobileNo.Trim());
            if (account == null) return new ResponseDto { IsSuccess = false, Message = "Account not found." };

            if(account.Balance < request.Amount) return new ResponseDto { IsSuccess = false, Message = "Insufficient balance." };
            
            account.Balance -= request.Amount;

            return new ResponseDto { IsSuccess = true, Message = $"Withdraw successfully.Your current balance is {account.Balance}." };
        }
    }
}
