using System.Collections.Generic;

namespace DriveLogCode.Objects
{
    // Classes and Atributes in danish to ease the deserializing from json.
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
