namespace ArslanBackup
{
    partial class FormYedeklenecekler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormYedeklenecekler));
            this.lv_YedeklenecekListesi = new System.Windows.Forms.ListView();
            this.Sira = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Konum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Sil = new System.Windows.Forms.Button();
            this.btn_Listele = new System.Windows.Forms.Button();
            this.btn_Kaydet = new System.Windows.Forms.Button();
            this.btn_KlasorEkle = new System.Windows.Forms.Button();
            this.btn_DosyaEkle = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sl_Bilgi = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_Bekleyiniz = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_YedeklenecekListesi
            // 
            this.lv_YedeklenecekListesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_YedeklenecekListesi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lv_YedeklenecekListesi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sira,
            this.Tur,
            this.Konum});
            this.lv_YedeklenecekListesi.FullRowSelect = true;
            this.lv_YedeklenecekListesi.GridLines = true;
            this.lv_YedeklenecekListesi.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_YedeklenecekListesi.HideSelection = false;
            this.lv_YedeklenecekListesi.Location = new System.Drawing.Point(11, 123);
            this.lv_YedeklenecekListesi.MultiSelect = false;
            this.lv_YedeklenecekListesi.Name = "lv_YedeklenecekListesi";
            this.lv_YedeklenecekListesi.Size = new System.Drawing.Size(775, 317);
            this.lv_YedeklenecekListesi.TabIndex = 0;
            this.lv_YedeklenecekListesi.UseCompatibleStateImageBehavior = false;
            this.lv_YedeklenecekListesi.View = System.Windows.Forms.View.Details;
            // 
            // Sira
            // 
            this.Sira.Text = "Sıra";
            // 
            // Tur
            // 
            this.Tur.Text = "Tür";
            this.Tur.Width = 160;
            // 
            // Konum
            // 
            this.Konum.Text = "Konum";
            this.Konum.Width = 550;
            // 
            // btn_Sil
            // 
            this.btn_Sil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sil.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sil.Image")));
            this.btn_Sil.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sil.Location = new System.Drawing.Point(631, 64);
            this.btn_Sil.Name = "btn_Sil";
            this.btn_Sil.Size = new System.Drawing.Size(155, 45);
            this.btn_Sil.TabIndex = 5;
            this.btn_Sil.Text = "Seçileni Sil";
            this.btn_Sil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Sil.UseVisualStyleBackColor = true;
            this.btn_Sil.Click += new System.EventHandler(this.btn_Sil_Click);
            // 
            // btn_Listele
            // 
            this.btn_Listele.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Listele.Image = global::ArslanBackup.Properties.Resources.list;
            this.btn_Listele.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Listele.Location = new System.Drawing.Point(631, 12);
            this.btn_Listele.Name = "btn_Listele";
            this.btn_Listele.Size = new System.Drawing.Size(155, 45);
            this.btn_Listele.TabIndex = 4;
            this.btn_Listele.Text = "Listele";
            this.btn_Listele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Listele.UseVisualStyleBackColor = true;
            this.btn_Listele.Click += new System.EventHandler(this.btn_Listele_Click);
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Kaydet.Image = global::ArslanBackup.Properties.Resources.save;
            this.btn_Kaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Kaydet.Location = new System.Drawing.Point(10, 452);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(775, 50);
            this.btn_Kaydet.TabIndex = 3;
            this.btn_Kaydet.Text = "Kaydet";
            this.btn_Kaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Kaydet.UseVisualStyleBackColor = true;
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // btn_KlasorEkle
            // 
            this.btn_KlasorEkle.Image = global::ArslanBackup.Properties.Resources.folder_add;
            this.btn_KlasorEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_KlasorEkle.Location = new System.Drawing.Point(12, 64);
            this.btn_KlasorEkle.Name = "btn_KlasorEkle";
            this.btn_KlasorEkle.Size = new System.Drawing.Size(155, 45);
            this.btn_KlasorEkle.TabIndex = 2;
            this.btn_KlasorEkle.Text = "Klasör Ekle";
            this.btn_KlasorEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_KlasorEkle.UseVisualStyleBackColor = true;
            this.btn_KlasorEkle.Click += new System.EventHandler(this.btn_KlasorEkle_Click);
            // 
            // btn_DosyaEkle
            // 
            this.btn_DosyaEkle.Image = global::ArslanBackup.Properties.Resources.doc_add;
            this.btn_DosyaEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DosyaEkle.Location = new System.Drawing.Point(12, 12);
            this.btn_DosyaEkle.Name = "btn_DosyaEkle";
            this.btn_DosyaEkle.Size = new System.Drawing.Size(155, 45);
            this.btn_DosyaEkle.TabIndex = 1;
            this.btn_DosyaEkle.Text = "Dosya Ekle";
            this.btn_DosyaEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_DosyaEkle.UseVisualStyleBackColor = true;
            this.btn_DosyaEkle.Click += new System.EventHandler(this.btn_DosyaEkle_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl_Bilgi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(799, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sl_Bilgi
            // 
            this.sl_Bilgi.BackColor = System.Drawing.Color.LightSkyBlue;
            this.sl_Bilgi.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.sl_Bilgi.Name = "sl_Bilgi";
            this.sl_Bilgi.Size = new System.Drawing.Size(779, 17);
            this.sl_Bilgi.Spring = true;
            this.sl_Bilgi.Text = "Yedeklemek istediğiniz verilerinizi dosya veya klasör olmasına göre ekleyiniz. De" +
    "ğişiklik yaptıktan sonra kaydediniz.";
            this.sl_Bilgi.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_Bekleyiniz
            // 
            this.lbl_Bekleyiniz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Bekleyiniz.AutoSize = true;
            this.lbl_Bekleyiniz.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Bekleyiniz.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_Bekleyiniz.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_Bekleyiniz.Location = new System.Drawing.Point(12, 270);
            this.lbl_Bekleyiniz.Name = "lbl_Bekleyiniz";
            this.lbl_Bekleyiniz.Padding = new System.Windows.Forms.Padding(185, 0, 185, 0);
            this.lbl_Bekleyiniz.Size = new System.Drawing.Size(773, 55);
            this.lbl_Bekleyiniz.TabIndex = 7;
            this.lbl_Bekleyiniz.Text = "Lütfen Bekleyiniz";
            // 
            // FormYedeklenecekler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 531);
            this.Controls.Add(this.lbl_Bekleyiniz);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Sil);
            this.Controls.Add(this.btn_Listele);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_KlasorEkle);
            this.Controls.Add(this.btn_DosyaEkle);
            this.Controls.Add(this.lv_YedeklenecekListesi);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(815, 1080);
            this.MinimumSize = new System.Drawing.Size(815, 570);
            this.Name = "FormYedeklenecekler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yedeklenecek Listesi";
            this.Shown += new System.EventHandler(this.FormYedeklenecekler_Shown);
            this.SizeChanged += new System.EventHandler(this.FormYedeklenecekler_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_YedeklenecekListesi;
        private System.Windows.Forms.ColumnHeader Sira;
        private System.Windows.Forms.ColumnHeader Tur;
        private System.Windows.Forms.ColumnHeader Konum;
        private System.Windows.Forms.Button btn_DosyaEkle;
        private System.Windows.Forms.Button btn_KlasorEkle;
        private System.Windows.Forms.Button btn_Kaydet;
        private System.Windows.Forms.Button btn_Listele;
        private System.Windows.Forms.Button btn_Sil;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sl_Bilgi;
        private System.Windows.Forms.Label lbl_Bekleyiniz;
    }
}