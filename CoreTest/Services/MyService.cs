using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Services
{
    public class MyService : IService
    {
        public string GetName()
        {
            return "myservice";
        }
    }
}
