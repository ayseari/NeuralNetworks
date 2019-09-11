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
using PerceptronSample;
using System.IO;
using System.Drawing.Drawing2D;

namespace NeuralNetworks.Forms
{
    public partial class Adaline : Form
    {
        #region Definitions

        nnTools.IniFile ini =
            new nnTools.IniFile(string.Format(@"{0}\prmAdaline.ini", Directory.GetCurrentDirectory()));

        List<Sample> samples = new List<Sample>();
        List<double> weights = new List<double>();
        Graphics objGraphics;
        Graphics grph;
        private double x1, x2, x3, x4;
        double thresholdValue = 0.0;
        double learningrate = 0.5;
        private double r = -30;
        private double p = 30;
        private int k = 50;
        private int iteration = 0;
        int maxIterations = 100;
        int sindex = 0;
        int control = 0;

        #endregion Definitions    

        public Adaline()
        {
            InitializeComponent();
        }

        public void WriteParameter()
        {
            try
            {
                ini.IniWriteValue("Adaline", "LearningRate", edtLearningRate.Text);
                ini.IniWriteValue("Adaline", "ThresholdValue", edtThreshold.Text);
                ini.IniWriteValue("Adaline", "Iteration", edtIteration.Text);
                ini.IniWriteValue("Adaline", "Weight1", edtWeight1.Text);
                ini.IniWriteValue("Adaline", "Weight2", edtWeight2.Text);
                ini.IniWriteValue("Adaline", "And", edtAnd.Checked.ToString());
                ini.IniWriteValue("Adaline", "Or", edtOR.Checked.ToString());
                ini.IniWriteValue("Adaline", "Xor", edtXOR.Checked.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error writing the parameter to inifile. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
   
        }

        private void ReadParameter()
        {
            try
            {
                edtLearningRate.Text = ini.IniReadValue("Adaline", "LearningRate");
                edtThreshold.Text = ini.IniReadValue("Adaline", "ThresholdValue");
                edtIteration.Text = ini.IniReadValue("Adaline", "Iteration");
                edtWeight1.Text = ini.IniReadValue("Adaline", "Weight1");
                edtWeight2.Text = ini.IniReadValue("Adaline", "Weight2");
                edtAnd.Checked = Convert.ToBoolean(ini.IniReadValue("Adaline", "And"));
                edtOR.Checked = Convert.ToBoolean(ini.IniReadValue("Adaline", "Or"));
                edtXOR.Checked = Convert.ToBoolean(ini.IniReadValue("Adaline", "Xor"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error reading the parameter from inifile. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
   
        }

        private void Adaline_Load(object sender, EventArgs e)
        {
            ReadParameter();
            objGraphics = edtPicture.CreateGraphics();
            grph = edtPicture.CreateGraphics();
            if (edtAnd.CanSelect)
            {
                samples.Add(new Sample(0.0, 0.0, -1));
                samples.Add(new Sample(1.0, 0.0, -1));
                samples.Add(new Sample(0.0, 1.0, -1));
                samples.Add(new Sample(1.0, 1.0, 1));
            }
            else if (edtOR.CanSelect)
            {
                samples.Add(new Sample(0.0, 0.0, -1));
                samples.Add(new Sample(1.0, 0.0, 1));
                samples.Add(new Sample(0.0, 1.0, 1));
                samples.Add(new Sample(1.0, 1.0, 1));
            }
            else
            {
                samples.Add(new Sample(0.0, 0.0, -1));
                samples.Add(new Sample(1.0, 0.0, 1));
                samples.Add(new Sample(0.0, 1.0, 1));
                samples.Add(new Sample(1.0, 1.0, -1));
            }
        }

        private void edtPicture_MouseDown(object sender, MouseEventArgs e)
        {
            Sample sample;
            SolidBrush brush = new SolidBrush(Color.Blue);

            double posX = (double)(e.X - edtPicture.Width / 2) / k;
            double posY = (double)(edtPicture.Height / 2 - e.Y) / k;

            if (e.Button == MouseButtons.Left)
            {
                brush = new SolidBrush(Color.Blue);
                sample = new Sample(posX, posY, 1);
            }
            else
            {
                brush = new SolidBrush(Color.DarkRed);
                sample = new Sample(posX, posY, -1);
            }
            samples.Add(sample);

            objGraphics.FillEllipse(brush, e.X, e.Y, 8f, 8f);
        }

        private void edtPicture_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int xo = edtPicture.Width / 2;
            int yo = edtPicture.Height / 2;
            g.FillRectangle(Brushes.White, 0, 0, 2 * xo, 2 * yo);

            if (samples.Count == 0) return;

            g.DrawLine(Pens.Gray, new Point(0, yo), new Point(2 * xo, yo));
            g.DrawLine(Pens.Gray, new Point(xo, 0), new Point(xo, 2 * yo));
            var rr = 4f;
            for (int i = 0; i < samples.Count; i++)
            {

                g.FillEllipse(samples[i].Class == 1 ? Brushes.Blue : Brushes.DarkRed,
                    (float)samples[i].X1 * k + xo,
                    yo - (float)samples[i].X2 * k, 2 * rr, 2 * rr);

            }
            if (tmrLearn.Enabled == false && control < samples.Count)
            {
                g.DrawString("The seperation line not found !", new Font(FontFamily.GenericMonospace, 19), Brushes.Blue, 15, 15);
                return;
            }


            g.DrawLine(Pens.Black, xo + (float)x2, yo - (float)x1, xo + (float)x3, yo - (float)x4);
        }

        private void iterations(Sample s)
        {

            int y;
            double net = 0;

            net = s.X1 * weights[0] + s.X2 * weights[1];

            net += thresholdValue;
            if (net >= 0)
            {
                y = 1;
            }
            else
            {
                y = -1;
            }
            if (y != s.Class)
            {
                control = 0;

                weights[0] = weights[0] + learningrate * (s.Class - y) * s.X1;
                weights[1] = weights[1] + learningrate * (s.Class - y) * s.X2;
                thresholdValue = thresholdValue + learningrate * (s.Class - y);
            }
            else
            {
                control++;
            }
            iteration++;
            x2 = r * k;
            x1 = -(weights[0] / weights[1]) * r * k - thresholdValue * k / weights[1];
            x3 = p * k;
            x4 = -(weights[0] / weights[1]) * p * k - thresholdValue * k / weights[1];
            if (x1 == double.MaxValue || x2 == double.MaxValue) tmrLearn.Enabled = false;
        }

        public void Learn()
        {
            if (double.TryParse(edtThreshold.Text, out thresholdValue) == false || edtLearningRate.Text == "" || edtIteration.Text == "" || edtWeight1.Text == "" || edtWeight2.Text == "")
            {
                MessageBox.Show("Please, enter all the parameters required for the network.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
  
            maxIterations = int.Parse(edtIteration.Text);
            weights.Add(double.Parse(edtWeight1.Text));
            weights.Add(double.Parse(edtWeight2.Text));
            learningrate = double.Parse(edtLearningRate.Text);
            thresholdValue = double.Parse(edtThreshold.Text);
            tmrLearn.Interval = 100;
            tmrLearn.Enabled = true;
            sindex = 0;
            iteration = 0;
            control = 0;
        }

        public void ClearSamples()
        {
            samples.Clear();
            edtPicture.Invalidate();
        }

        private void tmrLearn_Tick(object sender, EventArgs e)
        {
            if ((control == samples.Count) || (iteration == maxIterations))
            {
                tmrLearn.Enabled = false;
                edtPicture.Invalidate();
                if (control < samples.Count)
                    MessageBox.Show("Network is not learned.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    MessageBox.Show("Network is learned.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }

            var s = samples[sindex];
            iterations(s);
            if (++sindex >= samples.Count) sindex = 0;
            edtPicture.Invalidate();
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

        private void edtThreshold_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtIteration_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtWeight1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtWeight2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void edtAnd_CheckedChanged(object sender, EventArgs e)
        {
            samples.Clear();
            samples.Add(new Sample(0.0, 0.0, -1));
            samples.Add(new Sample(1.0, 0.0, -1));
            samples.Add(new Sample(0.0, 1.0, -1));
            samples.Add(new Sample(1.0, 1.0, 1));
            edtPicture.Invalidate();
        }

        private void edtOR_CheckedChanged(object sender, EventArgs e)
        {
            samples.Clear();
            samples.Add(new Sample(0.0, 0.0, -1));
            samples.Add(new Sample(1.0, 0.0, 1));
            samples.Add(new Sample(0.0, 1.0, 1));
            samples.Add(new Sample(1.0, 1.0, 1));
            edtPicture.Invalidate();
        }

        private void edtXOR_CheckedChanged(object sender, EventArgs e)
        {
            samples.Clear();
            samples.Add(new Sample(0.0, 0.0, -1));
            samples.Add(new Sample(1.0, 0.0, 1));
            samples.Add(new Sample(0.0, 1.0, 1));
            samples.Add(new Sample(1.0, 1.0, -1));
            edtPicture.Invalidate();
        }
    }
}
