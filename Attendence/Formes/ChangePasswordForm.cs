using Attendence.Classes;
using Attendence.dal;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendence.Formes
{
    public partial class ChangePasswordForm : Form
    {
        private readonly FormManager _formManager;
        private readonly DBcontext dbContext;
        private string _currentPassword;
        private string _employeeNatLabel;


        public ChangePasswordForm(FormManager formManager, DBcontext dbContextQ)
        {
            dbContext = dbContextQ;
            _formManager = formManager;
            InitializeComponent();

        }

        //public void CheckOldPassAndTZ(object sender, EventArgs e)
        //{
        //    string? Id;
        //    _currentPassword = oldPass.Text;
        //    _employeeNatLabel = employeeNatLabel.Text;

        //    if (!string.IsNullOrEmpty(_currentPassword))
        //    {
        //        // Hash the password using MD5
        //        byte[] hashedPassword = HashPassword(_currentPassword);


        //        string query = @"
        //        SELECT * 
        //            FROM Passwords p
        //            join Employees e on e.ID = p.EmployeeID

        //            WHERE e.EmployeeNat = @UserID
        //            AND p.Password = @hashedPassword
        //            AND p.IsActive = 1";


        //        SqlParameter[] parameter = new SqlParameter[]
        //        {
        //            new SqlParameter("@UserID", _employeeNatLabel),
        //            new SqlParameter("@hashedPassword", hashedPassword),
        //        };

        //        DataTable result = dbContext.MakeQueryWithParameters(query, parameter);
        //         if (result.Rows.Count > 0)
        //         {
        //        DataRow resultA = result.Rows[0];


        //             Id = resultA["ID"].ToString();
        //             // Password is correct
        //             SetNewPassword(Id);

        //         }
        //         else
        //         {
        //             // Password is incorrect
        //             oldPassError.Text = "Password is incorrect";
        //         }

        //    }
        //    else
        //    {
        //        testOld.Text = "Password cannot be empty";
        //    }
        //}


        //private byte[] HashPassword(string password)
        //{
        //    using (MD5 md5 = MD5.Create())
        //    {
        //        return md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    }
        //}


        //public void SetNewPassword(string employeeID)
        //{
        //    string newPass = newPass1.Text;
        //    string rePass = reNewPass.Text;

        //    if (newPass == rePass & string.IsNullOrEmpty(newPass) & string.IsNullOrEmpty(rePass))
        //    {
        //        byte[] hashedPassword = HashPassword(newPass);

        //        string query = @"
        //                UPDATE Passwords
        //                SET Password = @Password
        //                WHERE EmployeeID = @EmployeeID";


        //        SqlParameter[] parameter = 
        //        {
        //            new SqlParameter("@Password", hashedPassword),
        //            new SqlParameter("@EmployeeID", employeeID),
        //        };

        //        int result = dbContext.ExecuteNonQuery(query, parameter);
        //        if (result == 1)
        //        {
        //            MessageBox.Show("Password change");
        //            _formManager.ShowLoginForm();
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("There is some error");

        //        }
        //    }
        //    else
        //    {
        //        // Handle password mismatch scenario
        //        Console.WriteLine("Passwords do not match.");
        //    }
        //}

        private void CancelAndReturnToHomePage(object sender, EventArgs e)
        {
            _formManager.ShowLoginForm();
            this.Close();
        }

        private void label_changePassword_Click(object sender, EventArgs e)
        {
            


            string _Tz = employeeNatLabel.Text;
            string oldPassword = oldPass.Text;
            string newPassword = newPass1.Text;
            string newPassword2 = reNewPass.Text;


            string message = newPassword switch
            {
                _ when string.IsNullOrEmpty(_Tz) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newPassword2) => "נא למלא את כל השדות",
                _ when newPassword != newPassword2 => "הסיסמאות החדשות אינן תואמות",
                _ when oldPassword == newPassword => "הסיסמה החדשה זהה לסיסמה הישנה",
                _ => string.Empty
            };

            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            bool success = ChangePassword(_Tz, oldPassword, newPassword);
            if (success)
            {
                MessageBox.Show("הסיסמה שונתה בהצלחה");
                _formManager.ShowLoginForm();
                 this.Close();

                //NavigationService.ShowForm(FormNames.LoginForm, ref isNavigating);
                // TODO - Navigate to the main form when it's ready
            }
            else
            {
                MessageBox.Show("שגיאה בעת שינוי הסיסמה");
            }
        }


        public bool ChangePassword(string id, string oldPassword, string newPassword)
        {
            try
            {
                string query = @"
            DECLARE @UserTZ VARCHAR(10) = @EmployeeID;
            DECLARE @Employee_id INT;
            DECLARE @OldPass VARCHAR(10) = @oldPassword;

            SELECT @Employee_id = ID 
            FROM Employees
            WHERE EmployeeNat = @UserTZ;
            
            IF @Employee_id IS NOT NULL
            BEGIN
                UPDATE Passwords
                SET Password = HASHBYTES('MD5', @Password)
                WHERE @Employee_id = EmployeeID
                AND HASHBYTES('MD5', @OldPass) = Password;
            END";

                SqlParameter[] parameters = 
                {
                    new SqlParameter("@EmployeeID", SqlDbType.VarChar) { Value = id },
                    new SqlParameter("@Password", SqlDbType.VarChar) { Value = newPassword },
                    new SqlParameter("@oldPassword", SqlDbType.VarChar) { Value = oldPassword }
                };

                int result = dbContext.ExecuteNonQuery(query, parameters);

                if (result == 0)
                {
                    Console.WriteLine("res 0");
                    return false;
                }
                else
                {
                    Console.WriteLine("res 1");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("catch: " + ex.Message);
                // Log the exception or handle it as needed
                return false;
            }
        }


    }
}
