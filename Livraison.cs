using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class Livraison : Form
    {
        TB_Facture facture = new TB_Facture();
        public Livraison()
        {
            InitializeComponent();
        }

        public Livraison(string code)
        {
            InitializeComponent();
            facture.FindByKey(code);
            labelDateP.Text = facture.Date_Payement.ToLongDateString();
            labelModeP.Text = facture.Mode_Payement;
        }


        private void Livraison_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            facture.Livree = "Livree";
            facture.Date_livraison = DateTime.Now;
            facture.UpdateData();
            this.Close();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Livraison_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}