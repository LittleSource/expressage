using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ymcore.config
{
    public class database
    {
        private static string ConString = "Server=172_27_0_17;Database=expressage;User ID=myUsername;Password=myPassword;Trusted_Connection=True;";
        public static string getConString()
        {
            return ConString;
        }
    }
}