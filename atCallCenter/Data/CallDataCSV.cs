using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atCallCenter.Model;
using System.IO;

namespace atCallCenter.Data
{
    class CallDataCSV : ICallData
    {
        public IEnumerable<CallRecord> GetCalls()
        {
            StreamReader sr = null;
            string record = "";
            List<CallRecord> records = new List<CallRecord>();
            CallRate cr = new CallRate(.05, .07, .09, 080000, 170000);//each call has the same call rate data

            //read in the data from the csv file
            using (sr = new StreamReader("CallRecords.csv"))
            {
                //while the line it's on isn't null...
                while ((record = sr.ReadLine()) != null)
                {
                    try
                    {
                        //add a new record with the callrate
                        records.Add(new CallRecord(record, cr));
                    }
                    catch (ArgumentException ae)
                    {

                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            //return the list of records
            return records;
        }
    }
}
