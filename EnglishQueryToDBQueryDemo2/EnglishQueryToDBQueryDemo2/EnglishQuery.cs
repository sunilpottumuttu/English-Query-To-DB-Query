using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS;

namespace EnglishQueryToDBQueryDemo2
{

   

    public class EnglishQuery
    {
        private string _appId = "f3a00b57-72d0-4817-ad66-f1e2cb739d62";
        private string _subscriptionKey = "0412598c6e17402280a6d10d02b0321d";
        private LuisClient _client;
        private LuisResult __result;
        public LuisResult Result { get { return __result; }  }
        

        public EnglishQuery()
        {
            this._client = new LuisClient(_appId, _subscriptionKey, true);
        }

        public async Task Predict(string sentence)
        {
            __result = await _client.Predict(sentence);
        }

        

    }
}
