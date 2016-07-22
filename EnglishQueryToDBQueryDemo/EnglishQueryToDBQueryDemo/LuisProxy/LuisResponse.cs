using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishQueryToDBQueryDemo.LuisProxy
{
    public class LuisResponse
    {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }
        [JsonProperty(PropertyName = "intents")]
        public Intent[] Intents { get; private set; }
        [JsonProperty(PropertyName = "entities")]
        public Entity[] Entities { get; private set; }
    }
}
