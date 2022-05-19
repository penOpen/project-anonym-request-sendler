using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymRequest.Logic.TYPES
{
    public interface ITYPES
    {
        public Task<int> GetTypeIDByValue(string value); 
    }
}
