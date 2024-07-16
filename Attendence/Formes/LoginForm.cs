using Attendence.Classes;
using Attendence.dal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendence
{
    public partial class LoginForm : Form
    {
        private readonly FormManager _formManager;
        private DBcontext dbContext;
        //public IConfiguration Configuration;



        public LoginForm(FormManager formManager, DBcontext dbContextQ)
        {
            InitializeComponent();
            _formManager = formManager;

            //_connectionString = "Server=DAVIDWORK;Database=attendence;User Id=sa;Password=1234;";
            dbContext = dbContextQ;

            button1.Click += LoginButton_Click;
            //button2.Click += ChangePasswordButton_Click;


        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string employeeNat = textBox1.Text;
            string password = textBox2.Text;

            UserService userService = new UserService(dbContext);
            UserDetails user = userService.Authenticate(employeeNat, password);

            if (user != null)
            {
                _formManager.ShowHomeForm(user);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials!");
            }
        }


        private void ChangePasswordButton_Click(Object sender, EventArgs e)
        {
            _formManager.ShowChangePassword();
            this.Close();


        }

        
    }
}
