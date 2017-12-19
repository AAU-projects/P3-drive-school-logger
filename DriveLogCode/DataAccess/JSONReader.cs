using System;
using System.Net;
using System.Text;
using DriveLogCode.Objects;
using Newtonsoft.Json;

namespace DriveLogCode.DataAccess
{
    public static class JSONReader
    {

        /// <summary>
        /// Method used to get city name with a zip code
        /// </summary>
        /// <param name="zip">A valid zip code in Denmark</param>
        /// <returns>Returns the city name matching the zip code</returns>
        public static string GetCity(int zip)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var downloadedString = client.DownloadString($"https://dawa.aws.dk/postnumre/{zip}");
                //Matcing the dowloaded json string with class ZipCode
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


