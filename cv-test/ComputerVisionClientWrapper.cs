using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cv_test.Interfaces;
using Newtonsoft.Json;

namespace cv_test
{
    public class ComputerVisionClientWrapper : Interfaces.IComputerVisionClient
    {
        private readonly ComputerVisionClient _client;

        public ComputerVisionClientWrapper(string endpoint, string subscriptionKey)
        {
            _client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };
        }
        public async Task<ImageAnalysis> AnalyseImageOrigin(string imageUrl)
        {
            List<VisualFeatureTypes?> visualFeatureTypes = new List<VisualFeatureTypes?>()
        { 
                 VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
                 VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
                 VisualFeatureTypes.Tags, VisualFeatureTypes.Adult,
                 VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
                 VisualFeatureTypes.Objects
        };


            ImageAnalysis results = await _client.AnalyzeImageAsync(imageUrl, visualFeatures: visualFeatureTypes);

            string resultConvertToJson = JsonConvert.SerializeObject(results);

            await Console.Out.WriteLineAsync(resultConvertToJson);

            return results;
        }
    }
}
