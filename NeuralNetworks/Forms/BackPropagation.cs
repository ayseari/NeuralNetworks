using NeuralNetwork;
using NNTOOLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OUTWRITER;

namespace NeuralNetworks.Forms
{
    public partial class BackPropagation : Form
    {
        #region Definitions
        nnTools nnet = new nnTools();
        BackPropagationNetwork bpn;

        nnTools.IniFile inii =
            new nnTools.IniFile(string.Format(@"{0}\prmNetwork.ini", Directory.GetCurrentDirectory()));

        double[][] input, output, trainInput, trainOutput, testInput, testOutput;
        double[][][] InitializeWeight;
        double[][] InitializeBias;
        DataTable dtNormalDataset = new DataTable();
        DataTable dtNormalTrainset = new DataTable();
        DataTable dtNormalTestset = new DataTable();
        DataTable dtDataset = new DataTable();
        DataTable dtTrainset = new DataTable();
        DataTable dtTestset = new DataTable();
        DataTable dtTest = new DataTable();
        public List<double> ErrorPoints = new List<double>();
        public DataTable dtConfusion = new DataTable();
        List<int> matchDesired = new List<int>();
        List<int> matchOutput = new List<int>();
        public double accuracy = 0.0;
        string mainFolder = string.Empty;
        string foldername = string.Empty;
        double trainPercent = 0.0;
        double testPercent = 0.0;
        public string PrepareMethod = string.Empty;
        string NormalizationMethod = string.Empty;
        bool matchControl = false;
        string problemType = string.Empty;
        double error = 0.0, trainTime = 0.0;
        public int classnumber = 0;
        bool ShowErrorWindow = false;
        public bool check = false;
        string testsetname = string.Empty;
        #endregion Definitions

        public BackPropagation()
        {
            InitializeComponent();
            ReadParameters();
        }

        public void WriteParameters()
        {
            #region Parameter Writing
            inii.IniWriteValue("Network", "Problem Type", problemType);
            inii.IniWriteValue("Network", "Normalization Method", NormalizationMethod);
            inii.IniWriteValue("Network", "Show Error Window", ShowErrorWindow.ToString());
            inii.IniWriteValue("Network", "Train Percent", trainPercent.ToString());
            inii.IniWriteValue("Network", "Test Percent", testPercent.ToString());
            inii.IniWriteValue("Network", "Prepare Method", PrepareMethod);
            inii.IniWriteValue("Network", "TestsetName", testsetname);
            inii.IniWriteValue("Network", "LayerSizes", edtLayerSizes.Text);
            inii.IniWriteValue("Network", "LayerTransferFunctions", edtTransferFunctions.Text);
            inii.IniWriteValue("Network", "LearningRate", edtLearningRate.Text);
            inii.IniWriteValue("Network", "Momentum", edtMomentum.Text);
            inii.IniWriteValue("Network", "Iteration", edtIterations.Text);
            inii.IniWriteValue("Network", "FinishingCondition", edtFinishCondition.Text);
            inii.IniWriteValue("Network", "ErrorRate", edtErrorRate.Text);
            inii.IniWriteValue("Network", "LRDecay", edtDecayLR.Checked.ToString());
            inii.IniWriteValue("Network", "LRDecayValue", edtDecayLRValue.Text);
            inii.IniWriteValue("Network", "MomentumDecay", edtDecayMomentum.Checked.ToString());
            inii.IniWriteValue("Network", "MomentumDecayValue", edtDecayMomentumValue.Text);
            inii.IniWriteValue("Network", "WeightsOption", edtWeightsOption.SelectedItem.ToString());
            inii.IniWriteValue("Network", "BiasesOption", edtBiasesOption.SelectedItem.ToString());
            inii.IniWriteValue("Network", "DatasetFileName", edtDatasetFile.Text);
            inii.IniWriteValue("Network", "TrainsetFileName", edtTrainsetFile.Text);
            inii.IniWriteValue("Network", "TestsetFileName", edtTestsetFile.Text);
            inii.IniWriteValue("Network", "WeightsFile", edtWeightsFile.Text);
            inii.IniWriteValue("Network", "BiasesFile", edtBiasesFile.Text);
            #endregion Parameter Writing
        }

        public void ReadParameters()
        {
            #region Parameter Reading
            problemType=inii.IniReadValue("Network", "Problem Type");
            NormalizationMethod=inii.IniReadValue("Network", "Normalization Method");
            ShowErrorWindow=Convert.ToBoolean(inii.IniReadValue("Network", "Show Error Window"));
            edtLayerSizes.Text = inii.IniReadValue("Network", "LayerSizes");
            edtTransferFunctions.Text = inii.IniReadValue("Network", "LayerTransferFunctions");
            edtLearningRate.Text = inii.IniReadValue("Network", "LearningRate");
            edtMomentum.Text = inii.IniReadValue("Network", "Momentum");
            edtIterations.Text = inii.IniReadValue("Network", "Iteration");
            edtFinishCondition.Text = inii.IniReadValue("Network", "FinishingCondition");
            edtErrorRate.Text = inii.IniReadValue("Network", "ErrorRate");
            edtDecayLR.Checked = Convert.ToBoolean(inii.IniReadValue("Network", "LRDecay"));
            edtDecayLRValue.Text = inii.IniReadValue("Network", "LRDecayValue");
            edtDecayMomentum.Checked = Convert.ToBoolean(inii.IniReadValue("Network", "MomentumDecay"));
            edtDecayMomentumValue.Text = inii.IniReadValue("Network", "MomentumDecayValue");
            edtWeightsOption.Text = inii.IniReadValue("Network", "WeightsOption");
            edtBiasesOption.Text = inii.IniReadValue("Network", "BiasesOption");
            edtDatasetFile.Text = inii.IniReadValue("Network", "DatasetFileName");
            edtTrainsetFile.Text = inii.IniReadValue("Network", "TrainsetFileName");
            edtTestsetFile.Text = inii.IniReadValue("Network", "TestsetFileName");
            edtWeightsFile.Text = inii.IniReadValue("Network", "WeightsFileName");
            edtBiasesFile.Text = inii.IniReadValue("Network", "BiasesFileName");
            #endregion Parameter Reading
        }

        public void Match()
        {
            matchDesired.Clear();
            matchOutput.Clear();
            dtTest.Columns.Add("Match", typeof(string));
            for (int i = 0; i < dtTest.Rows.Count; i++)
            {
                string[] desired = dtTest.DefaultView[i]["Output1"].ToString().TrimEnd().Split(' ');
                for (int j = 0; j < desired.Length; j++)
                {
                    if (desired[j] == "1")
                    {
                        matchDesired.Add(j);
                        break;
                    }
                }
                double max = double.MinValue;
                int index = 0;
                string[] nnetoutput = dtTest.DefaultView[i]["NetworkOutput"].ToString().TrimEnd().Split(' ');
                int t = 0, k = 0;
                for (k = 0; k < nnetoutput.Length; k++)
                {
                    if (max < double.Parse(nnetoutput[k]))
                    {
                        max = double.Parse(nnetoutput[k]);
                        t = k;
                        index = t;
                    }
                }
                matchOutput.Add(t);
            }

            for (int i = 0; i < matchDesired.Count; i++)
            {
                if (matchDesired[i] == matchOutput[i])
                    dtTest.DefaultView[i]["Match"] = "true";
                else dtTest.DefaultView[i]["Match"] = "false";

            }
            matchControl = true;

        } // yaklaşım pronlemleri için farklı olacak yap !!

