using CodingChallenge.Controllers;
using CodingChallenge.Data;
using CodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CodingChallengeTests
{
    public class BasicTests
    : IClassFixture<WebApplicationFactory<CodingChallenge.Startup>>
    {
        private readonly WebApplicationFactory<CodingChallenge.Startup> _factory;

        public BasicTests(WebApplicationFactory<CodingChallenge.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task Get_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
