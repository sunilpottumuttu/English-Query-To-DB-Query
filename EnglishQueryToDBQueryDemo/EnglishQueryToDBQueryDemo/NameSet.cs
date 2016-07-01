using Syn.Bot.Siml.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQueryToDBQueryDemo
{
    public class NameSet : ISet
    {
        private readonly HashSet<string> _nameSet;
        public NameSet(EmployeeDB db)
        {
            _nameSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            db.Command.CommandText = "SELECT * FROM EMPLOYEES";
            var reader = db.Command.ExecuteReader();
            while (reader.Read())
            {
                _nameSet.Add(reader["name"].ToString());
            }
            reader.Close();
        }
        public bool Contains(string item)
        {
            return _nameSet.Contains(item);
        }
        public string Name { get { return "Emp-Name"; } }
        public IEnumerable<string> Values { get { return _nameSet; } }
    }
}
