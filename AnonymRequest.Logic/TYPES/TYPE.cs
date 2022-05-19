using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymRequest.Logic.TYPES
{
    public class TYPE : ITYPES
    {
        private readonly Context _context;
        public TYPE(Context context)
        {
            _context = context;
        }
    
        public async Task<int> GetTypeIDByValue(string value)
        {
            var typeid = await _context.Types.OrderBy(p=>p.value == value).FirstOrDefaultAsync();
            return typeid.Id;
        }
    }
}
