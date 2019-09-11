using NNTOOLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworks.Forms
{
    public partial class Confusion : Form
    {
        nnTools nnet = new nnTools();
        public Confusion()
        {
            InitializeComponent();
            grdConfusion.DataSource = ((BackPropagation)Application.OpenForms["BackPropagation"]).dtConfusion;
            grdConfusion.AllowUserToAddRows = false;

            //for (int i = 0; i < grdConfusion.Rows.Count; i++)
            //{
            //    for (int j = 0; j < grdConfusion.Columns.Count; j++)
            //    {
            //        grdConfusion.Rows[i].Cells[i].Style.BackColor = Color.Green;
            //        grdConfusion.Rows[i].Cells[j].Style.BackColor = Color.Red;

            //    }

            //}

            nnet.MyGridStyle(grdConfusion);
            lblAccuracy.Text = string.Format("Accuracy is % {0}", ((BackPropagation)Application.OpenForms["BackPropagation"]).accuracy);

        }

        private void grdConfusion_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
