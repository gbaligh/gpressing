using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class GestionClient : Form
    {
        public GestionClient()
        {
            InitializeComponent();
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            InfoClient client = new InfoClient();
            client.ShowDialog(this);
            GestionClient_Load(sender, e);
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
            InfoClient client = new InfoClient(Code);
            client.ShowDialog(this);
            GestionClient_Load(sender, e);
        }

        private void GestionClient_Load(object sender, EventArgs e)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            c1TrueDBGrid1.DataSource = dataBase.returnDataSet("SELECT * FROM \"Client\"").Tables[0];
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vous ete sure de vouloire Supprimer ceux Client ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = c1TrueDBGrid1.Row;
                string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
                if (Code == null)
                {
                    MessageBox.Show("Code Vide");
                    return;
                }
                DB_PostgreSQL dataBase = new DB_PostgreSQL();
                dataBase.ExecuteNonQuery("DELETE FROM \"Facture\" Where \"Code_Client\"='"+Code+"'");
                TB_Client Ar = new TB_Client();
                Ar.FindByKey(Code);
                Ar.DeleteData();
                GestionClient_Load(sender, e);
            }
        }

        private void List_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1.PrintInfo.UseGridColors = false;
            c1TrueDBGrid1.PrintInfo.PageHeader = "TIPS Informatiaue";
            c1TrueDBGrid1.PrintInfo.PrintPreview();
        }

        private void Recherche_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1.FilterBar = !c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.AllowFilter = c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.FilterActive = c1TrueDBGrid1.FilterBar;
        }

        private void Quiter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}