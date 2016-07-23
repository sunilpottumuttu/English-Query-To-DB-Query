//using Luis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EnglishQueryToDBQueryDemo.IntentMapper
//{
//    public class TestWeather
//    {
//        public string GetMapper()
//        {
//            var lst = new List<LuisToDBQueryMapper>
//            {
//                new LuisToDBQueryMapper() {Intent="xyx",DBQuery="asdfads" },
//                new LuisToDBQueryMapper() {Intent="abc",DBQuery="1234" }
//            };
//            var intentToSearch = "xyx";
//            var result = string.Empty;
//            result = lst.Where(x => x.Intent == intentToSearch).Select(x => x.DBQuery).FirstOrDefault();
//            return result;

//        }
//    }
//}
