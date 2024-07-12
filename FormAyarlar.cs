using System;
using System.IO;
using System.Windows.Forms;

namespace ArslanBackup
{
    public partial class FormAyarlar : Form
    {
        public FormAyarlar()
        {
            InitializeComponent();
        }       
        void ayarOku()
        {
            string dosyaKonumu = Path.Combine(Application.StartupPath, "ayar.txt");
            if (File.Exists(dosyaKonumu))
            {
                FileStream fs = new FileStream(dosyaKonumu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                tx_KlasorKonumu.Text = sw.ReadLine();
                sw.Close();
                fs.Close();
            }
        }       
        void ayarYaz(string deger)
        {
            string dosyaKonumu = Path.Combine(Application.StartupPath, "ayar.txt");
            FileStream fs = new FileStream(dosyaKonumu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(deger);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            ayarOku();
            sl_Bilgi.Text = "Yedekleme konumu ayarlamak için 3 noktalı butondan konum seçebilirsiniz.";
        }

        private void btn_KonumSec_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tx_KlasorKonumu.Text = folderBrowserDialog1.SelectedPath;
                tx_KlasorKonumu.Focus();
                sl_Bilgi.Text = "Yedekleme konumu seçildi. Konumun yedekleme konumu olması için kaydedin.";
            }
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            tx_KlasorKonumu.Text = tx_KlasorKonumu.Text.Trim();
            if (Directory.Exists(tx_KlasorKonumu.Text) && Path.IsPathRooted(tx_KlasorKonumu.Text))
            {
                ayarYaz(tx_KlasorKonumu.Text);
                sl_Bilgi.Text = "Yedekleme konumu kaydedildi.";
            }
            else
            {
                sl_Bilgi.Text = "Yedekleme konumu kaydedilemedi. Uygun konum seçiniz.";
                MessageBox.Show("Yedekleme konumunun bulunan bir konum ve kök dizini olması gerekmektedir.", "Hata! Geçersiz/bulunmayan konum girdiniz.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
