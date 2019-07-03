using System.Collections.Generic;

namespace MobNetPrefixPH.Models
{
    public class NetworkProvider
    {
        public string Network { get; set; }
        public List<string> Prefixes { get; set; }
    }
}
