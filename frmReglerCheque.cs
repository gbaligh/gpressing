using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class frmReglerCheque : Form
    {
        private bool VerifierChamo()
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("Le Montant du Cheque ??");
                return false;
            }
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("Le Numeros du Cheque ??");
                return false;
            }
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("La Banque du Cheque ??");
                return false;
            }
            return true;
        }

        private string CodeFacture;

        public frmReglerCheque(string CodeFacture)
        {
            InitializeComponent();
            this.dateTimePicker1.Value = DateTime.Now;
            this.CodeFacture = CodeFacture;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (VerifierChamo())
            {
                DB_PostgreSQL dataBase = new DB_PostgreSQL();
                Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand();
                command.CommandText = "INSERT INTO \"Cheque\" (\"Banque\", \"Montant\", \"Date\", \"Num\", \"Code_Facture\") "+
                    "Values('"+comboBox1.Text+"','"+textBox1.Text+"',:date,'"+textBox2.Text+"','"+CodeFacture+"')";
                command.Parameters.Add(new Npgsql.NpgsqlParameter(":date", DbType.DateTime));
                command.Parameters[0].Value = dateTimePicker1.Value;
                dataBase.ExecuteCommand(command);
                ((Payement)Owner).regle = true;
                this.Close();
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Aqua;
            ((Control)sender).Focus();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;            
        }
    }
}