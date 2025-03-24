using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class CsharpUtility
    {
        /*
                 * this method is used to get the current date and time
                 */
        public static string Date_time()
        {
            // DateTime dateTime=DateTime.Now;

            // string dt= dateTime.ToString("s");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");


            return timestamp;
        }
        public static string Date()
        {
            // DateTime dateTime=DateTime.Now;
            // string dt= dateTime.ToString("s");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd");
            return timestamp;
        }
        /*
         * this method is used to get the random number
         * */
        public static int Random_No()
        {
            Random r = new Random();
            return r.Next(500);
        }
    }
}

