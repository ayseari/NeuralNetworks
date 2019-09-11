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
    public partial class PlotError : Form
    {
        public PlotError()
        {
            InitializeComponent();
            chartPlotError.Series.Clear();
            chartPlotError.Series.Add("Error");
            chartPlotError.Series[0].ChartType = SeriesChartType.FastLine;
            chartPlotError.Series[0].Color = Color.Red;
            int Count = ((BackPropagation)Application.OpenForms["BackPropagation"]).ErrorPoints.Count;
            for (int i = 0; i < Count; i++)
            {
                chartPlotError.Series[0].Points.AddXY(i, ((BackPropagation)Application.OpenForms["BackPropagation"]).ErrorPoints[i]);
            }
        }
    }
}
