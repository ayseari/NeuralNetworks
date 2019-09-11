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
using System.IO;

namespace NeuralNetworks.Forms
{
    public partial class TwoVariable : Form
    {
        #region Definitions

        nnTools.IniFile ini = new nnTools.IniFile(string.Format(@"{0}\prmTwoVariable.ini", Directory.GetCurrentDirectory()));
        nnTools.IniFile inii = new nnTools.IniFile(string.Format(@"{0}\prmFunctionsFiles.ini", Directory.GetCurrentDirectory()));
        MathParser parser = new MathParser('.');
        DataTable dtData = new DataTable();

        DataTable dtTrain = new DataTable();
        DataTable dtTest = new DataTable();
        DataTable data = new DataTable();
        List<double> inputsx = new List<double>();
        List<double> inputsy = new List<double>();
        List<double> outputs = new List<double>();

        List<double> TrainInputsx = new List<double>();
        List<double> TrainInputsy = new List<double>();
        List<double> TrainOutputs = new List<double>();
        List<double> TestInputsx = new List<double>();
        List<double> TestInputsy = new List<double>();
        List<double> TestOutputs = new List<double>();

        private Graphics g;
        nnTools tls = new nnTools();
        string input = string.Empty;
        string text = string.Empty;
        double startx = 0;
        double finishx = 0;
        double starty = 0;
        double finishy = 0;
        string mainFolder = string.Empty;
        string functionFolder = string.Empty;
        string foldername = string.Empty;
        #endregion Definitions

        public TwoVariable()
        {
            InitializeComponent();
            mainFolder = tls.CreateMainFolder(Directory.GetCurrentDirectory(), "Function");
            functionFolder = tls.CreateMainFolder(mainFolder, "Two Variable");
            foldername = tls.CreateFolder(functionFolder, "Two Variable");
            ReadParameter();
        }

        public void WriteParameter()
        {
            ini.IniWriteValue("TwoVariable", "Function", edtFunction.Text);
            ini.IniWriteValue("TwoVariable", "Startx", edtStartx.Text);
            ini.IniWriteValue("TwoVariable", "Finishx", edtFinishx.Text);
            ini.IniWriteValue("TwoVariable", "Intervalx", edtIntervalx.Text);
            ini.IniWriteValue("TwoVariable", "Starty", edtStarty.Text);
            ini.IniWriteValue("TwoVariable", "Finishy", edtFinishy.Text);          
            ini.IniWriteValue("TwoVariable", "Intervaly", edtIntervaly.Text);
            ini.IniWriteValue("TwoVariable", "TrainPercent",edtTrainPercent.Text);
            ini.IniWriteValue("TwoVariable", "TestPercent", edtTestPercent.Text);
            ini.IniWriteValue("TwoVariable", "InOrder", edtInOrder.Checked.ToString());
            ini.IniWriteValue("TwoVariable", "Random", edtRandom.Checked.ToString());
            ini.IniWriteValue("TwoVariable", "Interval", edtInterval.Checked.ToString());
            ini.IniWriteValue("TwoVariable", "Incrementx", edtIncrementx.Text);
            ini.IniWriteValue("TwoVariable", "Incrementy", edtIncrementy.Text);


        }

        public void ReadParameter()
        {
            edtFunction.Text = ini.IniReadValue("TwoVariable", "Function");
            edtStartx.Text = ini.IniReadValue("TwoVariable", "Startx");
            edtFinishx.Text = ini.IniReadValue("TwoVariable", "Finishx");
            edtIntervalx.Text = ini.IniReadValue("TwoVariable", "Intervalx");
            edtStarty.Text = ini.IniReadValue("TwoVariable", "Starty");
            edtFinishy.Text = ini.IniReadValue("TwoVariable", "Finishy");   
            edtIntervaly.Text = ini.IniReadValue("TwoVariable", "Intervaly");
            edtTrainPercent.Text = ini.IniReadValue("TwoVariable", "TrainPercent");
            edtTestPercent.Text = ini.IniReadValue("TwoVariable", "TestPercent");
            edtInOrder.Checked= Convert.ToBoolean(ini.IniReadValue("TwoVariable", "InOrder"));
            edtRandom.Checked = Convert.ToBoolean(ini.IniReadValue("TwoVariable", "Random"));
            edtInterval.Checked = Convert.ToBoolean(ini.IniReadValue("TwoVariable", "Interval"));
            edtIncrementx.Text = ini.IniReadValue("TwoVariable", "Incrementx");
            edtIncrementy.Text = ini.IniReadValue("TwoVariable", "Incrementy");
        }

