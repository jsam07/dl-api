
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace JSONReplacer;

public class JsonReplacer
{
    public static string Replace(string payload, string old, string replacement){
        if(old == "") {
            return payload;
        }
        
        return payload.Replace(old, replacement);
    }
}
