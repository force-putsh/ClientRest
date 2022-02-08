using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRest
{
    public partial class Form1 : Form
    {
        UserDemo userDemo = new UserDemo();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userDemo.ShowAllUsers(dtgList);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            UserDemo userDemo = new UserDemo();
            userDemo.Nom = txtNom.Text;
            userDemo.Prenom = txtPrenom.Text;
            userDemo.CreateUser(userDemo);
            userDemo.ShowAllUsers(dtgList);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserDemo userDemo =this.userDemo.ShowUserById(int.Parse(txtSearch.Text));
            userDemo.Nom = txtNom.Text;
            userDemo.Prenom = txtPrenom.Text;
            userDemo.UpdateUser(int.Parse(txtSearch.Text), userDemo);
            userDemo.ShowAllUsers(dtgList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.userDemo.DeleteUser(int.Parse(txtSearch.Text));
            userDemo.ShowAllUsers(dtgList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UserDemo userDemo =this.userDemo.ShowUserById(int.Parse(txtSearch.Text));
            txtNom.Text = userDemo.Nom;
            txtPrenom.Text = userDemo.Prenom;
            txtId.Text = userDemo.id.ToString();
        }
    }
}
