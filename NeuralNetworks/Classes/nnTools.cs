using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using NeuralNetworks;
using NeuralNetworks.Forms;

namespace NNTOOLS
{
    class nnTools
    {
        string problemType = ((fNN)Application.OpenForms["fNN"]).ProblemType.TrimEnd(); 
            
        public enum Normalization
        {
            None,
            Linear,
            MaxMin,
            ZScore
        }

        public static class Normalizations
        {
            public static DataTable Evaluate(Normalization Norm, ref double[][] input, ref double[][] output)
            {
                switch (Norm)
                {
                    case Normalization.Linear:
                        {
                             Linear(ref input, ref output);
                            return ConvertArrayToTable(ref input, ref output);
                        }
                      case Normalization.MaxMin:
                        {
                            MaxMin(ref input, ref output);
                            return ConvertArrayToTable(ref input, ref output);
                        }
                       

                    case Normalization.ZScore:
                        {
                            ZScore(ref input, ref output);
                            return ConvertArrayToTable(ref input, ref output);
                        }
                    default:
                        return ConvertArrayToTable(ref input, ref output);
                }
            }
            //private static void None()
            //{
            //    return;
            //}
            private static void Linear(ref double[][] input, ref double[][] output)
            {
                List<double> maximumInputList = new List<double>();
                List<double> maximumOutputList = new List<double>();
                           
                for (int j = 0; j < input[0].Length; j++)
                {                                        
                    double max = double.MinValue;
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        if (max < input[i][j]) max = input[i][j];
                    }
                    maximumInputList.Add(max);
                }

                for (int i = 0; i < input.GetLength(0); i++)
                {
                    for (int j = 0; j < input[0].Length; j++)
                    {
                        input[i][j] = Math.Round(input[i][j] / maximumInputList[j], 5);
                    }

                }
                if (((fNN)Application.OpenForms["fNN"]).ProblemType.TrimEnd() == "Approximation")
                {
                    for (int j = 0; j < output[0].Length; j++)
                    {
                        double max = double.MinValue;
                        for (int i = 0; i < output.GetLength(0); i++)
                        {
                            if (max < output[i][j]) max = output[i][j];
                        }
                        maximumOutputList.Add(max);
                    }

                    for (int i = 0; i < output.GetLength(0); i++)
                    {
                        for (int j = 0; j < output[0].Length; j++)
                        {
                            output[i][j] = Math.Round(output[i][j] / maximumOutputList[j], 5);
                        }

                    }
                }
     

            }

            private static void MaxMin(ref double[][] input, ref double[][] output)
            {
                List<double> maximumInputList = new List<double>();
                List<double> minimumInputList= new List<double>();
             
                for (int j = 0; j < input[0].Length; j++)//i ve j ters çünkü sutun bazında her özelliğin max ve min değeri bulunur
                {
                    double max = double.MinValue;
                    double min = double.MaxValue;
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        if (max < input[i][j]) max = input[i][j];
                        if (min > input[i][j]) min = input[i][j];
                    }
                    maximumInputList.Add(max);
                    minimumInputList.Add(min);
                }

                for (int i = 0; i < input.GetLength(0); i++)
                {
                    for (int j = 0; j < input[0].Length; j++)
                    {
                        if (maximumInputList[j] == minimumInputList[j]) input[i][j] = input[i][j];
                        else
                        {
                            input[i][j] = Math.Round((input[i][j] - minimumInputList[j]) / (maximumInputList[j] - minimumInputList[j]), 5);
                        }

                    }
                }
                if (((fNN)Application.OpenForms["fNN"]).ProblemType.TrimEnd() == "Approximation")
                {
                    List<double> maximumOutputList = new List<double>();
                    List<double> minimumOutputList = new List<double>();
                    for (int j = 0; j < output[0].Length; j++)//i ve j ters çünkü sutun bazında her özelliğin max ve min değeri bulunur
                    {
                        double max = double.MinValue;
                        double min = double.MaxValue;
                        for (int i = 0; i < output.GetLength(0); i++)
                        {
                            if (max < output[i][j]) max = output[i][j];
                            if (min > output[i][j]) min = output[i][j];
                        }
                        maximumOutputList.Add(max);
                        minimumOutputList.Add(min);
                    }

                    for (int i = 0; i < output.GetLength(0); i++)
                    {
                        for (int j = 0; j < output[0].Length; j++)
                        {
                            if (maximumOutputList[j] == minimumOutputList[j]) output[i][j] = output[i][j];
                            else
                            {
                                output[i][j] = Math.Round((output[i][j] - minimumOutputList[j]) / (maximumOutputList[j] - minimumOutputList[j]), 5);
                            }

                        }
                    }
                }

            }

