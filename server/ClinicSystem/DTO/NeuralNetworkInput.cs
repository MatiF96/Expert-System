using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSystem.DTO
{
    public class NeuralNetworkInput
    {
        [Required]
        public float Pregnancies { get; set; }

        [Required]
        public float Glucose { get; set; }

        [Required]
        public float BloodPressure { get; set; }

        [Required]
        public float SkinThickness { get; set; }

        [Required]
        public float Insulin { get; set; }

        [Required]
        public float BMI { get; set; }

        [Required]
        public float DiabetesPedigreeFunction { get; set; }

        [Required]
        public float Age { get; set; }

        public float[] ToInputData()
        {
            return new float[]
            {
                Pregnancies,
                Glucose,
                BloodPressure,
                SkinThickness,
                Insulin,
                BMI,
                DiabetesPedigreeFunction,
                Age
            };
        }
    }
}
