using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class FactureParCode : Form
    {
        TB_Facture facture = new TB_Facture();

        public FactureParCode()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (facture.FindByKey(textBox1.Text))
                {
                    if ((facture.Etat == "Non Reglee")||(facture.Livree=="Non Livree"))
                    {
                        label9.Visible = false;
                        Payement p = new Payement(textBox1.Text);
                        p.ShowDialog(this.Owner);
                        this.Close();
                    }
                    else
                    {
                        label9.Visible = true;
                        label9.Text = "Ticket Trouvee\nReglee le " + facture.Date_Payement.ToLongDateString()+"\n"+
                            "Livree le " + facture.Date_livraison.ToLongDateString();
                    }
                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "Numeros de Ticket non trouvee ...\nVERIFIEZ !";
                }
            }
        }
    }
}