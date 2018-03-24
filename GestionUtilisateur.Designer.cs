namespace GP
{
    partial class GestionUtilisateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionUtilisateur));
            this.label1 = new System.Windows.Forms.Label();
            this.Recherche = new System.Windows.Forms.Button();
            this.Quiter = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.Button();
            this.Modifier = new System.Windows.Forms.Button();
            this.Supprimer = new System.Windows.Forms.Button();
            this.Ajouter = new System.Windows.Forms.Button();
            this.c1TrueDBGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "GESTION DES UTILISATEURS";
            // 
            // Recherche
            // 
            this.Recherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Recherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Recherche.Image = global::GP.Properties.Resources.greyscale_22;
            this.Recherche.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Recherche.Location = new System.Drawing.Point(580, 256);
            this.Recherche.Name = "Recherche";
            this.Recherche.Size = new System.Drawing.Size(113, 47);
            this.Recherche.TabIndex = 16;
            this.Recherche.Text = "Recherche";
            this.Recherche.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Recherche.UseVisualStyleBackColor = true;
            this.Recherche.Click += new System.EventHandler(this.Recherche_Click);
            // 
            // Quiter
            // 
            this.Quiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Quiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quiter.Image = global::GP.Properties.Resources.greyscale_12;
            this.Quiter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Quiter.Location = new System.Drawing.Point(580, 309);
            this.Quiter.Name = "Quiter";
            this.Quiter.Size = new System.Drawing.Size(113, 47);
            this.Quiter.TabIndex = 15;
            this.Quiter.Text = "Quiter";
            this.Quiter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Quiter.UseVisualStyleBackColor = true;
            this.Quiter.Click += new System.EventHandler(this.Quiter_Click);
            // 
            // List
            // 
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.List.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.List.Image = global::GP.Properties.Resources.greyscale_26;
            this.List.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.List.Location = new System.Drawing.Point(580, 203);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(113, 47);
            this.List.TabIndex = 14;
            this.List.Text = "Imprimer List";
            this.List.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.List.UseVisualStyleBackColor = true;
            this.List.Click += new System.EventHandler(this.List_Click);
            // 
            // Modifier
            // 
            this.Modifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Modifier.Image = global::GP.Properties.Resources.greyscale_18;
            this.Modifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Modifier.Location = new System.Drawing.Point(580, 150);
            this.Modifier.Name = "Modifier";
            this.Modifier.Size = new System.Drawing.Size(113, 47);
            this.Modifier.TabIndex = 13;
            this.Modifier.Text = "Modifier";
            this.Modifier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Modifier.UseVisualStyleBackColor = true;
            this.Modifier.Click += new System.EventHandler(this.Modifier_Click);
            // 
            // Supprimer
            // 
            this.Supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Supprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Supprimer.Image = global::GP.Properties.Resources.greyscale_11;
            this.Supprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Supprimer.Location = new System.Drawing.Point(580, 97);
            this.Supprimer.Name = "Supprimer";
            this.Supprimer.Size = new System.Drawing.Size(113, 47);
            this.Supprimer.TabIndex = 12;
            this.Supprimer.Text = "Supprimer";
            this.Supprimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Supprimer.UseVisualStyleBackColor = true;
            this.Supprimer.Click += new System.EventHandler(this.Supprimer_Click);
            // 
            // Ajouter
            // 
            this.Ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ajouter.Image = global::GP.Properties.Resources.greyscale_10;
            this.Ajouter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ajouter.Location = new System.Drawing.Point(580, 44);
            this.Ajouter.Name = "Ajouter";
            this.Ajouter.Size = new System.Drawing.Size(113, 47);
            this.Ajouter.TabIndex = 11;
            this.Ajouter.Text = "Ajouter";
            this.Ajouter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Ajouter.UseVisualStyleBackColor = true;
            this.Ajouter.Click += new System.EventHandler(this.Ajouter_Click);
            // 
            // c1TrueDBGrid1
            // 
            this.c1TrueDBGrid1.AllowArrows = false;
            this.c1TrueDBGrid1.AllowColMove = false;
            this.c1TrueDBGrid1.AllowColSelect = false;
            this.c1TrueDBGrid1.AllowUpdate = false;
            this.c1TrueDBGrid1.AlternatingRows = true;
            this.c1TrueDBGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c1TrueDBGrid1.CaptionHeight = 20;
            this.c1TrueDBGrid1.FetchRowStyles = true;
            this.c1TrueDBGrid1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat;
            this.c1TrueDBGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid1.Images"))));
            this.c1TrueDBGrid1.Location = new System.Drawing.Point(12, 44);
            this.c1TrueDBGrid1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.c1TrueDBGrid1.RecordSelectorWidth = 17;
            this.c1TrueDBGrid1.RowDivider.Color = System.Drawing.Color.DarkGray;
            this.c1TrueDBGrid1.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
            this.c1TrueDBGrid1.RowHeight = 21;
            this.c1TrueDBGrid1.RowSubDividerColor = System.Drawing.Color.Gainsboro;
            this.c1TrueDBGrid1.Size = new System.Drawing.Size(562, 439);
            this.c1TrueDBGrid1.TabIndex = 1;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.DoubleClick += new System.EventHandler(this.c1TrueDBGrid1_DoubleClick);
            this.c1TrueDBGrid1.PropBag = resources.GetString("c1TrueDBGrid1.PropBag");
            // 
            // GestionUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(705, 495);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Recherche);
            this.Controls.Add(this.Quiter);
            this.Controls.Add(this.List);
            this.Controls.Add(this.Modifier);
            this.Controls.Add(this.Supprimer);
            this.Controls.Add(this.Ajouter);
            this.Controls.Add(this.c1TrueDBGrid1);
            this.Name = "GestionUtilisateur";
            this.ShowInTaskbar = false;
            this.Text = "GestionUtilisateur";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GestionUtilisateur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid1;
        private System.Windows.Forms.Button Recherche;
        private System.Windows.Forms.Button Quiter;
        private System.Windows.Forms.Button List;
        private System.Windows.Forms.Button Modifier;
        private System.Windows.Forms.Button Supprimer;
        private System.Windows.Forms.Button Ajouter;
        private System.Windows.Forms.Label label1;
    }
}