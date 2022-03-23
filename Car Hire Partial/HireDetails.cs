using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Hire_Partial
{
    public static class HireDetails
    {
        public static string carType;
        public static int hireDays;
        public static float cost;
        public static int age;
        public static string location;
        public static int carIndex = -1;

        public static void Reset()
        {
            // Reset the static class, this will be used when the user is finished entering their details and want to try again.
            carType = "";
            hireDays = 0;
            cost = 0f;
            age = 0;
            location = "";
            carIndex = -1;
        }
    }
}
