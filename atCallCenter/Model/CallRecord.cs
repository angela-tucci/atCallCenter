using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atCallCenter.Model
{
    public class CallRecord
    {
        //fields
        private string _callType;
        private string _callDate;
        private string _callTime; 
        private string _callDuration;
        private string _callFromNumber;
        private string _callToNumber;
        private string _callCompleteStatus;
        private CallRate _rate; //no validation needed!
        private string _cost;


        //properties
        public string CallType
        {
            get { return _callType; }
            private set {
                if (!ValidCallType(value))
                {
                    throw new ArgumentException($"{value} is not a valid call type");
                }
                _callType = value;
            }
        }

        public string CallDate
        {
            get { return _callDate; }
            private set {
                
                if (!ValidDate(value))
                {
                    throw new ArgumentException($"{value} is in the future!");
                }
                _callDate = ConvertDate(value);
            }
        }

        public string CallTime
        {
            get { return _callTime; }
            private set {
                if (!ValidTime(value))
                {
                    throw new ArgumentException($"{value} is not a valid time");
                }
                _callTime = ConvertTime(value);
            }
        }

        public string CallDuration
        {
            get { return _callDuration; }
            private set {
                if (!ValidNumber(value))
                {
                    throw new ArgumentException($"{value} is not a valid call duration (not a number)");
                }
                _callDuration = ConvertDuration(value);
            }
        }

        public string CallFromNumber
        {
            get { return _callFromNumber; }
            private set {
                if (!ValidPhoneNumber(value))
                {
                    //throw exception
                    throw new ArgumentException($"{value} is not a valid phone number");
                }
                _callFromNumber = FormatPhoneNumber(value);
            }
        }

        public string CallToNumber
        {
            get { return _callToNumber; }
            private set {
                if (!ValidPhoneNumber(value))
                {
                    //throw exception
                    throw new ArgumentException($"{value} is not a valid phone number");
                }
                _callToNumber = FormatPhoneNumber(value);
            }
        }

        public string CallCompletedStatus
        {
            get { return _callCompleteStatus; }
            private set {
                if (!ValidCompleteStatus(value))
                {
                    throw new ArgumentException($"{value} is not a valid call completion status (Y or N only)");
                }
                _callCompleteStatus = value;
            }
        }

        public CallRate Rate
        {
            get { return _rate; }
            private set { _rate = value; }
        }

        public string Cost
        {
            get { return _cost;  }
            private set { _cost = value; }
        }

        //constructor - sets the state
        public CallRecord(string callData, CallRate rate)
        {
            //set the state
            try {
                SetState(callData, rate);
            }
            catch(ArgumentException ae)
            {
                //MessageBox.Show(ae.Message);
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public string ConvertDate(string d)
        {
            //convert the date to a DateTime object
            DateTime date = DateTime.ParseExact(d, "mmddyyyy", CultureInfo.InvariantCulture);
            //return its ToString, ex 11/11/2001
            return date.ToString("mm/dd/yyyy");
        }

        public string ConvertTime(string t)
        {
            //convert the time to a DateTime object
            DateTime time = DateTime.ParseExact(t, "HHmmss", CultureInfo.InvariantCulture);
            //return its ToString, ex 1:45 PM
            return time.ToString("hh:mm:ss tt");
        }

        private void SetState(string callData, CallRate rate)
        {
            //split the data, seperated by the comma
            string[] data = callData.Split(',');
                CallType = data[0];
                CallDate = data[1];
                CallTime = data[2];
                CallDuration = data[3];
                CallFromNumber = data[4]; 
                CallToNumber = data[5]; 
                CallCompletedStatus = data[6];
                Rate = rate;

                //call method to calculate cost
                _cost = CalcCost(data[0], data[2], data[3]);
        }

        public string CalcCost(string callType, string callTime, string callDuration)
        {
            //set the duration to be in minutes
            double durationInMinutes = double.Parse(callDuration) / 60;
            double costPerMinute = 0;
            double cost = 0;

            //if the call is local...
            if(callType == "LC")
            {
                costPerMinute = Rate.LocalRate; //use the local rate per minute
                cost = costPerMinute * durationInMinutes;
            }
            //if the call is long distance...
            else if(callType == "LD")
            {
                //format the peak start and peak end times to be converted to DateTime objects
                string peakStartString = Rate.PeakStartTime.ToString("000000");
                string peakEndString = Rate.PeakEndTime.ToString("000000");

                //convert the peak start and peak end to DateTime objects
                DateTime peakStart = DateTime.ParseExact(peakStartString, "HHmmss", CultureInfo.InvariantCulture);
                DateTime peakEnd = DateTime.ParseExact(Rate.PeakEndTime.ToString(), "HHmmss", CultureInfo.InvariantCulture);

                //convert the callStart and callEnd times to DateTime objects
                DateTime callStartTime = DateTime.ParseExact(callTime, "HHmmss", CultureInfo.InvariantCulture);
                DateTime callEndTime = callStartTime.Add(new TimeSpan(0, Convert.ToInt32(durationInMinutes), 0));
                
                //if during peak time only
                if (callStartTime >= peakStart && callEndTime < peakEnd)
                {
                    costPerMinute = Rate.LongDistancePeakRate; //use long distance peak rate
                    cost = costPerMinute * durationInMinutes;
                }

                //if during off peak time only
                else if((callStartTime < peakStart || callStartTime >= peakEnd) 
                    && (callEndTime > peakEnd || callEndTime < peakStart))
                {
                    costPerMinute = Rate.LongDistanceOffPeakRate;  //use long distance off peak rate
                    cost = costPerMinute * durationInMinutes;
                }

                //if call starts in peak and ends in off peak
                else if (callStartTime >= peakStart && (callEndTime > peakEnd
                    || callEndTime < peakStart))
                {
                    //create a TimeSpan object to find the amount of time in peak and off peak
                    TimeSpan timeInPeak = peakEnd.Subtract(callStartTime);
                    TimeSpan timeInOffPeak = callEndTime.Subtract(peakEnd);
                    
                    //get the total minutes spent in peak and off peak
                    double minuteSpanInPeak = timeInPeak.TotalMinutes;
                    double minuteSpanOffPeak = timeInOffPeak.TotalMinutes;
                  
                    //calculate the cost
                    cost = (minuteSpanInPeak * Rate.LongDistancePeakRate) +
                        (minuteSpanOffPeak * Rate.LongDistanceOffPeakRate);
                    //MessageBox.Show(cost.ToString("0.00"));
                }

                //if call starts in off peak and ends in peak
                else if((callStartTime < peakStart || callStartTime > peakEnd) &&
                    (callEndTime >= peakStart && callEndTime < peakEnd))
                {
                    //create a TimeSpan object to find the amount of time in peak and off peak
                    TimeSpan timeInOffPeak = peakStart.Subtract(callStartTime);
                    TimeSpan timeInPeak = callEndTime.Subtract(peakStart);

                    //get the total minutes spent in peak and off peak
                    double minuteSpanInPeak = timeInPeak.TotalMinutes;
                    double minuteSpanOffPeak = timeInOffPeak.TotalMinutes;

                    //calculate the cost
                    cost = (minuteSpanInPeak * Rate.LongDistancePeakRate) +
                        (minuteSpanOffPeak * Rate.LongDistanceOffPeakRate);
                }
            }
            
            //return the cost formatted to 2 decimal places            
            return cost.ToString("0.00");
        }

        public bool ValidCallType(string callType)
        {
            //check that the call type is either LC or LD
            if(callType != "LC" && callType != "LD")
            {
                return false;
            }
            return true;
        }

        public bool ValidDate(string date)
        {   //check that the date isn't in the future, spooky
            DateTime callDate = DateTime.ParseExact(date, "mmddyyyy", CultureInfo.InvariantCulture);
            if (callDate > DateTime.Today)
            {
                return false;
            }
            return true;
        }

        public bool ValidTime(string time)
        {
            //try to convert the time to a DateTime object to validate it
            string[] format = {"HHmmss"};
            DateTime callTime;
            if (!DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out callTime))
            {
                return false;
            }
            return true;
        }
        
        public bool ValidNumber(string number)
        {
            //check that a value is a number
            long num;
            if (!long.TryParse(number, out num))
            {
                return false;
            }
            return true;
        }

        public bool ValidPhoneNumber(string phoneNumber)
        {
            //check that the phone number has the correct number of digits in it
            char[] phoneNumberArray = phoneNumber.ToCharArray();

            if(phoneNumberArray.Length != 10) 
            {
                return false;
            }

            return true;
        }

        public bool ValidCompleteStatus(string status)
        {
            //check that the call completed status is either Y or N
            if (status != "Y" && status != "N")
            {
                return false;
            }
            return true;
        }

        public string ConvertDuration(string duration)
        {
            //convert the duration from seconds to minutes
            double minutes = double.Parse(duration) / 60;
            return $"{minutes.ToString("#.##")}";
        }

        public string FormatPhoneNumber(string number)
        {
            char[] arrayNumbers = number.ToCharArray();
            //put the phone number in the correct format, ex. (454)389-3489
            string formatNumber = $"({arrayNumbers[0]}{arrayNumbers[1]}{arrayNumbers[2]})" +
                $"{arrayNumbers[3]}{arrayNumbers[4]}{arrayNumbers[5]}-" +
                $"{arrayNumbers[6]}{arrayNumbers[7]}{arrayNumbers[8]}{arrayNumbers[9]}";

            return formatNumber;
        }
        
        public override string ToString()
        {
            //ToString for initial testing
            return $"Type: {CallType}\nDate: {CallDate}\nTime: {CallTime}\nDuration: " + 
                $"{CallDuration}\nFrom Number: {CallFromNumber}\nTo Number: {CallToNumber}" + 
                $"\nCall Complete?: {CallCompletedStatus}\nCost: ${Cost}\n";
        }
    }
}
