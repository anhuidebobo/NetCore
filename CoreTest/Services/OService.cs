using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Services
{
    public class OService : IService
    {
        public string GetName()
        {
            return "oservice";
        }
    }
}
