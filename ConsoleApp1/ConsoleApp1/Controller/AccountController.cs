using ConsoleApp1.Enity;
using ConsoleApp1.Service;
using System.Collections.Generic;

namespace ConsoleApp1.Controller
{
    public class AccountController
    {
        private readonly AccountService accountService = new AccountService();
        public List<Account> GetAllAccounts()
        {
            return accountService.GetAllAccounts();
        }

        public int CreateNewAccount(string name, string email, string password)
        {
            return accountService.CreateNewAccount(name, email, password);
        }

        public Account GetId(int id)
        {
            return accountService.GetId(id);
        }
        public void DeleteAccount(int id)
        {
            accountService.DeleteAccount(id);
        }
        public void UpdateAccount(int id, string name, string email, string password)
        {
            accountService.UpdateAccount(id, name, email, password);
        }
    }
}
