using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Create_Account : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Create_Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;

            accountController.CreateNewAccount(name, email, password);

            List<Account> accounts = accountController.GetAllAccounts();
            accounts.ForEach(account =>
            {
                ListViewItem item = new ListViewItem(account.Id.ToString());
                item.SubItems.Add(account.Name);
                item.SubItems.Add(account.Email);
                item.SubItems.Add(account.Password);
                listView1.Items.Add(item);
            });
        }
    }
}
