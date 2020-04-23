using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Services
{
    public interface IService
    {
        public IEnumerable<String> GetPrescriptions();
    }
}
