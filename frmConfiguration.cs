using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class frmConfiguration : Form
    {
        #region Chargement des champs du fichier XML
        private void LoadChamps()
        {
            /***   PARTIE Configuration Connexion */
            string connString = GlobalVars.connString;
            if (connString != null)
            {
                foreach (string s in connString.Split(";".ToCharArray()))
                {
                    switch ((s.Split("=".ToCharArray()))[0])
                    {
                        case "Server":
                            textBoxServer.Text = (s.Split("=".ToCharArray()))[1];
                            break;
                        case "Port":
                            textBoxPort.Text = (s.Split("=".ToCharArray()))[1];
                            break;
                        case "User Id":
                            textBoxDBUser.Text = (s.Split("=".ToCharArray()))[1];
                            break;
                        case "Password":
                            textBoxDBUserPass.Text = (s.Split("=".ToCharArray()))[1];
                            break;
                        case "DataBase":
                            textBoxDB.Text = (s.Split("=".ToCharArray()))[1];
                            break;
                    }
                }
            }

            /***   PARTIE Configuration Societe */
            InfoSociete societe = new InfoSociete();
            if (societe.existe)
            {
                txtNom.Text = societe.nom;
                txtAdresse.Text = societe.adresse;
                txttele.Text = societe.tel;
                txtfax.Text = societe.fax;
                MemoryStream ms = new MemoryStream();
                ms.Write(societe.logo, 0, societe.logo.Length);
                Image imgPhoto = Image.FromStream(ms);
                pbxLogo.Image = imgPhoto;
            }

            /***   PARTIE Configuration Client */
            textPrefixFacture.Text = GlobalVars.PrefixFacture;
            textPremierFacture.Text = GlobalVars.PremierFacture;
            textPrefixClient.Text = GlobalVars.PrefixClient;
            textMaxAutre.Text = GlobalVars.maxAutre;
            textMaxPressing.Text = GlobalVars.maxPressing;
            textMaxRepassage.Text = GlobalVars.maxRepassage;
            textMaxTenture.Text = GlobalVars.maxTenture;


            /***   PARTIE Configuration Imprimante */
            comboPrinters.Text = GlobalVars.namePrinter;
            comboPage.DataSource = Enum.GetNames(typeof(CrystalDecisions.Shared.PaperSize));
            try
            {
                comboPage.SelectedIndex = int.Parse(GlobalVars.page);
            }
            catch (Exception)
            {
                comboPage.SelectedIndex = 0;
            }
            textNbTicket.Text = GlobalVars.nombreCopieTicket;
            foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                comboPrinters.Items.Add(s);
        }
        #endregion

        #region Valider les champs de saisie
        private bool validateFields()
        {
            txtNom.BackColor = Color.White;
            txtNom.Focus();
            txttele.BackColor = Color.White;
            txttele.Focus();
            txtAdresse.BackColor = Color.White;
            txtAdresse.Focus();
            if (txtNom.Text == string.Empty)
            {
                MessageBox.Show("SVP, Choisir le nom de la société!", this.Text);
                txtNom.BackColor = Color.Cyan;
                txtNom.Focus();
                return false;
            }
            if (txtAdresse.Text.Length == 0)
            {
                MessageBox.Show("SVP, Entrez l'adresse de votre société", this.Text);
                txtAdresse.BackColor = Color.Cyan;
                txtAdresse.Focus();
                return false;
            }

            if (txttele.Text.Length == 0)
            {
                MessageBox.Show("SVP, Entrer votre Téléphone!", this.Text);
                txttele.BackColor = Color.Cyan;
                txttele.Focus();
                return false;
            }

            /*
            if (tbxPhoto.Text.Length == 0)
            {
                MessageBox.Show("SVP, Entrer le logo de votre société!", this.Text);
                tbxPhoto.BackColor = Color.Cyan;
                tbxPhoto.Focus();
                return false;
            }
             */
            return true;
        }
        #endregion

        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void maskedTextBoxPort_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------
                DB_PostgreSQL dataBase = new DB_PostgreSQL();
                string connString = string.Empty;
                connString += "Server=" + textBoxServer.Text + ";";
                connString += "Port=" + textBoxPort.Text + ";";
                connString += "User Id=" + textBoxDBUser.Text + ";";
                connString += "Password=" + textBoxDBUserPass.Text + ";";
                connString += "DataBase=" + textBoxDB.Text + ";";
                GlobalVars.connString = connString;
                if (dataBase.testConnection(connString))
                {
                    ConfigSettings.WriteSetting("connString", connString);
                }
                else
                    MessageBox.Show("Vérifiez la configuration de la base de données =>" + connString);
            //--------------------------------------------------------
                string Printer = comboPrinters.Text;
                string Page = comboPage.SelectedIndex.ToString();
                string NbTicket = textNbTicket.Text;
                string MaxPressing = textMaxPressing.Text;
                string MaxRepassage = textMaxRepassage.Text;
                string MaxTenture = textMaxTenture.Text;
                string MaxAutre = textMaxAutre.Text;
                GlobalVars.page = comboPage.SelectedIndex.ToString();
                GlobalVars.namePrinter = Printer;
                GlobalVars.nombreCopieTicket = NbTicket;
                GlobalVars.maxAutre = MaxAutre;
                GlobalVars.maxPressing = MaxPressing;
                GlobalVars.maxRepassage = MaxRepassage;
                GlobalVars.maxTenture = MaxTenture;
                ConfigSettings.WriteSetting("Printer", Printer);
                ConfigSettings.WriteSetting("Page", Page);
                ConfigSettings.WriteSetting("NbTicket", NbTicket);
                ConfigSettings.WriteSetting("MaxPressing", MaxPressing);
                ConfigSettings.WriteSetting("MaxRepassage", MaxRepassage);
                ConfigSettings.WriteSetting("MaxTenture", MaxTenture);
                ConfigSettings.WriteSetting("MaxAutre", MaxAutre);
            //--------------------------------------------------------
                string PrefixFacture = textPrefixFacture.Text;
                string PremierFacture = textPremierFacture.Text;
                string PrefixClient = textPrefixClient.Text;
                GlobalVars.PrefixFacture = PrefixFacture;
                GlobalVars.PremierFacture = PremierFacture;
                GlobalVars.PrefixClient = PrefixClient;
                ConfigSettings.WriteSetting("prefixFacutre", PrefixFacture);
                ConfigSettings.WriteSetting("firstFacutre", PremierFacture);
                ConfigSettings.WriteSetting("prefixClient", PrefixClient);
            //----------------------------------------------------------
            //---------------------------------------------------------- 
            MyUtils myUtils = new MyUtils();
                if (validateFields())
                {
                    InfoSociete societe = new InfoSociete();
                    societe.nom = txtNom.Text;
                    societe.adresse = txtAdresse.Text;
                    societe.tel = txttele.Text;
                    societe.fax = txtfax.Text;
                    if(tbxPhoto.Text != string.Empty)
                        societe.logo = myUtils.GetPhoto(tbxPhoto.Text);
                    societe.SaveData();
                }
            //-------------------------------------------------------------
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = string.Empty;
            connString += "Server=" + textBoxServer.Text + ";";
            connString += "Port=" + textBoxPort.Text + ";";
            connString += "User Id=" + textBoxDBUser.Text + ";";
            connString += "Password=" + textBoxDBUserPass.Text + ";";
            connString += "DataBase=" + textBoxDB.Text + ";";
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            if (dataBase.testConnection(connString))
                MessageBox.Show("Connexion établie");
            else
                MessageBox.Show("Erreur de Configuration " );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            LoadChamps();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            MyUtils myUtils = new MyUtils();
            string sPath = myUtils.PhotoPath();

            if (sPath != string.Empty)
            {
                byte[] img = myUtils.GetPhoto(sPath);
                MemoryStream ms = new MemoryStream();
                ms.Write(img, 0, img.Length);
                Image imgPhoto = Image.FromStream(ms);
                pbxLogo.Image = imgPhoto;
                tbxPhoto.Text = sPath;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            

        }
    }
}