        public void LoadSets()
        {
            #region clear
            grdData.DataSource = null;
            grdTrain.DataSource = null;
            grdTest.DataSource = null;
            #endregion clear

            #region Selection of loading data
            string filename = string.Empty;
            problemType = ((fNN)Application.OpenForms["fNN"]).ProblemType.TrimEnd();
            if (problemType == "")
            {
                MessageBox.Show("Please, enter problem type.", "Warning", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                return;
            }
            mainFolder = nnet.CreateMainFolder(Directory.GetCurrentDirectory(), "Network");
            foldername = nnet.CreateFolder(mainFolder, "Network");
            List<double> OutputList = new List<double>()
                ; //train ve test set yüklendiğinde outputu sınıflandırmak için farklı outputların tutulduğu liste (sınıf sayısını belirlemek için)

            if (edtDatasetFile.Text == "" && edtTrainsetFile.Text == "" && edtTestsetFile.Text == "")
            {
                MessageBox.Show("Please, select the dataset or train and testset file", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtDatasetFile.Text != "" && edtTrainsetFile.Text != "" && edtTestsetFile.Text != "")
            {
                MessageBox.Show("Please, select the dataset or train and testset file", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtDatasetFile.Text == "" && edtTrainsetFile.Text != "" && edtTestsetFile.Text != "")
            {
                #region Loading Train and Test Set
                string trainfileName = edtTrainsetFile.Text;
                string testfileName = edtTestsetFile.Text;
                if (problemType == "Pattern Recognition")
                {
                    nnet.Load(trainfileName, ref trainInput, ref trainOutput, 1, OutputList);
                    nnet.Load(testfileName, ref testInput, ref testOutput, 1, OutputList);
                    classnumber = OutputList.Count;
                }
                else
                {
                    nnet.Load(trainfileName, ref trainInput, ref trainOutput, 1);
                    nnet.Load(testfileName, ref testInput, ref testOutput, 1);
                }
                dtTrainset = nnet.ConvertArrayToTable(trainInput, trainOutput); // trainset datatable a aktarılır 

                dtTestset = nnet.ConvertArrayToTable(testInput, testOutput); // testset datatable a aktarılır 
                tabMain.SelectedIndex = 1;
                grdTrain.DataSource = dtTrainset;
                grdTrain.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdTrain);

                tabMain.SelectedIndex = 2;
                grdTest.DataSource = dtTestset;
                grdTest.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdTest);
                 check = true;//eğer train ve test set load edildiyse Train ve Test hazırlama kısmı anaformda enabled yapılır
                nnet.PrintTxt($"{foldername}\\Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtTrainset);
                nnet.PrintTxt($"{foldername}\\Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtTestset);

                #endregion Loading Train and Test Set
            }
            else if (edtDatasetFile.Text != "" && edtTrainsetFile.Text == "" && edtTestsetFile.Text == "")
            {
                #region Loading Dataset
                filename = edtDatasetFile.Text;
                if (problemType == "Pattern Recognition")
                {
                    nnet.Load(filename, ref input, ref output, 1, OutputList);
                    classnumber = OutputList.Count;
                }
                else
                {
                    nnet.Load(filename, ref input, ref output, 1);
                }
                dtDataset = nnet.ConvertArrayToTable(input, output);
                tabMain.SelectedIndex = 0;
                grdData.DataSource = dtDataset;
                grdData.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdData);
                nnet.PrintTxt($"{foldername}\\Dataset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtDataset);

                #endregion Loading Dataset
            }

            #endregion Selection of loading data
        }

        public void NormalizedData()
        {

            if (edtDatasetFile.Text == "" && edtTrainsetFile.Text != "" && edtTestsetFile.Text != "")
            {
                #region Choose Normalization Method

                NormalizationMethod = ((fNN)Application.OpenForms["fNN"]).normalizationMethod.TrimEnd();
                switch (NormalizationMethod)
                {
                    default:
                        //NormalizedTrainset = trainset.Select(a => a.ToArray()).ToArray();
                        //NormalizedTestset = testset.Select(a => a.ToArray()).ToArray();
                        dtNormalTrainset =
                       nnTools.Normalizations.Evaluate(nnTools.Normalization.None, ref trainInput, ref trainOutput);
                        dtNormalTestset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.None, ref testInput, ref testOutput);
                        break;
                    case "Linear Normalization":
                        dtNormalTrainset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.Linear, ref trainInput, ref trainOutput);
                        dtNormalTestset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.Linear, ref testInput, ref testOutput);
                        break;
                    case "Max-Min Normalization":
                        dtNormalTrainset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.MaxMin, ref trainInput, ref trainOutput);
                        dtNormalTestset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.MaxMin, ref testInput, ref testOutput);
                        break;
                    case "ZScore Normalization":
                        dtNormalTrainset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.ZScore, ref trainInput, ref trainOutput);
                        dtNormalTestset =
                            nnTools.Normalizations.Evaluate(nnTools.Normalization.ZScore, ref testInput, ref testOutput);
                        break;
                }

                #endregion Choose Normalization Method

                #region OutputClassification

                if (problemType.TrimEnd() == "Pattern Recognition")
                {
                    trainOutput =
                        nnet.OutputClasification(trainOutput, classnumber); //output kolonu sınıflandırılır.
                    dtNormalTrainset = nnet.OutputClasificationDataTable(dtNormalTrainset, trainOutput);
                    testOutput = nnet.OutputClasification(testOutput, classnumber);
                    dtNormalTestset = nnet.OutputClasificationDataTable(dtNormalTestset, testOutput);

                }
                #endregion OutputClassification

