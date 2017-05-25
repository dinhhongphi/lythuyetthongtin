using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruyenTin.src;

namespace TruyenTin
{
    public partial class Form1 : Form
    {
        private Matrix_Binary matrix;

        public Form1()
        {
            InitializeComponent();
            Log.control = this.txtResult;
            matrix = new Matrix_Binary(4, 7);
            matrix.SetValue(0, 0, 1);
            matrix.SetValue(0, 1, 1);
            matrix.SetValue(0, 2, 0);
            matrix.SetValue(0, 3, 1);
            matrix.SetValue(0, 4, 0);
            matrix.SetValue(0, 5, 0);
            matrix.SetValue(0, 6, 0);
            matrix.SetValue(1, 0, 1);
            matrix.SetValue(1, 1, 0);
            matrix.SetValue(1, 2, 1);
            matrix.SetValue(1, 3, 1);
            matrix.SetValue(1, 4, 1);
            matrix.SetValue(1, 5, 0);
            matrix.SetValue(1, 6, 0);
            matrix.SetValue(2, 0, 0);
            matrix.SetValue(2, 1, 1);
            matrix.SetValue(2, 2, 0);
            matrix.SetValue(2, 3, 0);
            matrix.SetValue(2, 4, 0);
            matrix.SetValue(2, 5, 1);
            matrix.SetValue(2, 6, 1);
            matrix.SetValue(3, 0, 1);
            matrix.SetValue(3, 1, 0);
            matrix.SetValue(3, 2, 1);
            matrix.SetValue(3, 3, 0);
            matrix.SetValue(3, 4, 0);
            matrix.SetValue(3, 5, 0);
            matrix.SetValue(3, 6, 1);
        }

        private void DrawMatrix(bool allowModifier)
        {
            if (matrix != null)
            {
                //remove old item in matrix
                this.panMatrix.Controls.Clear();
                //show matrix
                var X_begin = 7;
                var Y_begin = 19;
                for (int i = 1; i <= matrix.GetM(); i++)
                {
                    for (int j = 1; j <= matrix.GetN(); j++)
                    {
                        TextBox txt = new TextBox();
                        txt.Location = new System.Drawing.Point(X_begin, Y_begin);
                        txt.Name = "txt" + i.ToString() + j.ToString();
                        txt.Size = new System.Drawing.Size(44, 20);
                        txt.Enabled = allowModifier;
                        txt.TextChanged += Txt_TextChanged; ;
                        this.panMatrix.Controls.Add(txt);
                        X_begin += 52;
                    }
                    X_begin = 7;
                    Y_begin += 32;
                }
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            var control = ((TextBox)sender);
            if (control.Text == "")
                return;
            int i = int.Parse(control.Name.Substring(3, 1)) - 1;
            int j = int.Parse(control.Name.Substring(4, 1)) - 1;
            try
            {
                matrix.SetValue(i, j, int.Parse(control.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("input invalid","Error",MessageBoxButtons.OK);
                control.Text = "";
                return;
            }
        }

        private void btnInitMatrix_Click(object sender, EventArgs e)
        {
            int m, n;
            if (!Int32.TryParse(txtM.Text, out m))
            {
                MessageBox.Show("Nhập lại M", "Error", MessageBoxButtons.OK);
                return;
            }
            if (!Int32.TryParse(txtN.Text, out n))
            {
                MessageBox.Show("Nhập lại N", "Error", MessageBoxButtons.OK);
                return;
            }
            matrix = new Matrix_Binary(m, n);
            DrawMatrix(true);
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void mophongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            if(matrix != null && txtU.Text.Trim() != "")
            {
                try
                {
                    string u = txtU.Text;
                    c.u = new Matrix_Binary(1, u.Length);
                    for(int i = 0; i < u.Length; i++)
                    {
                        c.u.SetValue(0, i, int.Parse(u[i].ToString()));
                    }
                    c.G = matrix;
                    c.Handler();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
