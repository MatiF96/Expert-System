using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.DTO
{
    public class TrainingResult
    {
        public float TrainingDatasetScore { get; set; }
        public float TestDatasetScore { get; set; }
        public int CompletedEpochs { get; set; }
        public double TrainingTime { get; set; }
        public List<EvaulationResult> ValidationReports { get; set; }
        public List<EvaulationResult> TestReports { get; set; }

    }

    public class EvaulationResult
    {
        public float Cost { get; set; }
        public float Accuraty { get; set; }
    }
}
