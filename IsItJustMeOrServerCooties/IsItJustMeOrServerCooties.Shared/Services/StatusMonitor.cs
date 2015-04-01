using IsItJustMeOrServerCooties.Data;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IsItJustMeOrServerCooties.Services
{
    public static class StatusMonitor
    {
        private static readonly String[] Hosts =
        {
            "isitjustmeorservercooti.es",
            "isitjusmeorservercooties.com",
            "isitjustmeorservercooties.com",
            "servercooties.com"
        };

        private const String DataPath = "index.json";

        public static async Task<DiscoStatus> GetCurrentStatus()
        {
            foreach (var request in from host in Hosts
                                    let uri = String.Format("http://{0}/{1}", host, DataPath)
                                    select WebRequest.CreateHttp(uri))
            {
                try
                {
                    using (var response = await request.GetResponseAsync())
                    {
                        var data = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        return JsonConvert.DeserializeObject<DiscoStatus>(data);
                    }
                }
                catch
                {
                    request.Abort();
                }
            }
            return null;
        }
    }
}