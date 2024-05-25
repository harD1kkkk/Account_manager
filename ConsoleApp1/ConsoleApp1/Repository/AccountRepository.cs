using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Principal;

namespace ConsoleApp1.Repository
{
    public class AccountRepository
    {

        public List<Account> GetAllAccounts(SqlConnection connection)
        {
            List<Account> accounts = new List<Account>();

            string query = "select * from Accounts";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        Account account = new Account(id, name, email, password);
                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }

        public int CreateNewAccount(SqlConnection connection, string name, string email, string password)
        {
            int id = 0;
            string query = $"insert into Accounts(name,email,password) output INSERTED.ID " + $" Values  (@name, @email, @password)";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                id = (int)cmd.ExecuteScalar();
                Console.WriteLine("Inserted row with id: " + id);
            }
            return id;
        }

        public Account GetId(SqlConnection connection, int id)
        {
            string query = $"select * from Accounts WHERE id={id}";
            int id2 = 0;
            Account account = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id2 = Convert.ToInt32(reader["id"]);
                        string name = Convert.ToString(reader["name"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);

                        Console.WriteLine("id: " + id);
                        Console.WriteLine("name: " + name);
                        Console.WriteLine("email: " + email);
                        Console.WriteLine("password: " + password);
                        account = new Account(id, name, email, password);
                    }
                }
            }
            if (id2 == 0)
            {
                Console.WriteLine("id not exist");
                return null;
            }
            return account;
        }

        public void DeleteAccount(SqlConnection connection, int id)
        {
            string query = $"DELETE FROM Accounts WHERE  id = {id}";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Account was deleted with id: " + id);
            }
        }

        public void UpdateAccount(SqlConnection connection, int id, string name, string email, string password)
        {
            string query = "UPDATE Accounts SET name = @name, email = @email, password = @password WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Console.WriteLine($"Account updated with id: {id}");
            }
        }


    }

}
