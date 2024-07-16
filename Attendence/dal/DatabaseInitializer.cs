using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence.dal
{
    internal static class DatabaseInitializer
    {
        static DBcontext dbContext = new DBcontext();
        public static void Initialize()
        {
            string connectionString = dbContext.GetConnString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the database exists
                string checkDbQuery = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Attendance') CREATE DATABASE Attendance;";
                SqlCommand checkDbCommand = new SqlCommand(checkDbQuery, connection);
                checkDbCommand.ExecuteNonQuery();

                connection.ChangeDatabase("Attendance");

                // Create Employees table
                string createEmployeesTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Employees')
                    CREATE TABLE Employees (
                        ID INT IDENTITY(1,1) PRIMARY KEY,
                        EmployeeNat NVARCHAR(10) NOT NULL,
                        FirstName NVARCHAR(15) NOT NULL,
                        LastName NVARCHAR(15) NOT NULL
                    );";
                SqlCommand createEmployeesCommand = new SqlCommand(createEmployeesTable, connection);
                createEmployeesCommand.ExecuteNonQuery();

                // Create EmployeeAttendance table
                string createEmployeeAttendanceTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EmployeeAttendance')
                    CREATE TABLE EmployeeAttendance (
                        ID INT IDENTITY(1,1) PRIMARY KEY,
                        EmployeeCode INT NOT NULL,
                        EntryTime DATETIME NOT NULL,
                        ExitTime DATETIME NOT NULL,
                        FOREIGN KEY (EmployeeCode) REFERENCES Employees(ID)
                    );";
                SqlCommand createEmployeeAttendanceCommand = new SqlCommand(createEmployeeAttendanceTable, connection);
                createEmployeeAttendanceCommand.ExecuteNonQuery();

                // Create Passwords table
                string createPasswordsTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Passwords')
                    CREATE TABLE Passwords (
                        ID INT IDENTITY(1,1) PRIMARY KEY,
                        EmployeeID INT NOT NULL,
                        Password VARBINARY(MAX) NOT NULL,
                        IsActive BIT NOT NULL,
                        ExpireDate DATETIME NOT NULL,
                        FOREIGN KEY (EmployeeID) REFERENCES Employees(ID)
                    );";
                SqlCommand createPasswordsCommand = new SqlCommand(createPasswordsTable, connection);
                createPasswordsCommand.ExecuteNonQuery();

                // Insert initial data into Employees
                string insertEmployeesData = @"
                    IF NOT EXISTS (SELECT * FROM Employees)
                    BEGIN
                        INSERT INTO Employees (EmployeeNat, FirstName, LastName) VALUES
                        ('E001', 'John', 'Doe'),
                        ('E002', 'Jane', 'Smith'),
                        ('E003', 'Bob', 'Johnson');
                    END;";
                SqlCommand insertEmployeesCommand = new SqlCommand(insertEmployeesData, connection);
                insertEmployeesCommand.ExecuteNonQuery();

                // Insert initial data into EmployeeAttendance
                string insertEmployeeAttendanceData = @"
                    IF NOT EXISTS (SELECT * FROM EmployeeAttendance)
                    BEGIN
                        INSERT INTO EmployeeAttendance (EmployeeCode, EntryTime, ExitTime) VALUES
                        (1, '2024-07-15 08:00:00', '2024-07-15 17:00:00'),
                        (2, '2024-07-15 08:15:00', '2024-07-15 17:15:00'),
                        (3, '2024-07-15 08:30:00', '2024-07-15 17:30:00');
                    END;";
                SqlCommand insertEmployeeAttendanceCommand = new SqlCommand(insertEmployeeAttendanceData, connection);
                insertEmployeeAttendanceCommand.ExecuteNonQuery();

                // Insert initial data into Passwords
                string insertPasswordsData = @"
                    IF NOT EXISTS (SELECT * FROM Passwords)
                    BEGIN
                        INSERT INTO Passwords (EmployeeID, Password, IsActive, ExpireDate) VALUES
                        (1, HASHBYTES('MD5', 'a'), 1, '2024-12-31'),
                        (2, HASHBYTES('MD5', 'b'), 1, '2024-12-31'),
                        (3, HASHBYTES('MD5', 'c'), 1, '2024-12-31');
                    END;";
                SqlCommand insertPasswordsCommand = new SqlCommand(insertPasswordsData, connection);
                insertPasswordsCommand.ExecuteNonQuery();
            }

            Console.WriteLine("Database and tables created, and data inserted successfully.");
        }
    }
}
