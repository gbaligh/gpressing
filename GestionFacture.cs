using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class GestionFacture : Form
    {
        private DataSet facture;

        public GestionFacture()
        {
            InitializeComponent();
        }

        private void GestionFacture_Load(object sender, EventArgs e)
        {
            DB_PostgreSQL databse = new DB_PostgreSQL();
            facture = databse.returnDataSet("SELECT * FROM \"Facture\"");
            facture.Tables[0].Constraints.Add("PrimaryKey", facture.Tables[0].Columns["Code"], true);
            c1TrueDBGrid1.DataSource = facture.Tables[0];
            c1TrueDBGrid1.RowHeight = 0;
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

        private void List_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1.PrintInfo.UseGridColors = false;
            c1TrueDBGrid1.PrintInfo.PageHeader = "TIPS Informatiaue";
            c1TrueDBGrid1.PrintInfo.PrintPreview();
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
            IndoFacture Facture = new IndoFacture(Code);
            Facture.ShowDialog(this);
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {

        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            IndoFacture f = new IndoFacture();
            f.ShowDialog(this);
        }
    }
}