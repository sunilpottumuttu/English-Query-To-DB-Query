using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace EnglishQueryToDBQueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDB db = new EmployeeDB();
            db.CreateDB();

            var bot = new Syn.Bot.Siml.SimlBot();
            bot.Sets.Add(new NameSet(db));
            bot.Adapters.Add(new SQLAdapter());
            var simlFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "SIML"), "*.siml", SearchOption.AllDirectories);
            foreach (var simlDocument in simlFiles.Select(XDocument.Load))
            {
                bot.AddSiml(simlDocument);
            }




        }
    }
}
