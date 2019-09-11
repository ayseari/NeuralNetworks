namespace NeuralNetworks.Forms
{
    partial class OneVariable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTrainTest = new System.Windows.Forms.GroupBox();
            this.edtIncrementx = new System.Windows.Forms.TextBox();
            this.edtInterval = new System.Windows.Forms.CheckBox();
            this.edtRandom = new System.Windows.Forms.CheckBox();
            this.edtInOrder = new System.Windows.Forms.CheckBox();
            this.edtTestPercent = new System.Windows.Forms.TextBox();
            this.edtTrainPercent = new System.Windows.Forms.TextBox();
            this.lblTestPercent = new System.Windows.Forms.Label();
            this.lblTrainPercent = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.edtFinishx = new System.Windows.Forms.TextBox();
            this.edtIntervalx = new System.Windows.Forms.TextBox();
            this.edtStartx = new System.Windows.Forms.TextBox();
            this.edtFunction = new System.Windows.Forms.TextBox();
            this.Intervalx = new System.Windows.Forms.Label();
            this.lblFinishx = new System.Windows.Forms.Label();
            this.lblStartx = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.chartFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpgData = new System.Windows.Forms.TabPage();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.tpgTrain = new System.Windows.Forms.TabPage();
            this.grdTrain = new System.Windows.Forms.DataGridView();
            this.tpgTest = new System.Windows.Forms.TabPage();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpTrainTest.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tpgData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tpgTrain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).BeginInit();
            this.tpgTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTrainTest);
            this.pnlTop.Controls.Add(this.grpData);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1030, 118);
            this.pnlTop.TabIndex = 0;
            // 
            // grpTrainTest
            // 
            this.grpTrainTest.BackColor = System.Drawing.Color.LightBlue;
            this.grpTrainTest.Controls.Add(this.edtIncrementx);
            this.grpTrainTest.Controls.Add(this.edtInterval);
            this.grpTrainTest.Controls.Add(this.edtRandom);
            this.grpTrainTest.Controls.Add(this.edtInOrder);
            this.grpTrainTest.Controls.Add(this.edtTestPercent);
            this.grpTrainTest.Controls.Add(this.edtTrainPercent);
            this.grpTrainTest.Controls.Add(this.lblTestPercent);
            this.grpTrainTest.Controls.Add(this.lblTrainPercent);
            this.grpTrainTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTrainTest.Location = new System.Drawing.Point(508, 0);
            this.grpTrainTest.Name = "grpTrainTest";
            this.grpTrainTest.Size = new System.Drawing.Size(522, 118);
            this.grpTrainTest.TabIndex = 3;
            this.grpTrainTest.TabStop = false;
            this.grpTrainTest.Text = "Train and Test Parameters";
            // 
            // edtIncrementx
            // 
            this.edtIncrementx.Location = new System.Drawing.Point(313, 83);
            this.edtIncrementx.Name = "edtIncrementx";
            this.edtIncrementx.Size = new System.Drawing.Size(49, 20);
            this.edtIncrementx.TabIndex = 9;
            this.edtIncrementx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIncrementx_KeyPress);
            // 
            // edtInterval
            // 
            this.edtInterval.AutoSize = true;
            this.edtInterval.Location = new System.Drawing.Point(246, 87);
            this.edtInterval.Name = "edtInterval";
            this.edtInterval.Size = new System.Drawing.Size(61, 17);
            this.edtInterval.TabIndex = 8;
            this.edtInterval.Text = "Interval";
            this.edtInterval.UseVisualStyleBackColor = true;
            // 
            // edtRandom
            // 
            this.edtRandom.AutoSize = true;
            this.edtRandom.Location = new System.Drawing.Point(246, 57);
            this.edtRandom.Name = "edtRandom";
            this.edtRandom.Size = new System.Drawing.Size(66, 17);
            this.edtRandom.TabIndex = 7;
            this.edtRandom.Text = "Random";
            this.edtRandom.UseVisualStyleBackColor = true;
            // 
            // edtInOrder
            // 
            this.edtInOrder.AutoSize = true;
            this.edtInOrder.Location = new System.Drawing.Point(246, 24);
            this.edtInOrder.Name = "edtInOrder";
            this.edtInOrder.Size = new System.Drawing.Size(64, 17);
            this.edtInOrder.TabIndex = 6;
            this.edtInOrder.Text = "In Order";
            this.edtInOrder.UseVisualStyleBackColor = true;
            // 
            // edtTestPercent
            // 
            this.edtTestPercent.Location = new System.Drawing.Point(112, 83);
            this.edtTestPercent.Name = "edtTestPercent";
            this.edtTestPercent.Size = new System.Drawing.Size(75, 20);
            this.edtTestPercent.TabIndex = 5;
            this.edtTestPercent.TextChanged += new System.EventHandler(this.edtTestPercent_TextChanged);
            this.edtTestPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtTestPercent_KeyPress);
            // 
            // edtTrainPercent
            // 
            this.edtTrainPercent.Location = new System.Drawing.Point(112, 35);
            this.edtTrainPercent.Name = "edtTrainPercent";
            this.edtTrainPercent.Size = new System.Drawing.Size(74, 20);
            this.edtTrainPercent.TabIndex = 4;
            this.edtTrainPercent.TextChanged += new System.EventHandler(this.edtTrainPercent_TextChanged);
            this.edtTrainPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtTrainPercent_KeyPress);
            // 
            // lblTestPercent
            // 
            this.lblTestPercent.AutoSize = true;
            this.lblTestPercent.Location = new System.Drawing.Point(64, 86);
            this.lblTestPercent.Name = "lblTestPercent";
            this.lblTestPercent.Size = new System.Drawing.Size(48, 13);
            this.lblTestPercent.TabIndex = 13;
            this.lblTestPercent.Text = "Test  % :";
            // 
            // lblTrainPercent
            // 
            this.lblTrainPercent.AutoSize = true;
            this.lblTrainPercent.Location = new System.Drawing.Point(64, 35);
            this.lblTrainPercent.Name = "lblTrainPercent";
            this.lblTrainPercent.Size = new System.Drawing.Size(48, 13);
            this.lblTrainPercent.TabIndex = 12;
            this.lblTrainPercent.Text = "Train % :";
            // 
            // grpData
            // 
            this.grpData.BackColor = System.Drawing.Color.LightBlue;
            this.grpData.Controls.Add(this.edtFinishx);
            this.grpData.Controls.Add(this.edtIntervalx);
            this.grpData.Controls.Add(this.edtStartx);
            this.grpData.Controls.Add(this.edtFunction);
            this.grpData.Controls.Add(this.Intervalx);
            this.grpData.Controls.Add(this.lblFinishx);
            this.grpData.Controls.Add(this.lblStartx);
            this.grpData.Controls.Add(this.lblFunction);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(508, 118);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "Data Parameters";
            // 
            // edtFinishx
            // 
            this.edtFinishx.Location = new System.Drawing.Point(242, 75);
            this.edtFinishx.Name = "edtFinishx";
            this.edtFinishx.Size = new System.Drawing.Size(74, 20);
            this.edtFinishx.TabIndex = 2;
            this.edtFinishx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtFinishx_KeyPress);
            // 
            // edtIntervalx
            // 
            this.edtIntervalx.Location = new System.Drawing.Point(394, 72);
            this.edtIntervalx.Name = "edtIntervalx";
            this.edtIntervalx.Size = new System.Drawing.Size(79, 20);
            this.edtIntervalx.TabIndex = 3;
            this.edtIntervalx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIntervalx_KeyPress);
            // 
            // edtStartx
            // 
            this.edtStartx.Location = new System.Drawing.Point(96, 72);
            this.edtStartx.Name = "edtStartx";
            this.edtStartx.Size = new System.Drawing.Size(74, 20);
            this.edtStartx.TabIndex = 1;
            this.edtStartx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtStartx_KeyPress);
            // 
            // edtFunction
            // 
            this.edtFunction.Location = new System.Drawing.Point(110, 35);
            this.edtFunction.Name = "edtFunction";
            this.edtFunction.Size = new System.Drawing.Size(363, 20);
            this.edtFunction.TabIndex = 0;
            // 
            // Intervalx
            // 
            this.Intervalx.AutoSize = true;
            this.Intervalx.Location = new System.Drawing.Point(322, 75);
            this.Intervalx.Name = "Intervalx";
            this.Intervalx.Size = new System.Drawing.Size(71, 13);
            this.Intervalx.TabIndex = 6;
            this.Intervalx.Text = "Interval for x :";
            // 
            // lblFinishx
            // 
            this.lblFinishx.AutoSize = true;
            this.lblFinishx.Location = new System.Drawing.Point(176, 75);
            this.lblFinishx.Name = "lblFinishx";
            this.lblFinishx.Size = new System.Drawing.Size(60, 13);
            this.lblFinishx.TabIndex = 3;
            this.lblFinishx.Text = "Finish for x:";
            // 
            // lblStartx
            // 
            this.lblStartx.AutoSize = true;
            this.lblStartx.Location = new System.Drawing.Point(35, 75);
            this.lblStartx.Name = "lblStartx";
            this.lblStartx.Size = new System.Drawing.Size(55, 13);
            this.lblStartx.TabIndex = 1;
            this.lblStartx.Text = "Start for x:";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(35, 35);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(54, 13);
            this.lblFunction.TabIndex = 0;
            this.lblFunction.Text = "Function :";
            // 
            // chartFunction
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFunction.ChartAreas.Add(chartArea1);
            this.chartFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartFunction.Legends.Add(legend1);
            this.chartFunction.Location = new System.Drawing.Point(508, 118);
            this.chartFunction.Name = "chartFunction";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFunction.Series.Add(series1);
            this.chartFunction.Size = new System.Drawing.Size(522, 441);
            this.chartFunction.TabIndex = 4;
            this.chartFunction.Text = "chart1";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpgData);
            this.tabMain.Controls.Add(this.tpgTrain);
            this.tabMain.Controls.Add(this.tpgTest);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabMain.Location = new System.Drawing.Point(0, 118);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(508, 441);
            this.tabMain.TabIndex = 5;
            // 
            // tpgData
            // 
            this.tpgData.Controls.Add(this.grdData);
            this.tpgData.Location = new System.Drawing.Point(4, 22);
            this.tpgData.Name = "tpgData";
            this.tpgData.Padding = new System.Windows.Forms.Padding(3);
            this.tpgData.Size = new System.Drawing.Size(500, 415);
            this.tpgData.TabIndex = 0;
            this.tpgData.Text = "Dataset";
            this.tpgData.UseVisualStyleBackColor = true;
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.EnableHeadersVisualStyles = false;
            this.grdData.Location = new System.Drawing.Point(3, 3);
            this.grdData.Name = "grdData";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdData.Size = new System.Drawing.Size(494, 409);
            this.grdData.TabIndex = 0;
            this.grdData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdData_RowPostPaint);
            // 
            // tpgTrain
            // 
            this.tpgTrain.Controls.Add(this.grdTrain);
            this.tpgTrain.Location = new System.Drawing.Point(4, 22);
            this.tpgTrain.Name = "tpgTrain";
            this.tpgTrain.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTrain.Size = new System.Drawing.Size(500, 415);
            this.tpgTrain.TabIndex = 1;
            this.tpgTrain.Text = "Trainset";
            this.tpgTrain.UseVisualStyleBackColor = true;
            // 
            // grdTrain
            // 
            this.grdTrain.AllowUserToAddRows = false;
            this.grdTrain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTrain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTrain.EnableHeadersVisualStyles = false;
            this.grdTrain.Location = new System.Drawing.Point(3, 3);
            this.grdTrain.Name = "grdTrain";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTrain.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdTrain.Size = new System.Drawing.Size(494, 409);
            this.grdTrain.TabIndex = 1;
            this.grdTrain.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdTrain_RowPostPaint);
            // 
            // tpgTest
            // 
            this.tpgTest.Controls.Add(this.grdTest);
            this.tpgTest.Location = new System.Drawing.Point(4, 22);
            this.tpgTest.Name = "tpgTest";
            this.tpgTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTest.Size = new System.Drawing.Size(500, 415);
            this.tpgTest.TabIndex = 2;
            this.tpgTest.Text = "Testset";
            this.tpgTest.UseVisualStyleBackColor = true;
            // 
            // grdTest
            // 
            this.grdTest.AllowUserToAddRows = false;
            this.grdTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTest.EnableHeadersVisualStyles = false;
            this.grdTest.Location = new System.Drawing.Point(3, 3);
            this.grdTest.Name = "grdTest";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTest.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdTest.Size = new System.Drawing.Size(494, 409);
            this.grdTest.TabIndex = 1;
            this.grdTest.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdTest_RowPostPaint);
            // 
            // OneVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 559);
            this.Controls.Add(this.chartFunction);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "OneVariable";
            this.Text = "OneVariable";
            this.pnlTop.ResumeLayout(false);
            this.grpTrainTest.ResumeLayout(false);
            this.grpTrainTest.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tpgData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tpgTrain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).EndInit();
            this.tpgTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.TextBox edtFinishx;
        private System.Windows.Forms.TextBox edtIntervalx;
        private System.Windows.Forms.TextBox edtStartx;
        private System.Windows.Forms.TextBox edtFunction;
        private System.Windows.Forms.Label Intervalx;
        private System.Windows.Forms.Label lblFinishx;
        private System.Windows.Forms.Label lblStartx;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.GroupBox grpTrainTest;
        private System.Windows.Forms.TextBox edtIncrementx;
        private System.Windows.Forms.CheckBox edtInterval;
        private System.Windows.Forms.CheckBox edtRandom;
        private System.Windows.Forms.CheckBox edtInOrder;
        private System.Windows.Forms.TextBox edtTestPercent;
        private System.Windows.Forms.TextBox edtTrainPercent;
        private System.Windows.Forms.Label lblTestPercent;
        private System.Windows.Forms.Label lblTrainPercent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpgData;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.TabPage tpgTrain;
        private System.Windows.Forms.DataGridView grdTrain;
        private System.Windows.Forms.TabPage tpgTest;
        private System.Windows.Forms.DataGridView grdTest;
    }
}