using cv_test.Interfaces;
using Moq;
using DotNetEnv;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using AutoFixture.AutoMoq;
using AutoFixture;
using Newtonsoft.Json;

namespace cv_test.Test
{
    public class ComputerVisionClientTest
    {

        private readonly IComputerVisionClient _client;

        public ComputerVisionClientTest(IComputerVisionClient client)
        {
            _client = client;
        }

        static string imageUrl = Environment.GetEnvironmentVariable("IMAGE_URL") ?? string.Empty;


        [Fact]
        public async Task Test1()
        {

            DotNetEnv.Env.Load();

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var computerVisionClient = fixture.Freeze<Mock<IComputerVisionClient>>();


            var mockCaptions = new MockClass.Captions { text = "a city with tall buildings", confidence = 0.48468858003616333 };
            var mockDescription = new MockClass.Description { tags = new List<string> { "outdoor", "city", "white" }, captions = new List<MockClass.Captions> { mockCaptions } };
            var mockMetadata = new MockClass.Metadata { height = 300, width = 239, format = "Png" };
            var mockApplication = new MockClass.Application { description = mockDescription, requestId = "7e5e5cac-ef16-43ca-a0c4-02bd49d379e9", metadata = mockMetadata, modelVersion = "2021-05-01" };

            string jsonMockApplication = JsonConvert.SerializeObject(mockApplication);

            computerVisionClient
                .Setup(vs => vs.AnalyseImageOrigin(imageUrl))
                .ReturnsAsync(new ImageAnalysis { ModelVersion = jsonMockApplication});

            // Act

            var result = await _client.AnalyseImageOrigin(imageUrl);

            string convertResultToJson = JsonConvert.SerializeObject(result);

            // Assert 

            Assert.NotNull(result);
            Assert.Equal(jsonMockApplication, convertResultToJson);

        }
    }
}