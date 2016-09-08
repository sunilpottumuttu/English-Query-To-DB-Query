using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS;


namespace EnglishQueryToDBQueryDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var query = new EnglishQuery();
            //query.Predict("what is the weather in tokyo").Wait();
            //var result = query.Result;

            var objWeather = new WeatherApp();

            var luisClient = new LuisClient("f3a00b57-72d0-4817-ad66-f1e2cb739d62", "0412598c6e17402280a6d10d02b0321d", true);
            IntentRouter router = IntentRouter.Setup<WeatherApp>(luisClient);
            Task<bool> taskResult = router.Route("weather in delhi", objWeather);
            taskResult.Wait();

            
            Console.WriteLine("Task Completed");
            Console.ReadLine();
        }


        public static async Task<LuisResult>  Predict(LuisClient client, string sentence)
        {
             LuisResult result = await client.Predict(sentence);
            return result;
        }


    }
}
