using NeuralNetworkNET.APIs.Interfaces;
using NeuralNetworkNET.APIs.Interfaces.Data;
using NeuralNetworkNET.APIs.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    interface INNetwork
    {
        INeuralNetwork Network { get; }
        Task<TrainingSessionResult> Train(ITrainingDataset dataset);
        bool Decide(float[] input);
    }
}
