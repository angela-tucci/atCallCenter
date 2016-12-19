using atCallCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atCallCenter.Data
{
    interface ICallData
    {
        //CRUD
        //read
        IEnumerable<CallRecord> GetCalls();
    }
}
