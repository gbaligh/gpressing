using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GP
{
    public partial class InfoUtilisateur : Form
    {
        private bool Save = false;
        private bool newPic = false;

        private bool VerifierChamp()
        {
            if (c1TextBox1.Text == "")
            {
                MessageBox.Show("Il faut donne le Login ??");
                return false;
            }
            if (c1TextBox2.Text == "")
            {
                MessageBox.Show("Il faut donne le Password ??");
                return false;
            }
            return true;
        }

        private TB_User GetChamp()
        {
            TB_User r = new TB_User();
            r.Login = (string)c1TextBox1.Value;
            r.Password = (string)c1TextBox2.Value;
            r.Tel = (string)c1TextBox3.Value;
            r.Role = comboBox1.SelectedIndex;
            return r;
        }

        public InfoUtilisateur()
        {
            InitializeComponent();
            Save = true;
        }

        public InfoUtilisateur(string Code)
        {
            InitializeComponent();
            Save = false;
            TB_User Utilisateut = new TB_User();
            Utilisateut.FindByKey(Code);
            c1TextBox1.Enabled = false;
            c1TextBox1.Value = Utilisateut.Login;
            c1TextBox2.Value = Utilisateut.Password;
            c1TextBox3.Value = Utilisateut.Tel;
            comboBox1.SelectedIndex = Utilisateut.Role;
            MemoryStream ms = new MemoryStream();
            ms.Write(Utilisateut.Photo, 0, Utilisateut.Photo.Length);
            Image imgPhoto = Image.FromStream(ms);
            pictureBox1.Image = imgPhoto;
        }


        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MyUtils myUtils = new MyUtils();
            string sPath = myUtils.PhotoPath();

            if (sPath != string.Empty)
            {
                byte[] img = myUtils.GetPhoto(sPath);
                MemoryStream ms = new MemoryStream();
                ms.Write(img, 0, img.Length);
                Image imgPhoto = Image.FromStream(ms);
                pictureBox1.Image = imgPhoto;
                pictureBox1.Text = sPath;
                btnOK.Enabled = true;
                newPic = true;
            }
        }

        private void InfoUtilisateur_Load(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MyUtils myUtils = new MyUtils();
            if (VerifierChamp())
            {
                TB_User newUser = GetChamp();
                if(newPic)
                    newUser.Photo = myUtils.GetPhoto(pictureBox1.Text);
                if (!Save)
                    newUser.UpdateData();
                else
                    newUser.SaveData();
                this.Close();
            }
        }

        private void c1TextBox1_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void c1TextBox1_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Aqua;
            ((Control)sender).Focus();
        }

        private void c1TextBox1_Leave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }
    }
}