namespace NeuralNetworks.Forms
{
    partial class PlotError
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPlotError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlotError)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPlotError
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPlotError.ChartAreas.Add(chartArea1);
            this.chartPlotError.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartPlotError.Legends.Add(legend1);
            this.chartPlotError.Location = new System.Drawing.Point(0, 0);
            this.chartPlotError.Name = "chartPlotError";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPlotError.Series.Add(series1);
            this.chartPlotError.Size = new System.Drawing.Size(426, 341);
            this.chartPlotError.TabIndex = 1;
            this.chartPlotError.Text = "chart1";
            // 
            // PlotError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 341);
            this.Controls.Add(this.chartPlotError);
            this.Name = "PlotError";
            this.Text = "Plot Error";
            ((System.ComponentModel.ISupportInitialize)(this.chartPlotError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlotError;
    }
}