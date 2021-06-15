using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

using Cymax.Api.Dtos;

using Newtonsoft.Json;

namespace Cymax.Api.Utils
{
    public static class RequestCreator
    {
        public static HttpRequestMessage CreateApi1Request(PriceCompareDto model)
        {
            // depending on the architecture, api URLs will come from a database, etc. 

            var request = new HttpRequestMessage(HttpMethod.Post, "api1Url");
            request.Headers.Add("Authorization", "Bearer whatever_token_for_api_1");
            var body1 = new Api1RequestDto
            {
                ContactAddress = model.Sender,
                WarehouseAddress = model.Receiver,
                CartonDimensions = new double[] { model.Width, model.Length, model.Height }
            };
            var strContent1 = JsonConvert.SerializeObject(body1);
            request.Content = new StringContent(strContent1, Encoding.UTF8, "application/json");
            return request;
        }

        public static HttpRequestMessage CreateApi2Request(PriceCompareDto model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api2Url");
            request.Headers.Add("Authorization", "Bearer whatever_token_for_api_2");
            var body = new Api2RequestDto
            {
                Consignor = model.Sender,
                Consignee = model.Receiver,
                Cartons = new double[] { model.Width, model.Length, model.Height }
            };
            var strContent = JsonConvert.SerializeObject(body);
            request.Content = new StringContent(strContent, Encoding.UTF8, "application/json");

            return request;
        }

        public static HttpRequestMessage CreateApi3Request(PriceCompareDto model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api3Url");
            request.Headers.Add("Authorization", "Bearer whatever_token_for_api_3");
            var body = new Api3RequestDto
            {
                Source = model.Sender,
                Destination = model.Receiver,
                Packages = new double[] { model.Width, model.Length, model.Height }
            };
            var sr = new StringWriter();
            new XmlSerializer(body.GetType()).Serialize(sr, body);
            request.Content = new StringContent(sr.ToString(), Encoding.UTF8, "application/xml");
            return request;
        }
    }
}