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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Car_Hire_Partial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // store the list of cars in an array of strings
        string[] carNames = { "Toyota IQ", "Mini Cooper", "VW Polo", "Audi TT", "Mercedes A220", "Range Rover Evoque", "Jaguar" };

        string[] locations = { "Edinburgh Airport", "Glasgow Airport", "Prestwick Airport", "Edinburgh City Centre", "Glasgow City Centre", "Livingston" };

        // store the list of prices in an array of floats
        // as this is money so we do need to decimal point
        float[] carPrice = { 10, 18, 15, 30, 40, 50, 55 };

        public MainWindow()
        {
            // constructor is the only method that executes when the window loads
            // therefore use this to initialise the listbox with the details of
            // all the cars
            InitializeComponent();

            // go through each item in the array and add the car name from the carNames
            // array and the price from the carPrice array to the list box
            for (int i = 0; i < carNames.Length; i++)
            {
                // for each item in the array, add the name from carNames and the cost from carPrice
                listCars.Items.Add(carNames[i] + " - £" + carPrice[i]);
            }

            if (HireDetails.carIndex != -1)
                listCars.SelectedIndex = HireDetails.carIndex;

            // Locations list box init
            for (int i = 0; i < locations.Length; i++)
            {
                listLocations.Items.Add(locations[i]);
            }

            if (!string.IsNullOrEmpty(HireDetails.location))
                listLocations.SelectedValue = HireDetails.location;
        }

        private void listCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                HireDetails.carIndex = listCars.SelectedIndex;	//find out the index of the item selected from the listbox

                // once we know the index of the item selected from the listbox we can then use it to look up the array
                // when we get the data out of the array we need store it in the central store called HireDetails
                // remember that cost is stored as a string in the array so we need to convert it to an integer

                HireDetails.carType = carNames[HireDetails.carIndex]; // use the listbox index to lookup the name in the carNames array
                HireDetails.cost = carPrice[HireDetails.carIndex]; // use the listbox index to lookup the price in the carPrice array
            }
            catch(Exception ex)
            {
                MessageBox.Show(CommonErrors.Format(CommonErrors.InvalidSelectedData, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            // this is the procedure to navigate to the next window.
            // we don't need to pass any parameters as any data we want to share
            // has been put in the central store

            // navigation will only take place if the user has chosen a
            // car from the list.  If an item has not been chosen then the
            // selectedIndex has a value less than 0

            if (string.IsNullOrEmpty(HireDetails.carType))
            {
                MessageBox.Show("A car must be selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if(string.IsNullOrEmpty(HireDetails.location))
            {
                MessageBox.Show("A pickup location must be selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                /*short driverAge = short.Parse(driverAgeInput.Text);
                short daysForHire = short.Parse(daysForHireInput.Text);

                // Calculate cost
                if (driverAge < 25 && driverAge >= 16)
                {
                    HireDetails.cost = (HireDetails.cost * daysForHire) + 20;
                }
                else
                {
                    HireDetails.cost *= daysForHire;
                }*/

                DaysForHireWindow daysForHireWindow = new DaysForHireWindow();

                daysForHireWindow.Show();

                // build the result window in memory
                //Result result = new Result();

                // show the newly built window to the user
                //result.Show();

                // close the existing window (MainWindow)
                this.Close();
            }
        }

        private void listLocations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                HireDetails.carIndex = listLocations.SelectedIndex;
                HireDetails.location = locations[HireDetails.carIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(CommonErrors.Format(CommonErrors.InvalidSelectedData, ex.Message), "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
