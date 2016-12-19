using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atCallCenter.Data
{
    class CallRecordFactory
    {
        public static ICallData GetCallRecordRepo(string repoName)
        {
            Type repo = Type.GetType("atCallCenter.Data." + repoName);//gets the actual type
            return (ICallData)Activator.CreateInstance(repo);//returns an instance of the type
        }
    }
}
