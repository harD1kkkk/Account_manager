using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.View
{
    public class MainView
    {
        private readonly AccountController accountController = new AccountController();
        public void InitialInterface()
        {
            while (true)
            {
                Console.WriteLine("1 - show all accounts");
                Console.WriteLine("2 - get account by id");
                Console.WriteLine("3 - update account");
                Console.WriteLine("4 - create new account");
                Console.WriteLine("5 - delete account");

                Console.WriteLine("Input number:");
                int choose;
                choose = Int32.Parse(Console.ReadLine());

                if (choose == 1)
                {
                    ShowAllAccounts();
                }
                else if (choose == 2)
                {
                    int id;
                    Console.Write("Enter id: ");
                    id = Int32.Parse(Console.ReadLine());
                    Getid(id);
                }
                else if (choose == 3)
                {
                    UpdateAccount();
                }
                else if (choose == 4)
                {
                    CreateNewAccount();
                }
                else if (choose == 5)
                {
                    int id;
                    Console.Write("Enter id: ");
                    id = Int32.Parse(Console.ReadLine());
                    DeleteAccount(id);
                }
                else
                {
                    Console.WriteLine("Incorrect number.");
                }
            }
        }

        public void ShowAllAccounts()
        {
            List<Account> accounts = accountController.GetAllAccounts();
            accounts.ForEach(account => Console.WriteLine(account.Id + " " + account.Name + " " + account.Email + " " + account.Password));
            Console.WriteLine();
        }

        public void Getid(int id)
        {
            accountController.GetId(id);
            Console.WriteLine();
        }


        public void UpdateAccount()
        {
            int id;
            string name;
            string email;
            string password;
            Console.Write("Enter account id: ");
            id = Int32.Parse(Console.ReadLine());

            Console.Write("Enter account name: ");
            name = Console.ReadLine();

            Console.Write("Enter account email: ");
            email = Console.ReadLine();

            Console.Write("Enter account password: ");
            password = Console.ReadLine();

            accountController.UpdateAccount(id, name, email, password);
            Console.WriteLine();
        }
        public void CreateNewAccount()
        {
            Console.WriteLine("Input name for new account:");
            string name = Console.ReadLine();

            Console.WriteLine("Input email for new account:");
            string email = Console.ReadLine();

            Console.WriteLine("Input password for new account:");
            string password = Console.ReadLine();
            accountController.CreateNewAccount(name, email, password);
            Console.WriteLine();
        }
        public void DeleteAccount(int id)
        {
            accountController.DeleteAccount(id);
            Console.WriteLine();
        }


    }
}
