using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Configuration;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;
using Luis;

namespace EnglishQueryToDBQueryDemo
{
    class Program
    {

        public static string dbQuery;
        static async void MapToQuery(string intent,string entity)
        {
            //https://gist.github.com/amazedsaint/3828951
            //https://github.com/dotnet/roslyn/wiki/Scripting-API-Samples
            //https://www.jayway.com/2015/05/09/using-roslyn-to-build-a-simple-c-interactive-script-engine/
            //https://blogs.msdn.microsoft.com/csharpfaq/2011/12/02/introduction-to-the-roslyn-scripting-api/
            //http://source.roslyn.codeplex.com/#Microsoft.CodeAnalysis.CSharp.Scripting.UnitTests/ScriptTests.cs
            //http://daveaglick.com/posts/compiler-platform-scripting
            //https://blogs.msdn.microsoft.com/cdndevs/2015/12/01/adding-c-scripting-to-your-development-arsenal-part-1/
            //https://www.snip2code.com/Snippet/761385/Test-Roslyn-Scripting-API--It-s-cool!/
            //http://www.amazedsaint.com/2014/04/csharp6test-creating-tiny-roslyn-app-to.html
            //https://joshvarty.wordpress.com/


            var scriptPath = $@"IntentMapper\{intent}.csx";

            var code = System.IO.File.ReadAllText(scriptPath);

            ScriptOptions scriptOptions = ScriptOptions.Default;

            //Add reference to Assembly
            var luis = typeof(Luis.LuisToDBQueryMapper).Assembly;
            scriptOptions = scriptOptions.AddReferences(luis);

            //Add reference to NameSpaces
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");
            scriptOptions = scriptOptions.AddImports("System.Linq");
            scriptOptions = scriptOptions.AddImports("Luis");

            var returnValue = await CSharpScript.EvaluateAsync<string>(code, scriptOptions,new ScriptParameters() {intentToSearch= intent,entityToSearch=entity });

            dbQuery= returnValue;
        }

        static void Main(string[] args)
        {
            
            var dm = new DBManager();
            dm.CreateDB();

            dm.ShowRecords();

            var id = ConfigurationManager.AppSettings["id"].ToString();
            var subscriptionKey = ConfigurationManager.AppSettings["subscription-key"].ToString();

            var client = new LuisClient(id, subscriptionKey);

            for (;;)
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

                MapToQuery(intent.intent,entity.entity);
                WriteLine(dbQuery);

                dm.Execute(dbQuery);

                //Get the Query to be executed
                //CSharpScript.EvaluateAsync<string>()


                //WriteLine("Query: " + response.Query);
                //response.Intents.ToList().ForEach(x => WriteLine(x.intent + Environment.NewLine + x.score));
                //response.Entities.ToList().ForEach(x => WriteLine(x.entity + Environment.NewLine + x.score));


            }




        }
    }
}
