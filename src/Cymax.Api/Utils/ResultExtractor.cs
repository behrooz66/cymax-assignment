using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Cymax.Api.Dtos;

using Newtonsoft.Json.Linq;

namespace Cymax.Api.Utils
{
    public static class ResultExtractor
    {

        public static async Task<double> Api1ResponseExtract(HttpResponseMessage responseMessage)
        {
            var val = JObject.Parse(await responseMessage.Content.ReadAsStringAsync());
            return val["total"].Value<double>();
        }

        public static async Task<double> Api2ResponseExtract(HttpResponseMessage responseMessage)
        {
            var val = JObject.Parse(await responseMessage.Content.ReadAsStringAsync());
            return val["amount"].Value<double>();
        }

        public static async Task<double> Api3ResponseExtract(HttpResponseMessage responseMessage)
        {
            var sr = new StringReader(await responseMessage.Content.ReadAsStringAsync());
            var xml = new XmlSerializer(typeof(Api3ResponseDto));
            var resp = (Api3ResponseDto)xml.Deserialize(sr);
            return resp.Quote;
        }
    }
}