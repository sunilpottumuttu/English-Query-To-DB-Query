using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace Luis
{
    public class LuisClient
    {
        private string __id;
        private string __subscriptionKey;
       

        public LuisClient(string id, string subscriptionKey)
        {
            this.__id = id;
            this.__subscriptionKey = subscriptionKey;

        }

        public LuisResponse Query(string query)
        {
            var id = HttpUtility.UrlEncode(this.__id);
            var subscriptionKey = HttpUtility.UrlEncode(this.__subscriptionKey);
            var q = HttpUtility.UrlEncode(query);

            var uri = $"https://api.projectoxford.ai/luis/v1/application?id={id}&subscription-key={subscriptionKey}&q={q}";

            string json;
            using (HttpClient client = new HttpClient())
            {
                json = client.GetStringAsync(uri).Result;  //we prefer blocking calls
            }
            try
            {
                var response = JsonConvert.DeserializeObject<LuisResponse>(json);
                return response;
            }
            catch (JsonException ex)
            {
                return null;
            }
        }

        public string DBQuery(LuisResponse response)
        {
            var result = string.Empty;



            return result;
        }

    }
}
