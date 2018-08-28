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
    public class ReadMNIST
    {
        public List<List<Matrix<double>>> allData = new List<List<Matrix<double>>>();

        public ReadMNIST()
        {
            FileStream ifsLabels = new FileStream(System.IO.Directory.GetCurrentDirectory() + @"\train-labels.idx1-ubyte", FileMode.Open);
            FileStream ifsImages = new FileStream(System.IO.Directory.GetCurrentDirectory() + @"\train-images.idx3-ubyte", FileMode.Open);

            List<byte[][]> allPixels = new List<byte[][]>();
            List<byte> allLabels = new List<byte>();

            BinaryReader brLabels = new BinaryReader(ifsLabels);
            BinaryReader brImages = new BinaryReader(ifsImages);

            int magic1 = brImages.ReadInt32();
            int numImages = brImages.ReadInt32();
            int numRows = brImages.ReadInt32();
            int numCols = brImages.ReadInt32();

            int magic2 = brLabels.ReadInt32();
            int numLabels = brLabels.ReadInt32();

            byte[][] pixels = new byte[28][];
            for(int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = new byte[28];
            }

            for(int di = 0; di < 10000; di++)
            {
                allData.Add(new List<Matrix<double>>());
                Matrix<double> m = Matrix<double>.Build.Dense(28, 28);
                Matrix<double> l = Matrix<double>.Build.Dense(10, 1);


                for (int i = 0; i < 28; i++)
                {
                    for(int j = 0; j < 28; j++)
                    {
                        byte b = brImages.ReadByte();
                        pixels[i][j] = b;
                        m[i,j] = Convert.ToDouble(b);
                    }
                }

                byte lbl = brLabels.ReadByte();
                int ind = Convert.ToInt32(lbl);
                l[ind, 0] = 1;

                allData[di].Add(m);
                allData[di].Add(l);


                //allPixels.Add(pixels);
                //allLabels.Add(lbl);
                //DigitImage dImage = new DigitImage(pixels, lbl);
            }

            

            ifsImages.Close();
            brImages.Close();
            ifsLabels.Close();
            brLabels.Close();


        }
    }
}
