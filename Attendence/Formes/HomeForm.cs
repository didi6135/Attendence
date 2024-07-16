using Attendence.Classes;
using Attendence.dal;
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

namespace Attendence.Formes
{
    public partial class HomeForm : Form
    {
        private readonly UserDetails _user;
        private readonly FormManager _formManager;
        private readonly DBcontext dbContext;
        private bool _isCustomClose;


        public HomeForm(UserDetails user, DBcontext dbContextQ, FormManager formManager)
        {
            InitializeComponent();
            _user = user;
            _formManager = formManager;
            dbContext = dbContextQ; 
            DisplayUserDetails();

        }

        private void DisplayUserDetails()
        {
            label2.Text = _user.EmployeeNat;

            LoadLastLoginAndLogout();

        }

        private void LoadLastLoginAndLogout()
        {
                string query = @"
                    SELECT TOP 1 EntryTime, ExitTime
                    FROM EmployeeAttendance
                    WHERE EmployeeCode = @EmployeeCode
                    ORDER BY EntryTime DESC";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@EmployeeCode", _user.Id),
            };

            DataTable result = dbContext.MakeQueryWithParameters(query, parameter);
            DataRow resultA = result.Rows[0];


             if (resultA["EntryTime"] != DBNull.Value)
             {
                 label3.Text = resultA["EntryTime"].ToString();
                 label5.Text = resultA["ExitTime"].ToString();
             }
             

             if (resultA["ExitTime"] == DBNull.Value)
             {
                 button1.Enabled = false;
             }

             if(resultA["EntryTime"] != DBNull.Value && resultA["ExitTime"] != DBNull.Value)
             {
                 button3.Enabled = false;
             }

        }


        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isCustomClose)
            {
                Application.Exit();
            }
        }

        private void ExitFromProgrem(object sender, EventArgs e)
        {
            DateTime exitTime = DateTime.Now;

            string updateQuery = @"
                UPDATE EmployeeAttendance
                SET ExitTime = @ExitTime
                WHERE EmployeeCode = @EmployeeCode
                AND EntryTime = (
                    SELECT MAX(EntryTime)
                    FROM EmployeeAttendance
                    WHERE EmployeeCode = @EmployeeCode
                    AND ExitTime IS NULL
                )";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@EmployeeCode", _user.Id),
                new SqlParameter("@ExitTime", exitTime),
            };

            int result = dbContext.ExecuteNonQuery(updateQuery, parameter);
            //DataRow resultA = result.Rows[0];


            if (result != 0)
                {
                    MessageBox.Show("Logout time updated!");
                }
                else
                {
                    MessageBox.Show("No entry found to update logout time.");
                }



            _isCustomClose = true;
            _formManager.ShowLoginForm();
            this.Close();

        

        }



        private void EnterUser(object sender, EventArgs e)
        {

            //Insert a new shift for the user

           string instertQuery = "INSERT INTO EmployeeAttendance (EmployeeCode, EntryTime) VALUES (@EmployeeCode, @EntryTime)";

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@EmployeeCode", _user.Id),
                new SqlParameter("@EntryTime", DateTime.Now),
            };

            int result = dbContext.ExecuteNonQuery(instertQuery, parameter);
            
            if (result != 0)
            {
                button3.Enabled = true;

                MessageBox.Show("Login time updated!");
                //_user.LastLogin = enterTime.ToString();
                DisplayUserDetails(); // Update the displayed details
                //return true;    
                //button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("There is some error");
            }


        }
    }
}
