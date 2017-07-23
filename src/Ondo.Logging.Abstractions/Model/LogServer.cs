using System.Collections.Generic;

namespace Ondo.Logging.Abstractions
{
    public class LogServer : CommonOptions
    {
        public List<Servers> Servers { get; set; } = new List<Servers>() { new Servers() { Type = Defaults.ServerType.Seq.ToString(), Url = Defaults.SEQ_URL } };

        public LogServer()
        {
            this.Include = Defaults.INCLUDE_LOG_SERVER;
        }
    }

    public class Servers
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }
}
