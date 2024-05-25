using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Update_Account : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Update_Account()
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
                string name = textBox4.Text;
                string password = textBox2.Text;
                string email = textBox3.Text;

                accountController.UpdateAccount(id, name, email, password);
                account = accountController.GetId(id);
              
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
