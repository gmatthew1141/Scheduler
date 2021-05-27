using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace Scheduler.UserControls {


    /// <summary>
    /// Interaction logic for DailyView.xaml
    /// </summary>
    public partial class DailyView : UserControl {

        private double mainGridWidth = 1;

        private Grid DynamicGrid;

        public DailyView() {
            InitializeComponent();

            CreateTable();
            InitTable();
        }

        // Create the base table
        public void CreateTable() {
            // Create the Grid
            DynamicGrid = new Grid();
            DynamicGrid.Width = 1260;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            //DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.LightSteelBlue);

            // Create Columns
            ColumnDefinition nameCol = new ColumnDefinition();
            ColumnDefinition joinDateCol = new ColumnDefinition();
            ColumnDefinition positionCol = new ColumnDefinition();
            ColumnDefinition sectionCol = new ColumnDefinition();
            ColumnDefinition dailyScheduleCol = new ColumnDefinition();
            ColumnDefinition phBfrCol = new ColumnDefinition();
            ColumnDefinition phAddCol = new ColumnDefinition();
            ColumnDefinition phTknCol = new ColumnDefinition();
            ColumnDefinition phBlcCol = new ColumnDefinition();
            ColumnDefinition alBfrCol = new ColumnDefinition();
            ColumnDefinition alAddCol = new ColumnDefinition();
            ColumnDefinition alTknCol = new ColumnDefinition();
            ColumnDefinition alBlcCol = new ColumnDefinition();

            nameCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            joinDateCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            positionCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            sectionCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            dailyScheduleCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            phBfrCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            phAddCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            phTknCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            phBlcCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            alBfrCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            alAddCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            alTknCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);
            alBlcCol.Width = new GridLength(mainGridWidth, GridUnitType.Star);

            DynamicGrid.ColumnDefinitions.Add(nameCol);
            DynamicGrid.ColumnDefinitions.Add(joinDateCol);
            DynamicGrid.ColumnDefinitions.Add(positionCol);
            DynamicGrid.ColumnDefinitions.Add(sectionCol);
            DynamicGrid.ColumnDefinitions.Add(dailyScheduleCol);
            DynamicGrid.ColumnDefinitions.Add(phBfrCol);
            DynamicGrid.ColumnDefinitions.Add(phAddCol);
            DynamicGrid.ColumnDefinitions.Add(phTknCol);
            DynamicGrid.ColumnDefinitions.Add(phBlcCol);
            DynamicGrid.ColumnDefinitions.Add(alBfrCol);
            DynamicGrid.ColumnDefinitions.Add(alAddCol);
            DynamicGrid.ColumnDefinitions.Add(alTknCol);
            DynamicGrid.ColumnDefinitions.Add(alBlcCol);


            // Create Rows

            RowDefinition titleRow1 = new RowDefinition();
            titleRow1.Height = new GridLength(35);
            RowDefinition titleRow2 = new RowDefinition();
            titleRow2.Height = new GridLength(35);

            DynamicGrid.RowDefinitions.Add(titleRow1);
            DynamicGrid.RowDefinitions.Add(titleRow2);


            // Create header for each column
            TextBlock nameTextBlock = new TextBlock();
            Grid.SetRowSpan(nameTextBlock, 2);
            nameTextBlock.Text = "Name";
            nameTextBlock.FontSize = 14;
            nameTextBlock.FontWeight = FontWeights.Bold;
            nameTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            nameTextBlock.VerticalAlignment = VerticalAlignment.Center;
            nameTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(nameTextBlock, 0);
            Grid.SetColumn(nameTextBlock, 0);


            TextBlock joinDateTextBlock = new TextBlock();
            Grid.SetRowSpan(joinDateTextBlock, 2);
            joinDateTextBlock.Text = "Join date";
            joinDateTextBlock.FontSize = 14;
            joinDateTextBlock.FontWeight = FontWeights.Bold;
            joinDateTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            joinDateTextBlock.VerticalAlignment = VerticalAlignment.Center;
            joinDateTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(joinDateTextBlock, 0);
            Grid.SetColumn(joinDateTextBlock, 1);


            TextBlock positionTextBlock = new TextBlock();
            Grid.SetRowSpan(positionTextBlock, 2);
            positionTextBlock.Text = "Position";
            positionTextBlock.FontSize = 14;
            positionTextBlock.FontWeight = FontWeights.Bold;
            positionTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            positionTextBlock.VerticalAlignment = VerticalAlignment.Center;
            positionTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(positionTextBlock, 0);
            Grid.SetColumn(positionTextBlock, 2);



            TextBlock sectionTextBlock = new TextBlock();
            Grid.SetRowSpan(sectionTextBlock, 2);
            sectionTextBlock.Text = "Section";
            sectionTextBlock.FontSize = 14;
            sectionTextBlock.FontWeight = FontWeights.Bold;
            sectionTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            sectionTextBlock.VerticalAlignment = VerticalAlignment.Center;
            sectionTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(sectionTextBlock, 0);
            Grid.SetColumn(sectionTextBlock, 3);



            TextBlock dailyScheduleTextBlock = new TextBlock();
            Grid.SetRowSpan(dailyScheduleTextBlock, 2);
            dailyScheduleTextBlock.Text = "Schedule";
            dailyScheduleTextBlock.FontSize = 14;
            dailyScheduleTextBlock.FontWeight = FontWeights.Bold;
            dailyScheduleTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            dailyScheduleTextBlock.VerticalAlignment = VerticalAlignment.Center;
            dailyScheduleTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(dailyScheduleTextBlock, 0);
            Grid.SetColumn(dailyScheduleTextBlock, 4);


            // Column for PH

            TextBlock phTextBlock = new TextBlock();
            Grid.SetColumnSpan(phTextBlock, 4);
            phTextBlock.Text = "PH";
            phTextBlock.FontSize = 14;
            phTextBlock.FontWeight = FontWeights.Bold;
            phTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            phTextBlock.VerticalAlignment = VerticalAlignment.Center;
            phTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(phTextBlock, 0);
            Grid.SetColumn(phTextBlock, 5);

            TextBlock phBfrTextBlock = new TextBlock();
            Grid.SetColumnSpan(phTextBlock, 4);
            phBfrTextBlock.Text = "Before";
            phBfrTextBlock.FontSize = 14;
            phBfrTextBlock.FontWeight = FontWeights.Bold;
            phBfrTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            phBfrTextBlock.VerticalAlignment = VerticalAlignment.Center;
            phBfrTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(phBfrTextBlock, 1);
            Grid.SetColumn(phBfrTextBlock, 5);

            TextBlock phAddTextBlock = new TextBlock();
            Grid.SetColumnSpan(phTextBlock, 4);
            phAddTextBlock.Text = "Additional";
            phAddTextBlock.FontSize = 14;
            phAddTextBlock.FontWeight = FontWeights.Bold;
            phAddTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            phAddTextBlock.VerticalAlignment = VerticalAlignment.Center;
            phAddTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(phAddTextBlock, 1);
            Grid.SetColumn(phAddTextBlock, 6);

            TextBlock phTknTextBlock = new TextBlock();
            Grid.SetColumnSpan(phTextBlock, 4);
            phTknTextBlock.Text = "Taken";
            phTknTextBlock.FontSize = 14;
            phTknTextBlock.FontWeight = FontWeights.Bold;
            phTknTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            phTknTextBlock.VerticalAlignment = VerticalAlignment.Center;
            phTknTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(phTknTextBlock, 1);
            Grid.SetColumn(phTknTextBlock, 7);

            TextBlock phBlcTextBlock = new TextBlock();
            Grid.SetColumnSpan(phTextBlock, 4);
            phBlcTextBlock.Text = "Balance";
            phBlcTextBlock.FontSize = 14;
            phBlcTextBlock.FontWeight = FontWeights.Bold;
            phBlcTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            phBlcTextBlock.VerticalAlignment = VerticalAlignment.Center;
            phBlcTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(phBlcTextBlock, 1);
            Grid.SetColumn(phBlcTextBlock, 8);

            // Column for AL

            TextBlock alTextBlock = new TextBlock();
            Grid.SetColumnSpan(alTextBlock, 4);
            alTextBlock.Text = "AL";
            alTextBlock.FontSize = 14;
            alTextBlock.FontWeight = FontWeights.Bold;
            alTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            alTextBlock.VerticalAlignment = VerticalAlignment.Center;
            alTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(alTextBlock, 0);
            Grid.SetColumn(alTextBlock, 9);


            TextBlock alBfrTextBlock = new TextBlock();
            alBfrTextBlock.Text = "Before";
            alBfrTextBlock.FontSize = 14;
            alBfrTextBlock.FontWeight = FontWeights.Bold;
            alBfrTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            alBfrTextBlock.VerticalAlignment = VerticalAlignment.Center;
            alBfrTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(alBfrTextBlock, 1);
            Grid.SetColumn(alBfrTextBlock, 9);

            TextBlock alAddTextBlock = new TextBlock();
            alAddTextBlock.Text = "Additional";
            alAddTextBlock.FontSize = 14;
            alAddTextBlock.FontWeight = FontWeights.Bold;
            alAddTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            alAddTextBlock.VerticalAlignment = VerticalAlignment.Center;
            alAddTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(alAddTextBlock, 1);
            Grid.SetColumn(alAddTextBlock, 10);

            TextBlock alTknTextBlock = new TextBlock();
            alTknTextBlock.Text = "Taken";
            alTknTextBlock.FontSize = 14;
            alTknTextBlock.FontWeight = FontWeights.Bold;
            alTknTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            alTknTextBlock.VerticalAlignment = VerticalAlignment.Center;
            alTknTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(alTknTextBlock, 1);
            Grid.SetColumn(alTknTextBlock, 11);

            TextBlock alBlcTextBlock = new TextBlock();
            alBlcTextBlock.Text = "Balance";
            alBlcTextBlock.FontSize = 14;
            alBlcTextBlock.FontWeight = FontWeights.Bold;
            alBlcTextBlock.Foreground = new SolidColorBrush(Colors.Green);
            alBlcTextBlock.VerticalAlignment = VerticalAlignment.Stretch;
            alBlcTextBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            alBlcTextBlock.TextAlignment = TextAlignment.Center;
            alBlcTextBlock.Background = new SolidColorBrush(Colors.AliceBlue);
            Grid.SetRow(alBlcTextBlock, 1);
            Grid.SetColumn(alBlcTextBlock, 12);


            //// Add column headers to the Grids

            DynamicGrid.Children.Add(nameTextBlock);
            DynamicGrid.Children.Add(joinDateTextBlock);
            DynamicGrid.Children.Add(positionTextBlock);
            DynamicGrid.Children.Add(sectionTextBlock);
            DynamicGrid.Children.Add(dailyScheduleTextBlock);
            DynamicGrid.Children.Add(phTextBlock);
            DynamicGrid.Children.Add(phBfrTextBlock);
            DynamicGrid.Children.Add(phAddTextBlock);
            DynamicGrid.Children.Add(phTknTextBlock);
            DynamicGrid.Children.Add(phBlcTextBlock);
            DynamicGrid.Children.Add(alTextBlock);
            DynamicGrid.Children.Add(alBfrTextBlock);
            DynamicGrid.Children.Add(alAddTextBlock);
            DynamicGrid.Children.Add(alTknTextBlock);
            DynamicGrid.Children.Add(alBlcTextBlock);

            // Display grid into a Window

            DailyViewControl.Content = DynamicGrid;
            Debug.WriteLine("finish creating table");
        }

        // Need funtion that populate the grid at start

        public static void InitTable() {

            Debug.WriteLine("Start initialize table");
            //Debug.WriteLine("No of employees: " + Employees.EmployeesList);

            foreach (var employee in Employees.EmployeesList) {
                Debug.WriteLine(employee.Name);
            }
            
        }

        // Need another funtion that update the grid when user added new employee

    }
}
