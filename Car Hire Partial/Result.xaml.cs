using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_Hire_Partial
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result()
        {
            InitializeComponent();

            // Add results
            resultsBox.Items.Add("Car Type: " + HireDetails.carType);
            resultsBox.Items.Add("Car Pickup Location: " + HireDetails.location);
            resultsBox.Items.Add("Car Days For Hire: " + HireDetails.hireDays);
            resultsBox.Items.Add("Driver's Age: " + HireDetails.age);
            resultsBox.Items.Add("Car Total Cost: £" + HireDetails.cost);
        }

        private void btnBegin_Click(object sender, RoutedEventArgs e)
        {
            // this is the procedure to navigate back to the start window.

            // Reset user details
            HireDetails.Reset();

            // build the start window in memory
            MainWindow mainWindow = new MainWindow();

            // show the newly built window to the user
            mainWindow.Show();

            // close the existing window (MainWindow)
            this.Close();
        }
    }
}
