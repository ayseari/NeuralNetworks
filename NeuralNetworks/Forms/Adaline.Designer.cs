namespace NeuralNetworks.Forms
{
  partial class Adaline
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.edtXOR = new System.Windows.Forms.RadioButton();
            this.edtOR = new System.Windows.Forms.RadioButton();
            this.edtAnd = new System.Windows.Forms.RadioButton();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.edtWeight2 = new System.Windows.Forms.TextBox();
            this.edtWeight1 = new System.Windows.Forms.TextBox();
            this.edtThreshold = new System.Windows.Forms.TextBox();
            this.edtIteration = new System.Windows.Forms.TextBox();
            this.edtLearningRate = new System.Windows.Forms.TextBox();
            this.lblWeight2 = new System.Windows.Forms.Label();
            this.lblWeight1 = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblIteration = new System.Windows.Forms.Label();
            this.lblLR = new System.Windows.Forms.Label();
            this.edtPicture = new System.Windows.Forms.PictureBox();
            this.tmrLearn = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpData);
            this.panel1.Controls.Add(this.grpParameters);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 514);
            this.panel1.TabIndex = 0;
            // 
            // grpData
            // 
            this.grpData.BackColor = System.Drawing.Color.LightBlue;
            this.grpData.Controls.Add(this.edtXOR);
            this.grpData.Controls.Add(this.edtOR);
            this.grpData.Controls.Add(this.edtAnd);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 315);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(200, 199);
            this.grpData.TabIndex = 3;
            this.grpData.TabStop = false;
            this.grpData.Text = "Dataset";
            // 
            // edtXOR
            // 
            this.edtXOR.AutoSize = true;
            this.edtXOR.Location = new System.Drawing.Point(29, 143);
            this.edtXOR.Name = "edtXOR";
            this.edtXOR.Size = new System.Drawing.Size(48, 17);
            this.edtXOR.TabIndex = 2;
            this.edtXOR.TabStop = true;
            this.edtXOR.Text = "XOR";
            this.edtXOR.UseVisualStyleBackColor = true;
            this.edtXOR.CheckedChanged += new System.EventHandler(this.edtXOR_CheckedChanged);
            // 
            // edtOR
            // 
            this.edtOR.AutoSize = true;
            this.edtOR.Location = new System.Drawing.Point(29, 90);
            this.edtOR.Name = "edtOR";
            this.edtOR.Size = new System.Drawing.Size(41, 17);
            this.edtOR.TabIndex = 1;
            this.edtOR.TabStop = true;
            this.edtOR.Text = "OR";
            this.edtOR.UseVisualStyleBackColor = true;
            this.edtOR.CheckedChanged += new System.EventHandler(this.edtOR_CheckedChanged);
            // 
            // edtAnd
            // 
            this.edtAnd.AutoSize = true;
            this.edtAnd.Location = new System.Drawing.Point(29, 38);
            this.edtAnd.Name = "edtAnd";
            this.edtAnd.Size = new System.Drawing.Size(48, 17);
            this.edtAnd.TabIndex = 0;
            this.edtAnd.TabStop = true;
            this.edtAnd.Text = "AND";
            this.edtAnd.UseVisualStyleBackColor = true;
            this.edtAnd.CheckedChanged += new System.EventHandler(this.edtAnd_CheckedChanged);
            // 
            // grpParameters
            // 
            this.grpParameters.BackColor = System.Drawing.Color.LightBlue;
            this.grpParameters.Controls.Add(this.edtWeight2);
            this.grpParameters.Controls.Add(this.edtWeight1);
            this.grpParameters.Controls.Add(this.edtThreshold);
            this.grpParameters.Controls.Add(this.edtIteration);
            this.grpParameters.Controls.Add(this.edtLearningRate);
            this.grpParameters.Controls.Add(this.lblWeight2);
            this.grpParameters.Controls.Add(this.lblWeight1);
            this.grpParameters.Controls.Add(this.lblThreshold);
            this.grpParameters.Controls.Add(this.lblIteration);
            this.grpParameters.Controls.Add(this.lblLR);
            this.grpParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParameters.Location = new System.Drawing.Point(0, 0);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(200, 315);
            this.grpParameters.TabIndex = 2;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Learning Parameters";
            // 
            // edtWeight2
            // 
            this.edtWeight2.Location = new System.Drawing.Point(113, 265);
            this.edtWeight2.Name = "edtWeight2";
            this.edtWeight2.Size = new System.Drawing.Size(81, 20);
            this.edtWeight2.TabIndex = 6;
            this.edtWeight2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtWeight2_KeyPress);
            // 
            // edtWeight1
            // 
            this.edtWeight1.Location = new System.Drawing.Point(112, 211);
            this.edtWeight1.Name = "edtWeight1";
            this.edtWeight1.Size = new System.Drawing.Size(81, 20);
            this.edtWeight1.TabIndex = 5;
            this.edtWeight1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtWeight1_KeyPress);
            // 
            // edtThreshold
            // 
            this.edtThreshold.Location = new System.Drawing.Point(112, 103);
            this.edtThreshold.Name = "edtThreshold";
            this.edtThreshold.Size = new System.Drawing.Size(81, 20);
            this.edtThreshold.TabIndex = 4;
            this.edtThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtThreshold_KeyPress);
            // 
            // edtIteration
            // 
            this.edtIteration.Location = new System.Drawing.Point(112, 157);
            this.edtIteration.Name = "edtIteration";
            this.edtIteration.Size = new System.Drawing.Size(81, 20);
            this.edtIteration.TabIndex = 3;
            this.edtIteration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtIteration_KeyPress);
            // 
            // edtLearningRate
            // 
            this.edtLearningRate.Location = new System.Drawing.Point(112, 49);
            this.edtLearningRate.Name = "edtLearningRate";
            this.edtLearningRate.Size = new System.Drawing.Size(81, 20);
            this.edtLearningRate.TabIndex = 3;
            this.edtLearningRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtLearningRate_KeyPress);
            // 
            // lblWeight2
            // 
            this.lblWeight2.AutoSize = true;
            this.lblWeight2.Location = new System.Drawing.Point(50, 268);
            this.lblWeight2.Name = "lblWeight2";
            this.lblWeight2.Size = new System.Drawing.Size(56, 13);
            this.lblWeight2.TabIndex = 4;
            this.lblWeight2.Text = "Weight 2 :";
            // 
            // lblWeight1
            // 
            this.lblWeight1.AutoSize = true;
            this.lblWeight1.Location = new System.Drawing.Point(50, 214);
            this.lblWeight1.Name = "lblWeight1";
            this.lblWeight1.Size = new System.Drawing.Size(56, 13);
            this.lblWeight1.TabIndex = 3;
            this.lblWeight1.Text = "Weight 1 :";
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(16, 106);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(90, 13);
            this.lblThreshold.TabIndex = 2;
            this.lblThreshold.Text = "Threshold Value :";
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Location = new System.Drawing.Point(3, 160);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(103, 13);
            this.lblIteration.TabIndex = 1;
            this.lblIteration.Text = "Number of Iteration :";
            // 
            // lblLR
            // 
            this.lblLR.AutoSize = true;
            this.lblLR.Location = new System.Drawing.Point(26, 52);
            this.lblLR.Name = "lblLR";
            this.lblLR.Size = new System.Drawing.Size(80, 13);
            this.lblLR.TabIndex = 0;
            this.lblLR.Text = "Learning Rate :";
            // 
            // edtPicture
            // 
            this.edtPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtPicture.Location = new System.Drawing.Point(200, 0);
            this.edtPicture.Name = "edtPicture";
            this.edtPicture.Size = new System.Drawing.Size(609, 514);
            this.edtPicture.TabIndex = 2;
            this.edtPicture.TabStop = false;
            this.edtPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.edtPicture_Paint);
            this.edtPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.edtPicture_MouseDown);
            // 
            // tmrLearn
            // 
            this.tmrLearn.Tick += new System.EventHandler(this.tmrLearn_Tick);
            // 
            // Adaline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 514);
            this.Controls.Add(this.edtPicture);
            this.Controls.Add(this.panel1);
            this.Name = "Adaline";
            this.Text = "Adaline";
            this.Load += new System.EventHandler(this.Adaline_Load);
            this.panel1.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPicture)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox grpData;
    private System.Windows.Forms.RadioButton edtXOR;
    private System.Windows.Forms.RadioButton edtOR;
    private System.Windows.Forms.RadioButton edtAnd;
    private System.Windows.Forms.GroupBox grpParameters;
    private System.Windows.Forms.TextBox edtWeight2;
    private System.Windows.Forms.TextBox edtWeight1;
    private System.Windows.Forms.TextBox edtThreshold;
    private System.Windows.Forms.TextBox edtIteration;
    private System.Windows.Forms.TextBox edtLearningRate;
    private System.Windows.Forms.Label lblWeight2;
    private System.Windows.Forms.Label lblWeight1;
    private System.Windows.Forms.Label lblThreshold;
    private System.Windows.Forms.Label lblIteration;
    private System.Windows.Forms.Label lblLR;
    private System.Windows.Forms.PictureBox edtPicture;
        private System.Windows.Forms.Timer tmrLearn;
    }
}