using Newtonsoft.Json;
using System.Net;

namespace AEMETData.Core.Models
{
    public class AEMETResponse
    {
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("estado")]
        public HttpStatusCode Estado { get; set; }

        [JsonProperty("datos")]
        public string Datos { get; set; }

        [JsonProperty("metadatos")]
        public string Metadatos { get; set; }
    }
}