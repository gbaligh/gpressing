namespace GP
{
    partial class frmFactureAjouterArticle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboOperation = new System.Windows.Forms.ComboBox();
            this.textPrix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textQ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboLibelle = new System.Windows.Forms.ComboBox();
            this.comboCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboFamille = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboOperation);
            this.panel1.Controls.Add(this.textPrix);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textQ);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboLibelle);
            this.panel1.Controls.Add(this.comboCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboFamille);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 120);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Prix";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Operation";
            // 
            // comboOperation
            // 
            this.comboOperation.FormattingEnabled = true;
            this.comboOperation.Items.AddRange(new object[] {
            "Pressing",
            "Repassage",
            "Tenture",
            "Autre"});
            this.comboOperation.Location = new System.Drawing.Point(101, 30);
            this.comboOperation.Name = "comboOperation";
            this.comboOperation.Size = new System.Drawing.Size(121, 21);
            this.comboOperation.TabIndex = 10;
            this.comboOperation.SelectedIndexChanged += new System.EventHandler(this.comboOperation_SelectedIndexChanged);
            // 
            // textPrix
            // 
            this.textPrix.Location = new System.Drawing.Point(461, 90);
            this.textPrix.Name = "textPrix";
            this.textPrix.Size = new System.Drawing.Size(100, 20);
            this.textPrix.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantite";
            // 
            // textQ
            // 
            this.textQ.Location = new System.Drawing.Point(355, 90);
            this.textQ.Name = "textQ";
            this.textQ.Size = new System.Drawing.Size(100, 20);
            this.textQ.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Article";
            // 
            // comboLibelle
            // 
            this.comboLibelle.FormattingEnabled = true;
            this.comboLibelle.Location = new System.Drawing.Point(228, 89);
            this.comboLibelle.Name = "comboLibelle";
            this.comboLibelle.Size = new System.Drawing.Size(121, 21);
            this.comboLibelle.TabIndex = 5;
            // 
            // comboCode
            // 
            this.comboCode.FormattingEnabled = true;
            this.comboCode.Location = new System.Drawing.Point(101, 89);
            this.comboCode.Name = "comboCode";
            this.comboCode.Size = new System.Drawing.Size(121, 21);
            this.comboCode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Famille";
            // 
            // comboFamille
            // 
            this.comboFamille.FormattingEnabled = true;
            this.comboFamille.Location = new System.Drawing.Point(101, 3);
            this.comboFamille.Name = "comboFamille";
            this.comboFamille.Size = new System.Drawing.Size(121, 21);
            this.comboFamille.TabIndex = 2;
            this.comboFamille.SelectedIndexChanged += new System.EventHandler(this.comboFamille_SelectedIndexChanged);
            this.comboFamille.TextChanged += new System.EventHandler(this.comboFamille_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code Artice";
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouter.Image = global::GP.Properties.Resources.button_ok;
            this.buttonAjouter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAjouter.Location = new System.Drawing.Point(525, 214);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(87, 35);
            this.buttonAjouter.TabIndex = 89;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnuler.Image = global::GP.Properties.Resources.button_cancel;
            this.buttonAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAnnuler.Location = new System.Drawing.Point(432, 214);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(87, 35);
            this.buttonAnnuler.TabIndex = 90;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 31);
            this.label7.TabIndex = 91;
            this.label7.Text = "Nouveau Article";
            // 
            // frmFactureAjouterArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.panel1);
            this.Name = "frmFactureAjouterArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmFactureAjouterArticle";
            this.Load += new System.EventHandler(this.frmFactureAjouterArticle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textQ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboLibelle;
        private System.Windows.Forms.ComboBox comboCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboFamille;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboOperation;
        private System.Windows.Forms.TextBox textPrix;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Label label7;

    }
}