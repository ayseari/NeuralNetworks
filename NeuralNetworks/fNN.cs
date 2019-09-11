using NeuralNetworks.Forms;
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
using System.IO;

namespace NeuralNetworks
{
    public partial class fNN : Form
    {
        #region Definitions
        nnTools.IniFile inii =
           new nnTools.IniFile(string.Format(@"{0}\prmNetwork.ini", Directory.GetCurrentDirectory()));

        public string normalizationMethod;
        public double trainPercent, testPercent;
        public string PrepareMethod = string.Empty;
        public string ProblemType = string.Empty;
        public bool showError = false;
        public string testData = string.Empty;
        public string trainingType = string.Empty;

        #endregion Definitions

        public fNN()
        {
            InitializeComponent();
            rbnTop.Tabs[0].Visible = false;
            rbnTop.Tabs[1].Visible = false;
            rbnTop.Tabs[2].Visible = false;
        }

        public TabPage tabControl(TabPage tpp, string tabName)
        {

            foreach (TabPage ttp in tabMain.TabPages)
            {
                if (ttp.Text == tabName)
                {
                    return ttp;
                }
            }
            return null;
        }

        public void tabClose(TabControl tc, string tabName)
        {
            for (int i = tc.TabPages.Count - 1; i >= 0; i--)
            {
                if (tc.TabPages[i].Text == tabName)
                    tc.TabPages[i].Dispose();
            }
        }

        private void tabMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var tab = tabMain.SelectedTab;
            tabMain.TabPages.Remove(tab);
            tab.Dispose();

        }

