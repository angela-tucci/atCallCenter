using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atCallCenter.Model;

namespace atCallCenter.Data
{
    class CallDataTest : ICallData
    {
        public IEnumerable<CallRecord> GetCalls()
        {   //testing data
            //create a call rate object
            CallRate cr = new CallRate(.05, .07, .09, 080000, 170000);//each call has the same call rate data

            return new List<CallRecord>() 
            { 
            new CallRecord("LC,01312004,120400,4131,2076651928,2051118684,Y", cr), //valid record
            new CallRecord("LC,12252015,140400,1132,2055551235,2051118684,Y", cr), //valid record
            new CallRecord("LC,01272016,000312,4131,205555123,2051118684,Y", cr), //bad from phone number, WORKS!
            new CallRecord("LC,01272016,000312,4131,2055551235,205111868,Y", cr), //bad to phone number, WORKS!
            new CallRecord("LA,12252015,140400,4131,2055551235,2051118684,Y", cr), //bad call type, WORKS!
            new CallRecord("LC,12252015,001404,not a number,2055551235,2051118684,Y", cr), //bad call duration, WORKS!
            new CallRecord("LC,01241999,140400,4131,2055551235,2051118684,L", cr), //bad call complete status, WORKS!
            new CallRecord("LC,12252017,140400,4131,2055551235,2051118684,Y", cr), //bad date, WORKS!
            new CallRecord("LC,12252015,not a number,1132,2055551235,2051118684,Y", cr), //bad time (not a number), WORKS!
            new CallRecord("LD,12012015,140404,4131,2055551235,2051118684,Y", cr), //LD during peak, WORKS!
            new CallRecord("LC,12252015,001465,1132,2055551235,2051118684,Y", cr), //not a valid time, WORKS!
            new CallRecord("LD,12252015,040404,1120,2055551235,2051118684,Y", cr), //LD during off peak, WORKS!
            new CallRecord("LD,12252015,163510,6131,1837261532,2051118684,N", cr), //LD starts in peak, ends in off peak
            new CallRecord("LD,12252015,073505,4131,1837261532,2051118684,N", cr), //LD starts in off peak, ends in peak
            new CallRecord("LD,12252015,073500,132,2076651928,2051118684,N", cr), //valid record
            new CallRecord("LD,12252015,040400,1121,2055551235,2051118684,N", cr), //valid record
            new CallRecord("LD,07232005,071000,3300,2055551235,2051118684,Y", cr), //valid record
            };
        }
    }
}
