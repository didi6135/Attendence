using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Attendence.dal;
using System.Data;

namespace Attendence.Classes
{
    public class UserService
    {

        private readonly DBcontext dbContext;

        public UserService(DBcontext dbContextQ)
        {
            dbContext = dbContextQ;
        }

        public UserDetails Authenticate(string employeeNat, string password)
        {
            UserDetails user = null;
            byte[] hashedPassword = HashPassword(password);

            string userQuery = @"
            SELECT e.ID, e.EmployeeNat, e.FirstName, e.LastName, p.Password 
            FROM Employees e
            JOIN Passwords p ON e.ID = p.EmployeeID
            WHERE e.EmployeeNat = @EmployeeNat AND p.Password = @Password AND p.IsActive = 1";

            SqlParameter[] parameter =
            {
                new SqlParameter("@EmployeeNat", employeeNat),
                new SqlParameter("@Password", hashedPassword),
            };

            DataTable result = dbContext.MakeQueryWithParameters(userQuery, parameter);
            if (result.Rows.Count != 0)
            {
                DataRow userR = result.Rows[0];
                
            user = new UserDetails
                    {
                        Id = userR["ID"].ToString(),
                        EmployeeNat = userR["EmployeeNat"].ToString(),
                        FirstName = userR["FirstName"].ToString(),
                        LastName = userR["LastName"].ToString(),
                    };

            }


            return user;
        }




        private static byte[] HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


    } 
}
