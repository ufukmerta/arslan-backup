using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArslanBackup
{
    public partial class FormYedeklenecekler : Form
    {
        public FormYedeklenecekler()
        {
            InitializeComponent();
        }
        ArrayList konumlar = new ArrayList();
        void YedekListesi()
        {
            lv_YedeklenecekListesi.Items.Clear();
            string yedekDosyaKonumu = Path.Combine(Application.StartupPath, "yedekle.txt");
            if (File.Exists(yedekDosyaKonumu))
            {
                StreamReader Oku = new StreamReader(yedekDosyaKonumu, Encoding.UTF8);
                while (!Oku.EndOfStream)
                {
                    konumlar.Add(Oku.ReadLine());
                }
                Oku.Close();
            }
            else
            {
                MessageBox.Show("Yedeklenecekler dosyası oluşturulmamıştır. Bu formda yedeklenecekleri seçip kayıt ederek" +
                    " oluşturabilirsiniz", "Hata! Yedeklenecekler dosyası bulunamadı.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void Listele()
        {
            for (int i = 0; i < konumlar.Count; i++)
            {
                string konum = konumlar[i].ToString();
                ListViewItem item = new ListViewItem();
                item.Text = (i+1).ToString();
                try
                {
                    FileAttributes attr = File.GetAttributes(konum);
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        item.SubItems.Add("Klasör");
                    }
                    else
                    {
                        item.SubItems.Add("Dosya");
                    }
                }
                catch (Exception)
                {
                    item.SubItems.Add("Geçersiz/Bulunmayan Konum");
                }
                item.SubItems.Add(konum);
                lv_YedeklenecekListesi.Items.Add(item);
            }
            BoyutuAyarla();
            btn_DosyaEkle.Enabled = btn_KlasorEkle.Enabled = btn_Listele.Enabled = btn_Sil.Enabled = btn_Kaydet.Enabled = true;
            lbl_Bekleyiniz.Visible = false;
        }
        void BoyutuAyarla()
        {
            if (lv_YedeklenecekListesi.Items.Count > 17)
            {
                int boyut = Convert.ToInt32(lv_YedeklenecekListesi.Items.Count * 18.5);
                if (lv_YedeklenecekListesi.Height >= boyut)
                {
                    lv_YedeklenecekListesi.Columns[2].Width = this.Width - 200 - 65;
                }
                else
                {
                    lv_YedeklenecekListesi.Columns[2].Width = this.Width - 218 - 65;
                }
            }
            else
            {
                lv_YedeklenecekListesi.Columns[2].Width = this.Width - 200 - 65;
            }
            lbl_Bekleyiniz.Location = new Point(lbl_Bekleyiniz.Location.X, (this.Height / 2) - 15);
        }
        Thread thl;
        private void FormYedeklenecekler_Shown(object sender, EventArgs e)
        {
            lbl_Bekleyiniz.Visible = true;
            btn_DosyaEkle.Enabled = btn_KlasorEkle.Enabled = btn_Listele.Enabled = btn_Sil.Enabled = btn_Kaydet.Enabled = false;
            thl = new Thread(YedekListesi);
            thl.Start();
            while (thl.IsAlive)
            {
                Thread.Sleep(500);
                Application.DoEvents();
            }
            Listele();
        }
        private void FormYedeklenecekler_SizeChanged(object sender, EventArgs e)
        {
            BoyutuAyarla();
        }
        private void btn_Listele_Click(object sender, EventArgs e)
        {
            lbl_Bekleyiniz.Visible = true;
            btn_DosyaEkle.Enabled = btn_KlasorEkle.Enabled = btn_Listele.Enabled = btn_Sil.Enabled = btn_Kaydet.Enabled = false;
            sl_Bilgi.Text = "Yedeklemek istediğiniz verilerinizi dosya veya klasör olmasına göre ekleyiniz. Değişiklik yaptıktan sonra kaydediniz.";
            Thread thl = new Thread(YedekListesi);
            thl.Start();
            while (thl.IsAlive)
            {
                Thread.Sleep(500);
                Application.DoEvents();
            }
            Listele();
        }
        private void btn_KlasorEkle_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (lv_YedeklenecekListesi.Items.Count + 1).ToString();
                item.SubItems.Add("Klasör");
                item.SubItems.Add(folderBrowserDialog.SelectedPath);
                lv_YedeklenecekListesi.Items.Add(item);
            }
            BoyutuAyarla();
        }
        private void btn_DosyaEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem();
                item.Text = (lv_YedeklenecekListesi.Items.Count + 1).ToString();
                item.SubItems.Add("Dosya");
                item.SubItems.Add(fileDialog.FileName);
                lv_YedeklenecekListesi.Items.Add(item);
            }
            BoyutuAyarla();
        }
        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_YedeklenecekListesi.SelectedItems.Count > 0)
                {
                    lv_YedeklenecekListesi.SelectedItems[0].Remove();
                    sl_Bilgi.Text = "Seçilen öge Silindi.";
                    BoyutuAyarla();
                }
                else
                {
                    sl_Bilgi.Text = "Silme işlemi için önce listeden veri seçmelisiniz.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata! Silme İşlemi Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            sl_Bilgi.Text = "Liste kaydediliyor";
            string yedekDosyaKonumu = Path.Combine(Application.StartupPath, "yedekle.txt");
            using (StreamWriter sw = new StreamWriter(new FileStream(yedekDosyaKonumu, FileMode.Create), Encoding.UTF8))
            {
                foreach (ListViewItem item in lv_YedeklenecekListesi.Items)
                {
                    sw.WriteLine(item.SubItems[2].Text);

                }
            }
            sl_Bilgi.Text = "Kaydedildi.";
        }
    }
}
