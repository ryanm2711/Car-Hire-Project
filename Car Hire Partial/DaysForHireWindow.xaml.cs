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
    /// Interaction logic for DaysForHireWindow.xaml
    /// </summary>
    public partial class DaysForHireWindow : Window
    {
        public DaysForHireWindow()
        {
            InitializeComponent();

            // If previous value exists, bring it back
            if (HireDetails.hireDays != 0)
                daysForHireInput.Text = HireDetails.hireDays.ToString();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                short days = short.Parse(daysForHireInput.Text);
                if (days <= 0)
                {
                    MessageBox.Show(CommonErrors.Format(CommonErrors.FailedToGetTextBoxData, "Days must be greater than 0"), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                    

                HireDetails.hireDays = days;

                // Calculate cost with days
                HireDetails.cost *= days;

                DriversAgeWindow driversAgeWindow = new DriversAgeWindow();
                driversAgeWindow.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(CommonErrors.Format(CommonErrors.FailedToGetTextBoxData, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(CommonErrors.Format(CommonErrors.FailedToNavigate, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
