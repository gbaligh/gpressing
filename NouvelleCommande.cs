using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class NouvelleCommande : Form
    {
        List<TB_Famille> familles = TB_Famille.GetList();
        TB_Facture facture = new TB_Facture();
        TB_Client client = new TB_Client();
        List<ListAF> ligneCommande = new List<ListAF>();
        bool clientExiste = false;
        PrintingW wait = new PrintingW();
        float Total = 0;

        #region Ajouter une ligne de commande
        public void addLigneCommande(string code, string famille, string libelle, string quantite, string operation, string prix)
        {
            int index = -1;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if ((string)row.Cells[0].Value == code)
                {
                    index = row.Index;
                }
            }
            if (index != -1)
            {
                int q = int.Parse((string)dataGridView1.Rows[index].Cells["Quantite"].Value);
                float prixArticle = float.Parse(prix);
                int qArticle = int.Parse(quantite);
                dataGridView1.Rows[index].Cells["Quantite"].Value = (q + qArticle).ToString();
                Total += prixArticle * qArticle;
                labelTotal.Text = Total.ToString();
                numericPrixPayee.Maximum = (decimal)Total;
            }
            else
            {
                this.dataGridView1.Rows.Add(code, famille, libelle, quantite, operation, prix);
                float prixArticle = float.Parse(prix);
                int qArticle = int.Parse(quantite);
                Total += prixArticle * qArticle;
                labelTotal.Text = Total.ToString();
                numericPrixPayee.Maximum = (decimal)Total;
            }
        }
        #endregion
        
        #region Valider les champs
        private bool ValiderChamps()
        {
            if (comboCodeClient.Text == string.Empty)
            {
                MessageBox.Show("Verifier les donnee...");
                return false;
            }
            if (textNomClient.Text == string.Empty)
            {
                MessageBox.Show("Verifier les donnee...");
                return false;
            }
            if (textPrenomClient.Text == string.Empty)
            {
                MessageBox.Show("Verifier les donnee...");
                return false;
            }
            if (maskedTextTelClient.Text == string.Empty)
            {
                MessageBox.Show("Verifier les donnee...");
                return false;
            }

            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Aucun Article Selectionnee...");
                return false;
            }
            return true;
        }
        #endregion

        public NouvelleCommande()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NouvelleCommande_Load(object sender, EventArgs e)
        {
            this.comboCodeClient.Focus();

            //----------------Informations Societe (BEGIN)------------------------------//
            InfoSociete Societe = new InfoSociete();
            string titre = Societe.nom + "\n" + Societe.adresse + "\nTel:" + Societe.tel + " Fax:" + Societe.fax;
            label10.Text = titre;
            MemoryStream ms = new MemoryStream();
            ms.Write(Societe.logo, 0, Societe.logo.Length);
            Image imgPhoto = Image.FromStream(ms);
            picLogo.Image = imgPhoto;
            //----------------Informations Societe (END)------------------------------//

            labelCodeFacture.Text = facture.GenerateCode();
            comboCodeClient.DataSource = TB_Client.GetList();
            comboCodeClient.DisplayMember = "Code";
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(1);

            comboCodeClient.Text = client.GenerateCode();
            textNomClient.Text = "";
            textPrenomClient.Text = "";
            maskedTextTelClient.Text = "";
            textAdresseClient.Text = "";
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {   
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker2.Value = dateTimePicker1.Value;
                dateTimePicker2.MinDate = dateTimePicker1.Value;
            }
            else
                dateTimePicker2.Enabled = false;
        }

        private void comboCodeClient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TB_Client c = new TB_Client();
                if (c.FindByKey(comboCodeClient.Text))
                {
                    textNomClient.Text = c.Nom;
                    textPrenomClient.Text = c.Prenom;
                    maskedTextTelClient.Text = c.NTel;
                    textAdresseClient.Text = c.Adresse;
                    this.SelectNextControl(textAdresseClient, true, true, true, true);
                    clientExiste = true;
                }
                else
                {
                    comboCodeClient.Text = c.GenerateCode();
                    textNomClient.Text = "";
                    textPrenomClient.Text = "";
                    maskedTextTelClient.Text = "";
                    textAdresseClient.Text = "";
                    this.SelectNextControl(comboCodeClient, true, true, true, true);
                    clientExiste = false;
                }
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboCodeClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_Client c = new TB_Client();
            if (c.FindByKey(comboCodeClient.Text))
            {
                textNomClient.Text = c.Nom;
                textPrenomClient.Text = c.Prenom;
                maskedTextTelClient.Text = c.NTel;
                textAdresseClient.Text = c.Adresse;
                this.SelectNextControl(textAdresseClient, true, true, true, true);
                clientExiste = true;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (ValiderChamps())
            {
                #region //------------------Ticket a imprimer (Begin)----------------///
                if (checkBox1.Checked)
                {
                    this.Enabled = false;
                    wait.Show();
                    TicketClient ticket = new TicketClient();
                    TicketPiece piece = new TicketPiece();
                    InfoSociete societe = new InfoSociete();
                    List<ListAF> s = new List<ListAF>();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewRow row = dataGridView1.Rows[i];
                        s.Add(new ListAF());
                        s[i].Code_Article = (string)row.Cells["Code_Article"].Value;
                        s[i].Libelle_Article = (string)row.Cells["Article_Libelle"].Value;
                        s[i].Libelle_Famille = (string)row.Cells["Famille"].Value;
                        s[i].Operation = (string)row.Cells["Operation"].Value;
                        s[i].Prix = decimal.Parse((string)row.Cells["Prix"].Value);
                        s[i].Quantite = int.Parse((string)row.Cells["Quantite"].Value);
                    }
                    ticket.SetDataSource(s);
                    ticket.SetParameterValue("Code_Facture", facture.Code);
                    ticket.SetParameterValue("CodeClient", comboCodeClient.Text);
                    ticket.SetParameterValue("NomClient", textNomClient.Text);
                    ticket.SetParameterValue("PrenomClient", textPrenomClient.Text);
                    ticket.SetParameterValue("dateLivraison", dateTimePicker2.Value);
                    ticket.SetParameterValue("PrixPayee", numericPrixPayee.Value);
                    ticket.SetParameterValue("Prix_Total", labelTotal.Text);
                    ticket.SetParameterValue("Societe", societe.nom);
                    ticket.SetParameterValue("Tel", societe.tel);
                    ticket.SetParameterValue("Adress", societe.adresse);
                    if (GlobalVars.namePrinter == string.Empty)
                    {
                        MessageBox.Show("Verifier les Option de l'imprimante");
                        return;
                    }
                    //ticket.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)Enum.GetValues(typeof(CrystalDecisions.Shared.PaperSize)).GetValue(int.Parse(GlobalVars.page));
                    //piece.PrintOptions.PaperSize = ticket.PrintOptions.PaperSize;
                    ticket.PrintOptions.PrinterName = GlobalVars.namePrinter;
                    piece.PrintOptions.PrinterName = GlobalVars.namePrinter;

                    int nb = int.Parse(GlobalVars.nombreCopieTicket);
                    for (int i = 0; i < nb;i++ )
                        ticket.PrintToPrinter(1, true, 1, 1);


                    foreach (ListAF d in s)
                    {
                        piece.SetParameterValue("Code_Facture", facture.Code);
                        piece.SetParameterValue("Nom", textNomClient.Text + " " + textPrenomClient.Text);
                        piece.SetParameterValue("Date_Liv", dateTimePicker2.Value);
                        int n = (int)d.article.N_Pieces * d.Quantite;
                        if (d.article.Print)
                            continue;
                        switch (d.Operation)
                        {
                            case "Pressing":
                                if (GlobalVars.maxPressing != "#")
                                {
                                    if (d.Quantite > int.Parse(GlobalVars.maxPressing))
                                    {
                                        piece.PrintToPrinter(1, true, 1, 1);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < n; i++)
                                        piece.PrintToPrinter(1, true, 1, 1);
                                }
                                break;
                            case "Repassage":
                                if (GlobalVars.maxRepassage != "#")
                                {
                                    if (d.Quantite > int.Parse(GlobalVars.maxRepassage))
                                    {
                                        piece.PrintToPrinter(1, true, 1, 1);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < n; i++)
                                        piece.PrintToPrinter(1, true, 1, 1);
                                }
                                break;
                            case "Tenture":
                                if (GlobalVars.maxTenture != "#")
                                {
                                    if (d.Quantite > int.Parse(GlobalVars.maxTenture))
                                    {
                                        piece.PrintToPrinter(1, true, 1, 1);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < n; i++)
                                        piece.PrintToPrinter(1, true, 1, 1);
                                }
                                break;
                            case "Autre":
                                if (GlobalVars.maxAutre != "#")
                                {
                                    if (d.Quantite > int.Parse(GlobalVars.maxAutre))
                                    {
                                        piece.PrintToPrinter(1, true, 1, 1);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < n; i++)
                                        piece.PrintToPrinter(1, true, 1, 1);
                                }
                                break;
                        }
                    }
                    this.Enabled = true;
                    wait.Close();
                }
                #endregion //------------------Ticket a imprimer (End)----------------///
                
                #region //-----------------Enrigstrment de la Facture (Begin)------------------------///
                //client///
                 //
                client.Nom = textNomClient.Text;
                client.Prenom = textPrenomClient.Text;
                client.Adresse = textAdresseClient.Text;
                client.NTel = maskedTextTelClient.Text;
                client.Code = comboCodeClient.Text;
                 if (!clientExiste)
                 {
                     client.SaveData();
                 }
                 //Table Facture 
                 facture.Client = client;
                 facture.Date_livraison = dateTimePicker2.Value;
                 facture.Date_Recu = dateTimePicker1.Value;
                 facture.Prix_Total = double.Parse(labelTotal.Text);
                 facture.Prix_Partiel = (double)numericPrixPayee.Value;
                 facture.Mode_Payement = "Espece";
                 facture.Etat = "Non Reglee";
                 facture.Livree = "Non Livree";
                 facture.SaveData();

                 //lignes de commandes
                 foreach (DataGridViewRow row in dataGridView1.Rows)
                 {
                     ListAF sd = new ListAF();
                     sd.Code_Article = (string)row.Cells["Code_Article"].Value;
                     sd.Code_Facture = facture.Code;
                     sd.Operation = (string)row.Cells["Operation"].Value;
                     sd.Quantite = int.Parse((string)row.Cells["Quantite"].Value);
                     sd.Prix = decimal.Parse((string)row.Cells["Prix"].Value);
                     sd.saveData();
                 }
                #endregion //-----------------Enrigstrment de la Facture (End)------------------------///
                 
                if (checkBox2.Checked)
                 {
                     Payement p = new Payement(facture.Code);
                     p.ShowDialog(this.Owner);
                 }
                 this.Close();
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                frmFactureAjouterArticle Ajout = new frmFactureAjouterArticle();
                Ajout.ShowDialog(this);
            }
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string q = (string)selectedRow.Cells["Quantite"].Value;
                    string p = (string)selectedRow.Cells["Prix"].Value;
                    int Quantite = int.Parse(q);
                    float Prix = float.Parse(p);
                    Total -= Quantite * Prix;
                    labelTotal.Text = Total.ToString();
                    dataGridView1.Rows.Remove(selectedRow);
                }
                catch (Exception)
                {
                    MessageBox.Show("Aucunne ligne a supprimer...");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(3);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void comboCodeClient_Leave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        private void textNomClient_KeyUp(object sender, KeyEventArgs e)
        {
            clientExiste = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFactureAjouterArticle Ajout = new frmFactureAjouterArticle();
            Ajout.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string q = (string)selectedRow.Cells["Quantite"].Value;
                string p = (string)selectedRow.Cells["Prix"].Value;
                int Quantite = int.Parse(q);
                float Prix = float.Parse(p);
                Total -= Quantite * Prix;
                labelTotal.Text = Total.ToString();
                dataGridView1.Rows.Remove(selectedRow);
            }
            catch (Exception)
            {
                MessageBox.Show("Aucunne ligne a supprimer...");
            }
        }

        private void comboCodeClient_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Aqua;
            ((Control)sender).Focus();
        }
    }
}