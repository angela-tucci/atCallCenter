//Angela Tucci
//12/8/2016
//This program creates a form to display data from a call center
//Errors have been added into the xml and csv file, just for the first few records in the file
//If a record throws an exception, the callrecord is deleted and is not displayed in the forms

using atCallCenter.Data;
using atCallCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atCallCenter.UI
{
    class Program
    {
        [STAThread]
        //run the application
        static void Main(string[] args)
        {
            try {
                Application.Run(new MainForm());
            }
            catch(ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            } 
        }
    }
}
