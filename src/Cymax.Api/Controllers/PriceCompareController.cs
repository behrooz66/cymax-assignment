using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Cymax.Api.Dtos;
using Cymax.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace Cymax.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCompareController : ControllerBase
    {
        public PriceCompareController()
        {
            // initiations... 
        }

        [HttpPost("compare")]
        public async Task<double> GetPrices(PriceCompareDto model)
        {
            var api1Client = new HttpClient();

            var httpRequest1 = RequestCreator.CreateApi1Request(model);
            var httpRequest2 = RequestCreator.CreateApi2Request(model);
            var httpRequest3 = RequestCreator.CreateApi3Request(model);

            var taskList = new List<Task<HttpResponseMessage>> {
                api1Client.SendAsync(httpRequest1),
                api1Client.SendAsync(httpRequest2),
                api1Client.SendAsync(httpRequest3)
            };

            var result = await Task.WhenAll(taskList);
            var prices = new List<double>();

            prices.Add(await ResultExtractor.Api1ResponseExtract(result[0]));
            prices.Add(await ResultExtractor.Api2ResponseExtract(result[1]));
            prices.Add(await ResultExtractor.Api3ResponseExtract(result[2]));

            return prices.Min();
        }




    }
}