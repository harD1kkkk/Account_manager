using ConsoleApp1.Enity;
using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1.Service
{
    public class AccountService
    {
        //readonly string connectionString = "Server=tcp:newtestdb2.database.windows.net,1433;" +
        //    "Initial Catalog=Test;Persist Security Info=False;User ID=CloudSA142084fb;" +
        //    "Password=1qaz!QAZ;MultipleActiveResultSets=False;" +
        //    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; Pooling=true; Max Pool Size=10; Min Pool Size=2;";
        string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["db1_connectionString"].ConnectionString;
        private readonly AccountRepository accountRepository = new AccountRepository();
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    accounts = accountRepository.GetAllAccounts(conection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return accounts;
        }

        public int CreateNewAccount(string name, string email, string password)
        {
            using (SqlConnection conection = new SqlConnection(connectionString))
            {

                try
                {
                    conection.Open();
                    accountRepository.CreateNewAccount(conection, name, email, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return 0;
        }

        public Account GetId(int id)
        {
            Account account = null;
            using (SqlConnection conection = new SqlConnection(connectionString))
            {
                try
                {
                    conection.Open();
                    account = accountRepository.GetId(conection, id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (account == null)
                {
                    Console.WriteLine("Account with id: " + id + " not exist");
                }
            }
            return account;

        }

        public void DeleteAccount(int id)
        {
            if (GetId(id) == null)
            {
                Console.WriteLine("Error: incorrect id");
            }
            else
            {
                using (SqlConnection conection = new SqlConnection(connectionString))
                {
                    try
                    {
                        conection.Open();
                        accountRepository.DeleteAccount(conection, id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void UpdateAccount(int id,string name,string email,string password)
        {
            if (GetId(id) == null)
            {
                Console.WriteLine("Error: incorrect id");
            }
            else
            {
                using (SqlConnection conection = new SqlConnection(connectionString))
                {
                    try
                    {
                        conection.Open();
                        accountRepository.UpdateAccount(conection, id,name,email,password);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

    }

}
