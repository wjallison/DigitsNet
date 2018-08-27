using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DigitsNet
{
    class MyNetwork
    {
        public InputLayer inLayer;
        public OutputLayer outLayer;
        public List<HiddenLayer> hiddenLayers = new List<HiddenLayer>();

        public MyNetwork(int noInputs,int noOutputs,int noHiddenLayers,List<int> sizeOfHiddenLayers)
        {
            inLayer = new InputLayer(noInputs);

            hiddenLayers.Add(new HiddenLayer(inLayer.inputs, sizeOfHiddenLayers[0]));
            for (int i = 1; i < noHiddenLayers; i++)
            {
                hiddenLayers.Add(new HiddenLayer(hiddenLayers[i-1].outputs, sizeOfHiddenLayers[i]));
            }
        }
    }
    class InputLayer
    {
        //public List<double> inputs = new List<double>();
        //public Matrix<double> inputs;
        public Vector<double> inputs;

        public InputLayer(int noInputs)
        {
            for(int i = 0; i < noInputs; i++)
            {
                //inputs = Matrix<double>.Build.Random(noInputs, 1);
                inputs = Vector<double>.Build.Dense(noInputs);
                
            }
        }
    }
    class OutputLayer
    {

    }
    class HiddenLayer
    {
        //private InputLayer inLayer;
        public List<Neuron> neurons = new List<Neuron>();
        public Vector<double> outputs;

        public HiddenLayer(Vector<double> layerIn, int sizeOfLayer)
        {
            outputs = Vector<double>.Build.Dense(sizeOfLayer);

            for (int i = 0; i < sizeOfLayer; i++)
            {
                neurons.Add(new Neuron(layerIn));
                outputs[i] = neurons[i].result(layerIn);
            }

            
            
        }
    }
    class Neuron
    {
        //public List<double> inputs = new List<double>();
        //public InputLayer inputs;
        //public List<double> weights = new List<double>();
        Vector<double> weights;
        public double bias;

        public Neuron(Vector<double> inLayer)
        {
            //inputs = inLayer;
            weights = Vector<double>.Build.Random(inLayer.Count);
            Random rand = new Random();
            bias = rand.NextDouble();
        }

        public double result(Vector<double> inLayer)
        {
            double res = inLayer.DotProduct(weights) + bias;
            return res;
        }
    }
}
