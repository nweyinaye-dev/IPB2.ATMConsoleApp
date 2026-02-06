using IPB2.ATMConsoleApp.Features.Account.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPB2.ATMConsoleApp.Features.Account
{
    public class AccountUI
    {
        private AccountService accountService = new AccountService();
        public void Start()
        {
            while (true) {
                ShowMainMenu();
            }
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("\n*** Welcome to ATM ***");
            Console.WriteLine("1) Create Account");
            Console.WriteLine("2) Enter Account");
            Console.WriteLine("3) Exit");
            Console.Write("Please choose option: ");
            var choose = Console.ReadLine();
            bool isFlag = int.TryParse(choose, out int res);
            switch(res)
            {
                case 1: CreateAccont(); break;
                case 2: EnterAccount(); break;
                case 3: break;
                default: Console.WriteLine("Invalid option.Please try again."); break;
            }
        }
        public void ShowSessionMenu()
        {
            while (true)
            {
                Console.WriteLine("\n*** Session Menu ***");
                Console.WriteLine("1) Deposit");
                Console.WriteLine("2) Check Balance");
                Console.WriteLine("3) Withdraw");
                Console.WriteLine("4) Logout");
                Console.WriteLine("5) Exit");
                Console.Write("Please choose option: ");
                var choose = Console.ReadLine();

                bool isChoose = Enum.TryParse<ATMType>(choose, out ATMType res);

                switch (res)
                {
                    case ATMType.Deposit:Deposit(); break;
                    case ATMType.CheckBalance: CheckBalance(); break;
                    case ATMType.Withdraw: Withdraw(); break;
                    case ATMType.Logout: Logout();  break;
                    case ATMType.Exit: Exit(); break;
                    default: Console.WriteLine("Invalid option,please try again.");break;

                }

            }
        }
        public void CreateAccont()
        {
            string password = "";
            string confirmPassword = "";
            Console.WriteLine("\n*** Create Account ***");
            Console.Write("Enter your name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Enter your mobile no: ");
            var mobileNo = Console.ReadLine() ?? "";

            while (true) {
                Console.Write("Enter your password: ");
                 password = Console.ReadLine() ?? "";
                Console.Write("Enter your confirm password: ");
                 confirmPassword = Console.ReadLine() ?? "";
                if (password == confirmPassword) break;
                Console.WriteLine("Password and confirm password doesn't match.");
            }

            var request = new CreateAccountRequestDto(name, mobileNo, password,confirmPassword) ;
            var response = accountService.CreateAccount(request);
            Console.WriteLine(response.Message);
        }
        public void EnterAccount()
        {
            Console.WriteLine("\n*** Enter Account ***");
            Console.Write("Enter your mobile no: ");
            var mobileNo = Console.ReadLine() ?? "";
            Console.Write("Enter your password: ");
            var password = Console.ReadLine() ?? "";

            // to check Account
            ShowSessionMenu();

        }
        public void Deposit() {
            Console.WriteLine("\n*** Deposit ***");
        }
        public void CheckBalance() { Console.WriteLine("\n*** CheckBalance ***"); }
        public void Withdraw() { Console.WriteLine("\n*** Withdraw ***"); }
        public void Logout() { Console.WriteLine("\n*** Logout ***"); }
        public void Exit() { Environment.Exit(0); }
    }
}
