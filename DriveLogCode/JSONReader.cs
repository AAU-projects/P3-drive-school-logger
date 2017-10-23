using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DriveLogCode
{
    public static class JSONReader
    {
        public static string GetCity(int zip)
        {
            WebClient client = new WebClient();
            String downloadedString = client.DownloadString("https://dawa.aws.dk/postnumre?nr=8600");
            RootObject r = JsonConvert.DeserializeObject<RootObject>(downloadedString);

            return r.navn;
        }
    }
}


