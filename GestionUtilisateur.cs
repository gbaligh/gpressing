using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class GestionUtilisateur : Form
    {
        public GestionUtilisateur()
        {
            InitializeComponent();
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

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vous ete sure de vouloire Supprimer l'utilisateur ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = c1TrueDBGrid1.Row;
                string Code = c1TrueDBGrid1.Columns["Login"].CellText(index);
                if (Code == null)
                {
                    MessageBox.Show("Login Vide");
                    return;
                }
                TB_User Ar = new TB_User();
                Ar.FindByKey(Code);
                Ar.DeleteData();
                ((DataTable)c1TrueDBGrid1.DataSource).Rows.Find(Code).Delete();
            }
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Login"].CellText(index);
            InfoUtilisateur u = new InfoUtilisateur(Code);
            u.ShowDialog(this);
        }

        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {
            int index = c1TrueDBGrid1.Row;
            string Code = c1TrueDBGrid1.Columns["Login"].CellText(index);
            InfoUtilisateur u = new InfoUtilisateur(Code);
            u.ShowDialog(this);
        }

        private void GestionUtilisateur_Load(object sender, EventArgs e)
        {
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            c1TrueDBGrid1.DataSource = dataBase.returnDataSet("SELECT * FROM \"User\"").Tables[0];
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            InfoUtilisateur u = new InfoUtilisateur();
            u.ShowDialog();
        }

        private void Quiter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}