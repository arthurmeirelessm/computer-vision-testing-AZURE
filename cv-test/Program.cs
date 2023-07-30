using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;
using DotNetEnv;
using static System.Net.WebRequestMethods;
using cv_test;
using cv_test.Interfaces;

class Program
{
    static string subscriptionKey = Environment.GetEnvironmentVariable("SUBSCRIPTION_KEY") ?? string.Empty;
    static string endpoint = Environment.GetEnvironmentVariable("ENDPOINT") ?? string.Empty;
    static string imageURL = Environment.GetEnvironmentVariable("IMAGE_URL") ?? string.Empty;


    static void Main(string[] args)
    {

        DotNetEnv.Env.Load();

        cv_test.Interfaces.IComputerVisionClient computerVisionClient = new ComputerVisionClientWrapper(endpoint, subscriptionKey);

        computerVisionClient.AnalyseImageOrigin(imageURL).Wait();
    }
}