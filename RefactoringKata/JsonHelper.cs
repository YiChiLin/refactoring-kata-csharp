using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class JsonHelper
    {
        public static string SerializeArray(Dictionary<string, object> obj)
        {
            return "{" + string.Join(", ", obj.Select(prop => string.Format("\"{0}\": {1}", prop.Key, prop.Value)).ToArray()) + "}";
        }


        public static string SerializeObj(Dictionary<string, object> obj)
        {
            return "{" + string.Join(", ", obj.Select(prop =>
            {
                if (prop.Value is string)
                    return string.Format("\"{0}\": \"{1}\"", prop.Key, prop.Value);
                return string.Format("\"{0}\": {1}", prop.Key, prop.Value);
            }).ToArray()) + "}";
        }
    }
}