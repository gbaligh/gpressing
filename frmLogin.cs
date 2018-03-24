using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class frmLogin : Form
    {
        #region Chargement des champs du fichier XML
        private void LoadChamps()
        {
            string connString = ConfigSettings.ReadSetting("connString");
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
        }
        #endregion


        public frmLogin()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            TB_User Utilisateur = new TB_User();
            if (Utilisateur.FindByKey(textBoxLogin.Text))
            {
                if ((Utilisateur.Login == textBoxLogin.Text) && (Utilisateur.Password == textBoxPass.Text))
                {
                    GlobalVars.Utilisateur = Utilisateur;
                    this.Close();
                }
                this.labelError.Visible = true;
            }
            else
            {
                this.labelError.Visible = true;
            }
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            this.Height = this.Height<500?500:220;
            this.groupBox1.Visible = !this.groupBox1.Visible;
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveconnString_Click(object sender, EventArgs e)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            string connString = string.Empty;
            connString += "Server=" + textBoxServer.Text + ";";
            connString += "Port=" + textBoxPort.Text + ";";
            connString += "User Id=" + textBoxDBUser.Text + ";";
            connString += "Password=" + textBoxDBUserPass.Text + ";";
            connString += "DataBase=" + textBoxDB.Text + ";";
            if (dataBase.testConnection(connString))
            {
                GlobalVars.connString = connString;
                ConfigSettings.WriteSetting("connString", connString);
                buttonOptions_Click(sender, e);
            }
            else

                MessageBox.Show("Vérifiez la configuration de la base de données =>" + connString);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadChamps();
        }

        private void textBoxLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk_Click(sender, EventArgs.Empty);
            }
        }

        private void textBoxPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk_Click(sender, EventArgs.Empty);
            }
        }
    }
}