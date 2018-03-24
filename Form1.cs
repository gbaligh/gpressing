using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class Form1 : Form
    {
        #region Function de Login
        private void Login()
        {
            
            frmLogin login = new frmLogin();
            login.ShowDialog(this);
        }
        #endregion

        private void ShowAdmin(bool admin)
        {
            this.administrationToolStripMenuItem.Visible = admin;
        }

        public Form1()
        {
            InitializeComponent();
            frmChargement ch = new frmChargement();
            ch.ShowDialog(this);
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration conf = new frmConfiguration();
            conf.ShowDialog(this);
        }

        private void tIPSInformatiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox about = new frmAboutBox();
            about.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login();
            if (GlobalVars.Utilisateur == null)
                this.Close();
            else
            {
                ShowAdmin(GlobalVars.Utilisateur.Role == 0);
                labelUser.Text = GlobalVars.Utilisateur.Login;
                labelDate.Text = GlobalVars.ConnexionTime;
                DB_PostgreSQL dataBase = new DB_PostgreSQL();
                DataSet d = dataBase.returnDataSet("SELECT \"Code\",\"Date_Recu\",\"Prix_Total\",\"Prix_Partiel\",\"Code_Client\",\"Etat\",\"Livree\" FROM \"Facture\" WHERE (\"Etat\"='Non Reglee' OR \"Livree\"='Non Livree')AND date(\"Date_Livraison\")=:date", ":date", DbType.Date, DateTime.Now.Date);
                DataSet c = dataBase.returnDataSet("SELECT * FROM \"Client\"");
                c1TrueDBGrid1.DataSource = d.Tables[0];
                c1TrueDBDropdown1.DataSource = c.Tables[0];
                c1TrueDBGrid1.Splits[0].DisplayColumns["Code_Client"].Button = false;
                c1TrueDBGrid1.Splits[0].DisplayColumns["Code_Client"].FilterButton = true;
                c1TrueDBGrid1.Columns["Code_Client"].DropDown = this.c1TrueDBDropdown1;
                c1TrueDBDropdown1.DataField = "Code";
                c1TrueDBDropdown1.ListField = "Nom";
                c1TrueDBGrid1.Columns["Code_Client"].ValueItems.Translate = true;
                c1TrueDBDropdown1.ValueTranslate = true;
            }
        }

        private void quiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gestionDesClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionClient gestionClient = new GestionClient();
            gestionClient.ShowDialog();
        }

        private void aperçuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gestionDesFamillesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionFamille gestionFamille = new GestionFamille();
            gestionFamille.ShowDialog(this);
        }

        private void gestionDesFacturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionFacture gestionFacture = new GestionFacture();
            gestionFacture.ShowDialog(this);
        }

        private void gestionDesArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionArticle f = new gestionArticle();
            f.ShowDialog(this);
            /*frmGestionArtices gestionArticle = new frmGestionArtices();
            gestionArticle.ShowDialog();*/
        }

        private void nouvelleCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NouvelleCommande NCommande = new NouvelleCommande();
            NCommande.ShowDialog(this);
        }

        private void payementCommadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactureParCode fc = new FactureParCode();
            fc.ShowDialog(this);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            DataSet d = null;
            DataSet c = dataBase.returnDataSet("SELECT * FROM \"Client\"");   
            if (radioButton1.Checked)
            {
                d = dataBase.returnDataSet("SELECT \"Code\",\"Date_Recu\",\"Prix_Total\",\"Prix_Partiel\",\"Code_Client\",\"Etat\",\"Livree\" FROM \"Facture\" WHERE (\"Etat\"='Non Reglee' OR \"Livree\"='Non Livree') AND date(\"Date_Livraison\")=:date", ":date", DbType.Date, DateTime.Now.Date);
            }
            if (radioButton2.Checked)
            {
                d = dataBase.returnDataSet("SELECT \"Code\",\"Date_Recu\",\"Prix_Total\",\"Prix_Partiel\",\"Code_Client\",\"Etat\",\"Livree\" FROM \"Facture\" WHERE (\"Etat\"='Non Reglee' OR \"Livree\"='Non Livree') AND date(\"Date_Livraison\")<:date", ":date", DbType.Date, DateTime.Now.Date);
            }
            if (radioButton3.Checked)
            {
                d = dataBase.returnDataSet("SELECT \"Code\",\"Date_Recu\",\"Prix_Total\",\"Prix_Partiel\",\"Code_Client\",\"Etat\",\"Livree\" FROM \"Facture\" WHERE (\"Etat\"='Non Reglee' OR \"Livree\"='Non Livree') AND date(\"Date_Livraison\")>:date", ":date", DbType.Date, DateTime.Now.Date);
            }
            c1TrueDBGrid1.DataSource = d.Tables[0];
            c1TrueDBDropdown1.DataSource = c.Tables[0];
            c1TrueDBGrid1.Splits[0].DisplayColumns["Code_Client"].Button = false;
            c1TrueDBGrid1.Splits[0].DisplayColumns["Code_Client"].FilterButton = true;
            c1TrueDBGrid1.Columns["Code_Client"].DropDown = this.c1TrueDBDropdown1;
            c1TrueDBDropdown1.DataField = "Code";
            c1TrueDBDropdown1.ListField = "Nom";
            c1TrueDBGrid1.Columns["Code_Client"].ValueItems.Translate = true;
            c1TrueDBDropdown1.ValueTranslate = true;
        }

        private void c1TrueDBGrid1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
            Payement p = new Payement(Code);
            p.ShowDialog(this);
            radioButton1_CheckedChanged(sender, e);
        }

        private void gestionDesUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUtilisateur utilisateur = new GestionUtilisateur();
            utilisateur.ShowDialog();
        }

        private void bilanDunJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gestionDePressingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChargement a = new frmChargement(0);
            a.ShowDialog();
        }

        private void rechercheSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionDesFacturesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "N Ticket ...";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArticleFacture n = new ArticleFacture();
            n.ShowDialog(this);
        }
    }
}