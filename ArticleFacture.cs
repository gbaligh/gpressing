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
    public partial class ArticleFacture : Form
    {
        public ArticleFacture()
        {
            InitializeComponent();
           
        }

        private void ArticleFacture_Load(object sender, EventArgs e)
        {
            c1Combo1.Text = panel1.Height.ToString();
            comboBox1.Text = panel1.Width.ToString();
            DB_PostgreSQL dataBase = new DB_PostgreSQL();
            DataSet F = dataBase.returnDataSet("SELECT * FROM \"Famille\"");
            c1Combo1.DataSource = F.Tables[0];
            c1Combo1.DisplayMember = "Libelle";
            c1Combo1.ValueMember = "Code";
            int x = 0;
            int y = 0;
            foreach (DataRow r in F.Tables[0].Rows)
            {
                Button b = new Button();
                b.Parent = this.panel2;
                b.BackColor = Color.White;
                b.Font = new Font("Microsoft Sans Serif", 16);
                b.Text = (string)r["Libelle"];
                b.Size = new Size(200, 50);
                b.Tag = (string)r["Code"];
                b.Location = new Point(x, y);
                y += 50;
                b.Click += new EventHandler(b_Click);
            }
            comboBox1.DataSource = Enum.GetNames(typeof(GlobalVars.Operation));
            List<TB_Articles> da = TB_Articles.GetList((string)c1Combo1.SelectedValue,comboBox1.Text);
            x = 0;
            y = 0;
            foreach (TB_Articles a in da)
            {
                Button b = new Button();
                b.Parent = this.panel1;
                b.Text = a.Libelle;
                b.Size = new Size(200, 200);
                b.Location = new Point(x, y);
                if (x < panel1.Width)
                    if (y < panel1.Height)
                        y += 200;
                    else
                    {
                        y = 0;
                        x += 200;
                    }
            }
            this.Invalidate();
        }

        void b_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<TB_Articles> da = TB_Articles.GetList((string)((Button)sender).Tag, comboBox1.Text);
            int x = 0;
            int y = 0;
            int h = panel1.Height;
            int w = panel1.Width;
            foreach (TB_Articles a in da)
            {
                Button b = new Button();
                b.Parent = this.panel1;
                b.Text = a.Libelle;
                b.TextAlign = ContentAlignment.BottomCenter;
                b.BackgroundImageLayout = ImageLayout.Zoom;
                b.BackColor = Color.White;
                b.Font = new Font("Microsoft Sans Serif", 16);
                if (a.Photo != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(a.Photo, 0, a.Photo.Length);
                    Image imgPhoto = Image.FromStream(ms);
                    b.BackgroundImage = imgPhoto;
                }
                b.Size = new Size(200, 100);
                b.Location = new Point(x, y);
                if (y != 0)
                {
                    if ((h / (y+200)) >= 1)
                        y += 100;
                    else
                    {
                        y = 0;
                        x += 200;
                    }
                }
                else
                    y += 100;
            }
            this.Invalidate();
        }

        private void c1Combo1_TextChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            List<TB_Articles> da = TB_Articles.GetList((string)c1Combo1.SelectedValue, comboBox1.Text);
            int x = 0;
            int y = 0;
            foreach (TB_Articles a in da)
            {
                Button b = new Button();
                b.Parent = this.panel1;
                b.Text = a.Libelle;
                b.TextAlign = ContentAlignment.BottomCenter;
                b.BackgroundImageLayout = ImageLayout.Zoom;
                b.BackColor = Color.White;
                b.Font = new Font("Microsoft Sans Serif", 16);
                if (a.Photo != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(a.Photo, 0, a.Photo.Length);
                    Image imgPhoto = Image.FromStream(ms);
                    b.BackgroundImage = imgPhoto;
                }
                b.Size = new Size(200, 100);
                b.Location = new Point(x, y);
                if (x < panel1.Width)
                    if (y < panel1.Height)
                        y += 100;
                    else
                    {
                        y = 0;
                        x += 200;
                    }
            }
            this.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            
        }
    }
}