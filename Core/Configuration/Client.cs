using System.Collections.Generic;

namespace Core.Configuration
{
    public class Client
    {
        public int Id { get; set; }
        public string Script { get; set; }
        // www.arif.com www.arif1.com vb.
        public List<string> Audiences { get; set; }
    }
}
