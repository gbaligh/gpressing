namespace GP
{
    partial class InfoClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox2 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox3 = new C1.Win.C1Input.C1TextBox();
            this.c1TextBox4 = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c1TextBox5 = new C1.Win.C1Input.C1TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Image = global::GP.Properties.Resources.greyscale_20;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(354, 207);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 47);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "Sauvegarder";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Image = global::GP.Properties.Resources.greyscale_9;
            this.btnAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnuler.Location = new System.Drawing.Point(235, 207);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(113, 47);
            this.btnAnnuler.TabIndex = 22;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.Enabled = false;
            this.c1TextBox1.Location = new System.Drawing.Point(105, 12);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.Size = new System.Drawing.Size(205, 20);
            this.c1TextBox1.TabIndex = 24;
            this.c1TextBox1.Tag = null;
            this.c1TextBox1.TextChanged += new System.EventHandler(this.c1TextBox1_TextChanged);
            // 
            // c1TextBox2
            // 
            this.c1TextBox2.Location = new System.Drawing.Point(105, 38);
            this.c1TextBox2.Name = "c1TextBox2";
            this.c1TextBox2.Size = new System.Drawing.Size(205, 20);
            this.c1TextBox2.TabIndex = 25;
            this.c1TextBox2.Tag = null;
            this.c1TextBox2.Leave += new System.EventHandler(this.c1TextBox2_Leave);
            this.c1TextBox2.Enter += new System.EventHandler(this.c1TextBox2_Enter);
            this.c1TextBox2.TextChanged += new System.EventHandler(this.c1TextBox1_TextChanged);
            // 
            // c1TextBox3
            // 
            this.c1TextBox3.Location = new System.Drawing.Point(105, 64);
            this.c1TextBox3.Name = "c1TextBox3";
            this.c1TextBox3.Size = new System.Drawing.Size(205, 20);
            this.c1TextBox3.TabIndex = 26;
            this.c1TextBox3.Tag = null;
            this.c1TextBox3.Leave += new System.EventHandler(this.c1TextBox2_Leave);
            this.c1TextBox3.Enter += new System.EventHandler(this.c1TextBox2_Enter);
            this.c1TextBox3.TextChanged += new System.EventHandler(this.c1TextBox1_TextChanged);
            // 
            // c1TextBox4
            // 
            this.c1TextBox4.Location = new System.Drawing.Point(105, 116);
            this.c1TextBox4.Multiline = true;
            this.c1TextBox4.Name = "c1TextBox4";
            this.c1TextBox4.Size = new System.Drawing.Size(316, 76);
            this.c1TextBox4.TabIndex = 27;
            this.c1TextBox4.Tag = null;
            this.c1TextBox4.Leave += new System.EventHandler(this.c1TextBox2_Leave);
            this.c1TextBox4.Enter += new System.EventHandler(this.c1TextBox2_Enter);
            this.c1TextBox4.TextChanged += new System.EventHandler(this.c1TextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Code";
            // 
            // c1TextBox5
            // 
            this.c1TextBox5.Location = new System.Drawing.Point(105, 90);
            this.c1TextBox5.Name = "c1TextBox5";
            this.c1TextBox5.Size = new System.Drawing.Size(205, 20);
            this.c1TextBox5.TabIndex = 29;
            this.c1TextBox5.Tag = null;
            this.c1TextBox5.Leave += new System.EventHandler(this.c1TextBox2_Leave);
            this.c1TextBox5.Enter += new System.EventHandler(this.c1TextBox2_Enter);
            this.c1TextBox5.TextChanged += new System.EventHandler(this.c1TextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Prenom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Telephone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Adresse";
            // 
            // InfoClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(479, 266);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c1TextBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c1TextBox4);
            this.Controls.Add(this.c1TextBox3);
            this.Controls.Add(this.c1TextBox2);
            this.Controls.Add(this.c1TextBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnnuler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InfoClient";
            this.ShowInTaskbar = false;
            this.Text = "InfoClient";
            this.Load += new System.EventHandler(this.InfoClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnuler;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private C1.Win.C1Input.C1TextBox c1TextBox2;
        private C1.Win.C1Input.C1TextBox c1TextBox3;
        private C1.Win.C1Input.C1TextBox c1TextBox4;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox c1TextBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}