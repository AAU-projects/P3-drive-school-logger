using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class Kommuner
    {
        public string href { get; set; }
        public string kode { get; set; }
        public string navn { get; set; }
    }

    public class ZipCode
    {
        public string href { get; set; }
        public string nr { get; set; }
        public string navn { get; set; }
        public object stormodtageradresser { get; set; }
        public List<Kommuner> kommuner { get; set; }
    }
}
