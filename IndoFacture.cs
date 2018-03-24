using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class IndoFacture : Form
    {
        bool Save = false;
        TB_Facture currentFacture;
        
        public void addList(ListAF AF)
        {
            ((DataTable)c1TrueDBGrid1.DataSource).Rows.Add(AF.Code_Article, AF.Libelle_Article, AF.Operation, AF.Prix);
        }

        public IndoFacture()
        {
            InitializeComponent();
            Save = true;
            TB_Facture newfacture = new TB_Facture();
            TextCodeFacture.Value = newfacture.GenerateCode();
            DateRecuFacture.Value = DateTime.Now;
            DateLivraisonFacutre.Value = DateTime.Now.AddDays(1);
        }

        public IndoFacture(string Code)
        {
            InitializeComponent();
            Save = false;
            currentFacture = new TB_Facture();
            currentFacture.FindByKey(Code);
            TextCodeFacture.Value = currentFacture.Code;
            TextAdresseClient.Value = currentFacture.Client.Adresse;
            TextTelClient.Value = currentFacture.Client.NTel;
            TextNomClient.Value = currentFacture.Client.Nom;
            TextPrenomClient.Value = currentFacture.Client.Prenom;
            NumericPrixAvance.Value = currentFacture.Prix_Partiel;
            NumericPrixTotal.Value = currentFacture.Prix_Total;
            DateRecuFacture.Value = currentFacture.Date_Recu;
            DateLivraisonFacutre.Value = currentFacture.Date_livraison;
            comboModePayement.Text = currentFacture.Mode_Payement;
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            DataSet ARFAC = dataBase.returnDataSet("SELECT \"Code_Article\",\"Libelle\",\"Quantite\",\"Operation\",\"Prix\" FROM \"Articles\",\"Ar_Fac\" WHERE \"Ar_Fac\".\"Code_Facture\"='"+Code+"' AND" +
                "\"Articles\".\"Code\"=\"Ar_Fac\".\"Code_Article\"");
            c1TrueDBGrid1.DataSource = ARFAC.Tables[0];
            DataSet Client = dataBase.returnDataSet("SELECT * FROM \"Client\"");
            c1Combo1.DataSource = Client.Tables[0];
            c1Combo1.Text = currentFacture.Client.Code;
            c1Combo1.DisplayMember = "Code";
            c1Label1.Value = currentFacture.Etat;
            c1Label2.Value = currentFacture.Livree;
            if (currentFacture.Livree == "Non Livree")
                dateSortie.Visible = false;
            else
            {
                dateSortie.Value = currentFacture.Date_livraison;
            }
            
            Npgsql.NpgsqlDataReader reader = dataBase.returnDataReader("SELECT * FROM \"Cheque\" WHERE \"Code_Facture\"='"+Code+"'");
            if(reader.Read())
            {
                comboBox1.Text = (string)reader["Banque"];
                c1TextBox1.Value = (string)reader["Montant"];
                c1TextBox2.Value = (string)reader["Num"];
                c1DateEdit1.Value = (DateTime)reader["Date"];
            }
        }

        private void IndoFacture_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboModePayement.Text == "Cheque")
                c1DockingTabPage4.TabVisible = true;
            else
                c1DockingTabPage4.TabVisible = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1Combo1_TextChanged(object sender, EventArgs e)
        {
            TB_Client client = new TB_Client();
            client.FindByKey(c1Combo1.Text);
            TextNomClient.Value = client.Nom;
            TextPrenomClient.Value = client.Prenom;
            TextTelClient.Value = client.NTel;
            TextAdresseClient.Value = client.Adresse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TB_Client client = new TB_Client();
            TextNomClient.Value = "";
            TextPrenomClient.Value = "";
            TextTelClient.Value = "";
            TextAdresseClient.Value = "";
            c1Combo1.Text = client.GenerateCode();
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vous ete sure de vouloire Supprimer cette article de la Facture ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = c1TrueDBGrid1.Row;
                string Code = c1TrueDBGrid1.Columns["Code_Article"].CellText(index);
                if (Code == null)
                {
                    MessageBox.Show("Aucun Article selectionee");
                    return;
                }
                DB_PostgreSQL dataBase = new DB_PostgreSQL();
                dataBase.ExecuteNonQuery("DELETE FROM \"Ar_Fac\" WHERE \"Code_Article\"='"+Code+"' AND \"Code_Facture\"='"+currentFacture.Code+"'");
                DataSet ARFAC = dataBase.returnDataSet("SELECT \"Code_Article\",\"Libelle\",\"Quantite\",\"Operation\",\"Prix\" FROM \"Articles\",\"Ar_Fac\" WHERE \"Ar_Fac\".\"Code_Facture\"='" + currentFacture.Code + "' AND" +
                "\"Articles\".\"Code\"=\"Ar_Fac\".\"Code_Article\"");
                c1TrueDBGrid1.DataSource = ARFAC.Tables[0];
            }
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
        }

        private void c1DockingTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void c1Label1_TextChanged(object sender, EventArgs e)
        {
            if (c1Label1.Text == "Non Reglee")
            {
                pictureEtat.Image = GP.Properties.Resources.Rouge;
                datePayement.Visible = false;
            }
            if (c1Label1.Text == "Reglee")
            {
                datePayement.Visible = true;
                datePayement.Value = currentFacture.Date_Payement;
                pictureEtat.Image = GP.Properties.Resources.Vert;
            }
        }

        private void c1Label2_TextChanged(object sender, EventArgs e)
        {
            if (c1Label2.Text == "Non Livree")
            {
                pictureBox1.Image = GP.Properties.Resources.Rouge;
                dateSortie.Visible = false;
            }
            if (c1Label2.Text == "Livree")
            {
                dateSortie.Visible = true;
                dateSortie.Value = currentFacture.Date_livraison;
                pictureBox1.Image = GP.Properties.Resources.Vert;
            }
        }
    }
}