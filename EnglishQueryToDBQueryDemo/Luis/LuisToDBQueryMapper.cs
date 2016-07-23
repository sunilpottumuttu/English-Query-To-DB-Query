using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luis
{
    public class LuisToDBQueryMapper
    {
        public string Intent { get; set; }
        public string Entity { get; set; }
        public string DBQuery { get; set; }
    }
}
