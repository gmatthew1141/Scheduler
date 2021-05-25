using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Scheduler.Models {
    class Employees {

        public static ObservableCollection<Employee> EmployeesList = new ObservableCollection<Employee>();
        
        public static void AddEmployee(string name, DateTime joinDate, string section, string position) {
            Position pos = Positions.GetPosition(position);

            Section sec = Sections.GetSection(section);

            Employee employee = new Employee {
                Name = name,
                JoinDate = joinDate.Date.ToString(),
                EmployeePosition = pos,
                EmployeeSection = sec

            };

            EmployeesList.Add(employee);
            Database.AddEmployee(employee);
            // add data to database
        }

        public static string GenerateID() {
            return Guid.NewGuid().ToString();
        }

    }
}
