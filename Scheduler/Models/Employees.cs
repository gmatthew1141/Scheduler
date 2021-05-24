using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Scheduler.Models {
    class Employees {

        public static ObservableCollection<Employee> EmployeesList = new ObservableCollection<Employee>();
        
        public static void AddEmployee(string name, DateTime? joinDate, string section, string position) {
            Position pos = new Position {
                position = position
            };

            Section sec = new Section {
                section = section
            };

            Employee employee = new Employee {
                ID = GenerateID(),
                Name = name,
                JoinDate = joinDate.Date.ToString(),
                EmployeePosition = pos,
                EmployeeSection = sec

            };

            EmployeesList.Add(employee);
        }

        public static string GenerateID() {
            return Guid.NewGuid().ToString();
        }

    }
}
