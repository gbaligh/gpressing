using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class GestionFamille : Form
    {
        private void LoadData()
        {
            DB_PostgreSQL databse = new DB_PostgreSQL();
            DataSet tmp;
            tmp = databse.returnDataSet("SELECT * FROM \"Famille\"");
            tmp.Tables[0].Constraints.Add("PrimaryKey", tmp.Tables[0].Columns["Code"], true);
            c1TrueDBGrid1.DataSource = tmp.Tables[0];
            c1TrueDBGrid1.RowHeight = 0;
        }

        public GestionFamille()
        {
            InitializeComponent();
        }

        private void GestionFamille_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vous ete sure de vouloire Supprimer cette Famille ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = c1TrueDBGrid1.Row;
                string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
                if (Code == null)
                {
                    MessageBox.Show("Code Vide");
                    return;
                }
                TB_Famille Ar = new TB_Famille();
                Ar.FindByKey(Code);
                Ar.DeleteData();
                ((DataTable)c1TrueDBGrid1.DataSource).Rows.Find(Code).Delete();
            }
        }

        private void Recherche_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1.FilterBar = !c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.AllowFilter = c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.FilterActive = c1TrueDBGrid1.FilterBar;
        }

        private void List_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1.PrintInfo.UseGridColors = false;
            c1TrueDBGrid1.PrintInfo.PageHeader = "TIPS Informatiaue";
            c1TrueDBGrid1.PrintInfo.PrintPreview();
        }

        private void Quiter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
            InfoFamille fa = new InfoFamille(Code);
            fa.ShowDialog(this);
            LoadData();
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            InfoFamille fa = new InfoFamille();
            fa.ShowDialog(this);
            LoadData();
        }
    }
}