        public void CreateData()
        {
            #region Clear
            dtData.Rows.Clear();
            dtData.Columns.Clear();
            #endregion Clear
            if (edtFunction.Text == "" || edtStartx.Text == "" || edtFinishx.Text=="" || edtIntervalx.Text == "" || edtStarty.Text == "" || edtFinishy.Text==""|| edtIntervaly.Text == "")
            {
                MessageBox.Show("Please, enter all the parameters of the dataset.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            #region Settings
            startx = double.Parse(edtStartx.Text);
            finishx = double.Parse(edtFinishx.Text);
            starty = double.Parse(edtStarty.Text);
            finishy = double.Parse(edtFinishy.Text);
            double addx = double.Parse(edtIntervalx.Text);
           // double addy = double.Parse(edtIntervaly.Text);
            DataTable data = new DataTable();
            text = edtFunction.Text;
            double k = starty;
            double xx = (finishx - (startx)) / addx;
            //    double yy = (finishy - (starty)) / addy;
            var addy = (finishy - (starty)) / xx;
            edtIntervaly.Text = addy.ToString();
            #endregion Settings
            #region Create Dataset
            for (double i = startx; i <= finishx; i += addx)
            {
                input = string.Empty;
                inputsx.Add(Math.Round(i, 5));

                inputsy.Add(Math.Round(k, 5));
                for (int j = 0; j < text.Length; j++)
                {
                    string ch = text[j].ToString();
                    if (ch == "x") ch = i.ToString();
                    if (ch == "y") ch = k.ToString();
                    input += ch;
                }
                outputs.Add(parser.Parse(input));
                k += addy;
            }
            dtData.Columns.Add("input1", typeof(string));
            dtData.Columns.Add("input2", typeof(string));
            dtData.Columns.Add("input3", typeof(string));
            dtData.Columns.Add("output", typeof(string));
            for (int i = 0; i < inputsx.Count; i++)
            {
                DataRow dr = dtData.NewRow();
                dr["input1"] = inputsx[i];
                dr["input2"] = inputsy[i];
                dr["input3"] = outputs[i];
                if (outputs[i] < 0) dr["output"] = 0;
                else if (outputs[i] == 0) dr["output"] = 1;
                else if (outputs[i] > 0) dr["output"] = 2;
                dtData.Rows.Add(dr);
            }

            grdData.DataSource = dtData;
            tls.MyGridStyle(grdData);
            #endregion Create Dataset
        }

        public void CreateTrainTest()
        {
            if (edtTrainPercent.Text == "" && edtTestPercent.Text == "")
            {
                MessageBox.Show("Please, enter percentage of train and test set.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtInterval.Checked && edtIncrementx.Text == "" )
            {
                MessageBox.Show("Please, enter incremental value of x.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtInterval.Checked && edtIncrementy.Text == "")
            {
                MessageBox.Show("Please, enter incremental value of y.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (edtInterval.Checked == false && edtInOrder.Checked == false && edtRandom.Checked == false)
            {
                MessageBox.Show("Please, select creation type of train and test set.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            #region Clear
            dtTrain.Rows.Clear();
            dtTest.Rows.Clear();
            dtTrain.Columns.Clear();
            dtTest.Columns.Clear();
            #endregion Clear
            #region Create train and test set columns
            dtTrain.Columns.Add("input1", typeof(string));
            dtTrain.Columns.Add("input2", typeof(string));
            dtTrain.Columns.Add("input3", typeof(string));
            dtTrain.Columns.Add("output", typeof(string));
            dtTest.Columns.Add("input1", typeof(string));
            dtTest.Columns.Add("input2", typeof(string));
            dtTest.Columns.Add("input3", typeof(string));
            dtTest.Columns.Add("output", typeof(string));
            #endregion Create train and test set columns
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
                double addx = double.Parse(edtIncrementx.Text);
                double timesx = Math.Round(addx / double.Parse(edtIntervalx.Text), 0);
                double addy = double.Parse(edtIncrementy.Text);
                double timesy = Math.Round(timesx* double.Parse(edtIntervaly.Text), 0);

                List<int> TrainIndex = new List<int>();
                List<DataRow> drows = new List<DataRow>();
                for (int i = 0; i < count; i += (int)timesx)
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
            #endregion Interval

            tabMain.SelectedIndex = 1;
            grdTrain.DataSource = dtTrain;
            tls.MyGridStyle(grdTrain);
            grdTest.DataSource = dtTest;           
            tls.MyGridStyle(grdTest);
            WriteParameter();
        }

        public void PrintDataset()
        {
            string filename = $"{foldername}\\Dataset{DateTime.Now.ToString("u").Replace(':', '-')}.txt";
            tls.PrintTxt(filename, dtData, edtFunction.Text);
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
                if (edtTrainPercent.Text ==null ) edtTestPercent.Text = null;
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

        private void edtStarty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtFinishy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtIntervaly_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtIncrementy_KeyPress(object sender, KeyPressEventArgs e)
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
