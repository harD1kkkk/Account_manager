using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using ConsoleApp1.Repository;
using ConsoleApp1.Service;
using ConsoleApp1.View;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form get_Account_By_ID = new Get_Account_By_ID();
            get_Account_By_ID.StartPosition = FormStartPosition.Manual;
            get_Account_By_ID.Height = this.Height;
            get_Account_By_ID.Width = this.Width;
            get_Account_By_ID.Location = this.Location;
            get_Account_By_ID.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form show_All_Accounts = new Show_All_Accounts();
            show_All_Accounts.StartPosition = FormStartPosition.Manual;
            show_All_Accounts.Height = this.Height;
            show_All_Accounts.Width = this.Width;
            show_All_Accounts.Location = this.Location;
            show_All_Accounts.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form update_account = new Update_Account();
            update_account.StartPosition = FormStartPosition.Manual;
            update_account.Height = this.Height;
            update_account.Width = this.Width;
            update_account.Location = this.Location;
            update_account.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form create_account = new Create_Account();
            create_account.StartPosition = FormStartPosition.Manual;
            create_account.Height = this.Height;
            create_account.Width = this.Width;
            create_account.Location = this.Location;
            create_account.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form delete_account = new Delete_Account();
            delete_account.StartPosition = FormStartPosition.Manual;
            delete_account.Height = this.Height;
            delete_account.Width = this.Width;
            delete_account.Location = this.Location;
            delete_account.Show();
        }
    }
}
