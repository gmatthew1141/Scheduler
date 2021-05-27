using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Scheduler.Models;

namespace Scheduler.UserControls {
    /// <summary>
    /// Interaction logic for AddRemoveView.xaml
    /// </summary>
    public partial class AddRemoveView : UserControl {
        public AddRemoveView() {
            InitializeComponent();

            // take data from database here
            Employees.EmployeesList = Database.GetEmployeesFromDB();
            Positions.PositionList = Database.GetPositionsFromDB();
            Sections.SectionList = Database.GetSectionsFromDB();

            DailyView.InitTable();
        }

        public void SetVisibleGrid(int index) {
            switch (index) {
                case 0:
                    EmployeeGrid.Visibility = Visibility.Visible;
                    EmployeeListGrid.Visibility = Visibility.Visible;
                    PositionGrid.Visibility = Visibility.Hidden;
                    PositionListGrid.Visibility = Visibility.Hidden;
                    SectionGrid.Visibility = Visibility.Hidden;
                    SectionListGrid.Visibility = Visibility.Hidden;

                    EmployeeListBox.ItemsSource = Employees.EmployeesList;
                    PositionComboBox.ItemsSource = Positions.PositionList;
                    SectionComboBox.ItemsSource = Sections.SectionList;

                    break;
                case 1:
                    EmployeeGrid.Visibility = Visibility.Hidden;
                    EmployeeListGrid.Visibility = Visibility.Hidden;
                    PositionGrid.Visibility = Visibility.Visible;
                    PositionListGrid.Visibility = Visibility.Visible;
                    SectionGrid.Visibility = Visibility.Hidden;
                    SectionListGrid.Visibility = Visibility.Hidden;


                    PositionListBox.ItemsSource = Positions.PositionList;

                    break;
                case 2:

                    EmployeeGrid.Visibility = Visibility.Hidden;
                    EmployeeListGrid.Visibility = Visibility.Hidden;
                    PositionGrid.Visibility = Visibility.Hidden;
                    PositionListGrid.Visibility = Visibility.Hidden;
                    SectionGrid.Visibility = Visibility.Visible;
                    SectionListGrid.Visibility = Visibility.Visible;

                    SectionListBox.ItemsSource = Sections.SectionList;

                    break;
            }
                
        }

        private void AddRemoveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox cmb = sender as ComboBox;
            SetVisibleGrid(cmb.SelectedIndex);
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e) {
            var name = EmployeeNameTextBox.Text;

            if (JoinDatePicker.SelectedDate == null || name.CompareTo("") == 0 
                || PositionComboBox.SelectedItem == null || SectionComboBox.SelectedItem == null) {

                // show pop up
                MessageBoxResult lackInfoMessage = MessageBox.Show("Please enter all required information!");

                return;
            }

            var joinDate = (DateTime)JoinDatePicker.SelectedDate;
            var position = PositionComboBox.SelectedItem as Position;
            var section = SectionComboBox.SelectedItem as Models.Section;

            Employees.AddEmployee(name, joinDate, section.section, position.position);

            // add employee to database

            // show popup that tells the user an employee has been added
            MessageBoxResult successMessage = MessageBox.Show("Employee " + name + " successfully added to database.");

            // reset the form
            EmployeeNameTextBox.Text = "";
            JoinDatePicker.SelectedDate = null;
            PositionComboBox.SelectedItem = "";
            SectionComboBox.SelectedItem = "";
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e) {

            // Prevent the user to add a blank position
            if (PositionTitleTextBox.Text.CompareTo("") == 0) {

                MessageBoxResult enterTitleMessage = MessageBox.Show("Please enter position title!");
                // show a pop up

                return;
            }

            Positions.AddPosition(PositionTitleTextBox.Text);

            MessageBoxResult successMessage = MessageBox.Show("Successfully added new position to database.");
            PositionTitleTextBox.Text = "";
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e) {

            // Prevent the user to add a blank section
            if (SectionTitleTextBox.Text.CompareTo("") == 0) {

                // show popup
                MessageBoxResult enterTitleMessage = MessageBox.Show("Please enter section title!");

                return;
            }

            Sections.AddSection(SectionTitleTextBox.Text);
            MessageBoxResult successMessage = MessageBox.Show("Successfully added new section to database.");
            SectionTitleTextBox.Text = "";
        }

        private void EmployeeRemoveButton_Click(object sender, RoutedEventArgs e) {
            var item = EmployeeListBox.SelectedItem as Employee;

            Employees.RemoveEmployee(item);
        }

        private void PositionRemoveButton_Click(object sender, RoutedEventArgs e) {
            var item = PositionListBox.SelectedItem as Position;

            Positions.RemovePosition(item);
        }

        private void SectionRemoveButton_Click(object sender, RoutedEventArgs e) {
            var item = SectionListBox.SelectedItem as Models.Section;

            Sections.RemoveSection(item);

        }

        private void ClearEmployeeBtn_Click(object sender, RoutedEventArgs e) {
            EmployeeNameTextBox.Text = "";
            JoinDatePicker.SelectedDate = null;
            JoinDatePicker.DisplayDate = DateTime.Today;
            PositionComboBox.SelectedItem = null;
            SectionComboBox.SelectedItem = null;
        }

        private void ClearPositionBtn_Click(object sender, RoutedEventArgs e) {
            PositionTitleTextBox.Text = "";
        }

        private void ClearSectionBtn_Click(object sender, RoutedEventArgs e) {
            SectionTitleTextBox.Text = "";
        }
    }
}
