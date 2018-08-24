using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DigitsNet
{
    class Program
    {
        static void Main(string[] args)
        {











            Console.ReadKey();
        }
        public double sigmoid(double z)
        {
            return 1.0 / (1.0 + Math.Pow(2.71828, z));
        }
    }
    public class Network
    {
        List<Matrix<double>> weights = new List<Matrix<double>>();
        List<Matrix<double>> biases = new List<Matrix<double>>();
        int numLayers;

        public Network(List<int> sizes)
        {
            numLayers = sizes.Count();

            for(int i = 1; i < numLayers; i++)
            {
                biases.Add(Matrix<double>.Build.Random(sizes[i], 1));
            }

            for(int i = 1;i < numLayers; i++)
            {
                weights.Add(Matrix<double>.Build.Random(sizes[i], sizes[i - 1]));
            }

        }
    }
}
