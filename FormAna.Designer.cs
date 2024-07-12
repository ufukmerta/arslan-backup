namespace ArslanBackup
{
    partial class FormAna
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAna));
            this.timerYedekle = new System.Windows.Forms.Timer(this.components);
            this.timerYedeklemeKontrol = new System.Windows.Forms.Timer(this.components);
            this.rb_Saatlik = new System.Windows.Forms.RadioButton();
            this.rb_Gunluk = new System.Windows.Forms.RadioButton();
            this.rb_Haftalik = new System.Windows.Forms.RadioButton();
            this.cb_GunlukSaat = new System.Windows.Forms.ComboBox();
            this.cb_HaftalikGun = new System.Windows.Forms.ComboBox();
            this.cb_HaftalikSaat = new System.Windows.Forms.ComboBox();
            this.ss_Label = new System.Windows.Forms.StatusStrip();
            this.sl_Bilgi1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_YedeklenecekleriSec = new System.Windows.Forms.Button();
            this.btn_Kaydet = new System.Windows.Forms.Button();
            this.btn_ManuelYedekle = new System.Windows.Forms.Button();
            this.btn_OtomatikYedekle = new System.Windows.Forms.Button();
            this.btn_Ayarlar = new System.Windows.Forms.Button();
            this.btn_Bilgi = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ss_Progressbar = new System.Windows.Forms.StatusStrip();
            this.spb_Durum = new System.Windows.Forms.ToolStripProgressBar();
            this.timer_spb_Durum = new System.Windows.Forms.Timer(this.components);
            this.ss_Label.SuspendLayout();
            this.ss_Progressbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerYedekle
            // 
            this.timerYedekle.Interval = 15000;
            this.timerYedekle.Tick += new System.EventHandler(this.timerYedekle_Tick);
            // 
            // timerYedeklemeKontrol
            // 
            this.timerYedeklemeKontrol.Interval = 6000;
            this.timerYedeklemeKontrol.Tick += new System.EventHandler(this.timerYedeklemeKontrol_Tick);
            // 
            // rb_Saatlik
            // 
            this.rb_Saatlik.AutoSize = true;
            this.rb_Saatlik.Checked = true;
            this.rb_Saatlik.Location = new System.Drawing.Point(94, 57);
            this.rb_Saatlik.Name = "rb_Saatlik";
            this.rb_Saatlik.Size = new System.Drawing.Size(113, 17);
            this.rb_Saatlik.TabIndex = 2;
            this.rb_Saatlik.TabStop = true;
            this.rb_Saatlik.Text = "Saatte Bir Yedekle";
            this.rb_Saatlik.UseVisualStyleBackColor = true;
            this.rb_Saatlik.CheckedChanged += new System.EventHandler(this.rb_Saatlik_CheckedChanged);
            // 
            // rb_Gunluk
            // 
            this.rb_Gunluk.AutoSize = true;
            this.rb_Gunluk.Location = new System.Drawing.Point(94, 82);
            this.rb_Gunluk.Name = "rb_Gunluk";
            this.rb_Gunluk.Size = new System.Drawing.Size(114, 17);
            this.rb_Gunluk.TabIndex = 3;
            this.rb_Gunluk.Text = "Günde Bir Yedekle";
            this.rb_Gunluk.UseVisualStyleBackColor = true;
            this.rb_Gunluk.CheckedChanged += new System.EventHandler(this.rb_Gunluk_CheckedChanged);
            // 
            // rb_Haftalik
            // 
            this.rb_Haftalik.AutoSize = true;
            this.rb_Haftalik.Location = new System.Drawing.Point(94, 107);
            this.rb_Haftalik.Name = "rb_Haftalik";
            this.rb_Haftalik.Size = new System.Drawing.Size(120, 17);
            this.rb_Haftalik.TabIndex = 5;
            this.rb_Haftalik.Text = "Haftada Bir Yedekle";
            this.rb_Haftalik.UseVisualStyleBackColor = true;
            this.rb_Haftalik.CheckedChanged += new System.EventHandler(this.rb_Haftalik_CheckedChanged);
            // 
            // cb_GunlukSaat
            // 
            this.cb_GunlukSaat.Enabled = false;
            this.cb_GunlukSaat.FormattingEnabled = true;
            this.cb_GunlukSaat.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cb_GunlukSaat.Location = new System.Drawing.Point(224, 81);
            this.cb_GunlukSaat.Name = "cb_GunlukSaat";
            this.cb_GunlukSaat.Size = new System.Drawing.Size(168, 21);
            this.cb_GunlukSaat.TabIndex = 4;
            this.cb_GunlukSaat.Text = "Hangi saatte yedek alınacak?";
            // 
            // cb_HaftalikGun
            // 
            this.cb_HaftalikGun.Enabled = false;
            this.cb_HaftalikGun.FormattingEnabled = true;
            this.cb_HaftalikGun.Items.AddRange(new object[] {
            "Pazartesi",
            "Salı",
            "Çarşamba",
            "Perşembe",
            "Cuma",
            "Cumartesi",
            "Pazar"});
            this.cb_HaftalikGun.Location = new System.Drawing.Point(224, 106);
            this.cb_HaftalikGun.Name = "cb_HaftalikGun";
            this.cb_HaftalikGun.Size = new System.Drawing.Size(168, 21);
            this.cb_HaftalikGun.TabIndex = 6;
            this.cb_HaftalikGun.Text = "Hangi günde yedek alınacak?";
            // 
            // cb_HaftalikSaat
            // 
            this.cb_HaftalikSaat.Enabled = false;
            this.cb_HaftalikSaat.FormattingEnabled = true;
            this.cb_HaftalikSaat.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cb_HaftalikSaat.Location = new System.Drawing.Point(398, 106);
            this.cb_HaftalikSaat.Name = "cb_HaftalikSaat";
            this.cb_HaftalikSaat.Size = new System.Drawing.Size(168, 21);
            this.cb_HaftalikSaat.TabIndex = 7;
            this.cb_HaftalikSaat.Text = "Hangi saatte yedek alınacak?";
            // 
            // ss_Label
            // 
            this.ss_Label.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ss_Label.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl_Bilgi1});
            this.ss_Label.Location = new System.Drawing.Point(0, 259);
            this.ss_Label.Name = "ss_Label";
            this.ss_Label.Size = new System.Drawing.Size(634, 22);
            this.ss_Label.SizingGrip = false;
            this.ss_Label.TabIndex = 11;
            this.ss_Label.Text = "statusStrip1";
            // 
            // sl_Bilgi1
            // 
            this.sl_Bilgi1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.sl_Bilgi1.Name = "sl_Bilgi1";
            this.sl_Bilgi1.Size = new System.Drawing.Size(619, 17);
            this.sl_Bilgi1.Spring = true;
            this.sl_Bilgi1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_YedeklenecekleriSec
            // 
            this.btn_YedeklenecekleriSec.Image = global::ArslanBackup.Properties.Resources.clipboard_edit;
            this.btn_YedeklenecekleriSec.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_YedeklenecekleriSec.Location = new System.Drawing.Point(440, 12);
            this.btn_YedeklenecekleriSec.Name = "btn_YedeklenecekleriSec";
            this.btn_YedeklenecekleriSec.Size = new System.Drawing.Size(41, 41);
            this.btn_YedeklenecekleriSec.TabIndex = 13;
            this.btn_YedeklenecekleriSec.UseVisualStyleBackColor = true;
            this.btn_YedeklenecekleriSec.Click += new System.EventHandler(this.btn_YedeklenecekleriSec_Click);
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.AccessibleDescription = "";
            this.btn_Kaydet.AccessibleName = "";
            this.btn_Kaydet.Image = global::ArslanBackup.Properties.Resources.save;
            this.btn_Kaydet.Location = new System.Drawing.Point(487, 12);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(41, 41);
            this.btn_Kaydet.TabIndex = 8;
            this.btn_Kaydet.Tag = "";
            this.btn_Kaydet.UseVisualStyleBackColor = true;
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            this.btn_Kaydet.Enter += new System.EventHandler(this.btn_Kaydet_Enter);
            this.btn_Kaydet.MouseEnter += new System.EventHandler(this.btn_Kaydet_MouseEnter);
            // 
            // btn_ManuelYedekle
            // 
            this.btn_ManuelYedekle.Image = ((System.Drawing.Image)(resources.GetObject("btn_ManuelYedekle.Image")));
            this.btn_ManuelYedekle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ManuelYedekle.Location = new System.Drawing.Point(347, 139);
            this.btn_ManuelYedekle.Name = "btn_ManuelYedekle";
            this.btn_ManuelYedekle.Size = new System.Drawing.Size(275, 90);
            this.btn_ManuelYedekle.TabIndex = 0;
            this.btn_ManuelYedekle.Text = "Manuel Yedekle";
            this.btn_ManuelYedekle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ManuelYedekle.UseVisualStyleBackColor = true;
            this.btn_ManuelYedekle.Click += new System.EventHandler(this.btn_ManuelYedekle_Click);
            // 
            // btn_OtomatikYedekle
            // 
            this.btn_OtomatikYedekle.Image = ((System.Drawing.Image)(resources.GetObject("btn_OtomatikYedekle.Image")));
            this.btn_OtomatikYedekle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_OtomatikYedekle.Location = new System.Drawing.Point(12, 139);
            this.btn_OtomatikYedekle.Name = "btn_OtomatikYedekle";
            this.btn_OtomatikYedekle.Size = new System.Drawing.Size(275, 90);
            this.btn_OtomatikYedekle.TabIndex = 1;
            this.btn_OtomatikYedekle.Text = "Otomatik Yedeklemeyi Başlat";
            this.btn_OtomatikYedekle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_OtomatikYedekle.UseVisualStyleBackColor = true;
            this.btn_OtomatikYedekle.Click += new System.EventHandler(this.btn_OtomatikYedekle_Click);
            // 
            // btn_Ayarlar
            // 
            this.btn_Ayarlar.AccessibleDescription = "";
            this.btn_Ayarlar.AccessibleName = "";
            this.btn_Ayarlar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ayarlar.Image")));
            this.btn_Ayarlar.Location = new System.Drawing.Point(534, 12);
            this.btn_Ayarlar.Name = "btn_Ayarlar";
            this.btn_Ayarlar.Size = new System.Drawing.Size(41, 41);
            this.btn_Ayarlar.TabIndex = 9;
            this.btn_Ayarlar.Tag = "";
            this.btn_Ayarlar.UseVisualStyleBackColor = true;
            this.btn_Ayarlar.Click += new System.EventHandler(this.btn_Ayarlar_Click);
            // 
            // btn_Bilgi
            // 
            this.btn_Bilgi.Image = ((System.Drawing.Image)(resources.GetObject("btn_Bilgi.Image")));
            this.btn_Bilgi.Location = new System.Drawing.Point(581, 12);
            this.btn_Bilgi.Name = "btn_Bilgi";
            this.btn_Bilgi.Size = new System.Drawing.Size(41, 41);
            this.btn_Bilgi.TabIndex = 10;
            this.btn_Bilgi.UseVisualStyleBackColor = true;
            this.btn_Bilgi.Click += new System.EventHandler(this.btn_Bilgi_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Yedekleme Ayarlarını Kaydet";
            // 
            // ss_Progressbar
            // 
            this.ss_Progressbar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ss_Progressbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spb_Durum});
            this.ss_Progressbar.Location = new System.Drawing.Point(0, 237);
            this.ss_Progressbar.Name = "ss_Progressbar";
            this.ss_Progressbar.Size = new System.Drawing.Size(634, 22);
            this.ss_Progressbar.SizingGrip = false;
            this.ss_Progressbar.TabIndex = 15;
            this.ss_Progressbar.Text = "statusStrip2";
            this.ss_Progressbar.Visible = false;
            // 
            // spb_Durum
            // 
            this.spb_Durum.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.spb_Durum.Name = "spb_Durum";
            this.spb_Durum.Size = new System.Drawing.Size(615, 16);
            // 
            // timer_spb_Durum
            // 
            this.timer_spb_Durum.Interval = 6000;
            this.timer_spb_Durum.Tick += new System.EventHandler(this.timer_spb_Durum_Tick);
            // 
            // FormAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 281);
            this.Controls.Add(this.ss_Progressbar);
            this.Controls.Add(this.btn_YedeklenecekleriSec);
            this.Controls.Add(this.ss_Label);
            this.Controls.Add(this.btn_Kaydet);
            this.Controls.Add(this.btn_ManuelYedekle);
            this.Controls.Add(this.btn_OtomatikYedekle);
            this.Controls.Add(this.cb_HaftalikSaat);
            this.Controls.Add(this.cb_HaftalikGun);
            this.Controls.Add(this.cb_GunlukSaat);
            this.Controls.Add(this.rb_Haftalik);
            this.Controls.Add(this.rb_Gunluk);
            this.Controls.Add(this.rb_Saatlik);
            this.Controls.Add(this.btn_Ayarlar);
            this.Controls.Add(this.btn_Bilgi);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 320);
            this.MinimumSize = new System.Drawing.Size(650, 320);
            this.Name = "FormAna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arslan Backup";
            this.Shown += new System.EventHandler(this.FormAna_Shown);
            this.ss_Label.ResumeLayout(false);
            this.ss_Label.PerformLayout();
            this.ss_Progressbar.ResumeLayout(false);
            this.ss_Progressbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Bilgi;
        private System.Windows.Forms.Button btn_Ayarlar;
        private System.Windows.Forms.Timer timerYedekle;
        private System.Windows.Forms.Timer timerYedeklemeKontrol;
        private System.Windows.Forms.RadioButton rb_Saatlik;
        private System.Windows.Forms.RadioButton rb_Gunluk;
        private System.Windows.Forms.RadioButton rb_Haftalik;
        private System.Windows.Forms.ComboBox cb_GunlukSaat;
        private System.Windows.Forms.ComboBox cb_HaftalikGun;
        private System.Windows.Forms.ComboBox cb_HaftalikSaat;
        private System.Windows.Forms.Button btn_OtomatikYedekle;
        private System.Windows.Forms.Button btn_ManuelYedekle;
        private System.Windows.Forms.Button btn_Kaydet;
        private System.Windows.Forms.StatusStrip ss_Label;
        private System.Windows.Forms.ToolStripStatusLabel sl_Bilgi1;
        private System.Windows.Forms.Button btn_YedeklenecekleriSec;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip ss_Progressbar;
        private System.Windows.Forms.ToolStripProgressBar spb_Durum;
        private System.Windows.Forms.Timer timer_spb_Durum;
    }
}

