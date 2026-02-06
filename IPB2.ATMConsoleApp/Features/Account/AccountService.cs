using System;
using System.Collections.Generic;
using System.Linq;
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
                return new ResponseDto { IsSuccess = false, Message = "Mobile no is required." };
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
            var IsExitaccoount = _accountList.FirstOrDefault(x => x.MobileNo == request.MobileNo);
            if (IsExitaccoount != null) {
                return new ResponseDto { IsSuccess = false, Message = "Your mobile No is already created." };
            }

            var newAccount = new AccountDto(Guid.NewGuid().ToString(),
                    request.Name,
                    request.MobileNo,
                    request.Password,
                    0
            );
            _accountList.Add(newAccount);
            return new ResponseDto { IsSuccess = true, Message = "Account created successfully." };
        }
    }
}
