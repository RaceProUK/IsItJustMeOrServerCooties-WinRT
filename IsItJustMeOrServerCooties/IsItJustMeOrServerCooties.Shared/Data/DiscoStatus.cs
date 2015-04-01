using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace IsItJustMeOrServerCooties.Data
{
    public class DiscoStatus
    {
        [JsonProperty("version")]
        public String Version { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof (IsoDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        [JsonProperty("flavor")]
        public String Message { get; set; }

        [JsonProperty("up")]
        public Boolean IsUp { get; set; }

        [JsonProperty("percentage")]
        public Int32 Percentage { get; set; }

        [JsonProperty("host")]
        public String Host { get; set; }

        [JsonProperty("summary")]
        public List<Summary> Summary { get; set; }
    }

    public class Summary
    {
        [JsonProperty("name")]
        public String Uri { get; set; }

        [JsonProperty("code")]
        public Int32 StatusCode { get; set; }

        [JsonProperty("response")]
        public String Response { get; set; }

        [JsonProperty("responseTime")]
        public Decimal Ping { get; set; }

        [JsonProperty("polledAt")]
        public Int64 LastPolled { get; set; }
    }
}