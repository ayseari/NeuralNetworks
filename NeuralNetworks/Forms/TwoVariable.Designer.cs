namespace NeuralNetworks.Forms
{
    partial class TwoVariable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTrainTest = new System.Windows.Forms.GroupBox();
            this.edtIncrementy = new System.Windows.Forms.TextBox();
            this.edtIncrementx = new System.Windows.Forms.TextBox();
            this.edtInterval = new System.Windows.Forms.CheckBox();
            this.edtRandom = new System.Windows.Forms.CheckBox();
            this.edtInOrder = new System.Windows.Forms.CheckBox();
            this.edtTestPercent = new System.Windows.Forms.TextBox();
            this.edtTrainPercent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.edtFinishy = new System.Windows.Forms.TextBox();
            this.edtFinishx = new System.Windows.Forms.TextBox();
            this.edtIntervalx = new System.Windows.Forms.TextBox();
            this.edtIntervaly = new System.Windows.Forms.TextBox();
            this.edtStarty = new System.Windows.Forms.TextBox();
            this.edtStartx = new System.Windows.Forms.TextBox();
            this.edtFunction = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFinishy = new System.Windows.Forms.Label();
            this.lblFinishx = new System.Windows.Forms.Label();
            this.lblStarty = new System.Windows.Forms.Label();
            this.lblStartx = new System.Windows.Forms.Label();
            this.lblFunction = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpgData = new System.Windows.Forms.TabPage();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.tpgTrainTest = new System.Windows.Forms.TabPage();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.grdTrain = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpTrainTest.SuspendLayout();
            this.grpData.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tpgData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.tpgTrainTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTrainTest);
            this.pnlTop.Controls.Add(this.grpData);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(974, 125);
            this.pnlTop.TabIndex = 1;
            // 
            // grpTrainTest
            // 
            this.grpTrainTest.BackColor = System.Drawing.Color.LightBlue;
            this.grpTrainTest.Controls.Add(this.edtIncrementy);
            this.grpTrainTest.Controls.Add(this.edtIncrementx);
            this.grpTrainTest.Controls.Add(this.edtInterval);
            this.grpTrainTest.Controls.Add(this.edtRandom);
            this.grpTrainTest.Controls.Add(this.edtInOrder);
            this.grpTrainTest.Controls.Add(this.edtTestPercent);
            this.grpTrainTest.Controls.Add(this.edtTrainPercent);
            this.grpTrainTest.Controls.Add(this.label1);
            this.grpTrainTest.Controls.Add(this.label2);
            this.grpTrainTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTrainTest.Location = new System.Drawing.Point(508, 0);
            this.grpTrainTest.Name = "grpTrainTest";
            this.grpTrainTest.Size = new System.Drawing.Size(466, 125);
            this.grpTrainTest.TabIndex = 2;
            this.grpTrainTest.TabStop = false;
            this.grpTrainTest.Text = "Train and Test Parameters";
            // 
            // edtIncrementy
            // 
            this.edtIncrementy.Location = new System.Drawing.Point(405, 87);
            this.edtIncrementy.Name = "edtIncrementy";
            this.edtIncrementy.Size = new System.Drawing.Size(49, 20);
            this.edtIncrementy.TabIndex = 13;
            this.edtIncrementy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIncrementy_KeyPress);
            // 
            // edtIncrementx
            // 
            this.edtIncrementx.Location = new System.Drawing.Point(350, 87);
            this.edtIncrementx.Name = "edtIncrementx";
            this.edtIncrementx.Size = new System.Drawing.Size(49, 20);
            this.edtIncrementx.TabIndex = 12;
            this.edtIncrementx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIncrementx_KeyPress);
            // 
            // edtInterval
            // 
            this.edtInterval.AutoSize = true;
            this.edtInterval.Location = new System.Drawing.Point(246, 87);
            this.edtInterval.Name = "edtInterval";
            this.edtInterval.Size = new System.Drawing.Size(98, 17);
            this.edtInterval.TabIndex = 11;
            this.edtInterval.Text = "Interval x and y";
            this.edtInterval.UseVisualStyleBackColor = true;
            // 
            // edtRandom
            // 
            this.edtRandom.AutoSize = true;
            this.edtRandom.Location = new System.Drawing.Point(246, 57);
            this.edtRandom.Name = "edtRandom";
            this.edtRandom.Size = new System.Drawing.Size(66, 17);
            this.edtRandom.TabIndex = 10;
            this.edtRandom.Text = "Random";
            this.edtRandom.UseVisualStyleBackColor = true;
            // 
            // edtInOrder
            // 
            this.edtInOrder.AutoSize = true;
            this.edtInOrder.Location = new System.Drawing.Point(246, 24);
            this.edtInOrder.Name = "edtInOrder";
            this.edtInOrder.Size = new System.Drawing.Size(64, 17);
            this.edtInOrder.TabIndex = 9;
            this.edtInOrder.Text = "In Order";
            this.edtInOrder.UseVisualStyleBackColor = true;
            // 
            // edtTestPercent
            // 
            this.edtTestPercent.Location = new System.Drawing.Point(112, 83);
            this.edtTestPercent.Name = "edtTestPercent";
            this.edtTestPercent.Size = new System.Drawing.Size(75, 20);
            this.edtTestPercent.TabIndex = 8;
            this.edtTestPercent.TextChanged += new System.EventHandler(this.edtTestPercent_TextChanged);
            this.edtTestPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtTestPercent_KeyPress);
            // 
            // edtTrainPercent
            // 
            this.edtTrainPercent.Location = new System.Drawing.Point(112, 35);
            this.edtTrainPercent.Name = "edtTrainPercent";
            this.edtTrainPercent.Size = new System.Drawing.Size(74, 20);
            this.edtTrainPercent.TabIndex = 7;
            this.edtTrainPercent.TextChanged += new System.EventHandler(this.edtTrainPercent_TextChanged);
            this.edtTrainPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtTrainPercent_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Test  % :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Train % :";
            // 
            // grpData
            // 
            this.grpData.BackColor = System.Drawing.Color.LightBlue;
            this.grpData.Controls.Add(this.edtFinishy);
            this.grpData.Controls.Add(this.edtFinishx);
            this.grpData.Controls.Add(this.edtIntervalx);
            this.grpData.Controls.Add(this.edtIntervaly);
            this.grpData.Controls.Add(this.edtStarty);
            this.grpData.Controls.Add(this.edtStartx);
            this.grpData.Controls.Add(this.edtFunction);
            this.grpData.Controls.Add(this.label7);
            this.grpData.Controls.Add(this.label6);
            this.grpData.Controls.Add(this.lblFinishy);
            this.grpData.Controls.Add(this.lblFinishx);
            this.grpData.Controls.Add(this.lblStarty);
            this.grpData.Controls.Add(this.lblStartx);
            this.grpData.Controls.Add(this.lblFunction);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(508, 125);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            this.grpData.Text = "Data Parameters";
            // 
            // edtFinishy
            // 
            this.edtFinishy.Location = new System.Drawing.Point(238, 92);
            this.edtFinishy.Name = "edtFinishy";
            this.edtFinishy.Size = new System.Drawing.Size(74, 20);
            this.edtFinishy.TabIndex = 5;
            this.edtFinishy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtFinishy_KeyPress);
            // 
            // edtFinishx
            // 
            this.edtFinishx.Location = new System.Drawing.Point(238, 62);
            this.edtFinishx.Name = "edtFinishx";
            this.edtFinishx.Size = new System.Drawing.Size(74, 20);
            this.edtFinishx.TabIndex = 2;
            this.edtFinishx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtFinishx_KeyPress);
            // 
            // edtIntervalx
            // 
            this.edtIntervalx.Location = new System.Drawing.Point(390, 59);
            this.edtIntervalx.Name = "edtIntervalx";
            this.edtIntervalx.Size = new System.Drawing.Size(79, 20);
            this.edtIntervalx.TabIndex = 3;
            this.edtIntervalx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIntervalx_KeyPress);
            // 
            // edtIntervaly
            // 
            this.edtIntervaly.Location = new System.Drawing.Point(390, 92);
            this.edtIntervaly.Name = "edtIntervaly";
            this.edtIntervaly.Size = new System.Drawing.Size(79, 20);
            this.edtIntervaly.TabIndex = 6;
            this.edtIntervaly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIntervaly_KeyPress);
            // 
            // edtStarty
            // 
            this.edtStarty.Location = new System.Drawing.Point(92, 92);
            this.edtStarty.Name = "edtStarty";
            this.edtStarty.Size = new System.Drawing.Size(75, 20);
            this.edtStarty.TabIndex = 4;
            this.edtStarty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtStarty_KeyPress);
            // 
            // edtStartx
            // 
            this.edtStartx.Location = new System.Drawing.Point(92, 59);
            this.edtStartx.Name = "edtStartx";
            this.edtStartx.Size = new System.Drawing.Size(74, 20);
            this.edtStartx.TabIndex = 1;
            this.edtStartx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtStartx_KeyPress);
            // 
            // edtFunction
            // 
            this.edtFunction.Location = new System.Drawing.Point(106, 22);
            this.edtFunction.Name = "edtFunction";
            this.edtFunction.Size = new System.Drawing.Size(363, 20);
            this.edtFunction.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Interval for x :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Interval for y :";
            // 
            // lblFinishy
            // 
            this.lblFinishy.AutoSize = true;
            this.lblFinishy.Location = new System.Drawing.Point(173, 95);
            this.lblFinishy.Name = "lblFinishy";
            this.lblFinishy.Size = new System.Drawing.Size(60, 13);
            this.lblFinishy.TabIndex = 4;
            this.lblFinishy.Text = "Finish for y:";
            // 
            // lblFinishx
            // 
            this.lblFinishx.AutoSize = true;
            this.lblFinishx.Location = new System.Drawing.Point(172, 62);
            this.lblFinishx.Name = "lblFinishx";
            this.lblFinishx.Size = new System.Drawing.Size(60, 13);
            this.lblFinishx.TabIndex = 3;
            this.lblFinishx.Text = "Finish for x:";
            // 
            // lblStarty
            // 
            this.lblStarty.AutoSize = true;
            this.lblStarty.Location = new System.Drawing.Point(31, 95);
            this.lblStarty.Name = "lblStarty";
            this.lblStarty.Size = new System.Drawing.Size(55, 13);
            this.lblStarty.TabIndex = 2;
            this.lblStarty.Text = "Start for y:";
            // 
            // lblStartx
            // 
            this.lblStartx.AutoSize = true;
            this.lblStartx.Location = new System.Drawing.Point(31, 62);
            this.lblStartx.Name = "lblStartx";
            this.lblStartx.Size = new System.Drawing.Size(55, 13);
            this.lblStartx.TabIndex = 1;
            this.lblStartx.Text = "Start for x:";
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(31, 22);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(54, 13);
            this.lblFunction.TabIndex = 0;
            this.lblFunction.Text = "Function :";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tpgData);
            this.tabMain.Controls.Add(this.tpgTrainTest);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 125);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(974, 480);
            this.tabMain.TabIndex = 2;
            // 
            // tpgData
            // 
            this.tpgData.Controls.Add(this.grdData);
            this.tpgData.Location = new System.Drawing.Point(4, 22);
            this.tpgData.Name = "tpgData";
            this.tpgData.Padding = new System.Windows.Forms.Padding(3);
            this.tpgData.Size = new System.Drawing.Size(966, 454);
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
            this.grdData.Size = new System.Drawing.Size(960, 448);
            this.grdData.TabIndex = 0;
            this.grdData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdData_RowPostPaint);
            // 
            // tpgTrainTest
            // 
            this.tpgTrainTest.Controls.Add(this.grdTest);
            this.tpgTrainTest.Controls.Add(this.grdTrain);
            this.tpgTrainTest.Location = new System.Drawing.Point(4, 22);
            this.tpgTrainTest.Name = "tpgTrainTest";
            this.tpgTrainTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpgTrainTest.Size = new System.Drawing.Size(966, 454);
            this.tpgTrainTest.TabIndex = 1;
            this.tpgTrainTest.Text = "Train and Test set";
            this.tpgTrainTest.UseVisualStyleBackColor = true;
            // 
            // grdTest
            // 
            this.grdTest.AllowUserToAddRows = false;
            this.grdTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTest.EnableHeadersVisualStyles = false;
            this.grdTest.Location = new System.Drawing.Point(498, 3);
            this.grdTest.Name = "grdTest";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTest.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdTest.Size = new System.Drawing.Size(465, 448);
            this.grdTest.TabIndex = 1;
            this.grdTest.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdTest_RowPostPaint);
            // 
            // grdTrain
            // 
            this.grdTrain.AllowUserToAddRows = false;
            this.grdTrain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTrain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTrain.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdTrain.EnableHeadersVisualStyles = false;
            this.grdTrain.Location = new System.Drawing.Point(3, 3);
            this.grdTrain.Name = "grdTrain";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdTrain.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdTrain.Size = new System.Drawing.Size(495, 448);
            this.grdTrain.TabIndex = 0;
            this.grdTrain.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdTrain_RowPostPaint);
            // 
            // TwoVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 605);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "TwoVariable";
            this.Text = "Function";
            this.pnlTop.ResumeLayout(false);
            this.grpTrainTest.ResumeLayout(false);
            this.grpTrainTest.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tpgData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.tpgTrainTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grpTrainTest;
        private System.Windows.Forms.TextBox edtIncrementy;
        private System.Windows.Forms.TextBox edtIncrementx;
        private System.Windows.Forms.CheckBox edtInterval;
        private System.Windows.Forms.CheckBox edtRandom;
        private System.Windows.Forms.CheckBox edtInOrder;
        private System.Windows.Forms.TextBox edtTestPercent;
        private System.Windows.Forms.TextBox edtTrainPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.TextBox edtFinishy;
        private System.Windows.Forms.TextBox edtFinishx;
        private System.Windows.Forms.TextBox edtIntervalx;
        private System.Windows.Forms.TextBox edtIntervaly;
        private System.Windows.Forms.TextBox edtStarty;
        private System.Windows.Forms.TextBox edtStartx;
        private System.Windows.Forms.TextBox edtFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFinishy;
        private System.Windows.Forms.Label lblFinishx;
        private System.Windows.Forms.Label lblStarty;
        private System.Windows.Forms.Label lblStartx;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpgData;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.TabPage tpgTrainTest;
        private System.Windows.Forms.DataGridView grdTest;
        private System.Windows.Forms.DataGridView grdTrain;
    }
}