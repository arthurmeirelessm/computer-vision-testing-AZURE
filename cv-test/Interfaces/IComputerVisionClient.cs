using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_test.Interfaces
{
    public interface IComputerVisionClient
    {
         public Task<ImageAnalysis> AnalyseImageOrigin(string imageUrl);
    }
}
