using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeuralNet
{
    class Utilities
    {
        public static string LoadFile(string path)
        {
            string rawData = File.ReadAllText(path);

            return rawData;
        }
        public static float[][] PrepareData(string data)
        {
            string[] entriesSplitted = data.Split('\n', ' ');
            string[] splitted = entriesSplitted.Skip(1).ToArray();
            float[][] preparedData = splitted.Select(s => s.Split(',').Select(f => float.Parse(f, CultureInfo.InvariantCulture)).ToArray()).ToArray();

            return preparedData;
        }

        public static void NormalizeValues(float[][] data)
        {
            float[] max = new float[data[0].Length];
            float[] min = new float[data[0].Length];

            foreach (var set in data)
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (set[i] > max[i])
                    {
                        max[i] = set[i];
                    }
                    if (set[i] < min[i])
                    {
                        min[i] = set[i];
                    }
                }

            }
            foreach (var item in data)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    item[i] = (item[i] - min[i]) / (max[i] - min[i]);
                }
            }

        }
        public static (float[] First, float[] Second)[] FormatData(float[][] data)
        {
            float[][] input = data.Select(row => row[..^1]).ToArray();
            float[][] output2 = data.Select(row => row.Last()).ToArray().Select(Values).ToArray();

            return Enumerable.Zip(input, output2).ToArray();
        }
        public static float[] Values(float val)
        {
            return new float[] { val, 1 - val };
        }

        public static (IEnumerable<(float[] x, float[] y)>, IEnumerable<(float[] x, float[] y)>) CreateSets((float[] First, float[] Second)[] data) 
        {
            Random rnd = new Random();
            var randomize = data.OrderBy(x => rnd.Next()).ToArray();

            var dataLen = data.ToArray().Length;
            int trainingSetLen = (int)Math.Ceiling(0.7 * dataLen);

            var trainingSet = randomize.Take(trainingSetLen);
            var validationSet = randomize.Skip(dataLen - trainingSetLen);

            return (validationSet,trainingSet);
        }
    }
}
