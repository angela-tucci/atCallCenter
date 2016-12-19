using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atCallCenter.Model;
using System.Xml;

namespace atCallCenter.Data
{
    class CallDataXML : ICallData
    {
        public IEnumerable<CallRecord> GetCalls()
        {
            //make a list for the records
            var records = new List<CallRecord>();
            //create a callrate object
            CallRate cr = new CallRate(.05, .07, .09, 080000, 170000);
            var doc = new XmlDocument();
            //load the xml file
            doc.Load("CallRecords.xml");

            foreach(XmlNode node in doc.SelectNodes("//Calls")) //gets the outer node
            {
                foreach (XmlNode innerNode in node) //gets its inner nodes
                {
                    XmlNodeList children = innerNode.ChildNodes; //gets each child node
                    //get each piece of data from the nodes
                    //since the constructor splits by the commas in the record to get each item,
                    //we need to add the comma for the constructor to read it properly
                    string callType = children[0].InnerText + ",";
                    string callDate = children[1].InnerText + ",";
                    string callTime = children[2].InnerText + ",";
                    string callDuration = children[3].InnerText + ",";
                    string fromPhoneNumber = children[4].InnerText + ",";
                    string toPhoneNumber = children[5].InnerText + ",";
                    string completeStatus = children[6].InnerText + ",";

                    //put everything together to create a callrecord object
                    string call = callType + callDate + callTime + callDuration + fromPhoneNumber +
                        toPhoneNumber + completeStatus;
                    //add the call to the list of records
                    records.Add(new CallRecord(call, cr));
                }
            }
            //return the list of records
            return records;
        }
    }
}
