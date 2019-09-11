using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NeuralNetworks.Forms
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        Series s;
        private void Error_Load(object sender, EventArgs e)
        {
            chartError.Series.Clear();
            chartError.Series.Add("Error");
            chartError.Series[0].ChartType = SeriesChartType.FastLine;
            chartError.Series[0].Color = Color.Red;
            s = chartError.Series[0];
        }

        int lastTime = 0;

        public void update(double l)
        {
            chartError.Invoke(new Action(() =>
            {

                s.Points.Add(l);
                if (Environment.TickCount - lastTime > 800)
                {
                    lastTime = Environment.TickCount;
                    chartError.Invalidate();
                }
                //edtCurrentIteration.Text =((BackPropagation)Application.OpenForms["BackPropagation"]).count.ToString();
                //edtCurrentError.Text = l.ToString();
            }));

        }
    }
}
