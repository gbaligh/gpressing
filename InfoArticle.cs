using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class InfoArticle : Form
    {
        TB_Articles currentArticle = new TB_Articles();
        bool newPic = false;
        bool Save = false;
        TB_Famille famille = new TB_Famille();

        #region Operation sur les champs de la form
        private bool VerifierChamp()
        {
            if (c1Combo1.Text == "")
            {
                MessageBox.Show("Donner la Famille de l'article");
                return false;
            }
            if ((c1NumericEdit1.Text == "")&(checkBox1.Checked))
            {
                MessageBox.Show("Donner le prix de pressing de l'article");
                return false;
            }
            if ((c1NumericEdit2.Text == "")&(checkBox1.Checked))
            {
                MessageBox.Show("Donner le prix de repassage l'article");
                return false;
            }
            if ((c1NumericEdit3.Text == "")&(checkBox1.Checked))
            {
                MessageBox.Show("Donner le prix de tenture l'article");
                return false;
            }
            if ((c1NumericEdit4.Text == "")&(checkBox1.Checked))
            {
                MessageBox.Show("Donner le prix de l'operation auxiliaire de l'article");
                return false;
            }
            if (c1TextBox1.Text == "")
            {
                MessageBox.Show("Generez le Code de l'article");
                return false;
            }
            if (c1TextBox2.Text == "")
            {
                MessageBox.Show("Donner la Designation de l'article");
                return false;
            }
            if (c1TextBox3.Text == "")
            {
                MessageBox.Show("Donner le nombre de pieces de l'article");
                return false;
            }
            return true;
        }

        private TB_Articles GetChamp()
        {
            TB_Articles article = new TB_Articles();
            article.N_Pieces = (decimal)c1TextBox3.Value;
            article.Libelle = (string)c1TextBox2.Text;
            article.Code_Famille = (string)c1Combo1.SelectedValue;
            article.Code = (string)c1TextBox1.Text;
            article.Description = (string)c1TextBox4.Text;
            article.Prix_Pressing = (decimal)c1NumericEdit1.Value;
            article.Prix_Repassage = (decimal)c1NumericEdit2.Value;
            article.Prix_Tenture = (decimal)c1NumericEdit3.Value;
            article.Prix_Autre = (decimal)c1NumericEdit4.Value;
            article.Print = checkBox5.Checked;
            if (newPic)
            {
                MyUtils myUtils = new MyUtils();
                article.Photo = myUtils.GetPhoto(textBox1.Text);
            }
            else
                article.Photo = null;
            return article;
        }
        
        private void SetChamp(TB_Articles article)
        {
            c1TextBox1.Value = article.Code;
            c1TextBox2.Value = article.Libelle;
            c1TextBox3.Value = article.N_Pieces;
            c1TextBox4.Value = article.Description;
            c1NumericEdit1.Value = article.Prix_Pressing;
            c1NumericEdit2.Value = article.Prix_Repassage;
            c1NumericEdit3.Value = article.Prix_Tenture;
            c1NumericEdit4.Value = article.Prix_Autre;
            checkBox1.Checked = article.Pressing;
            checkBox2.Checked = article.Repassage;
            checkBox3.Checked = article.Tenture;
            checkBox4.Checked = article.Autre;
            c1Combo1.SelectedValue = article.Code_Famille;
            checkBox5.Checked = article.Print;
            if (article.Photo != null)
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(article.Photo, 0, article.Photo.Length);
                Image imgPhoto = Image.FromStream(ms);
                c1PictureBox1.Image = imgPhoto;
            }
        }
        #endregion
        
        public InfoArticle()
        {
            InitializeComponent();
            btnOK.Enabled = true;
            Save = true;
            c1TextBox3.Value = 1;
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            c1Combo1.DataSource = dataBase.returnDataSet("SELECT \"Code\",\"Libelle\" FROM \"Famille\"").Tables[0];
            c1Combo1.DisplayMember = "Libelle";
            c1Combo1.ValueMember = "Code";
            c1Combo1.Text = "";
            c1NumericEdit1.Value = 0;
            c1NumericEdit2.Value = 0;
            c1NumericEdit3.Value = 0;
            c1NumericEdit4.Value = 0;
            TB_Articles article = new TB_Articles();
           c1TextBox1.Value = article.GenerateCode((string)c1TextBox2.Text);
        }

        public InfoArticle(string Code)
        {
            InitializeComponent();
            Save = false;
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            c1Combo1.DataSource = dataBase.returnDataSet("SELECT \"Code\",\"Libelle\" FROM \"Famille\"").Tables[0];
            c1Combo1.DisplayMember = "Libelle";
            c1Combo1.ValueMember = "Code";
            currentArticle.FindByKey(Code);
            SetChamp(currentArticle);
            btnOK.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            c1NumericEdit1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            c1NumericEdit2.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            c1NumericEdit3.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            c1NumericEdit4.Enabled = checkBox4.Checked;
        }

        private void InfoArticle_Load(object sender, EventArgs e)
        {

        }

        private void c1TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void c1TextBox2_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            if (Save)
            {
                TB_Articles a = new TB_Articles();
                c1TextBox1.Value = a.GenerateCode((string)c1TextBox2.Text);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (VerifierChamp())
            {
                TB_Articles newArticle = GetChamp();
                if (!Save)
                    newArticle.UpdateData();
                else
                    newArticle.SaveData();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyUtils myUtils = new MyUtils();
            string sPath = myUtils.PhotoPath();

            if (sPath != string.Empty)
            {
                newPic = true;
                byte[] img = myUtils.GetPhoto(sPath);
                MemoryStream ms = new MemoryStream();
                ms.Write(img, 0, img.Length);
                Image imgPhoto = Image.FromStream(ms);
                c1PictureBox1.Image = imgPhoto;
                textBox1.Text = sPath;
                btnOK.Enabled = true;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c1TextBox2_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Aqua;
            ((Control)sender).Focus();
        }

        private void c1TextBox2_Leave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }
    }
}