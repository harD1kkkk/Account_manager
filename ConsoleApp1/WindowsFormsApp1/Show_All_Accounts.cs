using ConsoleApp1.Controller;
using ConsoleApp1.Enity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace WindowsFormsApp1

{
    public partial class Show_All_Accounts : Form
    {
        private readonly AccountController accountController = new AccountController();
        public Show_All_Accounts()
        {
            InitializeComponent();
            ShowAllAccounts();
        }

        private void ShowAllAccounts()
        {
            listView1.Items.Clear();
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

        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}
