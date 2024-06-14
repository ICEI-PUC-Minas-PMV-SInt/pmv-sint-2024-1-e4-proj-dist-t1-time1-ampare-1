using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ampare.api.Services;
using Moq;
using Xunit;


namespace ampare.api.Tests
{
    public class CnpjServiceTests
    {
        [Fact]
        public async Task GetCompanyName_Success()
        {
            var httpClientMock = new Mock<HttpClient>();

            httpClientMock
                .Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"nome\":\"Empresa de Teste\"}")
                });

            var cnpjService = new CnpjService(httpClientMock.Object);

            var companyName = await cnpjService.GetCompanyName("12345678000101");

            Assert.Equal("Empresa de Teste", companyName);
        }

        [Fact]
        public async Task GetCompanyName_Error()
        {
            var httpClientMock = new Mock<HttpClient>();

            httpClientMock
                .Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                });

            var cnpjService = new CnpjService(httpClientMock.Object);

            await Assert.ThrowsAsync<HttpRequestException>(() => cnpjService.GetCompanyName("12345678000101"));
        }
    }
}