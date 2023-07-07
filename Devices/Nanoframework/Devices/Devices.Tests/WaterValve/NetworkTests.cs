using nanoFramework.TestFramework;
using WaterValve.Models;
using WaterValve.Services;

namespace Devices.Tests.WaterValve
{
    //https://github.com/nanoframework/nanoFramework.Json/blob/main/nanoFramework.Json.Test/JsonUnitTests.cs
    [TestClass]
    public class NetworkTests
    {
        [Setup]
        public void Initialize()
        {
            OutputHelper.WriteLine("NetworkTests tests initialized.");
        }

        [Cleanup]
        public void CleanUp()
        {
            OutputHelper.WriteLine("Cleaning up after NetworkTests.");
        }


        [TestMethod]
        [DataRow("localhost")]
        public void ShouldConnectToHub(string baseRoute)
        {
            //Given
            var service = new NetworkService();
            service.SetBaseRoute(baseRoute);
            var request = new DeviceRequest("123", "esp32", "flowerpots");

            //When
            var output = service.ConnectToHub(request);

            //Then
            Assert.AreEqual(output, "connected");
        }

        //[TestCase("localhost")] //TODO Change
        //public void ShouldConnectToHub(string baseRoute)
        //{
        //    //Given
        //    var service = new NetworkService();
        //    service.SetBaseRoute(baseRoute);
        //    var request = new DeviceRequest("123", "esp32", "flowerpots");

        //    //When
        //    var output = service.ConnectToHub(request);

        //    //Then
        //    output.Should().Be("connected");
        //}
    }
}