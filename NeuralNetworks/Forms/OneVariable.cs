using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NNTOOLS;
using MathParserTK;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace NeuralNetworks.Forms
{
    public partial class OneVariable : Form
    {
        #region Definitions

        nnTools.IniFile ini = new nnTools.IniFile(string.Format(@"{0}\prmOneVariable.ini", Directory.GetCurrentDirectory()));
        nnTools.IniFile inii = new nnTools.IniFile(string.Format(@"{0}\prmFunctionsFiles.ini", Directory.GetCurrentDirectory()));
        MathParser parser = new MathParser('.');
        DataTable dtData = new DataTable();

        DataTable dtTrain = new DataTable();
        DataTable dtTest = new DataTable();
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();
        List<double> Classoutputs = new List<double>();
        List<double> Actualoutputs = new List<double>();
        List<double> ActualTrainoutputs = new List<double>();
        List<double> ActualTestoutputs = new List<double>();
        List<double> TrainInputs = new List<double>();
        List<double> TrainOutputs = new List<double>();
        List<double> TestInputs = new List<double>();
        List<double> TestOutputs = new List<double>();
        List<double> pixX = new List<double>();
        List<double> pixY = new List<double>();

        private Graphics g;

        string input = string.Empty;
        string text = string.Empty;
        double start = 0;
        double finish = 0;
        nnTools tls = new nnTools();
        string mainfolder = string.Empty;
        string functionFolder = string.Empty;
        string foldername = string.Empty;

        #endregion Definitions

        public OneVariable()
        {
            InitializeComponent();
            mainfolder = tls.CreateMainFolder(Directory.GetCurrentDirectory(), "Function");
            functionFolder= tls.CreateMainFolder(mainfolder, "One Variable");
            foldername = tls.CreateFolder(functionFolder, "One Variable");
        }

        public void CreateData()
        {
            #region Create Data
            dtData.Rows.Clear();
            dtData.Columns.Clear();
            if (edtFunction.Text=="" || edtStartx.Text == "" || edtFinishx.Text == "" ||  edtIntervalx.Text == "" )
            {
                MessageBox.Show("Please, enter all the parameters of the dataset.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            start = parser.Parse(edtStartx.Text);
            finish = parser.Parse(edtFinishx.Text);
            double add = parser.Parse(edtIntervalx.Text);
            DataTable data = new DataTable();
            text = edtFunction.Text;


            for (double i = start; i <= finish; i += add)
            {
                input = string.Empty;
             //   int k = int.Parse(inii.IniReadValue("TwoVariable", "DecimalNumber"));
                inputs.Add(Math.Round(i, 5));
                //  inputs.Add(i);
                for (int j = 0; j < text.Length; j++)
                {
                    string ch = text[j].ToString();
                    if (ch == "x") ch = Math.Round(i,5).ToString();
                    input += ch;
                }
                outputs.Add(parser.Parse(input));
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                Actualoutputs.Add(outputs[i]);
            }

            dtData.Columns.Add("input1", typeof(string));
            dtData.Columns.Add("input2", typeof(string));
            dtData.Columns.Add("output", typeof(string));
            for (int i = 0; i < inputs.Count; i++)
            {
                DataRow dr = dtData.NewRow();
                dr["input1"] = inputs[i];
                dr["input2"] = outputs[i];
                var epsilon = 0.00000000000001;
                if (outputs[i] < 0) { dr["output"] = 0; Classoutputs.Add(0); }
                else if (outputs[i] == 0) { dr["output"] = 1; Classoutputs.Add(1); }
                //else if (outputs[i] > 0 && Math.Abs(outputs[i]) <= epsilon) { dr["output"] = 1; Classoutputs.Add(1); }
                else if (outputs[i] > 0) { dr["output"] = 2; Classoutputs.Add(2); };
                dtData.Rows.Add(dr);
            }
            grdData.DataSource = dtData;
            tls.MyGridStyle(grdData);
             #endregion Create Data

            #region plot
            chartFunction.Series.Clear();
            chartFunction.Series.Add("Function");
            chartFunction.Series[0].ChartType = SeriesChartType.FastLine;
            chartFunction.Series[0].Color = Color.Blue;
            chartFunction.ChartAreas["ChartArea1"].CursorX.Interval = add;
            chartFunction.ChartAreas["ChartArea1"].CursorY.Interval = add;
            chartFunction.ChartAreas["ChartArea1"].AxisY.IsStartedFromZero = false;
            chartFunction.ChartAreas["ChartArea1"].AxisX.IsStartedFromZero = false;
            
            for (int i = 0; i < inputs.Count; i++)
            {
                chartFunction.Series[0].Points.AddXY(inputs[i], Actualoutputs[i]);
            }
            #endregion plot
        }

        public void TrainTestCreation()
        {
            if ( edtTrainPercent.Text=="" && edtTestPercent.Text == "" )
            {
                MessageBox.Show("Please, enter percentage of train and test set.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtInterval.Checked && edtIncrementx.Text == "")
            {
                MessageBox.Show("Please, enter incremental value of x.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtInterval.Checked==false && edtInOrder.Checked==false && edtRandom.Checked==false)
            {
                MessageBox.Show("Please, select creation type of train and test set.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            dtTrain.Columns.Add("input1", typeof(string));
            dtTrain.Columns.Add("input2", typeof(string));
            dtTrain.Columns.Add("output", typeof(string));
            dtTest.Columns.Add("input1", typeof(string));
            dtTest.Columns.Add("input2", typeof(string));
            dtTest.Columns.Add("output", typeof(string));

            int count = dtData.Rows.Count;
            #region InOrder
            if (edtInOrder.Checked)
            {
                double trainpercent = double.Parse(edtTrainPercent.Text);
                double textpercent = double.Parse(edtTrainPercent.Text);

                int trainCount = count * (int)trainpercent / 100;
                int testCount = count - trainCount;
                List<DataRow> drows = new List<DataRow>();
                List<DataRow> drowss = new List<DataRow>();
                for (int i = 0; i < trainCount; i++)
                {
                    drows.Add(dtData.Rows[i]);
                }
                dtTrain = drows.CopyToDataTable();


                for (int i = 0; i < testCount; i++)
                {
                    drowss.Add(dtData.Rows[trainCount + i]);
                }

                dtTest = drowss.CopyToDataTable();
            }
            #endregion InOrder
            #region Random
            else if (edtRandom.Checked)
            {
                double trainpercent = double.Parse(edtTrainPercent.Text);
                double textpercent = double.Parse(edtTestPercent.Text);
                Random r = new Random();
                List<int> TrainIndex = new List<int>();
                List<DataRow> drows = new List<DataRow>();
                int trainCount = count * (int)trainpercent / 100;
                int testCount = count - trainCount;
                for (int i = 0; i < trainCount; i++)
                {

                    int k = r.Next(0, count);
                    if (TrainIndex.Contains(k)) { i--; continue; }
                    TrainIndex.Add(k);
                    drows.Add(dtData.Rows[k]);

                }
                dtTrain = drows.CopyToDataTable();

                List<DataRow> drowss = new List<DataRow>();

                for (int i = 0; i < testCount; i++)
                {

                    int k = r.Next(0, count);
                    if (TrainIndex.Contains(k)) { i--; continue; }
                    drowss.Add(dtData.Rows[k]);

                }
                dtTest = drowss.CopyToDataTable();

            }
            #endregion Random
            #region Interval
            else
            {
                double add = double.Parse(edtIncrementx.Text);
                double times = Math.Round(add / double.Parse(edtIntervalx.Text), 0);
                List<int> TrainIndex = new List<int>();
                List<DataRow> drows = new List<DataRow>();
                for (int i = 0; i < count; i += (int)times)
                {
                    drows.Add(dtData.Rows[i]);
                    TrainIndex.Add(i);
                }
                dtTrain = drows.CopyToDataTable();

                List<DataRow> drowss = new List<DataRow>();

                for (int i = 0; i < count; i++)
                {
                    if (TrainIndex.Contains(i)) continue;
                    drowss.Add(dtData.Rows[i]);

                }
                dtTest = drowss.CopyToDataTable();
        
            }
            //chartFunction.Series.Clear();
            //chartFunction.Series.Add("Trainset");
            //chartFunction.Series[0].ChartType = SeriesChartType.FastLine;
            //chartFunction.Series[0].Color = Color.Blue;
            //chartFunction.Series.Add("Testset");
            //chartFunction.Series[1].ChartType = SeriesChartType.FastLine;
            //chartFunction.Series[1].Color = Color.Red;

            //for (int i = 0; i < TrainInputs.Count; i++)
            //{
            //  chartFunction.Series[0].Points.AddXY(TrainInputs[i], TrainOutputs[i]);
            //}

            //for (int i = 0; i < TestInputs.Count; i++)
            //{
            //  chartFunction.Series[1].Points.AddXY(TestInputs[i], TestOutputs[i]);
            //}
            #endregion Interval

            tabMain.SelectedIndex = 1;
            grdTrain.DataSource = dtTrain;
            tls.MyGridStyle(grdTrain);
            tabMain.SelectedIndex = 2;
            grdTest.DataSource = dtTest;
            tls.MyGridStyle(grdTest);
        }

        public void PrintData()
        {
            string filename = $"{foldername}\\Dataset{DateTime.Now.ToString("u").Replace(':', '-')}.txt";
            tls.PrintTxt(filename, dtData,edtFunction.Text);
            MessageBox.Show(string.Format("{0} file is created.", filename), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
       }

        public void PrintTrainTest()
        {
            string trainfilename = $"{foldername}\\Trainset{DateTime.Now.ToString("u").Replace(':', '-')}.txt";
            tls.PrintTxt(trainfilename, dtTrain, edtFunction.Text);
            MessageBox.Show(string.Format("{0} file is created.", trainfilename), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string testfilename = $"{foldername}\\Testset{DateTime.Now.ToString("u").Replace(':', '-')}.txt";
            tls.PrintTxt(testfilename, dtTest, edtFunction.Text);
            MessageBox.Show(string.Format("{0} file is created.", testfilename), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void edtTrainPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (edtTestPercent.Text == null) edtTrainPercent.Text = null;
                else edtTestPercent.Text = (100.0 - double.Parse(edtTrainPercent.Text)).ToString();
            }
            catch
            {

                //
            }
        }

        private void edtTestPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (edtTrainPercent.Text == null) edtTestPercent.Text = null;
                else edtTrainPercent.Text = (100.0 - double.Parse(edtTestPercent.Text)).ToString();
            }
            catch
            {
                //
            }
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

        private void edtStartx_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtFinishx_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtIntervalx_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtTrainPercent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtTestPercent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtIncrementx_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
