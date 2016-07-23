var lst = new List<LuisToDBQueryMapper>
{
    new LuisToDBQueryMapper() {Intent="GetWeather",Entity = "cairo" , DBQuery="select * from weather where cityname='cairo'" },
    new LuisToDBQueryMapper() {Intent="GetWeather",Entity = "Chennai" ,DBQuery="select * from weather where cityname='chennai'" },
    new LuisToDBQueryMapper() {Intent="GetWeather",Entity = "Delhi" ,DBQuery="select * from weather where cityname='Delhi'" },
    new LuisToDBQueryMapper() {Intent="GetWeather",Entity = "Mumbai" ,DBQuery="select * from weather where cityname='Mumbai'" },

};
//var intentToSearch = "xyx";
var result = string.Empty;
result = lst.Where(x => x.Intent.ToUpper() == intentToSearch.ToUpper())
    .Where(x => x.Entity.ToUpper()== entityToSearch.ToUpper())
    .Select(x => x.DBQuery).FirstOrDefault();
return result;







