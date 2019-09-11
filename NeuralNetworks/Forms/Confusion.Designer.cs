namespace NeuralNetworks.Forms
{
  partial class Confusion
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
            this.grdConfusion = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblAccuracy = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.lblrow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfusion)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdConfusion
            // 
            this.grdConfusion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdConfusion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdConfusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConfusion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConfusion.EnableHeadersVisualStyles = false;
            this.grdConfusion.Location = new System.Drawing.Point(0, 100);
            this.grdConfusion.Name = "grdConfusion";
            this.grdConfusion.Size = new System.Drawing.Size(575, 227);
            this.grdConfusion.TabIndex = 3;
            this.grdConfusion.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.grdConfusion_RowPostPaint);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Aqua;
            this.pnlTop.Controls.Add(this.lblAccuracy);
            this.pnlTop.Controls.Add(this.lblColumn);
            this.pnlTop.Controls.Add(this.lblrow);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(575, 100);
            this.pnlTop.TabIndex = 2;
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAccuracy.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAccuracy.Location = new System.Drawing.Point(139, 33);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(95, 24);
            this.lblAccuracy.TabIndex = 2;
            this.lblAccuracy.Text = "Accuracy";
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblColumn.Location = new System.Drawing.Point(420, 76);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(143, 15);
            this.lblColumn.TabIndex = 1;
            this.lblColumn.Text = "Columns : Predicted Classes";
            // 
            // lblrow
            // 
            this.lblrow.AutoSize = true;
            this.lblrow.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblrow.Location = new System.Drawing.Point(12, 76);
            this.lblrow.Name = "lblrow";
            this.lblrow.Size = new System.Drawing.Size(114, 15);
            this.lblrow.TabIndex = 0;
            this.lblrow.Text = "Rows : Actual Classes";
            // 
            // Confusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 327);
            this.Controls.Add(this.grdConfusion);
            this.Controls.Add(this.pnlTop);
            this.Name = "Confusion";
            this.Text = "Confusion";
            ((System.ComponentModel.ISupportInitialize)(this.grdConfusion)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView grdConfusion;
    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblAccuracy;
    private System.Windows.Forms.Label lblColumn;
    private System.Windows.Forms.Label lblrow;
  }
}