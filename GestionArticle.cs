using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class gestionArticle : Form
    {
        private DataSet famille;
        public DataRow newRow;
        private DataSet article;

        public gestionArticle()
        {
            InitializeComponent();

        }

        private void gestionArticle_Load(object sender, EventArgs e)
        {
            DB_PostgreSQL databse = new DB_PostgreSQL();
            article = databse.returnDataSet("SELECT \"Code\",\"Libelle\",\"Code_Famille\",\"Prix_Pressing\",\"Prix_Repassage\",\"Prix_Tenture\",\"Prix_Autre\",\"Photo\" FROM \"Articles\"");
            article.Tables[0].Constraints.Add("PrimaryKey", article.Tables[0].Columns["Code"], true);
            famille = databse.returnDataSet("SELECT * FROM \"Famille\"");
            
            c1TrueDBGrid1.DataSource = article.Tables[0];
            c1TrueDBGrid1.RowHeight = 0;

            c1TrueDBDropdown1.DataSource = famille.Tables[0];
            c1TrueDBGrid1.Columns["Code_Famille"].DropDown = this.c1TrueDBDropdown1;
            c1TrueDBGrid1.Columns["Code_Famille"].ValueItems.Translate = true;
            c1TrueDBGrid1.Columns["Code_Famille"].Caption = "Famille";
            c1TrueDBDropdown1.DataField = "Code";
            c1TrueDBDropdown1.ListField = "Libelle";
            c1TrueDBDropdown1.ValueTranslate = true;
            c1TrueDBGrid1.Splits[0].DisplayColumns["Famille"].FilterButton = true;
            c1TrueDBGrid1.Splits[0].DisplayColumns["Famille"].Button = false;
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

        private void Recherche_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1.FilterBar = !c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.AllowFilter = c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.FilterActive = c1TrueDBGrid1.FilterBar;
            c1TrueDBGrid1.Splits[0].DisplayColumns["Famille"].FilterButton = true;
            c1TrueDBGrid1.Splits[0].DisplayColumns["Famille"].Button = false;
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vous ete sure de vouloire Supprimer cette article ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = c1TrueDBGrid1.Row;
                string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
                if (Code == null)
                {
                    MessageBox.Show("Code Vide");
                    return;
                }
                TB_Articles Ar = new TB_Articles();
                Ar.FindByKey(Code);
                Ar.DeleteData();
                ((DataTable)c1TrueDBGrid1.DataSource).Rows.Find(Code).Delete();
            }
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Code"].CellText(index);
            InfoArticle frmarticle = new InfoArticle(Code);
            frmarticle.ShowDialog(this);
            gestionArticle_Load(sender, e);
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            InfoArticle frmarticle = new InfoArticle();
            frmarticle.ShowDialog(this);
            gestionArticle_Load(sender, e);
        }
    }
}