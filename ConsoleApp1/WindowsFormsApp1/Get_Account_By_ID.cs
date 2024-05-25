using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Get_Account_By_ID : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Get_Account_By_ID()
        {
            InitializeComponent();
        }




        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string str = textBox1.Text;
            int id = Convert.ToInt32(str);
            Account account = accountController.GetId(id); 

            if (account != null)
            {
                ListViewItem item = new ListViewItem(account.Id.ToString());
                item.SubItems.Add(account.Name);
                item.SubItems.Add(account.Email);
                item.SubItems.Add(account.Password);
                listView1.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Account not exist.");
            }
        }

    }
}
