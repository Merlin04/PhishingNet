using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.DataModels;
using Newtonsoft.Json;
using ModelAccess;

namespace PhishingNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MLLookupController
    {
        private readonly Access _access;
        
        public MLLookupController()
        {
            _access = new Access();
        }
        
        [HttpPost]
        public string Post([FromBody] PostModel text)
        { 
            ModelOutput output = _access.Predict(text.text);
            return JsonConvert.SerializeObject(output);
        }
    }
}