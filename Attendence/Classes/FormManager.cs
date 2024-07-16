using Attendence.dal;
using Attendence.Formes;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.Classes
{
    public class FormManager
    {
        private Form currentForm;
        public IConfiguration Configuration { get; set; }
        private DBcontext dbContext = new DBcontext();

     


        public void ShowLoginForm()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = new LoginForm(this, dbContext);
            currentForm.Show();

        } 

        public void ShowHomeForm(UserDetails user)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = new HomeForm(user, dbContext, this);
            currentForm.Show();
        }

        public void ShowChangePassword()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = new ChangePasswordForm(this, dbContext);
            currentForm.Show();
        }
    }
}
