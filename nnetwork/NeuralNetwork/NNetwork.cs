using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNetworkNET.APIs;
using NeuralNetworkNET.APIs.Enums;
using NeuralNetworkNET.APIs.Interfaces;
using NeuralNetworkNET.APIs.Interfaces.Data;
using NeuralNetworkNET.APIs.Results;
using NeuralNetworkNET.APIs.Structs;

namespace NeuralNet
{
    class NNetwork : INNetwork
    {
        public INeuralNetwork Network { get; set; }
        public NNetwork()
        {
            Network = NetworkManager.NewSequential(TensorInfo.Linear(8),
                NetworkLayers.FullyConnected(10, ActivationType.Tanh),
                NetworkLayers.FullyConnected(10, ActivationType.Tanh),
                NetworkLayers.Softmax(2));
        }

        public async Task<TrainingSessionResult> Train(ITrainingDataset dataset)
        {
            return await NetworkManager.TrainNetworkAsync(Network,
                dataset,
                TrainingAlgorithms.AdaDelta(),
                1000, //cykli uczenia
                0.5f,
                null,
                null,
                null,
                null,
                new System.Threading.CancellationToken());
        }

        public bool Decide(float[] input)
        {
            float[] output = Network.Forward(input);
            bool decision = output[0] > 0.5;
            return decision;
        }
    }
}
