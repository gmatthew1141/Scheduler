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
            var joinDate = JoinDatePicker.SelectedDate;
            var position = PositionComboBox.SelectedItem.ToString();
            var section = SectionComboBox.SelectedItem.ToString();

            Employees.AddEmployee(name, joinDate, section, position);

            // reset the form
            EmployeeNameTextBox.Text = "";
            JoinDatePicker.SelectedDate = null;
            PositionComboBox.SelectedItem = "";
            SectionComboBox.SelectedItem = "";
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e) {
            Positions.AddPosition(PositionTitleTextBox.Text);
            PositionTitleTextBox.Text = "";
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e) {
            Sections.AddSection(SectionTitleTextBox.Text);
            SectionTitleTextBox.Text = "";
        }
    }
}
