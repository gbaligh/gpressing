using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class frmReglerEspece : Form
    {
        private double Total;

        public frmReglerEspece()
        {
            InitializeComponent();
        }

        public frmReglerEspece(double Total)
        {
            InitializeComponent();
            this.Total = Total;
        }

        private void frmReglerEspece_Load(object sender, EventArgs e)
        {
            label2.Text = Total.ToString();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!label1.Visible)
            {
                label1.Visible = true;
                label1.Text = (double.Parse(textBox1.Text) - Total).ToString();
            }
            else
            {

                ((Payement)Owner).regle = true;
                this.Close();
            }
        }
    }
}