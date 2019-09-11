namespace NeuralNetworks
{
    partial class fNN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNN));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Adaline");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("BackPropagation");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Neural Networks", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("One Variable");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Two Variable");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Function Dataset", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.rbnTop = new System.Windows.Forms.Ribbon();
            this.rbnBP = new System.Windows.Forms.RibbonTab();
            this.rbpData = new System.Windows.Forms.RibbonPanel();
            this.edtProblemType = new System.Windows.Forms.RibbonComboBox();
            this.edtApproximation = new System.Windows.Forms.RibbonButton();
            this.edtPatternRecognition = new System.Windows.Forms.RibbonButton();
            this.edtLoad = new System.Windows.Forms.RibbonButton();
            this.ribbonComboBox1 = new System.Windows.Forms.RibbonComboBox();
            this.rbpNormalization = new System.Windows.Forms.RibbonPanel();
            this.edtNormalizationMethod = new System.Windows.Forms.RibbonComboBox();
            this.edtNone = new System.Windows.Forms.RibbonButton();
            this.edtLinear = new System.Windows.Forms.RibbonButton();
            this.edtMaxMin = new System.Windows.Forms.RibbonButton();
            this.edtZScore = new System.Windows.Forms.RibbonButton();
            this.edtNormalize = new System.Windows.Forms.RibbonButton();
            this.rbpTrainTest = new System.Windows.Forms.RibbonPanel();
            this.edtTrainPercent = new System.Windows.Forms.RibbonTextBox();
            this.edtTestPercent = new System.Windows.Forms.RibbonTextBox();
            this.edtInOrder = new System.Windows.Forms.RibbonCheckBox();
            this.edtRandom = new System.Windows.Forms.RibbonCheckBox();
            this.edtTrainTest = new System.Windows.Forms.RibbonButton();
            this.rbpLearn = new System.Windows.Forms.RibbonPanel();
            this.edtErrorWindow = new System.Windows.Forms.RibbonCheckBox();
            this.edtTrain = new System.Windows.Forms.RibbonButton();
            this.rbpTest = new System.Windows.Forms.RibbonPanel();
            this.edtTestWithData = new System.Windows.Forms.RibbonCheckBox();
            this.edtTestWithTrainset = new System.Windows.Forms.RibbonCheckBox();
            this.edtTestWithTest = new System.Windows.Forms.RibbonCheckBox();
            this.edtTest = new System.Windows.Forms.RibbonButton();
            this.rbpError = new System.Windows.Forms.RibbonPanel();
            this.edtPlotError = new System.Windows.Forms.RibbonButton();
            this.rbnAdaline = new System.Windows.Forms.RibbonTab();
            this.rbpTrain = new System.Windows.Forms.RibbonPanel();
            this.edtClear = new System.Windows.Forms.RibbonButton();
            this.edtLearn = new System.Windows.Forms.RibbonButton();
            this.rbnFunctionOperations = new System.Windows.Forms.RibbonTab();
            this.rbpDataset = new System.Windows.Forms.RibbonPanel();
            this.edtCreateData = new System.Windows.Forms.RibbonButton();
            this.edtCreateTrainTest = new System.Windows.Forms.RibbonButton();
            this.edtPrintData = new System.Windows.Forms.RibbonButton();
            this.edtPrintTrainTest = new System.Windows.Forms.RibbonButton();
            this.trvMain = new System.Windows.Forms.TreeView();
            this.stbMain = new System.Windows.Forms.StatusStrip();
            this.stbUniversity = new System.Windows.Forms.ToolStripStatusLabel();
            this.stbDepartment = new System.Windows.Forms.ToolStripStatusLabel();
            this.stbDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.tabNNet = new System.Windows.Forms.TabPage();
            this.edtNetwork = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.stbMain.SuspendLayout();
            this.tabNNet.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnTop
            // 
            this.rbnTop.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbnTop.Location = new System.Drawing.Point(0, 0);
            this.rbnTop.Minimized = false;
            this.rbnTop.Name = "rbnTop";
            // 
            // 
            // 
            this.rbnTop.OrbDropDown.BorderRoundness = 8;
            this.rbnTop.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.rbnTop.OrbDropDown.Name = "";
            this.rbnTop.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.rbnTop.OrbDropDown.TabIndex = 0;
            this.rbnTop.OrbImage = null;
            this.rbnTop.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.rbnTop.Size = new System.Drawing.Size(1234, 166);
            this.rbnTop.TabIndex = 0;
            this.rbnTop.Tabs.Add(this.rbnBP);
            this.rbnTop.Tabs.Add(this.rbnAdaline);
            this.rbnTop.Tabs.Add(this.rbnFunctionOperations);
            this.rbnTop.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.rbnTop.Text = "ribbon1";
            this.rbnTop.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // rbnBP
            // 
            this.rbnBP.Panels.Add(this.rbpData);
            this.rbnBP.Panels.Add(this.rbpNormalization);
            this.rbnBP.Panels.Add(this.rbpTrainTest);
            this.rbnBP.Panels.Add(this.rbpLearn);
            this.rbnBP.Panels.Add(this.rbpTest);
            this.rbnBP.Panels.Add(this.rbpError);
            this.rbnBP.Text = "Operations";
            // 
            // rbpData
            // 
            this.rbpData.Items.Add(this.edtProblemType);
            this.rbpData.Items.Add(this.edtLoad);
            this.rbpData.Text = "Dataset";
            // 
            // edtProblemType
            // 
            this.edtProblemType.DropDownItems.Add(this.edtApproximation);
            this.edtProblemType.DropDownItems.Add(this.edtPatternRecognition);
            this.edtProblemType.Text = "Problem Type";
            this.edtProblemType.TextBoxText = "";
            // 
            // edtApproximation
            // 
            this.edtApproximation.Image = ((System.Drawing.Image)(resources.GetObject("edtApproximation.Image")));
            this.edtApproximation.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtApproximation.SmallImage")));
            this.edtApproximation.Text = "Approximation";
            // 
            // edtPatternRecognition
            // 
            this.edtPatternRecognition.Image = ((System.Drawing.Image)(resources.GetObject("edtPatternRecognition.Image")));
            this.edtPatternRecognition.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtPatternRecognition.SmallImage")));
            this.edtPatternRecognition.Text = "Pattern Recognition";
            // 
            // edtLoad
            // 
            this.edtLoad.DropDownItems.Add(this.ribbonComboBox1);
            this.edtLoad.Image = ((System.Drawing.Image)(resources.GetObject("edtLoad.Image")));
            this.edtLoad.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtLoad.SmallImage")));
            this.edtLoad.Text = "Load";
            this.edtLoad.Click += new System.EventHandler(this.edtLoad_Click);
            // 
            // ribbonComboBox1
            // 
            this.ribbonComboBox1.Text = "ribbonComboBox1";
            this.ribbonComboBox1.TextBoxText = "";
            // 
            // rbpNormalization
            // 
            this.rbpNormalization.Items.Add(this.edtNormalizationMethod);
            this.rbpNormalization.Items.Add(this.edtNormalize);
            this.rbpNormalization.Text = "Normalization";
            // 
            // edtNormalizationMethod
            // 
            this.edtNormalizationMethod.DropDownItems.Add(this.edtNone);
            this.edtNormalizationMethod.DropDownItems.Add(this.edtLinear);
            this.edtNormalizationMethod.DropDownItems.Add(this.edtMaxMin);
            this.edtNormalizationMethod.DropDownItems.Add(this.edtZScore);
            this.edtNormalizationMethod.Text = "Normalization Method :";
            this.edtNormalizationMethod.TextBoxText = "";
            // 
            // edtNone
            // 
            this.edtNone.Image = ((System.Drawing.Image)(resources.GetObject("edtNone.Image")));
            this.edtNone.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtNone.SmallImage")));
            this.edtNone.Text = "None";
            // 
            // edtLinear
            // 
            this.edtLinear.Image = ((System.Drawing.Image)(resources.GetObject("edtLinear.Image")));
            this.edtLinear.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtLinear.SmallImage")));
            this.edtLinear.Text = "Linear Normalization";
            // 
            // edtMaxMin
            // 
            this.edtMaxMin.Image = ((System.Drawing.Image)(resources.GetObject("edtMaxMin.Image")));
            this.edtMaxMin.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtMaxMin.SmallImage")));
            this.edtMaxMin.Text = "Max-Min Normalization";
            // 
            // edtZScore
            // 
            this.edtZScore.Image = ((System.Drawing.Image)(resources.GetObject("edtZScore.Image")));
            this.edtZScore.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtZScore.SmallImage")));
            this.edtZScore.Text = "ZScore Normalization";
            // 
            // edtNormalize
            // 
            this.edtNormalize.Image = ((System.Drawing.Image)(resources.GetObject("edtNormalize.Image")));
            this.edtNormalize.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtNormalize.SmallImage")));
            this.edtNormalize.Text = "Normalize Data";
            this.edtNormalize.Click += new System.EventHandler(this.edtNormalize_Click);
            // 
            // rbpTrainTest
            // 
            this.rbpTrainTest.Items.Add(this.edtTrainPercent);
            this.rbpTrainTest.Items.Add(this.edtTestPercent);
            this.rbpTrainTest.Items.Add(this.edtInOrder);
            this.rbpTrainTest.Items.Add(this.edtRandom);
            this.rbpTrainTest.Items.Add(this.edtTrainTest);
            this.rbpTrainTest.Text = "Train and Test Set";
            // 
            // edtTrainPercent
            // 
            this.edtTrainPercent.Text = "Train % :";
            this.edtTrainPercent.TextBoxText = "80";
            this.edtTrainPercent.TextBoxTextChanged += new System.EventHandler(this.edtTrainPercent_TextBoxTextChanged);
            this.edtTrainPercent.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtTrainPercent_TextBoxKeyPress);
            // 
            // edtTestPercent
            // 
            this.edtTestPercent.Text = "Test  % : ";
            this.edtTestPercent.TextBoxText = "20";
            this.edtTestPercent.TextBoxTextChanged += new System.EventHandler(this.edtTestPercent_TextBoxTextChanged);
            this.edtTestPercent.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtTestPercent_TextBoxKeyPress);
            // 
            // edtInOrder
            // 
            this.edtInOrder.Text = "In Order   ";
            this.edtInOrder.CheckBoxCheckChanged += new System.EventHandler(this.edtInOrder_CheckBoxCheckChanged);
            // 
            // edtRandom
            // 
            this.edtRandom.Text = "Random";
            this.edtRandom.CheckBoxCheckChanged += new System.EventHandler(this.edtRandom_CheckBoxCheckChanged);
            // 
            // edtTrainTest
            // 
            this.edtTrainTest.Image = ((System.Drawing.Image)(resources.GetObject("edtTrainTest.Image")));
            this.edtTrainTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtTrainTest.SmallImage")));
            this.edtTrainTest.Text = "Prepare Train and Test Set";
            this.edtTrainTest.Click += new System.EventHandler(this.edtTrainTest_Click);
            // 
            // rbpLearn
            // 
            this.rbpLearn.Items.Add(this.edtErrorWindow);
            this.rbpLearn.Items.Add(this.edtTrain);
            this.rbpLearn.Text = "Train Network";
            // 
            // edtErrorWindow
            // 
            this.edtErrorWindow.Text = "Show Error Window";
            // 
            // edtTrain
            // 
            this.edtTrain.Image = ((System.Drawing.Image)(resources.GetObject("edtTrain.Image")));
            this.edtTrain.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtTrain.SmallImage")));
            this.edtTrain.Text = "Train";
            this.edtTrain.Click += new System.EventHandler(this.edtTrain_Click);
            // 
            // rbpTest
            // 
            this.rbpTest.Items.Add(this.edtTestWithData);
            this.rbpTest.Items.Add(this.edtTestWithTrainset);
            this.rbpTest.Items.Add(this.edtTestWithTest);
            this.rbpTest.Items.Add(this.edtTest);
            this.rbpTest.Text = "Test the Network";
            // 
            // edtTestWithData
            // 
            this.edtTestWithData.Text = "Test with all dataset";
            // 
            // edtTestWithTrainset
            // 
            this.edtTestWithTrainset.Text = "Test with trainset";
            // 
            // edtTestWithTest
            // 
            this.edtTestWithTest.Text = "Test with testset";
            // 
            // edtTest
            // 
            this.edtTest.Image = ((System.Drawing.Image)(resources.GetObject("edtTest.Image")));
            this.edtTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtTest.SmallImage")));
            this.edtTest.Text = "Test Network";
            this.edtTest.Click += new System.EventHandler(this.edtTest_Click);
            // 
            // rbpError
            // 
            this.rbpError.Items.Add(this.edtPlotError);
            this.rbpError.Text = "Error";
            // 
            // edtPlotError
            // 
            this.edtPlotError.Image = ((System.Drawing.Image)(resources.GetObject("edtPlotError.Image")));
            this.edtPlotError.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtPlotError.SmallImage")));
            this.edtPlotError.Text = "Plot Error";
            this.edtPlotError.Click += new System.EventHandler(this.edtPlotError_Click);
            // 
            // rbnAdaline
            // 
            this.rbnAdaline.Panels.Add(this.rbpTrain);
            this.rbnAdaline.Text = "Operation";
            // 
            // rbpTrain
            // 
            this.rbpTrain.Items.Add(this.edtClear);
            this.rbpTrain.Items.Add(this.edtLearn);
            this.rbpTrain.Text = "Learn";
            // 
            // edtClear
            // 
            this.edtClear.Image = ((System.Drawing.Image)(resources.GetObject("edtClear.Image")));
            this.edtClear.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtClear.SmallImage")));
            this.edtClear.Text = "Clear";
            this.edtClear.Click += new System.EventHandler(this.edtClear_Click);
            // 
            // edtLearn
            // 
            this.edtLearn.Image = ((System.Drawing.Image)(resources.GetObject("edtLearn.Image")));
            this.edtLearn.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtLearn.SmallImage")));
            this.edtLearn.Text = "Learn";
            this.edtLearn.Click += new System.EventHandler(this.edtLearn_Click);
            // 
            // rbnFunctionOperations
            // 
            this.rbnFunctionOperations.Panels.Add(this.rbpDataset);
            this.rbnFunctionOperations.Text = "Operations";
            // 
            // rbpDataset
            // 
            this.rbpDataset.Items.Add(this.edtCreateData);
            this.rbpDataset.Items.Add(this.edtCreateTrainTest);
            this.rbpDataset.Items.Add(this.edtPrintData);
            this.rbpDataset.Items.Add(this.edtPrintTrainTest);
            this.rbpDataset.Text = "Dataset Operations";
            // 
            // edtCreateData
            // 
            this.edtCreateData.Image = ((System.Drawing.Image)(resources.GetObject("edtCreateData.Image")));
            this.edtCreateData.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtCreateData.SmallImage")));
            this.edtCreateData.Text = "Create Dataset";
            this.edtCreateData.Click += new System.EventHandler(this.edtCreateData_Click);
            // 
            // edtCreateTrainTest
            // 
            this.edtCreateTrainTest.Image = ((System.Drawing.Image)(resources.GetObject("edtCreateTrainTest.Image")));
            this.edtCreateTrainTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtCreateTrainTest.SmallImage")));
            this.edtCreateTrainTest.Text = "Create Train and Test Set";
            this.edtCreateTrainTest.Click += new System.EventHandler(this.edtCreateTrainTest_Click);
            // 
            // edtPrintData
            // 
            this.edtPrintData.Image = ((System.Drawing.Image)(resources.GetObject("edtPrintData.Image")));
            this.edtPrintData.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtPrintData.SmallImage")));
            this.edtPrintData.Text = "Print Dataset";
            this.edtPrintData.Click += new System.EventHandler(this.edtPrintData_Click);
            // 
            // edtPrintTrainTest
            // 
            this.edtPrintTrainTest.Image = ((System.Drawing.Image)(resources.GetObject("edtPrintTrainTest.Image")));
            this.edtPrintTrainTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("edtPrintTrainTest.SmallImage")));
            this.edtPrintTrainTest.Text = "Print Train and Test Set";
            this.edtPrintTrainTest.Click += new System.EventHandler(this.edtPrintTrainTest_Click);
            // 
            // trvMain
            // 
            this.trvMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvMain.Location = new System.Drawing.Point(0, 166);
            this.trvMain.Name = "trvMain";
            treeNode1.Name = "NodeAdaline";
            treeNode1.Text = "Adaline";
            treeNode2.Name = "NodeBP";
            treeNode2.Text = "BackPropagation";
            treeNode3.Name = "NodeNNET";
            treeNode3.Text = "Neural Networks";
            treeNode4.Name = "NodeOneVariable";
            treeNode4.Text = "One Variable";
            treeNode5.Name = "NodeTwoVariable";
            treeNode5.Text = "Two Variable";
            treeNode6.Name = "NodeFunction";
            treeNode6.Text = "Function Dataset";
            this.trvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.trvMain.Size = new System.Drawing.Size(219, 388);
            this.trvMain.TabIndex = 2;
            this.trvMain.DoubleClick += new System.EventHandler(this.trvMain_DoubleClick);
            // 
            // stbMain
            // 
            this.stbMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.stbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbUniversity,
            this.stbDepartment,
            this.stbDate});
            this.stbMain.Location = new System.Drawing.Point(0, 554);
            this.stbMain.Name = "stbMain";
            this.stbMain.Size = new System.Drawing.Size(1234, 22);
            this.stbMain.TabIndex = 3;
            this.stbMain.Text = "statusStrip1";
            // 
            // stbUniversity
            // 
            this.stbUniversity.Name = "stbUniversity";
            this.stbUniversity.Size = new System.Drawing.Size(148, 17);
            this.stbUniversity.Text = "(c) Dokuz Eylül Üniversitesi";
            // 
            // stbDepartment
            // 
            this.stbDepartment.AutoSize = false;
            this.stbDepartment.Name = "stbDepartment";
            this.stbDepartment.Size = new System.Drawing.Size(1040, 17);
            this.stbDepartment.Text = "Department of Computer Science";
            // 
            // stbDate
            // 
            this.stbDate.Name = "stbDate";
            this.stbDate.Size = new System.Drawing.Size(31, 17);
            this.stbDate.Text = "Date";
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // tabNNet
            // 
            this.tabNNet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabNNet.BackgroundImage")));
            this.tabNNet.Controls.Add(this.edtNetwork);
            this.tabNNet.Location = new System.Drawing.Point(4, 22);
            this.tabNNet.Name = "tabNNet";
            this.tabNNet.Padding = new System.Windows.Forms.Padding(3);
            this.tabNNet.Size = new System.Drawing.Size(1007, 362);
            this.tabNNet.TabIndex = 0;
            this.tabNNet.Text = "Network";
            this.tabNNet.UseVisualStyleBackColor = true;
            // 
            // edtNetwork
            // 
            this.edtNetwork.BackColor = System.Drawing.Color.Gainsboro;
            this.edtNetwork.Font = new System.Drawing.Font("Cambria", 63.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.edtNetwork.Location = new System.Drawing.Point(209, 43);
            this.edtNetwork.Multiline = true;
            this.edtNetwork.Name = "edtNetwork";
            this.edtNetwork.Size = new System.Drawing.Size(820, 88);
            this.edtNetwork.TabIndex = 0;
            this.edtNetwork.Text = "Neural Networks";
            this.edtNetwork.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabNNet);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(219, 166);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1015, 388);
            this.tabMain.TabIndex = 6;
            this.tabMain.Click += new System.EventHandler(this.tabMain_Click);
            this.tabMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabMain_MouseDoubleClick);
            // 
            // fNN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 576);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.trvMain);
            this.Controls.Add(this.stbMain);
            this.Controls.Add(this.rbnTop);
            this.Name = "fNN";
            this.Text = "Neural Networks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fNN_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fNN_FormClosed);
            this.Shown += new System.EventHandler(this.fNN_Shown);
            this.stbMain.ResumeLayout(false);
            this.stbMain.PerformLayout();
            this.tabNNet.ResumeLayout(false);
            this.tabNNet.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon rbnTop;
        private System.Windows.Forms.RibbonTab rbnBP;
        private System.Windows.Forms.RibbonPanel rbpData;
        private System.Windows.Forms.RibbonButton edtLoad;
        private System.Windows.Forms.RibbonPanel rbpNormalization;
        private System.Windows.Forms.RibbonComboBox edtNormalizationMethod;
        private System.Windows.Forms.RibbonButton edtNone;
        private System.Windows.Forms.RibbonButton edtLinear;
        private System.Windows.Forms.RibbonButton edtMaxMin;
        private System.Windows.Forms.RibbonButton edtZScore;
        private System.Windows.Forms.RibbonPanel rbpTrainTest;
        private System.Windows.Forms.TreeView trvMain;
        private System.Windows.Forms.StatusStrip stbMain;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.ToolStripStatusLabel stbUniversity;
        private System.Windows.Forms.ToolStripStatusLabel stbDepartment;
        private System.Windows.Forms.ToolStripStatusLabel stbDate;
        private System.Windows.Forms.RibbonTextBox edtTrainPercent;
        private System.Windows.Forms.RibbonTextBox edtTestPercent;
        private System.Windows.Forms.RibbonCheckBox edtInOrder;
        private System.Windows.Forms.RibbonCheckBox edtRandom;
        private System.Windows.Forms.RibbonButton edtTrainTest;
        private System.Windows.Forms.RibbonPanel rbpLearn;
        private System.Windows.Forms.RibbonCheckBox edtErrorWindow;
        private System.Windows.Forms.RibbonButton edtTrain;
        private System.Windows.Forms.RibbonPanel rbpTest;
        private System.Windows.Forms.RibbonCheckBox edtTestWithData;
        private System.Windows.Forms.RibbonCheckBox edtTestWithTrainset;
        private System.Windows.Forms.RibbonCheckBox edtTestWithTest;
        private System.Windows.Forms.RibbonButton edtTest;
        private System.Windows.Forms.RibbonPanel rbpError;
        private System.Windows.Forms.RibbonButton edtPlotError;
        private System.Windows.Forms.RibbonTab rbnAdaline;
        private System.Windows.Forms.RibbonPanel rbpTrain;
        private System.Windows.Forms.RibbonButton edtClear;
        private System.Windows.Forms.RibbonButton edtLearn;
        private System.Windows.Forms.RibbonButton edtNormalize;
        private System.Windows.Forms.RibbonComboBox edtProblemType;
        private System.Windows.Forms.RibbonComboBox ribbonComboBox1;
        private System.Windows.Forms.RibbonButton edtApproximation;
        private System.Windows.Forms.RibbonButton edtPatternRecognition;
        private System.Windows.Forms.RibbonTab rbnFunctionOperations;
        private System.Windows.Forms.RibbonPanel rbpDataset;
        private System.Windows.Forms.RibbonButton edtCreateData;
        private System.Windows.Forms.RibbonButton edtCreateTrainTest;
        private System.Windows.Forms.RibbonButton edtPrintData;
        private System.Windows.Forms.RibbonButton edtPrintTrainTest;
        private System.Windows.Forms.TabPage tabNNet;
        private System.Windows.Forms.TextBox edtNetwork;
        private System.Windows.Forms.TabControl tabMain;
    }
}

