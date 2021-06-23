using Microsoft.AspNetCore.Mvc.Testing;
using MVCCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class BasicTest:IClassFixture<WebApplicationFactory<Startup>>
    {
        private WebApplicationFactory<Startup> _factory;
        public BasicTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/Home/Index2")]
        public async Task GetHttpRequest(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("Hello World",response.Content.ReadAsStringAsync().Result );
            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType.ToString());

        }


        [Theory]
        [InlineData("/Home/Index2")]
        public async Task GetHttpRequest2(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("Hello World", response.Content.ReadAsStringAsync().Result);
            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType.ToString());

        }
    }
}
