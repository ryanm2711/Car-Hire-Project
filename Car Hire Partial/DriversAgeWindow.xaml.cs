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
    /// Interaction logic for DriversAgeWindow.xaml
    /// </summary>
    public partial class DriversAgeWindow : Window
    {
        ushort underAgeFee = 20;

        public DriversAgeWindow()
        {
            InitializeComponent();

            // If previous value exists, bring it back
            if (HireDetails.age != 0)
                driversAgeInput.Text = HireDetails.age.ToString();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                short age = short.Parse(driversAgeInput.Text);
                HireDetails.age = age;

                // Check the age of driver, must be 17 or older
                // If the age is under 25 then add 20 to cost
                if (age < 17)
                {
                    MessageBox.Show("Sorry, but this driver is too young to drive.", "Invalid Age", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (age < 25)
                {
                    MessageBox.Show("Due to the driver being under 25, an additional fee of £" + underAgeFee + " has been added to the sub-total.", "Age Fee", MessageBoxButton.OK, MessageBoxImage.Information);
                    HireDetails.cost += underAgeFee;
                }



                Result resultWindow = new Result();
                resultWindow.Show();

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
                DaysForHireWindow daysForHireWindow = new DaysForHireWindow();
                daysForHireWindow.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(CommonErrors.Format(CommonErrors.FailedToNavigate, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
