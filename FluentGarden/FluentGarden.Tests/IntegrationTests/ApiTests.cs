using FluentAssertions;
using FluentGarden.Provider.Models.Requests;
using FluentGarden.Provider.Models.Response;
using FluentGarden.Tests.Base;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace FluentGarden.Tests.IntegrationTests;

public class ApiTests : IntegrationTest
{
    [TestCase("/devices")]
    public async Task ShouldAddDevice(string endpoint)
    {
        //Given
        string expectedMacAddress = "00-B0-D0-63-C2-26";
        DeviceRequest request = new(expectedMacAddress, "EsP32");

        //When
        var response = await HttpClient.PostAsJsonAsync(endpoint, request);
        string responseContent = await response.Content.ReadAsStringAsync();
        var outcome = JsonSerializer.Deserialize<DeviceResponse>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        //Then
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        outcome.MacAddress.Should().Be(expectedMacAddress);
    }
}