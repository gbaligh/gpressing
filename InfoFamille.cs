using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class InfoFamille : Form
    {
        TB_Famille currentFamille;
        bool save = false;

        #region Operation sur les champs du form
        private bool VerifierChamp()
        {
            if (c1TextBox1.Text == "")
            {
                MessageBox.Show("Generez le Code de l'article");
                return false;
            }
            if (c1TextBox2.Text == "")
            {
                MessageBox.Show("Donner la Designation de la Famille");
                return false;
            }
            return true;
        }

        private TB_Famille GetChamp()
        {
            TB_Famille r = new TB_Famille();
            r.Code = (string)c1TextBox1.Value;
            r.Libelle = (string)c1TextBox2.Value;
            r.Description = c1TextBox3.Text;
            return r;
        }

        private void SetChamp(TB_Famille currentFamille)
        {
            c1TextBox1.Value = currentFamille.Code;
            c1TextBox2.Value = currentFamille.Libelle;
            c1TextBox3.Value = currentFamille.Description;
        }

        #endregion


        public InfoFamille()
        {
            InitializeComponent();
            TB_Famille tmp = new TB_Famille();
            c1TextBox1.Value = tmp.GenerateCode();
            save = true;
        }

        public InfoFamille(string Code)
        {
            InitializeComponent();
            currentFamille = new TB_Famille();
            currentFamille.FindByKey(Code);
            SetChamp(currentFamille);
            save = false;
        }


        private void InfoFamille_Load(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1TextBox1_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (VerifierChamp())
            {
                TB_Famille newFamille = GetChamp();
                if (!save)
                    newFamille.UpdateData();
                else
                    newFamille.SaveData();
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