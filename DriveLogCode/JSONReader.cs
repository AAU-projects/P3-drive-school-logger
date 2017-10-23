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
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var downloadedString = client.DownloadString($"https://dawa.aws.dk/postnumre/{zip}");
                ZipCode r = JsonConvert.DeserializeObject<ZipCode>(downloadedString);

                return r.navn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}


