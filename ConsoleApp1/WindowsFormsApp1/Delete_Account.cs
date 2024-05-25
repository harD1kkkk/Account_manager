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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Delete_Account : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Delete_Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string str = textBox1.Text;
            int id = Convert.ToInt32(str);
            Account account = accountController.GetId(id);

            if (account != null)
            {
                accountController.DeleteAccount(id);
                List<Account> accounts = accountController.GetAllAccounts();
                accounts.ForEach(account1 =>
                {
                    ListViewItem item = new ListViewItem(account1.Id.ToString());
                    item.SubItems.Add(account1.Name);
                    item.SubItems.Add(account1.Email);
                    item.SubItems.Add(account1.Password);
                    listView1.Items.Add(item);
                });
            }
            else
            {
                MessageBox.Show("Id not exist.");
            }
        }
    }
}