        private void tabMain_Click(object sender, EventArgs e)
        {
            switch (tabMain.SelectedTab.Text)
            {
                case "Adaline":
                    rbnTop.Tabs[0].Visible = false;
                    rbnTop.Tabs[1].Visible = true;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[1].Panels)
                        pnl.Visible = true;
                    rbnTop.Tabs[2].Visible = false;
                    break;
                case "BackPropagation":
                    rbnTop.Tabs[0].Visible = true;
                    rbnTop.Tabs[1].Visible = false;
                    rbnTop.Tabs[2].Visible = false;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[0].Panels)
                        pnl.Visible = true;
                    break;
                case "One Variable":
                    rbnTop.Tabs[0].Visible = false;
                    rbnTop.Tabs[1].Visible = false;
                    rbnTop.Tabs[2].Visible = true;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[2].Panels)
                        pnl.Visible = true;
                    break;
                case "Two Variable":
                    rbnTop.Tabs[0].Visible = false;
                    rbnTop.Tabs[1].Visible = false;
                    rbnTop.Tabs[2].Visible = true;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[2].Panels)
                        pnl.Visible = true;
                    break;
            }

        }

        private void AdalineClosed(object sender, FormClosedEventArgs e)
        {
            tabClose(tabMain, "Adaline");
        }

        private void BackPropagationClosed(object sender, FormClosedEventArgs e)
        {
            tabClose(tabMain, "BackPropagation");
        }

        private void OneVariableClosed(object sender, FormClosedEventArgs e)
        {
            tabClose(tabMain, "One Variable");
        }

        private void TwoVariableClosed(object sender, FormClosedEventArgs e)
        {
            tabClose(tabMain, "Two Variable");
        }

        private void trvMain_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = trvMain.SelectedNode;
            menuOpen(node);
        }

        private void menu(TabPage page, string tabName)
        {
            TabPage npage = null;
            page = tabControl(page, tabName);
            switch (tabName)
            {
                case "Adaline":
                    rbnTop.Tabs[0].Visible = false;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[1].Panels)
                        pnl.Visible = true;
                    rbnTop.Tabs[1].Visible = true;
                    rbnTop.Tabs[2].Visible = false;
                    if (page != null)
                    {
                        tabMain.SelectedTab = page;
                    }
                    else
                    {
                        Adaline frm = new Adaline();
                        frm.FormClosed += new FormClosedEventHandler(AdalineClosed);
                        frm.TopLevel = false;
                        frm.AutoScroll = true;
                        frm.Dock = DockStyle.Fill;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        npage = new TabPage("Adaline");
                        npage.Controls.Add(frm);
                        npage.Tag = frm;
                        frm.Show();
                        tabMain.TabPages.Add(npage);
                        tabMain.SelectedTab = npage;
                    }
                    break;
                case "BackPropagation":
                    rbnTop.Tabs[0].Visible = true;
                    rbnTop.Tabs[1].Visible = false;
                    rbnTop.Tabs[2].Visible = false;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[0].Panels)
                        pnl.Visible = true;
                    edtProblemType.TextBoxText = inii.IniReadValue("Network", "Problem Type");
                    edtNormalizationMethod.TextBoxText = inii.IniReadValue("Network", "Normalization Method");
                    edtErrorWindow.Checked = Convert.ToBoolean(inii.IniReadValue("Network", "Show Error Window"));
                    edtTrainPercent.TextBoxText = inii.IniReadValue("Network", "Train Percent");
                    edtTestPercent.TextBoxText = inii.IniReadValue("Network", "Test Percent");
                    if (inii.IniReadValue("Network", "Prepare Method") == "InOrder")
                        edtInOrder.Checked = true;
                    else edtRandom.Checked = true;
                    string testsetname = inii.IniReadValue("Network", "TestsetName");
                    if (testsetname == "Testset") edtTestWithTest.Checked = true;
                    else if (testsetname == "Trainset") edtTestWithTrainset.Checked = true;
                    else edtTestWithData.Checked = true;
                    if (page != null)
                    {
                        tabMain.SelectedTab = page;
                    }
                    else
                    {
                        BackPropagation frm = new BackPropagation();
                        frm.FormClosed += new FormClosedEventHandler(BackPropagationClosed);
                        frm.TopLevel = false;
                        frm.AutoScroll = true;
                        frm.Dock = DockStyle.Fill;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        npage = new TabPage("BackPropagation");
                        npage.Controls.Add(frm);
                        npage.Tag = frm;
                        frm.Show();
                        tabMain.TabPages.Add(npage);
                        tabMain.SelectedTab = npage;
                    }
                    break;
                case "One Variable":
                    rbnTop.Tabs[0].Visible = false;
                    rbnTop.Tabs[1].Visible = false;
                    rbnTop.Tabs[2].Visible = true;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[2].Panels)
                        pnl.Visible = true;
                    if (page != null)
                    {
                        tabMain.SelectedTab = page;
                    }
                    else
                    {
                        OneVariable frm = new OneVariable();
                        frm.FormClosed += new FormClosedEventHandler(OneVariableClosed);
                        frm.TopLevel = false;
                        frm.AutoScroll = true;
                        frm.Dock = DockStyle.Fill;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        npage = new TabPage("One Variable");
                        npage.Controls.Add(frm);
                        npage.Tag = frm;
                        frm.Show();
                        tabMain.TabPages.Add(npage);
                        tabMain.SelectedTab = npage;
                    }
                    break;
                case "Two Variable":
                    rbnTop.Tabs[0].Visible = false;
                    rbnTop.Tabs[1].Visible = false;
                    rbnTop.Tabs[2].Visible = true;
                    foreach (RibbonPanel pnl in rbnTop.Tabs[2].Panels)
                        pnl.Visible = true;
                    if (page != null)
                    {
                        tabMain.SelectedTab = page;
                    }
                    else
                    {
                        TwoVariable frm = new TwoVariable();
                        frm.FormClosed += new FormClosedEventHandler(TwoVariableClosed);
                        frm.TopLevel = false;
                        frm.AutoScroll = true;
                        frm.Dock = DockStyle.Fill;
                        frm.FormBorderStyle = FormBorderStyle.None;
                        npage = new TabPage("Two Variable");
                        npage.Controls.Add(frm);
                        npage.Tag = frm;
                        frm.Show();
                        tabMain.TabPages.Add(npage);
                        tabMain.SelectedTab = npage;
                    }
                    break;



            }



        }

        private void menuOpen(TreeNode node)
        {
            menu(tabMain.SelectedTab, node.Text);
        }

        private void fNN_Shown(object sender, EventArgs e)
        {
            stbUniversity.Text = string.Format("© 2016 - {0} Dokuz Eylul University", DateTime.Now.Year);
            stbDepartment.Text = "Department Of Computer Science";
            stbDate.Text = DateTime.Now.ToString();

            this.WindowState = FormWindowState.Maximized;
        }

        private void fNN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit?", "WARNING",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.No)
                if (e != null) e.Cancel = true;
        }

        private void fNN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            stbDate.Text = DateTime.Now.ToString();
        }

        private void edtRandom_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            edtInOrder.Checked = false;
        }

        private void edtInOrder_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            edtRandom.Checked = false;
        }

        private void edtTrainPercent_TextBoxTextChanged(object sender, EventArgs e)
        {

            try
            {
                if (double.Parse(edtTrainPercent.TextBoxText) > 100) edtTrainPercent.TextBoxText = 100.ToString();
                edtTestPercent.TextBoxText = (100 - int.Parse(edtTrainPercent.TextBoxText)).ToString();
            }
            catch
            {//
            }

        }

        private void edtTestPercent_TextBoxTextChanged(object sender, EventArgs e)
        {

        }

        //Adaline
        private void edtLearn_Click(object sender, EventArgs e)
        {
            try
            {
                ((Adaline)Application.OpenForms["Adaline"]).Learn();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error learning Adaline Network. \n Error is {ex}", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void edtClear_Click(object sender, EventArgs e)
        {
            var adaline = tabMain.SelectedTab.Controls[0] as Adaline;
            adaline.ClearSamples();
        }
        //BackPropagation
        bool loaded = false;
        private void edtLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ProblemType = edtProblemType.TextBoxText;
                //((BackPropagation)Application.OpenForms["BackPropagation"]).LoadSets();
                var back = tabMain.SelectedTab.Controls[0] as BackPropagation;
                if (back == null) return;
                back.LoadSets();
                if (back.check == true)
                {
                    rbpTrainTest.Enabled = false;
                }
                loaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error loading data. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        bool normalized = false;
        private void edtNormalize_Click(object sender, EventArgs e)
        {
            try
            {
                if (loaded == false) edtLoad_Click(null, null);
                normalizationMethod = edtNormalizationMethod.TextBoxText;
                ((BackPropagation)Application.OpenForms["BackPropagation"]).NormalizedData();
                normalized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error normalizing data. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        bool traintest = false;
        private void edtTrainTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (normalized == false) edtNormalize_Click(null, null);
                trainPercent = double.Parse(edtTrainPercent.TextBoxText);
                testPercent = double.Parse(edtTestPercent.TextBoxText);
                if (edtInOrder.Checked) PrepareMethod = "InOrder";
                else PrepareMethod = "Random";
                ((BackPropagation)Application.OpenForms["BackPropagation"]).PrepareTrainTestset();
                traintest = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error prepearing train and testset. \n Error is {ex}", "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        bool trainNetwork = false;
        private void edtTrain_Click(object sender, EventArgs e)
        {
            try
            {
                if (traintest == false && edtTrainTest.Enabled == true) edtTrainTest_Click(null, null);
                showError = edtErrorWindow.Checked;
                ((BackPropagation)Application.OpenForms["BackPropagation"]).Learn();
                trainNetwork = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error train the network \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void edtTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (trainNetwork == false) edtTrain_Click(null, null);
                if (edtTestWithTest.Checked) testData = "Testset";
                else if (edtTestWithTrainset.Checked) testData = "Trainset";
                else testData = "Dataset";
                var back = tabMain.SelectedTab.Controls[0] as BackPropagation;
                if (back == null) return;
                back.Test();
                // ((BackPropagation)Application.OpenForms["BackPropagation"]).Test();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error test the network \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void edtPlotError_Click(object sender, EventArgs e)
        {
            PlotError frm = new PlotError();
            frm.Show();
        }

        // Function Creation
        private void edtCreateData_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabMain.SelectedTab.Text)
                {
                    case "One Variable":
                        ((OneVariable)Application.OpenForms["OneVariable"]).CreateData();
                        break;
                    case "Two Variable":
                        ((TwoVariable)Application.OpenForms["TwoVariable"]).CreateData();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error creating the dataset. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void edtCreateTrainTest_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabMain.SelectedTab.Text)
                {
                    case "One Variable":
                        ((OneVariable)Application.OpenForms["OneVariable"]).TrainTestCreation();
                        break;
                    case "Two Variable":
                        ((TwoVariable)Application.OpenForms["TwoVariable"]).CreateTrainTest();
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error creating the train and test set. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void edtPrintData_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabMain.SelectedTab.Text)
                {
                    case "One Variable":
                        ((OneVariable)Application.OpenForms["OneVariable"]).PrintData();
                        break;
                    case "Two Variable":
                        ((TwoVariable)Application.OpenForms["TwoVariable"]).PrintDataset();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error writing dataset to file. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void edtPrintTrainTest_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabMain.SelectedTab.Text)
                {
                    case "One Variable":
                        ((OneVariable)Application.OpenForms["OneVariable"]).PrintTrainTest();
                        break;
                    case "Two Variable":
                        ((TwoVariable)Application.OpenForms["TwoVariable"]).PrintTrainTest();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error writing  train and test set to the file. \n Error is {ex}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void edtTestPercent_TextBoxKeyPress(object sender, KeyPressEventArgs e)
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

        private void edtTrainPercent_TextBoxKeyPress(object sender, KeyPressEventArgs e)
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
