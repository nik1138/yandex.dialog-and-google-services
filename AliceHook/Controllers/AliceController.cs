using System;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AliceHook.Engine;
using AliceHook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Son4a.Controllers;

namespace AliceHook.Controllers
{

    [ApiController]
    [Route("/")]
    public class AliceController : ControllerBase
    {


        private static readonly JsonSerializerSettings ConverterSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
        
        [HttpGet]
        public string Get()
        {

            return "It works!";
            

        }

        [HttpPost]


        public Task Post()
        {
            
            State session = new State();
            session.Step = (Step)Person.ID;
            using var reader = new StreamReader(Request.Body);
            var body = reader.ReadToEnd();
            var aliceRequest = JsonConvert.DeserializeObject<AliceRequest>(body, ConverterSettings);
            var aliceResponse = session.HandleRequest(aliceRequest, session);
            var stringResponse = JsonConvert.SerializeObject(aliceResponse, ConverterSettings);
            Person.ID = (int)session.Step;
            return Response.WriteAsync(stringResponse);

        }

    }
}