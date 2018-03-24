using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class InfoClient : Form
    {
        private bool Save = false;

        private bool VerifierChamp()
        {
            if (c1TextBox1.Text == "")
            {
                MessageBox.Show("Le code de Client n'existe pas");
                return false;
            }
            if (c1TextBox2.Text == "")
            {
                MessageBox.Show("Le Nom de Client n'existe pas");
                return false;
            }
            if (c1TextBox3.Text == "")
            {
                MessageBox.Show("Le Prenom de Client n'existe pas");
                return false;
            }
            return true;
        }

        private TB_Client GetChamp()
        {
            TB_Client r = new TB_Client();
            r.Code = (string)c1TextBox1.Value;
            r.Nom = (string)c1TextBox2.Value;
            r.Prenom = (string)c1TextBox3.Value;
            r.NTel = (string)c1TextBox5.Value;
            r.Adresse = (string)c1TextBox4.Value;
            return r;
        }

        public InfoClient()
        {
            InitializeComponent();
            Save = true;
            btnOK.Enabled = true;
            TB_Client client = new TB_Client();
            c1TextBox1.Value = client.GenerateCode();
        }

        public InfoClient(string Code)
        {
            InitializeComponent();
            Save = false;
            TB_Client client = new TB_Client();
            client.FindByKey(Code);
            c1TextBox1.Value = client.Code;
            c1TextBox2.Value = client.Nom;
            c1TextBox3.Value = client.Prenom;
            c1TextBox4.Value = client.Adresse;
            c1TextBox5.Value = client.NTel;
        }

        private void c1TextBox1_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoClient_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (VerifierChamp())
            {
                TB_Client newClient = GetChamp();
                if (!Save)
                    newClient.UpdateData();
                else
                    newClient.SaveData();
                this.Close();
            }
        }

        private void c1TextBox2_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Aqua;
            ((Control)sender).Focus();
        }

        private void c1TextBox2_Leave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }
    }
}