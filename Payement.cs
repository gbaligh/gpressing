using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class Payement : Form
    {

        private TB_Facture facture = new TB_Facture();
        private TB_Client client = new TB_Client();
        private List<ListAF> article = new List<ListAF>();
        public bool regle;


        public Payement(string Code)
        {
            facture.FindByKey(Code);
            
            InitializeComponent();
            labelclient.Text = facture.Client.Nom +" "+ facture.Client.Prenom;
            labelTel.Text = facture.Client.NTel;
            labelDateRecu.Text = facture.Date_Recu.ToShortDateString();
            labelAdresse.Text = facture.Client.Adresse;
            labelTotal.Text = facture.Prix_Total.ToString();
            labelPrixPaye.Text = facture.Prix_Partiel.ToString();
            labelTotalPaye.Text = (facture.Prix_Total - facture.Prix_Partiel).ToString();
            List<ListAF> s = ListAF.GetList(facture.Code);
            foreach (ListAF a in s)
            {
                listBox1.Items.Add(a.article.Libelle+"\t"+a.article.Famille.Libelle+"\t x"+a.Quantite+"\t"+a.Operation+"\t"+a.Prix+" TND");
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Payement_Load(object sender, EventArgs e)
        {
            if ((facture.Livree == "Non Livree") && (facture.Etat == "Reglee"))
            {
                groupBox2.Visible = true;
                button2.Visible = true;
                labelDateP.Text = facture.Date_Payement.ToLongDateString();
                labelModeP.Text = facture.Mode_Payement;
            }
        }

        private void buttonAnnuler_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click_1(object sender, EventArgs e)
        {
            frmReglerEspece regler = new frmReglerEspece(double.Parse(labelTotalPaye.Text));
            regler.ShowDialog(this);
            if (regle)
            {
                facture.Mode_Payement = "Espece";
                facture.Date_Payement = DateTime.Now;
                facture.Etat = "Reglee";
                if (checkBox1.Checked)
                {
                    facture.Livree = "Livree";
                    facture.Date_livraison = DateTime.Now;
                }
                else
                    facture.Livree = "Non Livree";
                facture.UpdateData();
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmReglerCheque regler = new frmReglerCheque(facture.Code);
            regler.ShowDialog(this);
            if (regle)
            {
                facture.Mode_Payement = "Cheque";
                facture.Etat = "Reglee";
                facture.Date_Payement = DateTime.Now;
                if (checkBox1.Checked)
                {
                    facture.Livree = "Livree";
                    facture.Date_livraison = DateTime.Now;
                }
                else
                    facture.Livree = "Non Livree";
                facture.UpdateData();
                this.Close();
            }
        }

        private void Payement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                buttonOk_Click_1(sender, new EventArgs());
            if (e.KeyCode == Keys.F2)
                button1_Click_1(sender, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            facture.Livree = "Livree";
            facture.Date_livraison = DateTime.Now;
            facture.UpdateData();
            this.Close();
        }
    }
}