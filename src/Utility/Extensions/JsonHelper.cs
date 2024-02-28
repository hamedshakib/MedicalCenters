using Newtonsoft.Json;

namespace Utility.Extensions
{
    public static class JsonHelper
    {
        public static T ToModel<T>(this string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch
            {
                return default(T);
            }
        }

        public static string ToJsonString(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return null;
            }
        }
    }
}
