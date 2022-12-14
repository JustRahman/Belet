using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belet.Model.Media
{
    class MediaDatum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("attributes")]
        public PurpleAttributes Attributes { get; set; }
    }
}
