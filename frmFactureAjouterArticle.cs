using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class frmFactureAjouterArticle : Form
    {
        private List<TB_Articles> listArticle = new List<TB_Articles>();
        private List<TB_Famille> listFamille;
        private TB_Famille selectedFamilleItem = new TB_Famille();
        private string selectedOperation = "Pressing";


        public frmFactureAjouterArticle()
        {
            InitializeComponent();
            listArticle = TB_Articles.GetList();
            listFamille = TB_Famille.GetList();
        }

        private void frmFactureAjouterArticle_Load(object sender, EventArgs e)
        {
            textQ.Text = "1";

            comboOperation.Text = "Pressing";

            comboFamille.DataSource = listFamille;
            comboFamille.DisplayMember = "Libelle";
            comboFamille.ValueMember = "Code";
            
            comboCode.Text = "";
            comboLibelle.Text = "";
            comboLibelle.DataSource = comboCode.DataSource = TB_Articles.GetList(selectedFamilleItem.Code, comboOperation.Text);
            textPrix.DataBindings.Clear();
            textPrix.DataBindings.Add("Text", comboCode.DataSource, "Prix_" + comboOperation.Text);
                 
            comboLibelle.DisplayMember = "Libelle";
            comboCode.DisplayMember = "Code";

        }

        private void comboFamille_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFamilleItem = ((TB_Famille)comboFamille.SelectedItem);
            comboCode.Text = "";
            comboLibelle.Text = "";
            comboLibelle.DataSource = comboCode.DataSource = TB_Articles.GetList(selectedFamilleItem.Code, comboOperation.Text);
            textPrix.DataBindings.Clear();
            textPrix.DataBindings.Add("Text", comboCode.DataSource, "Prix_" + comboOperation.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboFamille_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void labelCodeFamille_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOperation = comboOperation.Text;
            comboCode.Text = "";
            comboLibelle.Text = "";
            comboLibelle.DataSource = comboCode.DataSource = TB_Articles.GetList(selectedFamilleItem.Code, selectedOperation);
            textPrix.DataBindings.Clear();
            textPrix.DataBindings.Add("Text", comboCode.DataSource, "Prix_" + selectedOperation);
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            ((NouvelleCommande)this.Owner).addLigneCommande(comboCode.Text,
                comboFamille.Text, comboLibelle.Text, textQ.Text, comboOperation.Text,
                textPrix.Text);
        }
    }
}