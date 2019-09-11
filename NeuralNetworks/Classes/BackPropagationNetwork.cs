using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{

  #region Transfer functions and their derivatives

  public enum TransferFunction
  {
    None,
    Sigmoid,
    Linear,
    Gaussian,
    RationalSigmoid,
    TangentHyperbolic
  }

  static class TransferFunctions
  {
    public static double Evaluate(TransferFunction tFunc, double input)
    {
      switch (tFunc)
      {
        case TransferFunction.Sigmoid:
          return sigmoid(input);

        case TransferFunction.Linear:
          return linear(input);

        case TransferFunction.Gaussian:
          return gaussian(input);

        case TransferFunction.RationalSigmoid:
          return rationalsigmoid(input);

        case TransferFunction.TangentHyperbolic:
          return tangenthyperbolic(input);

        case TransferFunction.None:
        default:
          return 0.0;
      }
    }

    public static double EvaluateDerivative(TransferFunction tFunc, double input)
    {
      switch (tFunc)
      {
        case TransferFunction.Sigmoid:
          return sigmoid_derivative(input);

        case TransferFunction.Linear:
          return linear_derivative(input);

        case TransferFunction.Gaussian:
          return gaussian_derivative(input);

        case TransferFunction.RationalSigmoid:
          return rationalsigmoid_derivative(input);

        case TransferFunction.TangentHyperbolic:
          return tangenthyperbolic_derivative(input);
        case TransferFunction.None:
        default:
          return 0.0;
      }
    }

    /* Transfer function definitions */
    private static double sigmoid(double x)
    {
      return 1.0 / (1.0 + Math.Exp(-x));
    }

    private static double sigmoid_derivative(double x)
    {
      return sigmoid(x) * (1 - sigmoid(x));
    }

    private static double linear(double x)
    {
      return x;
    }

    private static double linear_derivative(double x)
    {
      return 1.0;
    }

    private static double gaussian(double x)
    {
      return Math.Exp(-Math.Pow(x, 2));
    }

    private static double gaussian_derivative(double x)
    {
      return -2.0 * x * gaussian(x);
    }

    private static double rationalsigmoid(double x)
    {
      return x / (1.0 + Math.Sqrt(1.0 + x * x));
    }

    private static double rationalsigmoid_derivative(double x)
    {
      double val = Math.Sqrt(1.0 + x * x);
      return 1.0 / (val * (1 + val));
    }

    private static double tangenthyperbolic(double x)
    {
      double val = Math.Exp(-2*x);
      return (1-val)/ (1+val);
    }

    private static double tangenthyperbolic_derivative(double x)
    {
      return 1 - Math.Pow(tangenthyperbolic(x), 2);
    }
  }

  #endregion Transfer functions and their derivatives

  class BackPropagationNetwork
  {

    #region Private Data

    public int layerCount;  //katman sayısı
    public int inputSize;   //girdi sayısı
    public int[] layerSize; //her katmanda kaçtane nöron olduğunu söyler 
    //yani dizinin ilk elemanı ilk arakatmanın nöron sayısını verir girdi katmanı bu diziye dahil edilmeyip ayrı alınacak
    //çünkü girdi katmanını herhangi bir aktivasyon fonksiyonundan geçmeyip ara katmana girdiler ağırlıkla çarpılıp iletilir.
    public TransferFunction[] transferFunction;

    public double[][] layerOutput; // katman çıktısı - ilk indis katmanı ikinci indis o katmanın kaçıncı nöronu olduğunu belirtir.
    public double[][] layerInput; //katman girdisi - ilk indis katmanı ikinci indis o katmanın kaçıncı nöronu olduğunu belirtir.
    public double[][] bias;//eşik degeri - ilk indis katmanı ikinci indis o katmanın kaçıncı nöronuna gelen eşik değeri olduğunu belirtir.
    public double[][] delta; //katmanlardaki nöronlara düşen hata payları - ilk indis katmanı ikinci indis o katmanın kaçıncı nöronu olduğunu belirtir
    public double[][] previousBiasDelta;//eşik değerlerine düşen hata paylarını saklamak için 
    //birsonraki iterasyonda eşik değere düşen yeni hata hesaplanırken momentum katsayısı ile çarpılıp eklenecek 

    public double[][][] weight;//ağırlıklar - ilk indis katmanı ikinci indis bir önceki katmandaki nöronu üçüncü indis katmandaki nöronu belirtir
    //örneğin weights[2][3][1] -> 2. katmandaki 1.nörona bir önceki katmandaki 3.nörondan gelen ağırlıktır.
    public double[][][] previousWeightDelta;//ağırlıklara düşen hatapaylarını saklamak için 
   
    #endregion Private Data

    #region Constructors
    //Normal dağılım gösteren rastgele ağırlıklar ile ağ oluşturulur
    public BackPropagationNetwork(int[] layerSizes, TransferFunction[] transferFunctions)
    {
      // Ağın katmanlarının belirlenmesi
      layerCount = layerSizes.Length - 1; //girdi katmanı hariç katman sayısı
      inputSize = layerSizes[0]; //girdi katmanındaki nöron sayısı
      layerSize = new int[layerCount]; //her katmandaki nöron sayısının tutulacağı dizi(girdi katmanı hariç)

      //katmanların nöron sayısı belirlenir
      for (int i = 0; i < layerCount; i++) 
        layerSize[i] = layerSizes[i + 1];

      //katmanların transfer fonksiyonları belirlenir
      transferFunction = new TransferFunction[layerCount];
      for (int i = 0; i < layerCount; i++)
        transferFunction[i] = transferFunctions[i + 1];

      //Katmandaki nöronların girdi, çıktı, bias, hata, önceki bias, önceki hata, ağırlıklarının belirlenmesi
      bias = new double[layerCount][];
      previousBiasDelta = new double[layerCount][];
      delta = new double[layerCount][];
      layerOutput = new double[layerCount][];
      layerInput = new double[layerCount][];

      weight = new double[layerCount][][];
      previousWeightDelta = new double[layerCount][][];

      // İki boyutlu dizilerin doldurulması
      for (int l = 0; l < layerCount; l++)
      {
        bias[l] = new double[layerSize[l]]; // l.katmandaki nöron sayısı kadar bias oluşturulur.
        previousBiasDelta[l] = new double[layerSize[l]];
        delta[l] = new double[layerSize[l]]; //l.katmandaki nöron sayısı kadar hata oluşturulur.
        layerOutput[l] = new double[layerSize[l]]; //l.katmandaki nöronlar için çıktı oluşturulur.
        layerInput[l] = new double[layerSize[l]]; //l.katmandaki nöronlar için girdi oluşturulur.

        weight[l] = new double[l == 0 ? inputSize : layerSize[l - 1]][];
        previousWeightDelta[l] = new double[l == 0 ? inputSize : layerSize[l - 1]][];

        for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
        {
          weight[l][i] = new double[layerSize[l]];
          previousWeightDelta[l][i] = new double[layerSize[l]];
        }
      }

      // Initialize the weights
      for (int l = 0; l < layerCount; l++)
      {
        for (int j = 0; j < layerSize[l]; j++)
        {
          bias[l][j] = Gaussian.GetRandomGaussian();
          previousBiasDelta[l][j] = 0.0;
          layerOutput[l][j] = 0.0;
          layerInput[l][j] = 0.0;
          delta[l][j] = 0.0;
        }

        for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
        {
          for (int j = 0; j < layerSize[l]; j++)
          {
            weight[l][i][j] = Gaussian.GetRandomGaussian();
            previousWeightDelta[l][i][j] = 0.0;
          }
        }
      }
    }

    //Başlangıç ağırlıkları rastgele seçilerek ağ oluşturulur
    public BackPropagationNetwork(int[] layerSizes, TransferFunction[] transferFunctions, string random)
        {
          // Ağın katmanlarının belirlenmesi
          layerCount = layerSizes.Length - 1; //girdi katmanı hariç katman sayısı
          inputSize = layerSizes[0]; //girdi katmanındaki nöron sayısı
          layerSize = new int[layerCount]; //her katmandaki nöron sayısının tutulacağı dizi(girdi katmanı hariç)

          //katmanların nöron sayısı belirlenir
          for (int i = 0; i < layerCount; i++)
            layerSize[i] = layerSizes[i + 1];

          //katmanların transfer fonksiyonları belirlenir
          transferFunction = new TransferFunction[layerCount];
          for (int i = 0; i < layerCount; i++)
            transferFunction[i] = transferFunctions[i + 1];

          //Katmandaki nöronların girdi, çıktı, bias, hata, önceki bias, önceki hata, ağırlıklarının belirlenmesi
          bias = new double[layerCount][];
          previousBiasDelta = new double[layerCount][];
          delta = new double[layerCount][];
          layerOutput = new double[layerCount][];
          layerInput = new double[layerCount][];

          weight = new double[layerCount][][];
          previousWeightDelta = new double[layerCount][][];

          // İki boyutlu dizilerin doldurulması
          for (int l = 0; l < layerCount; l++)
          {
            bias[l] = new double[layerSize[l]]; // l.katmandaki nöron sayısı kadar bias oluşturulur.
            previousBiasDelta[l] = new double[layerSize[l]];
            delta[l] = new double[layerSize[l]]; //l.katmandaki nöron sayısı kadar hata oluşturulur.
            layerOutput[l] = new double[layerSize[l]]; //l.katmandaki nöronlar için çıktı oluşturulur.
            layerInput[l] = new double[layerSize[l]]; //l.katmandaki nöronlar için girdi oluşturulur.

            weight[l] = new double[l == 0 ? inputSize : layerSize[l - 1]][];
            previousWeightDelta[l] = new double[l == 0 ? inputSize : layerSize[l - 1]][];

            for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
            {
              weight[l][i] = new double[layerSize[l]];
              previousWeightDelta[l][i] = new double[layerSize[l]];
            }
          }
            Random r=new Random();
            for (int l = 0; l < layerCount; l++)
            {
                for (int j = 0; j < layerSize[l]; j++)
                {
                    bias[l][j] =r.NextDouble();
                    previousBiasDelta[l][j] = 0.0;
                    layerInput[l][j] = 0.0;
                    layerOutput[l][j] = 0.0;
                    delta[l][j] = 0.0;
                }

                for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
                {
                    for (int j = 0; j < layerSize[l]; j++)
                    {
                        weight[l][i][j] =r.NextDouble();
                        previousWeightDelta[l][i][j] = 0.0;
                    }
                }
            }
        }

    //Belirlenen başlanıç ağırlıklara göre ağ oluşturulur
    public BackPropagationNetwork(int[] layerSizes, TransferFunction[] transferFunctions, double[][][] initializeweight, double[][] initializeBias) 
        {
            layerCount = layerSizes.Length - 1;//katman sayısının 1 eksiği katman sayısı olarak kabul edilir çünkü girdi katmanı ayrı hesaplanacak
            inputSize = layerSizes[0];//input katmanındaki noron sayısı belirlenir
            layerSize = new int[layerCount];//katmanların noron sayılarını tutan dizi (girdi katmanı hariç)
            for (int i = 0; i < layerCount; i++)
            {
                layerSize[i] = layerSizes[i + 1];//katmanların noron sayıları atanır
            }
            //katmanların transfer fonksiyonları belirlenir
            transferFunction = new TransferFunction[layerCount];
            for (int i = 0; i < layerCount; i++)
              transferFunction[i] = transferFunctions[i + 1];

            bias = new double[layerCount][];
            previousBiasDelta = new double[layerCount][];
            delta = new double[layerCount][];
            layerOutput = new double[layerCount][];
            layerInput = new double[layerCount][];
            weight = new double[layerCount][][];
            previousWeightDelta = new double[layerCount][][];


            for (int i = 0; i < layerCount; i++)
            {
                bias[i] = new double[layerSize[i]];
                previousBiasDelta[i] = new double[layerSize[i]];
                delta[i] = new double[layerSize[i]];
                layerOutput[i] = new double[layerSize[i]];
                layerInput[i] = new double[layerSize[i]];
                weight[i] = new double[i == 0 ? inputSize : layerSize[i - 1]][];
                previousWeightDelta[i] = new double[i == 0 ? inputSize : layerSize[i - 1]][];

                for (int j = 0; j < (i == 0 ? inputSize : layerSize[i - 1]); j++)
                {
                    weight[i][j] = new double[layerSize[i]];
                    previousWeightDelta[i][j] = new double[layerSize[i]];
                }


            }

            for (int l = 0; l < layerCount; l++)
            {
                for (int j = 0; j < layerSize[l]; j++)
                {
                    bias[l][j] = initializeBias[l][j];
                    previousBiasDelta[l][j] = 0.0;
                    layerInput[l][j] = 0.0;
                    layerOutput[l][j] = 0.0;
                    delta[l][j] = 0.0;
                }

                for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
                {
                    for (int j = 0; j < layerSize[l]; j++)
                    {
                        weight[l][i][j] = initializeweight[l][i][j];
                        previousWeightDelta[l][i][j] = 0.0;
                    }
                }
            }
        }

    #endregion Constructors

    #region methods
    public void Run(ref double[] input, out double[] output)
    {
      // Yeterli veri olup olmadığının kontrolü
      //if (input.Length != inputSize)
      //  throw new ArgumentException("Input data is not of the correct dimension.");

      // Çıktı katmanındaki nöron sayısı
      output = new double[layerSize[layerCount - 1]];

      /* Ağın çalıştırılması */
      for (int l = 0; l < layerCount; l++)
      {
        for (int j = 0; j < layerSize[l]; j++)
        {
          double sum = 0.0;
          for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
            sum += weight[l][i][j] * (l == 0 ? input[i] : layerOutput[l - 1][i]); //girdi değerleri ile agırlıklar çarpılıp toplanarak ilgili norondaki net toplam belirlenir

          sum += bias[l][j]; //eşik değeri bu toplama eklenir
          layerInput[l][j] = sum;//katmanın girdisine atanır bir sonrakinde girdi olarak hesaplanması için

          layerOutput[l][j] = TransferFunctions.Evaluate(transferFunction[l], sum);//aktivasyon fonksiyonundan geçerek noronun çıktısı belirlenir.
        }
      }

      //son(çıkış) katmanın çıktısı ağın çıktısı olarak atanır
      for (int i = 0; i < layerSize[layerCount - 1]; i++)
        output[i] = layerOutput[layerCount - 1][i];
    }

    //ağın eğitilmesi backpropagation
    public double Train(ref double[] input, ref double[] desired, double TrainingRate, double Momentum)
    {
            // Local variable
            double error = 0.0, sum = 0.0, weightDelta = 0.0, biasDelta = 0.0;
      double[] output = new double[layerSize[layerCount - 1]];

      // Ağın çalıştırılması
      Run(ref input, out output);

      // Hatayı geri yaymak
      for (int l = layerCount - 1; l >= 0; l--)
      {
        // Çıktı katmanı
        if (l == layerCount - 1)
        {
          for (int k = 0; k < layerSize[l]; k++)
          {
            delta[l][k] = output[k] - desired[k];
            error += Math.Pow(delta[l][k], 2);
            delta[l][k] *= TransferFunctions.EvaluateDerivative(transferFunction[l],
                                      layerInput[l][k]);
          }
        }
        else // Gizli katman
        {
          for (int i = 0; i < layerSize[l]; i++)
          {
            sum = 0.0;
            for (int j = 0; j < layerSize[l + 1]; j++)
            {
              sum += weight[l + 1][i][j] * delta[l + 1][j];
            }
            sum *= TransferFunctions.EvaluateDerivative(transferFunction[l], layerInput[l][i]);

            delta[l][i] = sum;
          }
        }
      }

      // Ağırlıklar ve bias değerlerinin güncellenmesi
      for (int l = 0; l < layerCount; l++)
        for (int i = 0; i < (l == 0 ? inputSize : layerSize[l - 1]); i++)
          for (int j = 0; j < layerSize[l]; j++)
          {
            weightDelta = TrainingRate * delta[l][j] * (l == 0 ? input[i] : layerOutput[l - 1][i])
                            + Momentum * previousWeightDelta[l][i][j];
            weight[l][i][j] -= weightDelta;

            previousWeightDelta[l][i][j] = weightDelta;
          }

      for (int l = 0; l < layerCount; l++)
        for (int i = 0; i < layerSize[l]; i++)
        {
          biasDelta = TrainingRate * delta[l][i];
          bias[l][i] -= biasDelta + Momentum * previousBiasDelta[l][i];

          previousBiasDelta[l][i] = biasDelta;
        }

      return error;
    }

     #endregion methods

    }

    public static class Gaussian
  {
    private static Random gen = new Random();

    public static double GetRandomGaussian()
    {
      return GetRandomGaussian(0.0, 1.0);
    }

    public static double GetRandomGaussian(double mean, double stddev)
    {
      double rVal1, rVal2;

      GetRandomGaussian(mean, stddev, out rVal1, out rVal2);

      return rVal1;
    }

    public static void GetRandomGaussian(double mean, double stddev, out double val1, out double val2)
    {
      double u, v, s, t;

      do
      {
        u = 2 * gen.NextDouble() - 1;
        v = 2 * gen.NextDouble() - 1;
      } while (u * u + v * v > 1 || (u == 0 && v == 0));

      s = u * u + v * v;
      t = Math.Sqrt((-2.0 * Math.Log(s)) / s);

      val1 = stddev * u * t + mean;
      val2 = stddev * v * t + mean;
    }
  }

    public static class EXT
    {
        public static bool TryParseDouble(this string str, out double value)
        {
            return double.TryParse(str.Replace(',', '.'), out value);
        }

        public static T Parse<T>(this TextBox box, Func<string, T> f, T defVal)
        {
            try
            {
                box.BackColor = Color.White;
                var val = f(box.Text.Replace('.', ','));
                Console.WriteLine($@"#{box.Name} set to {val}");
                return val;
            }
            catch { box.BackColor = Color.Red; }
            return defVal;
        }

        public static int ParseInt(this TextBox box, int def) => Parse<int>(box, int.Parse, def);

        public static double ParseDouble
                (this TextBox box, double def) => Parse<double>(box, double.Parse, def);

        public static float ParseDouble
                (this TextBox box, float def) => Parse<float>(box, float.Parse, def);
    }

    public static class TextBoxExt
    {
        private static readonly FieldInfo _field;
        private static readonly PropertyInfo _prop;

        static TextBoxExt()
        {
            Type type = typeof(Control);
            _field = type.GetField("text", BindingFlags.Instance | BindingFlags.NonPublic);
            _prop = type.GetProperty("WindowText", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static void SetText(this TextBox box, string text)
        {
            _field.SetValue(box, text);
            _prop.SetValue(box, text, null);
        }
    }
}
