using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using ISC.Api.Web;
using System.Threading.Tasks;
using System.Net;

namespace ISC.Api.Test.Test
{
    public class ApiTest
    {
        private readonly HttpClient _client;

        public ApiTest()
        {
            var server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET", "", "")]
        public async Task UsuarioTestAsync(string Method, string login, string senha) {
            var request = new HttpRequestMessage(new HttpMethod(Method), "Api/Usuario/Login?login="+ login +"&&senha="+ senha +"");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
