using System;
using Xunit;
using cymax.api;
using Cymax.Api.Dtos;
using Cymax.Api.Utils;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace cymax.api.tests
{
    public class RequestCreatorTests
    {
        PriceCompareDto pc;

        public RequestCreatorTests()
        {
            pc = new PriceCompareDto
            {
                Height = 10,
                Length = 5.5,
                Width = 2.4,
                Receiver = "receiver",
                Sender = "sender"
            };
        }

        [Fact]
        public void CreateApi1Request_Contain_Auth_Header()
        {
            var req = RequestCreator.CreateApi1Request(pc);
            var headers = req.Headers.GetValues("Authorization");
            Assert.Contains("Bearer whatever_token_for_api_1", headers);
        }

        [Fact]
        public async Task CreateApi1Request_Body()
        {
            var req = RequestCreator.CreateApi1Request(pc);
            var body = await req.Content.ReadAsStringAsync();
            var dto = JObject.Parse(body);
            Assert.Equal("sender", dto["ContactAddress"].Value<string>());
        }

    }
}
