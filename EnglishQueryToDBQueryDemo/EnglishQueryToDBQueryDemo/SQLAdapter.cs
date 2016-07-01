using Syn.Bot.Siml.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syn.Bot.Siml;
using System.Xml.Linq;

namespace EnglishQueryToDBQueryDemo
{
    public class SQLAdapter : IAdapter
    {
        public bool IsRecursive
        {
            get
            {
                return true;
            }
        }

        public XName TagName
        {
            get
            {
                return Specification.Namespace.X + "Sql";
            }
        }

        public string Evaluate(Context context)
        {
            
        }
    }
}