            private static void ZScore(ref double[][] input, ref double[][] output)
            {
                List<double> InputMeans = new List<double>();
                List<double> InputStdv = new List<double>();
                double total = 0.0;
                double avg = 0.0;
             
                //herbir özellik için ortalama hesabı
                for (int j = 0; j < input[0].Length; j++)
                {
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        total += input[i][j];
                    }
                    avg = total / input.GetLength(0);
                    InputMeans.Add(avg);
                }
                //herbir özellik(kolon) için standart sapma hesabı
                for (int j = 0; j < input[0].Length; j++)
                {
                    total = 0.0;
                    double stdv = 0.0;
                    for (int i = 0; i < input.GetLength(0); i++)
                    {
                        total += Math.Pow((input[i][j] - InputMeans[j]), 2);
                    }
                    stdv = Math.Sqrt(total / input.GetLength(0));
                    InputStdv.Add(stdv);
                }
                //Z standartlaştırma
                for (int i = 0; i < input.GetLength(0); i++)
                {
                    for (int j = 0; j <input[0].Length; j++)
                    {
                        input[i][j] = Math.Round((input[i][j] - InputMeans[j]) / InputStdv[j], 5);
                    }
                }
                if (((fNN)Application.OpenForms["fNN"]).ProblemType.TrimEnd() == "Approximation")
                {
                    List<double> OutputMeans = new List<double>();
                    List<double> OutputStdv = new List<double>();
                     total = 0.0;
                     avg = 0.0;
                  
                    //herbir özellik için ortalama hesabı
                    for (int j = 0; j < output[0].Length; j++)
                    {
                        for (int i = 0; i < output.GetLength(0); i++)
                        {
                            total += output[i][j];
                        }
                        avg = total / output.GetLength(0);
                        OutputMeans.Add(avg);
                    }
                    //herbir özellik(kolon) için standart sapma hesabı
                    for (int j = 0; j < output[0].Length; j++)
                    {
                        total = 0.0;
                        double stdv = 0.0;
                        for (int i = 0; i < output.GetLength(0); i++)
                        {
                            total += Math.Pow((output[i][j] - OutputMeans[j]), 2);
                        }
                        stdv = Math.Sqrt(total / output.GetLength(0));
                        OutputStdv.Add(stdv);
                    }
                    //Z standartlaştırma
                    for (int i = 0; i < output.GetLength(0); i++)
                    {
                        for (int j = 0; j < output[0].Length; j++)
                        {
                            output[i][j] = Math.Round((output[i][j] - OutputMeans[j]) / OutputStdv[j], 5);
                        }
                    }
                }

            }
        }

        public void Load(string filename, ref double[][] input, ref double[][] output, int outputCount)
        {
            var lines = File.ReadAllLines(filename);
            input= new double[lines.Length][];
            output = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                var sample = lines[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                input[i] = new double[sample.Length-outputCount];
                output[i] = new double[outputCount];
                for (int j = 0; j < input[i].Length; j++)
                {
                    input[i][j] = double.Parse(sample[j]);
                }
                for (int j = 0; j < output[i].Length; j++)
                {
                    output[i][j] = double.Parse(sample[input[i].Length+j]);
                }

            }
        }

        public void Load(string filename, ref double[][] input, ref double[][] output, int outputCount, List<double> list)
        {
            var lines = File.ReadAllLines(filename);
            input = new double[lines.Length][];
            output = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                var sample = lines[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                input[i] = new double[sample.Length - outputCount];
                output[i] = new double[outputCount];
                for (int j = 0; j < input[i].Length; j++)
                {
                    input[i][j] = double.Parse(sample[j]);
                }
                for (int j = 0; j < output[i].Length; j++)
                {
                    output[i][j] = double.Parse(sample[input[i].Length + j]);
                    if (list.Contains(output[i][j]) == false) list.Add(output[i][j]);
                }

            }
        }

        public static DataTable ConvertArrayToTable(ref double[][] input, ref double[][] output)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < input[0].Length; i++)
            {
                dt.Columns.Add(string.Format("Input{0}", i+1), typeof(double));
            }
            for (int i = 0; i < output[0].Length; i++)
            {
                dt.Columns.Add(string.Format("Output{0}", i + 1));
            }
        
            for (int i = 0; i < input.GetLength(0); i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < input[0].Length; j++)
                {
                    dr[j] = input[i][j].ToString();
                }
                for (int j = 0; j < output[0].Length; j++)
                {
                    dr[input[0].Length+j] = output[i][j].ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public  DataTable ConvertArrayToTable(double[][] input,double[][] output)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < input[0].Length; i++)
            {
                dt.Columns.Add(string.Format("Input{0}", i + 1), typeof(double));
            }
            for (int i = 0; i < output[0].Length; i++)
            {
                dt.Columns.Add(string.Format("Output{0}", i + 1));
            }

            for (int i = 0; i < input.GetLength(0); i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < input[0].Length; j++)
                {
                    dr[j] = input[i][j].ToString();
                }
                for (int j = 0; j < output[0].Length; j++)
                {
                    dr[input[0].Length + j] = output[i][j].ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void ConvertTableToArray(DataTable dt,ref double[][]input, ref double[][] output,int outputCount)
        {
            input= new double[dt.Rows.Count][];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                input[i] = new double[dt.Columns.Count - outputCount];
            }
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    input[i][j] = double.Parse(dt.DefaultView[i][j].ToString());
                }
            }
            if (problemType== "Approximation")
            {
                output = new double[dt.Rows.Count][];
                for (int i = 0; i < output.GetLength(0); i++)
                {
                    output[i] = new double[outputCount];
                }
                for (int i = 0; i < output.GetLength(0); i++)
                {
                    for (int j = 0; j < output[i].Length; j++)
                    {
                        output[i][j] = double.Parse(dt.DefaultView[i][input[i].Length + j].ToString());
                    }
                }
            }else
            {
                int classnumber = ((BackPropagation)Application.OpenForms["BackPropagation"]).classnumber;
                output = new double[dt.Rows.Count][];
                for (int i = 0; i < output.GetLength(0); i++)
                {
                    output[i] = new double[classnumber];
                }
                for (int i = 0; i < output.GetLength(0); i++)
                {
                    string[] classifiedOutput = dt.DefaultView[i][dt.Columns.Count - 1].ToString().TrimEnd().Split(' ');
                    output[i] = new double[classifiedOutput.Length];
                    for (int j = 0; j < classifiedOutput.Length; j++)
                    {
                        output[i][j] = double.Parse(classifiedOutput[j]);
                    }
                }
            }
         

        }
                                
        public double[][] OutputClasification(double[][] output, int classnumber)
        {
            double[][] outputs = new double[output.GetLength(0)][];
            for (int i = 0; i < outputs.GetLength(0); i++)
            {
                outputs[i] = new double[classnumber];
                for (int j = 0; j < classnumber; j++)
                {
                    if (output[i][0] == j)//output kolonuna bakılır
                        outputs[i][j] = 1;
                    else
                        outputs[i][j] = 0;
                }
            }
            return outputs;
        }

        public DataTable OutputClasificationDataTable(DataTable dt, double[][] output)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {          
                dt.DefaultView[i][dt.Columns.Count - 1] = string.Join(" ", output[i]);
            }
            return dt;
        }

        public string CreateFolder(string path, string name)
        {
            var date = DateTime.Now.ToString("G").Replace(':', '-');

            string foldername = string.Format(date + "   " + name);

            var folder = Path.Combine(path, foldername);

            Directory.CreateDirectory(folder);

            return folder;
        }

        public string CreateMainFolder(string path, string name)
        {
            string foldername = string.Format(name);

            var folder = Path.Combine(path, foldername);

            Directory.CreateDirectory(folder);

            return folder;
        }

        public List<double> Txt2Weights(string filename)//txt 'den ağırlıkları okunur
        {
            List<double> Weights = new List<double>();
            var lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; i++)
            {
                Weights.Add(double.Parse(lines[i].TrimEnd()));
            }
            return Weights;
        }

        public List<double> Txt2Biases(string filename) //txt'den biaslar okunur
        {
            List<double> Biases = new List<double>();
            var lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Length; i++)
            {
                Biases.Add(double.Parse(lines[i].TrimEnd()));
            }
            return Biases;

        }

        public void MyGridStyle(DataGridView grd)
        {
            for (int i = 0; i < grd.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    grd.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
            }

        }

        public DataTable NotNormalset(DataTable dt,List<int> list)
        {
            List<DataRow> drows = new List<DataRow>();
            for (int i = 0; i < list.Count; i++)
            {
                drows.Add(dt.Rows[list[i]]);
            }
            DataTable dtt=new DataTable();
            if (drows.Count != 0)
                dtt=drows.CopyToDataTable();
            return dtt;
        }

        public void PrintTxt(string filename, DataTable dt)
        {
            try
            {
               if (File.Exists(filename)) File.Delete(filename);

                using (var txt = new StreamWriter(File.Open(filename, FileMode.CreateNew), Encoding.GetEncoding("ibm857")))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string row = string.Empty;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            row += dt.DefaultView[i][j].ToString() + " ";
                        }
                        txt.WriteLine(row);

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(String.Format("There was an error print data to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void PrintTxt(string filename, DataTable dt,string function)
        {
            try
            {
                if (File.Exists(filename)) File.Delete(filename);

                using (var txt = new StreamWriter(File.Open(filename, FileMode.CreateNew), Encoding.GetEncoding("ibm857")))
                {
                    txt.WriteLine(function);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string row = string.Empty;
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            row += dt.DefaultView[i][j].ToString() + " ";
                        }
                        txt.WriteLine(row);

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(String.Format("There was an error print data to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public enum CreateTrainset
        {
            InOrder,
            Random
        }

        public class Trainset
        {
            public static DataTable dtTrain = new DataTable();

            public static List<int> TrainIndex = new List<int>();

            public static DataTable Evaluate(CreateTrainset train, DataTable data, double trainPercent)
            {
                TrainIndex.Clear();
                switch (train)
                {
                    case CreateTrainset.InOrder:
                        return InOrder(data, trainPercent);

                    case CreateTrainset.Random:
                        return Random(data, trainPercent);
                    default:
                        return data;
                }
            }

            public static DataTable InOrder(DataTable data, double trainPercent)
            {
                List<DataRow> drows = new List<DataRow>();
                int count = data.Rows.Count;
                int trainCount = count * (int)trainPercent / 100;
                for (int i = 0; i < trainCount; i++)
                {
                    drows.Add(data.Rows[i]);
                    TrainIndex.Add(i);
                }
                dtTrain = drows.CopyToDataTable();
                return dtTrain;
            }

            public static DataTable Random(DataTable data, double trainPercent)
            {
                List<DataRow> drows = new List<DataRow>();
                int count = data.Rows.Count;
                int trainCount = count * (int)trainPercent / 100;
                Random r = new Random();
                for (int i = 0; i < trainCount; i++)
                {
                    int k = r.Next(0, count);
                    if (TrainIndex.Contains(k)) { i--; continue; }
                    TrainIndex.Add(k);
                    drows.Add(data.Rows[k]);
                }
                dtTrain = drows.CopyToDataTable();
                return dtTrain;
            }

        }

        public enum CreateTestset
        {
            InOrder,
            Random
        }

        public class Testset
        {
            public static DataTable dtTest = new DataTable();
            public static List<int> TestIndex = new List<int>();

            public static DataTable Evaluate(CreateTestset train, DataTable data, double testPercent)
            {
                TestIndex.Clear();
                switch (train)
                {
                    case CreateTestset.InOrder:
                        return InOrder(data, testPercent);

                    case CreateTestset.Random:
                        return Random(data, testPercent);
                    default:
                        return data;
                }
            }

            public static DataTable InOrder(DataTable data, double testPercent)
            {
                List<DataRow> drows = new List<DataRow>();
                int count = data.Rows.Count;
                int trainCount = count * (int)(100 - testPercent) / 100;
                int testCount = count - trainCount;
                for (int i = 0; i < testCount; i++)
                {
                    drows.Add(data.Rows[trainCount + i]);
                    TestIndex.Add(trainCount + i);
                }
                if (drows.Count != 0)
                    dtTest = drows.CopyToDataTable();
                return dtTest;
            }

            public static DataTable Random(DataTable data, double testPercent)
            {
                List<DataRow> drows = new List<DataRow>();
                int count = data.Rows.Count;
                int trainCount = count * (int)(100-testPercent) / 100;
                int testCount = count - trainCount;
                Random r = new Random();
                for (int i = 0; i < testCount; i++)
                {

                    int k = r.Next(0, count);
                    if (Trainset.TrainIndex.Contains(k)) { i--; continue; }
                    drows.Add(data.Rows[k]);
                    TestIndex.Add(k);
                }
                if(drows.Count!=0)
                dtTest = drows.CopyToDataTable();
                return dtTest;
            }

        }

        public class IniFile
        {
            public string path;

            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

            public IniFile(string INIPath)
            {
                path = INIPath;
            }

            public void IniWriteValue(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, this.path);
            }

            public string IniReadValue(string Section, string Key)
            {
                StringBuilder temp = new StringBuilder(255);
                GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
                return temp.ToString();
            }
        }


    }


}