                tabMain.SelectedIndex = 4;
                grdNormalTrain.DataSource = dtNormalTrainset;
                grdNormalTrain.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalTrain);
                nnet.PrintTxt($"{foldername}\\Normalized Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalTrainset);
                tabMain.SelectedIndex = 5;
                grdNormalTest.DataSource = dtNormalTestset;
                grdNormalTest.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalTest);
                nnet.PrintTxt($"{foldername}\\Normalized Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalTestset);

            }
            else
            {
                #region Choose Normalization Method
                NormalizationMethod = ((fNN)Application.OpenForms["fNN"]).normalizationMethod.TrimEnd();
                switch (NormalizationMethod)
                {
                    default:
                        dtNormalDataset = nnTools.Normalizations.Evaluate(nnTools.Normalization.None, ref input, ref output);
                        break;
                    case "Linear Normalization":
                        dtNormalDataset = nnTools.Normalizations.Evaluate(nnTools.Normalization.Linear, ref input, ref output);
                        break;
                    case "Max-Min Normalization":
                        dtNormalDataset = nnTools.Normalizations.Evaluate(nnTools.Normalization.MaxMin, ref input, ref output);
                        break;
                    case "ZScore Normalization":
                        dtNormalDataset = nnTools.Normalizations.Evaluate(nnTools.Normalization.ZScore, ref input, ref output);
                        break;
                }
                #endregion Choose Normalization Method

                #region OutputClassification
                if (problemType.TrimEnd() == "Pattern Recognition")
                {
                    output = nnet.OutputClasification(output, classnumber);
                    dtNormalDataset = nnet.OutputClasificationDataTable(dtNormalDataset, output);
                }
                #endregion OutputClassification

                tabMain.SelectedIndex = 3;
                grdNormalData.DataSource = dtNormalDataset;
                grdNormalData.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalData);
                nnet.PrintTxt($"{foldername}\\Normalized Dataset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalDataset);

            }

        }

        public void PrepareTrainTestset()
        {

            trainPercent = ((fNN)Application.OpenForms["fNN"]).trainPercent;
            testPercent = ((fNN)Application.OpenForms["fNN"]).testPercent;
            PrepareMethod = ((fNN)Application.OpenForms["fNN"]).PrepareMethod;
            if (PrepareMethod == "Random")
            {
                #region Random Normalized Train Test Creation
                dtNormalTrainset = nnTools.Trainset.Evaluate(nnTools.CreateTrainset.Random, dtNormalDataset, trainPercent);
                nnet.ConvertTableToArray(dtNormalTrainset, ref trainInput, ref trainOutput, 1);
                tabMain.SelectedIndex = 4;
                grdNormalTrain.DataSource = dtNormalTrainset;
                grdNormalTrain.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalTrain);
                nnet.PrintTxt($"{foldername}\\Normalized Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalTrainset);


                dtNormalTestset = nnTools.Testset.Evaluate(nnTools.CreateTestset.Random, dtNormalDataset, testPercent);
                nnet.ConvertTableToArray(dtNormalTestset, ref testInput, ref testOutput, 1);
                tabMain.SelectedIndex = 5;
                grdNormalTest.DataSource = dtNormalTestset;
                grdNormalTest.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalTest);
                nnet.PrintTxt($"{foldername}\\Normalized Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalTestset);

                #endregion Random Normalized Train Test Creation

                #region Random Train Test Creation
                dtTrainset = nnet.NotNormalset(dtDataset, nnTools.Trainset.TrainIndex); //datasetten normalleştirilmemiş trainset çekilir.
                tabMain.SelectedIndex = 1;
                grdTrain.DataSource = dtTrainset;
                grdTrain.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdTrain);
                nnet.PrintTxt($"{foldername}\\Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtTrainset);

                dtTestset = nnet.NotNormalset(dtDataset, nnTools.Testset.TestIndex); //datasetten normalleştirilmemiş testset çekilir.
                tabMain.SelectedIndex = 2;
                grdTest.DataSource = dtTestset;
                nnet.MyGridStyle(grdTest);
                grdTest.AllowUserToAddRows = false;
                nnet.PrintTxt($"{foldername}\\Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtTestset);

                #endregion Random Train Test Creation
                tabMain.SelectedIndex = 5;
            }
            else
            {
                #region  Normalized Train Test Creation in Order
                dtNormalTrainset = nnTools.Trainset.Evaluate(nnTools.CreateTrainset.InOrder, dtNormalDataset, trainPercent);
                nnet.ConvertTableToArray(dtNormalTrainset, ref trainInput, ref trainOutput, 1);// sadece input kolanları alınır
                tabMain.SelectedIndex = 4;
                grdNormalTrain.DataSource = dtNormalTrainset;
                grdNormalTrain.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalTrain);
                nnet.PrintTxt($"{foldername}\\Normalized Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalTrainset);

                dtNormalTestset = nnTools.Testset.Evaluate(nnTools.CreateTestset.InOrder, dtNormalDataset, testPercent);
                nnet.ConvertTableToArray(dtNormalTestset, ref testInput, ref testOutput, 1);// sadece input kolanları alınır test için
                tabMain.SelectedIndex = 5;
                grdNormalTest.DataSource = dtNormalTestset;
                grdNormalTest.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdNormalTest);
                nnet.PrintTxt($"{foldername}\\Normalized Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtNormalTestset);

                #endregion Normalized Train Test Creation in Order

                #region  Train Test Creation in order
                dtTrainset = nnet.NotNormalset(dtDataset, nnTools.Trainset.TrainIndex); //datasetten normalleştirilmemiş trainset çekilir.
                tabMain.SelectedIndex = 1;
                grdTrain.DataSource = dtTrainset;
                grdTrain.AllowUserToAddRows = false;
                nnet.MyGridStyle(grdTrain);
                nnet.PrintTxt($"{foldername}\\Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtTrainset);

                dtTestset = nnet.NotNormalset(dtDataset, nnTools.Testset.TestIndex); //datasetten normalleştirilmemiş testset çekilir.
                tabMain.SelectedIndex = 2;
                grdTest.DataSource = dtTestset;
                nnet.MyGridStyle(grdTest);
                grdTest.AllowUserToAddRows = false;
                nnet.PrintTxt($"{foldername}\\Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt", dtTestset);

                #endregion  Train Test Creation in order
                tabMain.SelectedIndex = 5;
            }
        }

        public void Learn()
        {
            #region controls
            if(edtLayerSizes.Text=="" || edtIterations.Text=="" || edtTransferFunctions.Text == "" || edtLearningRate.Text == "" || edtMomentum.Text == "" )
            {
                MessageBox.Show("Please, enter all parameters of the network.", "Warning", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
                return;
            }
            if(edtFinishCondition.SelectedIndex!=1)
            {
                MessageBox.Show("Please, enter the error rate", "Warning", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
                return;
            }
            if(edtDecayLR.Checked==true && edtDecayLRValue.Text=="")
            {
                MessageBox.Show("Please, enter decay value of learning rate.", "Warning", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
                return;
            }
            if (edtDecayMomentum.Checked == true && edtDecayMomentumValue.Text == "")
            {
                MessageBox.Show("Please, enter decay value of momentum.", "Warning", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
                return;
            }
            #endregion controls

            #region Definitions
            int[] layersizes;
            double learningrate = 0.0;
            double momentum = 0.0;
            int maxiteration = 0, count = 0;
            List<double> WeightsFromTxt = new List<double>();
            List<double> BiasesFromTxt = new List<double>();
            List<double> lastweights = new List<double>();
            List<double> lastbiases = new List<double>();
            #endregion Definitions

            #region Setting Network Constructors
            string[] layerSize = edtLayerSizes.Text.Split(' ');
            int layerCount = layerSize.Length;
            layersizes = new int[layerCount];
            for (int i = 0; i < layerSize.Length; i++)
            {
                layersizes[i] = int.Parse(layerSize[i]);
            }
            if (layersizes[0] != trainInput[0].Length)
            {
                MessageBox.Show("Invalid input size", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                return;
            }
            learningrate = double.Parse(edtLearningRate.Text);
            momentum = double.Parse(edtMomentum.Text);
            maxiteration = int.Parse(edtIterations.Text);
            double errorRate = double.Parse(edtErrorRate.Text);
            string[] Tf = edtTransferFunctions.Text.ToUpper().Split(' ');
            #endregion Setting Network Constructors

            #region Setting TransferFunctions
            TransferFunction[] tFunctions = new TransferFunction[layerCount];
            for (int i = 0; i < layerCount; i++)
            {
                if (Tf[i].ToUpper() == "N") tFunctions[i] = TransferFunction.None;
                if (Tf[i].ToUpper() == "L") tFunctions[i] = TransferFunction.Linear;
                if (Tf[i].ToUpper() == "S") tFunctions[i] = TransferFunction.Sigmoid;
                if (Tf[i].ToUpper() == "T") tFunctions[i] = TransferFunction.TangentHyperbolic;
                if (Tf[i].ToUpper() == "G") tFunctions[i] = TransferFunction.Gaussian;
                if (Tf[i].ToUpper() == "R") tFunctions[i] = TransferFunction.RationalSigmoid;

            }
            #endregion Setting TransferFunctions

            #region Control
            if (tFunctions.Length != layersizes.Length || tFunctions[0] != TransferFunction.None)
            {
                MessageBox.Show("Cannot construct a network with these parameters.", "Warning", MessageBoxButtons.OK,
             MessageBoxIcon.Warning);
                return;
            }
        
            if (trainOutput[0].Length != layersizes[layerCount - 1])
            {
                MessageBox.Show("Invalid output size.", "Warning", MessageBoxButtons.OK,
       MessageBoxIcon.Warning);
                return;
            }
            #endregion Control

            #region Read Weights and Biases from txt
            if (edtWeightsOption.SelectedIndex == 4)
            {
                if (edtWeightsFile.Text == " " || edtBiasesFile.Text == " ")
                { MessageBox.Show("Please, choose filename of the weights and biases.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                WeightsFromTxt = nnet.Txt2Weights(edtWeightsFile.Text);
                BiasesFromTxt = nnet.Txt2Biases(edtBiasesFile.Text);

            }
            #endregion Read Weights and Biases from txt

            #region Setting Initialize Weight and Bias

            if (edtWeightsOption.SelectedIndex == 2 || edtWeightsOption.SelectedIndex == 3 || edtWeightsOption.SelectedIndex == 4 || edtBiasesOption.SelectedIndex == 2 || edtBiasesOption.SelectedIndex == 3 || edtBiasesOption.SelectedIndex == 4)
            {
                InitializeWeight = new double[layersizes.Length - 1][][];
                InitializeBias = new double[layersizes.Length - 1][];

                for (int i = 0; i < layersizes.Length - 1; i++)
                {
                    InitializeBias[i] = new double[layersizes[i + 1]];
                    InitializeWeight[i] = new double[layersizes[i]][];
                    for (int j = 0; j < layersizes[i]; j++)
                    {
                        InitializeWeight[i][j] = new double[layersizes[i + 1]];

                    }
                }
            }

            #endregion Setting Initialize Weight and Bias

            #region Fill Initialize Weight and Bias
            //Ağırlık -1 ile 1 arasında
            if (edtWeightsOption.SelectedIndex == 2)
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int i = 0; i < layersizes[l]; i++)
                    {
                        for (int j = 0; j < layersizes[l + 1]; j++)
                        {
                            InitializeWeight[l][i][j] = (r.NextDouble()) * 2 - 1;
                        }
                    }
                }
            }
            if (edtWeightsOption.SelectedIndex == 3) //Ağırlık  -0.5 ile 0.5 arasında
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int i = 0; i < layersizes[l]; i++)
                    {
                        for (int j = 0; j < layersizes[l + 1]; j++)
                        {
                            InitializeWeight[l][i][j] = r.NextDouble() - 0.5;
                        }
                    }
                }
            }
            if (edtBiasesOption.SelectedIndex == 2) // bias -1 ile 1 arasında
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int j = 0; j < layersizes[l + 1]; j++)
                    {
                        InitializeBias[l][j] = (r.NextDouble()) * 2 - 1;
                    }
                }
            }
            if (edtBiasesOption.SelectedIndex == 3) // bias -0.5 ile 0.5 arasında
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int j = 0; j < layersizes[l + 1]; j++)
                    {
                        InitializeBias[l][j] = r.NextDouble() - 0.5;
                    }
                }
            }
            //Ağırlık ve biaslar dosyadan okunduğunda*******************************
            if (edtWeightsOption.SelectedIndex == 4 && edtBiasesOption.SelectedIndex == 4)
            {
                int k = 0;
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int i = 0; i < layersizes[l]; i++)
                    {
                        for (int j = 0; j < layersizes[l + 1]; j++)
                        {
                            InitializeWeight[l][i][j] = WeightsFromTxt[k];
                            k++;
                        }
                    }
                }
                int p = 0;
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int j = 0; j < layersizes[l + 1]; j++)
                    {
                        InitializeBias[l][j] = BiasesFromTxt[p];
                        p++;
                    }
                }
            }

            #endregion Fill Inialize Weight and Bias

            #region Setting Initialize Weight and Bias

            if (edtWeightsOption.SelectedIndex == 2 || edtWeightsOption.SelectedIndex == 3 || edtWeightsOption.SelectedIndex == 4 || edtBiasesOption.SelectedIndex == 2 || edtBiasesOption.SelectedIndex == 3 || edtBiasesOption.SelectedIndex == 4)
            {
                InitializeWeight = new double[layersizes.Length - 1][][];
                InitializeBias = new double[layersizes.Length - 1][];

                for (int i = 0; i < layersizes.Length - 1; i++)
                {
                    InitializeBias[i] = new double[layersizes[i + 1]];
                    InitializeWeight[i] = new double[layersizes[i]][];
                    for (int j = 0; j < layersizes[i]; j++)
                    {
                        InitializeWeight[i][j] = new double[layersizes[i + 1]];
                    }
                }
            }

            #endregion Setting Initialize Weight and Bias

            #region Fill Initialize Weight and Bias
            //Ağırlık -1 ile 1 arasında
            if (edtWeightsOption.SelectedIndex == 2)
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int i = 0; i < layersizes[l]; i++)
                    {
                        for (int j = 0; j < layersizes[l + 1]; j++)
                        {
                            InitializeWeight[l][i][j] = r.NextDouble() * 2 - 1;
                        }
                    }
                }
            }
            if (edtWeightsOption.SelectedIndex == 3) //Ağırlık  -0.5 ile 0.5 arasında
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int i = 0; i < layersizes[l]; i++)
                    {
                        for (int j = 0; j < layersizes[l + 1]; j++)
                        {
                            InitializeWeight[l][i][j] = r.NextDouble() - 0.5;
                        }
                    }
                }
            }
            if (edtBiasesOption.SelectedIndex == 2) // bias -1 ile 1 arasında
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int j = 0; j < layersizes[l + 1]; j++)
                    {
                        InitializeBias[l][j] = (r.NextDouble()) * 2 - 1;
                    }
                }
            }
            if (edtBiasesOption.SelectedIndex == 3) // bias -0.5 ile 0.5 arasında
            {
                Random r = new Random();
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int j = 0; j < layersizes[l + 1]; j++)
                    {
                        InitializeBias[l][j] = r.NextDouble() - 0.5;
                    }
                }
            }
            //Ağırlık ve biaslar dosyadan okunduğunda*******************************
            if (edtWeightsOption.SelectedIndex == 4 && edtBiasesOption.SelectedIndex == 4)
            {
                int k = 0;
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int i = 0; i < layersizes[l]; i++)
                    {
                        for (int j = 0; j < layersizes[l + 1]; j++)
                        {
                            InitializeWeight[l][i][j] = WeightsFromTxt[k];
                            k++;
                        }
                    }
                }
                int p = 0;
                for (int l = 0; l < layersizes.Length - 1; l++)
                {
                    for (int j = 0; j < layersizes[l + 1]; j++)
                    {
                        InitializeBias[l][j] = BiasesFromTxt[p];
                        p++;
                    }
                }
            }

            #endregion Fill Inialize Weight and Bias

            #region Choose Network
            if (edtWeightsOption.SelectedIndex == 0 && edtBiasesOption.SelectedIndex == 0)
                bpn = new BackPropagationNetwork(layersizes, tFunctions, "random");
            else if (edtWeightsOption.SelectedIndex == 1 && edtBiasesOption.SelectedIndex == 1)
                bpn = new BackPropagationNetwork(layersizes, tFunctions);
            else
                bpn = new BackPropagationNetwork(layersizes, tFunctions, InitializeWeight, InitializeBias);
            #endregion Choose Network

            #region Options Setting
            var first = edtDecayLR.Checked && edtDecayMomentum.Checked;
            var second = edtDecayLR.Checked;
            var third = edtDecayMomentum.Checked;
            var condition1 = edtFinishCondition.SelectedIndex == 0;
            var condition2 = edtFinishCondition.SelectedIndex == 1;
            var condition3 = edtFinishCondition.SelectedIndex == 2;
            double LRdecay = double.Parse(edtDecayLRValue.Text.Length == 0 ? "0" : edtDecayLRValue.Text);
            double MomentumDecay = double.Parse(edtDecayMomentumValue.Text.Length == 0 ? "0" : edtDecayMomentumValue.Text);
            var finishCondition = edtFinishCondition.Text;
            var dataFile = edtDatasetFile.Text;
            var trainFile = edtTrainsetFile.Text;
            var testFile = edtTestsetFile.Text;
            var weightsOption = edtWeightsOption.Text;
            var biasesOption = edtBiasesOption.Text;
            var weightsFile = edtWeightsFile.Text;
            var biasesFile = edtBiasesFile.Text;
            #endregion Options Setting

            #region Print to txt Network Constructors
            try
            {
                string filename = $"{foldername}\\Network Constructure{DateTime.Now.ToString("u").Replace(':', '-')}.txt";

                var fi = new FileInfo(filename);
                using (var txt = fi.AppendText())
                {
                    txt.WriteLine("Problem Type " + problemType.TrimEnd());
                    txt.WriteLine("LayerSizes " + edtLayerSizes.Text);
                    txt.WriteLine("TransferFunctions " + edtTransferFunctions.Text);
                    txt.WriteLine("LearningRate " + learningrate);
                    txt.WriteLine("Momentum " + momentum);
                    txt.WriteLine("Iteration " + maxiteration);
                    txt.WriteLine("Finish Condition :" + finishCondition);
                    txt.WriteLine("Error Rate :" + errorRate);
                    txt.WriteLine("TrainPercent " + trainPercent);
                    txt.WriteLine("TestPercent " + testPercent);
                    txt.WriteLine("LR Decay :" + edtDecayLR.Checked.ToString());
                    txt.WriteLine("LR Decay Value :" + edtDecayLRValue.Text);
                    txt.WriteLine("Momentum Decay :" + edtDecayMomentum.Checked.ToString());
                    txt.WriteLine("Momentum Decay Value :" + edtDecayMomentumValue.Text);
                    txt.WriteLine("WeightsOption :" + weightsOption);
                    txt.WriteLine("BiasesOption :" + biasesOption);
                    txt.WriteLine("Normalization Method :" + NormalizationMethod);
                    txt.WriteLine("Train Test Preparation Method :" + PrepareMethod);
                    txt.WriteLine("DatasetFile " + dataFile);
                    txt.WriteLine("TrainsetFile " + trainFile);
                    txt.WriteLine("TestsetFile " + testFile);
                    txt.WriteLine("WeightsFile " + weightsFile);
                    txt.WriteLine("BiasesFile " + biasesFile);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(String.Format("There was an error print to network constructors to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion Print to txt Network Constructors

            #region Train
            ShowErrorWindow = ((fNN)Application.OpenForms["fNN"]).showError;
            if (ShowErrorWindow)
            {
                Error frm = new Error();
                frm.Show();
                new Thread(() =>
                {
                    #region Choosing Training Function
                    ErrorPoints.Clear();
                    Stopwatch sw = new Stopwatch();

                    if (condition1)
                    {
                        if (first)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                learningrate = learningrate / (1 + count * LRdecay);
                                momentum = momentum / (1 + count * MomentumDecay);
                            } while (error > errorRate);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else if (second)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                learningrate = learningrate / (1 + count * LRdecay);
                            } while (error > errorRate);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else if (third)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                momentum = momentum / (1 + count * MomentumDecay);
                            } while (error > errorRate);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                            } while (error > errorRate);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                    }
                    else if (condition2)
                    {
                        if (first)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                learningrate = learningrate / (1 + count * LRdecay);
                                momentum = momentum / (1 + count * MomentumDecay);
                            } while (count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else if (second)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                learningrate = learningrate / (1 + count * LRdecay);
                            } while (count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else if (third)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                momentum = momentum / (1 + count * MomentumDecay);
                            } while (count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                            } while (count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }

                    }
                    else
                    {
                        if (first)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                learningrate = learningrate / (1 + count * LRdecay);
                                momentum = momentum / (1 + count * MomentumDecay);
                            } while (error > errorRate || count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else if (second)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i],learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                learningrate = learningrate / (1 + count * LRdecay);
                            } while (error > errorRate || count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else if (third)
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                                momentum = momentum / (1 + count * MomentumDecay);
                            } while (error > errorRate || count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }
                        else
                        {
                            sw.Start();
                            do
                            {
                                count++;
                                error = 0.0;
                                for (int i = 0; i < trainInput.GetLength(0); i++)
                                {
                                    error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                                }
                                error = Math.Sqrt(error) / 2;
                                frm.update(error);
                                ErrorPoints.Add(error);
                            } while (error > errorRate || count < maxiteration);
                            sw.Stop();
                            trainTime = sw.Elapsed.Seconds;
                        }

                    }
                    #endregion Choosing Training Function

                    List<double> WB = new List<double>();
                    #region Evaluate WB
                    for (int i = 0; i < layersizes.Length - 1; i++)
                    {
                        for (int j = 0; j < layersizes[i + 1]; j++)
                        {
                            WB.Add(bpn.bias[i][j]);
                        }
                        for (int j = 0; j < layersizes[i]; j++)
                        {
                            for (int k = 0; k < layersizes[i + 1]; k++)
                            {
                                WB.Add(bpn.weight[i][j][k]);
                            }
                        }

                    }
                    #endregion Evaluate WB

                    #region Get Last Weights and Biases
                    for (int i = 0; i < layersizes.Length - 1; i++)
                    {
                        for (int j = 0; j < layersizes[i + 1]; j++)
                        {
                            lastbiases.Add(bpn.bias[i][j]);
                        }
                        for (int j = 0; j < layersizes[i]; j++)
                        {
                            for (int k = 0; k < layersizes[i + 1]; k++)
                            {
                                lastweights.Add(bpn.weight[i][j][k]);
                            }
                        }
                    }

                    #endregion Get Last Weights and Biases

                    #region Print to txt Last Weights
                    string row = string.Empty;

                    try
                    {
                        string filename = string.Format("{0}\\Weights{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                        if (File.Exists(filename)) File.Delete(filename);

                        var trainText = string.Join(Environment.NewLine,
                                lastweights.Select(p => string.Join(" ", p)));

                        File.WriteAllText(filename, trainText, Encoding.GetEncoding("ibm857"));

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(String.Format("There was an error print to weights to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion Print to txt Last Weights

                    #region Print to txt Last Biases
                    try
                    {
                        string filename = string.Format("{0}\\Biases{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                        if (File.Exists(filename)) File.Delete(filename);
                        var trainText = string.Join(Environment.NewLine,
                                                  lastbiases.Select(p => string.Join(" ", p)));

                        File.WriteAllText(filename, trainText, Encoding.GetEncoding("ibm857"));
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(String.Format("There was an error print to biases to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion Print to txt Last Biases

                    #region Print to txt WB
                    try
                    {
                        string filename = string.Format("{0}\\WB{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                        if (File.Exists(filename)) File.Delete(filename);

                        var trainText = "[" + string.Join(Environment.NewLine,
                                WB.Select(p => string.Join(" ", p))) + "];";

                        File.WriteAllText(filename, trainText, Encoding.GetEncoding("ibm857"));

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(String.Format("There was an error print to biases to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion Print to txt WB


                    MessageBox.Show(string.Format("Network trained :){0}You can test the network.", Environment.NewLine), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }).Start();

            }
            else
            {
                Console.SetOut(new OutWriter { box = edtTrainReport });
                tabMain.SelectedIndex = 6;
                Console.WriteLine(@"@ Process start...");
                #region Choosing Training Function
                ErrorPoints.Clear();
                Stopwatch sw = new Stopwatch();
                if (condition1)
                {
                    if (first)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"  Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            learningrate = learningrate / (1 + count * LRdecay);
                            momentum = momentum / (1 + count * MomentumDecay);
                        } while (error > errorRate);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else if (second)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i],learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            learningrate = learningrate / (1 + count * LRdecay);
                        } while (error > errorRate);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else if (third)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"  Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            momentum = momentum / (1 + count * MomentumDecay);
                        } while (error > errorRate);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"  Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                        } while (error > errorRate);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }

                }
                else if (condition2)
                {
                    if (first)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            learningrate = learningrate / (1 + count * LRdecay);
                            momentum = momentum / (1 + count * MomentumDecay);
                        } while (count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else if (second)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            learningrate = learningrate / (1 + count * LRdecay);
                        } while (count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else if (third)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            momentum = momentum / (1 + count * MomentumDecay);
                        } while (count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"  Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                        } while (count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                }
                else
                {
                    if (first)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            learningrate = learningrate / (1 + count * LRdecay);
                            momentum = momentum / (1 + count * MomentumDecay);
                        } while (error > errorRate || count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else if (second)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            learningrate = learningrate / (1 + count * LRdecay);
                        } while (error > errorRate || count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else if (third)
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"   Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                            momentum = momentum / (1 + count * MomentumDecay);
                        } while (error > errorRate || count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                    else
                    {
                        sw.Start();
                        do
                        {
                            count++;
                            error = 0.0;
                            for (int i = 0; i < trainInput.GetLength(0); i++)
                            {
                                error += bpn.Train(ref trainInput[i], ref trainOutput[i], learningrate, momentum);
                            }
                            error = Math.Sqrt(error) / 2;
                            Console.WriteLine($@"  Iteration : {count} -> Error : {error}");
                            ErrorPoints.Add(error);
                        } while (error > errorRate || count < maxiteration);
                        sw.Stop();
                        trainTime = sw.Elapsed.Seconds;
                    }
                }
                #endregion Choosing Training Function
                Console.WriteLine($@"@  Process Completed :) ");
                List<double> WB = new List<double>();
                #region Evaluate WB
                for (int i = 0; i < layersizes.Length - 1; i++)
                {
                    for (int j = 0; j < layersizes[i + 1]; j++)
                    {
                        WB.Add(bpn.bias[i][j]);
                    }
                    for (int j = 0; j < layersizes[i]; j++)
                    {
                        for (int k = 0; k < layersizes[i + 1]; k++)
                        {
                            WB.Add(bpn.weight[i][j][k]);
                        }
                    }

                }
                #endregion Evaluate WB

                #region Get Last Weights and Biases
                for (int i = 0; i < layersizes.Length - 1; i++)
                {
                    for (int j = 0; j < layersizes[i + 1]; j++)
                    {
                        lastbiases.Add(bpn.bias[i][j]);
                    }
                    for (int j = 0; j < layersizes[i]; j++)
                    {
                        for (int k = 0; k < layersizes[i + 1]; k++)
                        {
                            lastweights.Add(bpn.weight[i][j][k]);
                        }
                    }
                }

                #endregion Get Last Weights and Biases

                #region Print to txt Last Weights
                string row = string.Empty;

                try
                {
                    string filename = string.Format("{0}\\Weights{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                    if (File.Exists(filename)) File.Delete(filename);

                    var trainText = string.Join(Environment.NewLine,
                            lastweights.Select(p => string.Join(" ", p)));

                    File.WriteAllText(filename, trainText, Encoding.GetEncoding("ibm857"));

                }
                catch (Exception err)
                {
                    MessageBox.Show(String.Format("There was an error print to weights to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion Print to txt Last Weights

                #region Print to txt Last Biases
                try
                {
                    string filename = string.Format("{0}\\Biases{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                    if (File.Exists(filename)) File.Delete(filename);
                    var trainText = string.Join(Environment.NewLine,
                                              lastbiases.Select(p => string.Join(" ", p)));

                    File.WriteAllText(filename, trainText, Encoding.GetEncoding("ibm857"));
                }
                catch (Exception err)
                {
                    MessageBox.Show(String.Format("There was an error print to biases to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion Print to txt Last Biases

                #region Print to txt WB
                try
                {
                    string filename = string.Format("{0}\\WB{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                    if (File.Exists(filename)) File.Delete(filename);

                    var trainText = "[" + string.Join(Environment.NewLine,
                            WB.Select(p => string.Join(" ", p))) + "];";

                    File.WriteAllText(filename, trainText, Encoding.GetEncoding("ibm857"));

                }
                catch (Exception err)
                {
                    MessageBox.Show(String.Format("There was an error print to biases to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, err.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion Print to txt WB

                MessageBox.Show(string.Format("Network trained :){0}You can test the network.", Environment.NewLine), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion Train

            }
        }

        public void Test()
        {
            dtTest.Rows.Clear();
            dtTest.Columns.Clear();
            dtConfusion.Rows.Clear();
            dtConfusion.Columns.Clear();
            accuracy = 0;
            double testTime = 0.0;
            double[][] ConfusionMatris = new double[classnumber + 1][];
            #region Select Testset
            try
            {
                testsetname = ((fNN)Application.OpenForms["fNN"]).testData;
                if (testsetname == "Testset")
                {
                    dtTest = dtNormalTestset;

                }
                else if (testsetname == "Trainset")
                {
                    dtTest = dtNormalTrainset;
                    testInput = trainInput;
                    testOutput = trainOutput;
                }
                else
                {
                    if (edtDatasetFile.Text == "")
                    {
                        for (int i = 0; i < dtNormalTrainset.Columns.Count; i++)
                        {
                            dtTest.Columns.Add(dtNormalTestset.Columns[i].ColumnName);
                        }
                        for (int i = 0; i < dtNormalTrainset.Rows.Count; i++)
                        {
                            DataRow dr = dtTest.NewRow();
                            for (int j = 0; j < dtNormalTrainset.Columns.Count; j++)
                            {
                                if (j == dtNormalTestset.Columns.Count - 1) dr[j] = dtNormalTrainset.DefaultView[i][j].ToString();
                                else dr[j] = double.Parse(dtNormalTrainset.DefaultView[i][j].ToString());
                            }
                            dtTest.Rows.Add(dr);
                        }
                        for (int i = 0; i < dtNormalTestset.Rows.Count; i++)
                        {
                            DataRow dr = dtTest.NewRow();
                            for (int j = 0; j < dtNormalTestset.Columns.Count; j++)
                            {
                                if(j==dtNormalTestset.Columns.Count-1) dr[j] = dtNormalTestset.DefaultView[i][j].ToString();
                                else dr[j] = double.Parse(dtNormalTestset.DefaultView[i][j].ToString());
                            }
                            dtTest.Rows.Add(dr);
                        }
                        testInput = new double[dtTest.Rows.Count][];
                        testOutput = new double[dtTest.Rows.Count][];
                        for (int i = 0; i < dtTest.Rows.Count; i++)
                        {
                            var outText = dtTest.DefaultView[i][dtTest.Columns.Count - 1].ToString().TrimEnd().Split(' ');
                            testOutput[i] = new double[outText.Length];
                            for (int j = 0; j < outText.Length; j++)
                            {
                                testOutput[i][j] = double.Parse(outText[j]);
                            }
                           
                        }
                      for (int i = 0; i < dtTest.Rows.Count; i++)
                        {
                            testInput[i] = new double[dtTest.Columns.Count - 1];
                         
                            for (int j = 0; j < dtTest.Columns.Count - 1; j++)
                            {
                                testInput[i][j] = double.Parse(dtTest.DefaultView[i][j].ToString());
                            }
                        }
                       

                    }
                    else
                    {
                        dtTest = dtNormalDataset;
                        testInput = input;
                        testOutput = output;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(string.Format("There was an error select the testset. {0}Error Details : {1}", Environment.NewLine, err.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion Select Testset

            #region Test to Network
            double[][] outputnnet = new double[dtTest.Rows.Count][];//ağın ürettiği çıktıların tutulduğu matris
            Stopwatch sww = new Stopwatch();
            sww.Start();
            for (int i = 0; i < testInput.GetLength(0); i++)
            {
                bpn.Run(ref testInput[i], out outputnnet[i]);
            }
            sww.Stop();
            testTime = sww.Elapsed.Seconds;
            double testError = 0.0;
            for (int r = 0; r < testInput.GetLength(0); r++)
            {
                for (int j = 0; j < outputnnet[r].Length; j++)
                {
                    testError += Math.Pow(testOutput[r][j] - outputnnet[r][j], 2);
                }
            }
            testError = Math.Sqrt(testError) / 2;

            dtTest.Columns.Add("NetworkOutput", typeof(string));
            for (int i = 0; i < dtTest.Rows.Count; i++)
            {
                string sampleoutput = string.Empty;
                for (int j = 0; j < outputnnet[0].Length; j++)
                {
                    sampleoutput += Math.Round(outputnnet[i][j],5).ToString() + " ";
                }
                dtTest.DefaultView[i]["NetworkOutput"] = sampleoutput;
            }
            #endregion Test to Network

            grdNormalTest.Columns.Clear();
            tabMain.SelectedIndex = 5;
            grdNormalTest.DataSource = null;
            if (problemType.TrimEnd() == "Pattern Recognition") Match();
            grdNormalTest.DataSource = dtTest;
            grdNormalTest.Columns["Match"].Visible = false;
            grdNormalTest.AllowUserToAddRows = false;
            nnet.MyGridStyle(grdNormalTest);
            if (problemType.TrimEnd() == "Pattern Recognition")
            {
                #region Match Color
                if (matchControl)
                {
                    for (int i = 0; i < grdNormalTest.Rows.Count; i++)
                    {
                        if (grdNormalTest.Rows[i].Cells["Match"].Value.ToString() == "true")
                        {
                            grdNormalTest.Rows[i].Cells["Output1"].Style.BackColor = Color.Green;
                            grdNormalTest.Rows[i].Cells["NetworkOutput"].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            grdNormalTest.Rows[i].Cells["Output1"].Style.BackColor = Color.Red;
                            grdNormalTest.Rows[i].Cells["NetworkOutput"].Style.BackColor = Color.Red;

                        }
                    }

                }
                #endregion Match Color

                #region Confusion and Accuracy

                for (int i = 0; i < classnumber + 1; i++)
                {
                    ConfusionMatris[i] = new double[classnumber + 1];
                }
                for (int i = 0; i < matchDesired.Count; i++)
                {
                    ConfusionMatris[matchDesired[i]][matchOutput[i]] += 1;
                }
                for (int i = 0; i < classnumber; i++)
                {
                    dtConfusion.Columns.Add(string.Format("PredictedClass{0}", i + 1));
                }
                dtConfusion.Columns.Add("Sensitivity");
                for (int i = 0; i < classnumber; i++)
                {
                    accuracy += (double)ConfusionMatris[i][i] / (dtTest.Rows.Count);

                }

                for (int i = 0; i < ConfusionMatris.GetLength(0); i++)
                {
                    if (i != ConfusionMatris.GetLength(0) - 1)
                    {
                        double colsum = 0;
                        double rowsum = 0;
                        for (int j = 0; j < classnumber; j++)
                        {
                            colsum += ConfusionMatris[j][i];
                            rowsum += ConfusionMatris[i][j];
                        }
                        ConfusionMatris[i][ConfusionMatris[i].Length - 1] = Math.Round(ConfusionMatris[i][i] / rowsum, 2);
                        ConfusionMatris[ConfusionMatris.GetLength(0) - 1][i] = Math.Round(ConfusionMatris[i][i] / colsum, 2);

                    }
                    else
                    {
                        ConfusionMatris[i][ConfusionMatris.GetLength(0) - 1] = Math.Round(accuracy, 2);
                    }

                }
                for (int i = 0; i < classnumber + 1; i++)
                {
                    DataRow dr = dtConfusion.NewRow();
                    for (int j = 0; j < classnumber + 1; j++)
                    {
                        dr[j] = ConfusionMatris[i][j];
                    }
                    dtConfusion.Rows.Add(dr);
                }
                accuracy *= 100;
                Confusion frm = new Confusion();
                frm.Show();
                #endregion Confision and Accuracy      
            }


            #region Print Network Result to the text
            string row = string.Empty;

            try
            {
                string filename = string.Format("{0}\\NetworkResults{1}.txt", foldername, DateTime.Now.ToString("u").Replace(':', '-'));
                if (File.Exists(filename)) File.Delete(filename);

                using (var txt = new StreamWriter(File.Open(filename, FileMode.CreateNew), Encoding.GetEncoding("ibm857")))
                {
                    txt.WriteLine("TestSetName " + testsetname);
                    txt.WriteLine("Actual Output + Network Output ");
                    for (int i = 0; i < dtTest.Rows.Count; i++)
                    {
                        row = string.Empty;
                        row += dtTest.DefaultView[i]["Output1"] + "  +  ";
                        string val = string.Empty;
                        for (int j = 0; j < outputnnet[i].Length; j++)
                        {
                            val += outputnnet[i][j].ToString() + " ";
                        }
                        row += val;
                        if (problemType.TrimEnd() == "Pattern Recognition")
                        {
                            row += "  +  " + dtTest.DefaultView[i]["Match"];
                        }
                        txt.WriteLine(row);
                    }
                    txt.WriteLine("Train Error :" + error.ToString());
                    txt.WriteLine("Train Time :" + trainTime.ToString());
                    txt.WriteLine("Test Error :" + testError.ToString());
                    txt.WriteLine("TestTime :" + testTime.ToString());
                    if (problemType.TrimEnd() == "Pattern Recognition")
                    {
                        txt.WriteLine("Confusion Matris is : ");
                        txt.WriteLine(string.Join(Environment.NewLine,
                         ConfusionMatris.Select(p => string.Join(" ", p))));
                        //for (int i = 0; i < dtConfusion.Rows.Count; i++)
                        //{
                        //    row = string.Empty;

                        //    for (int j = 0; j < dtConfusion.Columns.Count; j++)
                        //    {
                        //        row += dtConfusion.DefaultView[i][j].ToString() + " ";
                        //    }
                        //    txt.WriteLine(row);
                        //}
                        txt.WriteLine("Accuracy : " + accuracy);
                    }


                }
            }
            catch (Exception error)
            {
                MessageBox.Show(String.Format("There was an error print to network results to the file..{0}{0}Error Details:{0}{1}", Environment.NewLine, error.ToString()), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion Print Network Result to the text
            WriteParameters();
        } 

        private void grdData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void grdTrain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void grdTest_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void grdNormalData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void grdNormalTrain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void edtWeightsOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (edtWeightsOption.SelectedIndex == 0) edtBiasesOption.SelectedIndex = 0;
                else if (edtWeightsOption.SelectedIndex == 1) edtBiasesOption.SelectedIndex = 1;
                else if (edtWeightsOption.SelectedIndex == 2) edtBiasesOption.SelectedIndex = 2;
                else if (edtWeightsOption.SelectedIndex == 3) edtBiasesOption.SelectedIndex = 3;
                else if (edtWeightsOption.SelectedIndex == 4) edtBiasesOption.SelectedIndex = 4;
            }
            catch (Exception)
            {

              //
            }
        }

        private void edtBiasesOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (edtBiasesOption.SelectedIndex == 0) edtWeightsOption.SelectedIndex = 0;
                else if (edtBiasesOption.SelectedIndex == 1) edtWeightsOption.SelectedIndex = 1;
                else if (edtBiasesOption.SelectedIndex == 4) edtWeightsOption.SelectedIndex = 4;
                else if (edtBiasesOption.SelectedIndex == 2) edtWeightsOption.SelectedIndex = 2;
                else if (edtBiasesOption.SelectedIndex == 3) edtWeightsOption.SelectedIndex = 3;

            }
            catch (Exception)
            {

                //
            }
        }

        private void edtLayerSizes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtLearningRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtMomentum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtIterations_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtErrorRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtDecayLRValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtDecayMomentumValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void edtTransferFunctions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void grdNormalTest_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void edtDataFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog DataFile = new OpenFileDialog()
            {
                Title = "Select the dataset file",
                Filter = "Text Dosyası |*.txt| Tüm Dosyalar |*.*"
            };
            if (DataFile.ShowDialog() == DialogResult.OK)
            {
                edtDatasetFile.Text = DataFile.FileName;
            }
        }

        private void edtTrainFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog TrainFile = new OpenFileDialog()
            {
                Title = "Select the trainset file",
                Filter = "Text Dosyası |*.txt| Tüm Dosyalar |*.*"
            };
            if (TrainFile.ShowDialog() == DialogResult.OK)
            {
                edtTrainsetFile.Text = TrainFile.FileName;
            }
        }

        private void edtTestFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog TestsetFile = new OpenFileDialog()
            {
                Title = "Select the testset file",
                Filter = "Text Dosyası |*.txt| Tüm Dosyalar |*.*"
            };
            if (TestsetFile.ShowDialog() == DialogResult.OK)
            {
                edtTestsetFile.Text = TestsetFile.FileName;
            }
        }

        private void edtWeightFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog WeightsFile = new OpenFileDialog()
            {
                Title = "Select the weights file",
                Filter = "Text Dosyası |*.txt| Tüm Dosyalar |*.*"
            };
            if (WeightsFile.ShowDialog() == DialogResult.OK)
            {
                edtWeightsFile.Text = WeightsFile.FileName;
            }
        }

        private void edtBiasFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog BiasesFile = new OpenFileDialog()
            {
                Title = "Select the biases file",
                Filter = "Text Dosyası |*.txt| Tüm Dosyalar |*.*"
            };
            if (BiasesFile.ShowDialog() == DialogResult.OK)
            {
                edtBiasesFile.Text = BiasesFile.FileName;
            }
        }
    }
}