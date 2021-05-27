using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using MongoDB.Bson;

namespace Scheduler.Models {
    class Employees {

        public static ObservableCollection<Employee> EmployeesList = new ObservableCollection<Employee>();
        
        public static void AddEmployee(string name, DateTime joinDate, string section, string position) {
            Position pos = Positions.GetPosition(position);

            Section sec = Sections.GetSection(section);

            Employee employee = new Employee {
                _id = ObjectId.GenerateNewId(),
                Name = name,
                JoinDate = joinDate.Date.ToString(),
                EmployeePosition = pos,
                EmployeeSection = sec

            };

            EmployeesList.Add(employee);
            Database.AddEmployee(employee);
            // add data to database
        }

        public static void RemoveEmployee(Employee employee) {
            // remove from database 
            Database.RemoveEmployeeFromDB(employee._id);

            // remove from list
            EmployeesList.Remove(employee);
        }

    }
}
