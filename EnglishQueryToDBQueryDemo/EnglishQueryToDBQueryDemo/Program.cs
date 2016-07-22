using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using EnglishQueryToDBQueryDemo.LuisProxy;
using System.Configuration;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace EnglishQueryToDBQueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DBManager();
            dm.CreateDB();

            dm.ShowRecords();
            
            var id = ConfigurationManager.AppSettings["id"].ToString();
            var subscriptionKey = ConfigurationManager.AppSettings["subscription-key"].ToString();

            var client = new LuisClient(id, subscriptionKey);

            for(;;)
            {
                WriteLine("Please Enter Some Query");
                var query = ReadLine();
                if (string.IsNullOrEmpty(query))
                {
                    continue;
                }

                var response = client.Query(query);
                if (response == null)
                {
                    WriteLine("Not able to understand the query you entered");
                    continue;
                }

                var maxScoreIntent = response.Intents.ToList().Max(x => x.score);
                var maxScoreEntity = response.Entities.ToList().Max(x => x.score);

                var intent = response.Intents.ToList().First(x => x.score == maxScoreIntent);
                var entity = response.Entities.ToList().First(x => x.score == maxScoreEntity);

                var str = entity.entity;
                WriteLine(str);

                //Get the Query to be executed
                //CSharpScript.EvaluateAsync<string>()


                //WriteLine("Query: " + response.Query);
                //response.Intents.ToList().ForEach(x => WriteLine(x.intent + Environment.NewLine + x.score));
                //response.Entities.ToList().ForEach(x => WriteLine(x.entity + Environment.NewLine + x.score));


            }
            



        }
    }
}
