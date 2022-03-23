using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Hire_Partial
{
    public static class CommonErrors
    {
        public static string InvalidSelectedData = "Failed to get selected data.";
        public static string FailedToGetTextBoxData = "Failed to get input from text box.";
        public static string FailedToNavigate = "Failed to navigate to next window.";

        public static string Format(string errorMessage, string exceptionMessage)
        {
            string formattedMsg = errorMessage + " " + exceptionMessage;
            return formattedMsg;
        }
    }
}
