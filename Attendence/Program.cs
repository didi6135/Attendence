using Attendence.Classes;
using Attendence.dal;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Attendance
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


          // Initialize application configuration such as high DPI settings or default font
           ApplicationConfiguration.Initialize();

            // Initialize the database
            DatabaseInitializer.Initialize();

            // Create an instance of the FormManager
            FormManager formManager = new FormManager();


                // Show the login form
                formManager.ShowLoginForm();

                // Keep the application running
                Application.Run();
            
        }
    }
}
