using NeuralNetworkNET.APIs.Interfaces;
using NeuralNetworkNET.APIs.Interfaces.Data;
using NeuralNetworkNET.APIs.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.NeuralNetwork
{
    interface INNetwork
    {
        INeuralNetwork Network { get; }
        Task<TrainingSessionResult> Train(ITrainingDataset dataset, int epochs);
        (bool, float) Decide(float[] input);
        Task<(bool, float)> CheckPatient(float[] input);
    }
}
