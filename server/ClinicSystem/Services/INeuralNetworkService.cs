using ClinicSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public interface INeuralNetworkService
    {
        Task<TrainingResult> Train();
        DecisionResult GetDecision(NeuralNetworkInput input);
    }
}
