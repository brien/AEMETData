using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace AEMETData.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        private readonly IConfiguration _config;
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var myValue = "0";
            myValue = _config.GetValue<string>("message");
            return new string[] { "value1", "value2", myValue };
        }

        // GET api/values/keyfromAEMET
        [HttpGet("{key}")]
        public ActionResult<string> Get(string key)
        {
            var client = new RestClient("https://opendata.aemet.es/opendata/api/valores/climatologicos/inventarioestaciones/todasestaciones/?api_key=" + key);
            client.RemoteCertificateValidationCallback = 
            (sender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            return response.Content.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
