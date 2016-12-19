using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atCallCenter.Model
{
    public struct CallRate
    {
        //constructor for a CallRate
        public CallRate(double local,
                        double longDistanceOffPeak,
                        double longDistancePeak,
                        int peakStart,
                        int peakEnd)
        : this()
        {
            //fields
            LocalRate = local;
            LongDistancePeakRate = longDistancePeak;
            LongDistanceOffPeakRate = longDistanceOffPeak;
            PeakStartTime = peakStart;
            PeakEndTime = peakEnd;
        }
        //properties
        public double LocalRate { get; set; }
        public double LongDistancePeakRate { get; set; }
        public double LongDistanceOffPeakRate { get; set; }
        public int PeakStartTime { get; set; }
        public int PeakEndTime { get; set; }
    }
}
