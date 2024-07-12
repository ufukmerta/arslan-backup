namespace ArslanBackup
{
    partial class FormAyarlar
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tx_KlasorKonumu = new System.Windows.Forms.TextBox();
            this.btn_KonumSec = new System.Windows.Forms.Button();
            this.panel_Btn = new System.Windows.Forms.Panel();
            this.btn_Kaydet = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sl_Bilgi = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_Btn.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tx_KlasorKonumu
            // 
            this.tx_KlasorKonumu.Location = new System.Drawing.Point(51, 62);
            this.tx_KlasorKonumu.Name = "tx_KlasorKonumu";
            this.tx_KlasorKonumu.Size = new System.Drawing.Size(284, 20);
            this.tx_KlasorKonumu.TabIndex = 0;
            // 
            // btn_KonumSec
            // 
            this.btn_KonumSec.Location = new System.Drawing.Point(341, 60);
            this.btn_KonumSec.Name = "btn_KonumSec";
            this.btn_KonumSec.Size = new System.Drawing.Size(38, 22);
            this.btn_KonumSec.TabIndex = 1;
            this.btn_KonumSec.Text = "...";
            this.btn_KonumSec.UseVisualStyleBackColor = true;
            this.btn_KonumSec.Click += new System.EventHandler(this.btn_KonumSec_Click);
            // 
            // panel_Btn
            // 
            this.panel_Btn.Controls.Add(this.btn_Kaydet);
            this.panel_Btn.Location = new System.Drawing.Point(51, 88);
            this.panel_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Btn.Name = "panel_Btn";
            this.panel_Btn.Padding = new System.Windows.Forms.Padding(45, 10, 45, 10);
            this.panel_Btn.Size = new System.Drawing.Size(328, 91);
            this.panel_Btn.TabIndex = 3;
            // 
            // btn_Kaydet
            // 
            this.btn_Kaydet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Kaydet.Image = global::ArslanBackup.Properties.Resources.save;
            this.btn_Kaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Kaydet.Location = new System.Drawing.Point(45, 10);
            this.btn_Kaydet.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Kaydet.Name = "btn_Kaydet";
            this.btn_Kaydet.Size = new System.Drawing.Size(238, 71);
            this.btn_Kaydet.TabIndex = 3;
            this.btn_Kaydet.Text = "Kaydet";
            this.btn_Kaydet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Kaydet.UseVisualStyleBackColor = true;
            this.btn_Kaydet.Click += new System.EventHandler(this.btn_Kaydet_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl_Bilgi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 204);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(439, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sl_Bilgi
            // 
            this.sl_Bilgi.Name = "sl_Bilgi";
            this.sl_Bilgi.Size = new System.Drawing.Size(424, 17);
            this.sl_Bilgi.Spring = true;
            this.sl_Bilgi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 226);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel_Btn);
            this.Controls.Add(this.btn_KonumSec);
            this.Controls.Add(this.tx_KlasorKonumu);
            this.Name = "FormAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yedekleme Konumu Ayarlama Ekranı";
            this.Load += new System.EventHandler(this.FormAyarlar_Load);
            this.panel_Btn.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tx_KlasorKonumu;
        private System.Windows.Forms.Button btn_KonumSec;
        private System.Windows.Forms.Panel panel_Btn;
        public System.Windows.Forms.Button btn_Kaydet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sl_Bilgi;
    }
}