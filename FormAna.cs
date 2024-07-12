using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArslanBackup
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }
        string saatlikSaat, gunlukGun, gunlukSaat, haftalikGun, haftalikSaat, haftalikHafta;
        string yedeklemeKonumu = "", yedeklemeTuruBilgisi = "";
        int hataSayac = 0;
        bool kontrol;
        DateTime haftalikTarih;
        void yedeklemeKonumuGetir()
        {
            string dosyaKonumu = Path.Combine(Application.StartupPath, "ayar.txt");
            if (File.Exists(dosyaKonumu))
            {
                FileStream fs = new FileStream(dosyaKonumu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                yedeklemeKonumu = sw.ReadLine();
                if (Directory.Exists(yedeklemeKonumu)) { }
                else if (Path.IsPathRooted(yedeklemeKonumu)) { }
                else
                {
                    yedeklemeKonumu = null;
                    MessageBox.Show("Yedekleme klasörü tanımı yanlış.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sw.Close();
                    fs.Close();
                    yedeklemeAyarlarınıAc();
                }
                sw.Close();
                fs.Close();
            }
            else
            {
                DialogResult yedekKonumuUyarisi = MessageBox.Show("Yedekleme yapılacak konum bulunamadı. Yedekleme konumu seçmek istiyor musunuz?", "Yedekleme Konumu Seçilmemiş", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (yedekKonumuUyarisi == DialogResult.Yes)
                {
                    yedeklemeAyarlarınıAc();
                }
                else
                {
                    if (btn_OtomatikYedekle.Text == "Otomatik Yedeklemeyi Durdur")
                    {
                        MessageBox.Show("Yedekleme yapılacak konum bulunamadı. Otomatik yedekleme durduruldu.", "Yedekleme Konumu Seçilmemiş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btn_OtomatikYedekle_Click(null, new EventArgs());
                    }
                }
            }
        }
        int tumIslemleriListele()
        {
            int i = 0;
            string yedekDosyaKonumu = Path.Combine(Application.StartupPath, "yedekle.txt");
            StreamReader Oku = new StreamReader(yedekDosyaKonumu, Encoding.UTF8);
            while (Oku.ReadLine() != null)
            {
                i += 1;
            }
            Oku.Close();
            return i;
        }
        void sl_Bilgi1Guncelle(string metin)
        {
            sl_Bilgi1.Text = metin;
            Application.DoEvents();
        }
        void spb_DurumGuncelle(int deger)
        {
            spb_Durum.Value = deger;
            Application.DoEvents();
        }
        void raporYaz(string yazi)
        {
            string raporKonumu = Path.Combine(Application.StartupPath, "rapor.txt");
            using (StreamWriter sw = File.AppendText(raporKonumu))
            {
                sw.WriteLine(yazi);
            }
        }
        string klasorDosyaAdiGetir(string metin)
        {
            metin = metin.Replace("\\", @"\");
            string cikti = metin.Substring(metin.LastIndexOf(@"\") + 1);
            if (cikti == "")
            {
                cikti = metin.Substring(0, metin.Length - 1);
                cikti = cikti.Substring(cikti.LastIndexOf(@"\") + 1);
            }
            return cikti;
        }
        void klasorYedekle(string metin)
        {
            string klasorAdi = klasorDosyaAdiGetir(metin);
            string klasorKonumu = metin.Substring(0, metin.LastIndexOf(klasorAdi)).Replace(":", "");
            string saat = DateTime.Now.ToString("HH-mm-ss");
            try { Directory.CreateDirectory(Path.Combine(yedeklemeKonumu, klasorKonumu)); } catch (Exception) { }
            string zipKlasorAdi = Path.Combine(yedeklemeKonumu, klasorKonumu) + klasorAdi + "__" + DateTime.Now.ToString("d") + "__" + saat + ".zip";
            try
            {
                ZipFile.CreateFromDirectory(metin, zipKlasorAdi, CompressionLevel.Fastest, true);
                raporYaz(zipKlasorAdi + "; Oluşturma Başarılı");
            }
            catch (Exception e)
            {
                raporYaz("");
                raporYaz(e.Message);
                hataSayac += 1;
            }

        }
        void dosyaYedekle(string metin)
        {
            string dosyaAdi = klasorDosyaAdiGetir(metin);
            if (metin.Substring(metin.Length - 1) == @"\")
                metin = metin.Substring(0, metin.Length - 1);
            string dosyaKonumu = metin.Substring(0, metin.LastIndexOf(dosyaAdi)).Replace(":", "");
            string saat = DateTime.Now.ToString("HH-mm-ss");
            try { Directory.CreateDirectory(Path.Combine(yedeklemeKonumu, dosyaKonumu)); } catch (Exception) { }
            string zipKlasorAdi = Path.Combine(yedeklemeKonumu, dosyaKonumu) + dosyaAdi + "__" + DateTime.Now.ToString("d") + "__" + saat + ".zip";
            try
            {
                using (ZipArchive newFile = ZipFile.Open(zipKlasorAdi, ZipArchiveMode.Create))
                {
                    newFile.CreateEntryFromFile(metin, dosyaAdi, CompressionLevel.Fastest);
                }
                raporYaz(zipKlasorAdi + "; Oluşturma Başarılı");
            }
            catch (Exception e)
            {
                raporYaz("");
                raporYaz(e.Message);
                hataSayac += 1;
            }
        }
        void yedekle()
        {
            hataSayac = 0;
            sl_Bilgi1Guncelle("Yedekleme işlemi başlıyor.");
            raporYaz("Yedekleme Başlangıç Zamanı: " + DateTime.Now + " Yedekleme Türü: " + yedeklemeTuruBilgisi);
            raporYaz("");
            string yedekDosyaKonumu = Path.Combine(Application.StartupPath, "yedekle.txt");
            StreamReader Oku;
            try
            {
                sl_Bilgi1Guncelle("Yedekleme yapılıyor.");
                int islem = tumIslemleriListele();
                int sayac = 0;
                spb_Durum.Minimum = 0;
                spb_Durum.Maximum = islem;
                ss_Progressbar.Visible = true;
                Oku = new StreamReader(yedekDosyaKonumu, Encoding.UTF8);
                while (!Oku.EndOfStream)
                {
                    sayac = sayac + 1;
                    spb_DurumGuncelle(sayac);
                    Application.DoEvents();
                    sl_Bilgi1Guncelle("Yedekleme yapılıyor. Lütfen bekleyin. İşlem durumu: " + sayac + "/" + islem);
                    string metin = Oku.ReadLine();
                    if (metin == "")
                    {
                        continue;
                    }
                    try
                    {
                        FileAttributes attr = File.GetAttributes(metin);
                        yedeklemeKonumuGetir();
                        if (!string.IsNullOrWhiteSpace(yedeklemeKonumu))
                        {
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                klasorYedekle(metin);
                            }
                            else
                            {
                                dosyaYedekle(metin);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        hataSayac += 1;
                        string hata = e.Message;
                        raporYaz(hata);
                    }
                }
                Oku.Close();
            }
            catch (FileNotFoundException e)
            {
                sl_Bilgi1Guncelle("Yedekleme yapılamadı. Yedeklenecekler dosyası bulunamadı.");
                hataSayac += 1;
                raporYaz(e.Message);
                if (btn_OtomatikYedekle.Text != "Otomatik Yedeklemeyi Başlat")
                {
                    DialogResult dialog = MessageBox.Show(e.Message + "\nYedekleme işlemini durdurmak istiyor musunuz? Eğer iptal edilmezse sonraki yedekleme " +
                        "zamanına kadar yedek alınamayacak. Daha erken yedek alınması için otomatik yedeklemeyi iptal edip yedeklenecekler dosyasını(yedekle metin dosyası) oluşturup yedeklemeyi tekrar kurmanız gerekir.", "Hata! Yedeklenecekler Dosyası Bulunamadı", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialog == DialogResult.Yes)
                    {
                        btn_OtomatikYedekle_Click(null, new EventArgs());
                    }
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Yedekleme Yapılamıyor.\n" + e.Message, "Hata! Yedeklenecekler Dosyası Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            raporYaz("");
            raporYaz("Toplam Oluşan Hata Sayısı: " + hataSayac);
            raporYaz("");
            raporYaz("");
            sl_Bilgi1Guncelle("Yedekleme işlemi bitti.");
            if (btn_OtomatikYedekle.Text == "Otomatik Yedeklemeyi Durdur")
                sl_Bilgi1Guncelle(sl_Bilgi1.Text + " Kontrol işlemine geçiliyor.");
            sl_Bilgi1Guncelle(sl_Bilgi1.Text + " Yedekleme sırasında oluşan hatalar: " + hataSayac);
            if (hataSayac > 0)
                sl_Bilgi1Guncelle(sl_Bilgi1.Text + " . Raporu kontrol ediniz.");
            timer_spb_Durum.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        void yedeklemeAyarlarınıAc()
        {
            FormAyarlar formAyar = new FormAyarlar();
            formAyar.ShowDialog();
            yedeklemeKonumuGetir();
        }
        private void rb_Haftalik_CheckedChanged(object sender, EventArgs e)
        {
            cb_GunlukSaat.Enabled = false;
            cb_HaftalikGun.Enabled = true;
            cb_HaftalikSaat.Enabled = true;
        }
        private void rb_Gunluk_CheckedChanged(object sender, EventArgs e)
        {
            cb_GunlukSaat.Enabled = true;
            cb_HaftalikGun.Enabled = false;
            cb_HaftalikSaat.Enabled = false;
        }
        private void rb_Saatlik_CheckedChanged(object sender, EventArgs e)
        {
            cb_GunlukSaat.Enabled = false;
            cb_HaftalikGun.Enabled = false;
            cb_HaftalikSaat.Enabled = false;
        }
        private void timerYedekle_Tick(object sender, EventArgs e)
        {
            if (rb_Saatlik.Checked)
            {
                if (saatlikSaat == DateTime.Now.Hour.ToString())
                {
                    timerYedekle.Enabled = false;
                    Cursor.Current = Cursors.WaitCursor;
                    yedekle();
                    saatlikSaat = (DateTime.Now.AddHours(1)).Hour.ToString();
                    timerYedeklemeKontrol.Enabled = true;
                }
            }
            else if (rb_Gunluk.Checked)
            {
                if (Convert.ToInt32(gunlukSaat) < DateTime.Now.Hour && gunlukGun == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString())
                {
                    MessageBox.Show("Yedekleme için girdiğiniz saat sistem tarihinden önce bu nedenle sonraki günden yedeklemeye başlanacak.", "Girilen Tarih Sistem Tarihinden Önce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gunlukGun = ((int)(DateTime.Now.AddDays(1).DayOfWeek + 6) % 7).ToString();
                }
                if (gunlukGun == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString() && gunlukSaat == DateTime.Now.Hour.ToString())
                {
                    timerYedekle.Enabled = false;
                    yedekle();
                    gunlukGun = ((int)(DateTime.Now.AddDays(1).DayOfWeek + 6) % 7).ToString();
                    timerYedeklemeKontrol.Enabled = true;
                }
            }
            else if (rb_Haftalik.Checked)
            {
                string suankiHafta = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
                if (Convert.ToInt32(haftalikGun) < ((int)(DateTime.Now.DayOfWeek + 6) % 7) && suankiHafta == haftalikHafta)
                {
                    MessageBox.Show("Yedekleme için girdiğiniz tarih sistem tarihinden önce bu nedenle sonraki haftanın gününden yedeklemeye başlanacak.", "Girilen Tarih Sistem Tarihinden Önce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    haftalikHafta = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
                }
                if (Convert.ToInt32(haftalikGun) == ((int)(DateTime.Now.DayOfWeek + 6) % 7) && Convert.ToInt32(haftalikSaat) < DateTime.Now.Hour && suankiHafta == haftalikHafta)
                {
                    MessageBox.Show("Yedekleme için girdiğiniz saat sistem tarihinden önce bu nedenle sonraki haftanın gününden yedeklemeye başlanacak.", "Girilen Tarih Sistem Tarihinden Önce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    haftalikHafta = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
                }
                if (haftalikGun == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString() && haftalikSaat == DateTime.Now.Hour.ToString() && haftalikHafta == suankiHafta)
                {
                    timerYedekle.Enabled = false;
                    yedekle();
                    timerYedeklemeKontrol.Enabled = true;
                    haftalikHafta = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now.AddDays(7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
                    haftalikTarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                }
            }
        }
        void dosyaKontrol(DirectoryInfo dr, string dosyaAdi)
        {
            FileInfo[] files = null;
            try
            {
                files = dr.GetFiles(dosyaAdi);
            }
            catch (Exception)
            {
            }
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    kontrol = true;
                }
            }
        }
        void yedeklemeKontrol2(string kontrolTuru)
        {
            raporYaz("Yedekleme Kontrol Zamanı: " + DateTime.Now + " Yedekleme Türü: " + yedeklemeTuruBilgisi);
            raporYaz("");
            sl_Bilgi1Guncelle("Yedekleme kontrolü başlıyor.");
            hataSayac = 0;
            bool ilkEkleme = true;
            string yedekDosyaKonumu = Path.Combine(Application.StartupPath, "yedekle.txt");
            string saat = DateTime.Now.ToString("HH");
            StreamReader Oku;
            try
            {
                sl_Bilgi1Guncelle("Yedekleme kontrolü yapılıyor.");
                int islem = tumIslemleriListele();
                int sayac = 0; 
                spb_Durum.Minimum = 0;
                spb_Durum.Maximum = islem;
                ss_Progressbar.Visible = true;
                Oku = new StreamReader(yedekDosyaKonumu, Encoding.UTF8);
                while (!Oku.EndOfStream)
                {
                    sayac += 1;
                    spb_DurumGuncelle(sayac);
                    Application.DoEvents();
                    sl_Bilgi1Guncelle("Yedekleme kontrolü yapılıyor. İşlem durumu: " + sayac + "/" + islem);

                    kontrol = false;
                    string metin = Oku.ReadLine();
                    if (metin == "")
                    {
                        continue;
                    }
                    try
                    {
                        FileAttributes attr = File.GetAttributes(metin);
                        yedeklemeKonumuGetir();
                        DirectoryInfo dr;
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            string klasorAdi = klasorDosyaAdiGetir(metin);
                            string klasorKonumu = metin.Substring(0, metin.LastIndexOf(klasorAdi)).Replace(":", "");
                            dr = new DirectoryInfo(Path.Combine(yedeklemeKonumu, klasorKonumu));
                            DateTime time = new DateTime();
                            string zipKlasorAdi = "";
                            if (kontrolTuru == "")
                            {
                                zipKlasorAdi = klasorAdi + "__" + DateTime.Now.ToString("d") + "__" + saat + "*.zip";
                                dosyaKontrol(dr, zipKlasorAdi);
                            }
                            else if (kontrolTuru == ((int)(DateTime.Now.AddDays(1).DayOfWeek + 6) % 7).ToString())
                            {
                                zipKlasorAdi = klasorAdi + "__" + DateTime.Now.ToString("d") + "__" + "*.zip";
                                dosyaKontrol(dr, zipKlasorAdi);
                            }
                            else if (kontrolTuru == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString())
                            {
                                for (int i = 0; i > -2; i--)
                                {
                                    time = Convert.ToDateTime(DateTime.Now.AddDays(i).ToString("d"));
                                    zipKlasorAdi = klasorAdi + "__" + time.ToString("d") + "__" + "*.zip";
                                    dosyaKontrol(dr, zipKlasorAdi);
                                }
                            }
                            else if (kontrolTuru == "-1")
                            {
                                time = haftalikTarih;
                                for (int i = 0; i <= 7; i++)
                                {
                                    if (i > 0)
                                        time = time.AddDays(1);
                                    zipKlasorAdi = klasorAdi + "__" + time.ToString("d") + "__" + "*.zip";
                                    dosyaKontrol(dr, zipKlasorAdi);
                                }
                            }
                            if (!kontrol)
                            {
                                if (ilkEkleme)
                                {
                                    raporYaz("Yedekleme Tekrar Oluşturma Zamanı:" + DateTime.Now);
                                    raporYaz("");
                                    ilkEkleme = false;
                                }
                                klasorYedekle(metin);
                            }
                        }
                        else
                        {
                            string dosyaAdi = klasorDosyaAdiGetir(metin);
                            if (metin.Substring(metin.Length - 1) == @"\")
                                metin = metin.Substring(0, metin.Length - 1);
                            string dosyaKonumu = metin.Substring(0, metin.LastIndexOf(dosyaAdi)).Replace(":", "");
                            dr = new DirectoryInfo(Path.Combine(yedeklemeKonumu, dosyaKonumu));
                            DateTime time = new DateTime();
                            string zipKlasorAdi = "";
                            if (kontrolTuru == "")
                            {
                                zipKlasorAdi = dosyaAdi + "__" + DateTime.Now.ToString("d") + "__" + saat + "*.zip";
                                dosyaKontrol(dr, zipKlasorAdi);
                            }
                            else if (kontrolTuru == ((int)(DateTime.Now.AddDays(1).DayOfWeek + 6) % 7).ToString())
                            {
                                zipKlasorAdi = dosyaAdi + "__" + DateTime.Now.ToString("d") + "__" + "*.zip";
                                dosyaKontrol(dr, zipKlasorAdi);
                            }
                            else if (kontrolTuru == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString())
                            {
                                for (int i = 0; i > -2; i--)
                                {
                                    time = Convert.ToDateTime(DateTime.Now.AddDays(i).ToString("d"));
                                    zipKlasorAdi = dosyaAdi + "__" + time.ToString("d") + "__" + "*.zip";
                                    dosyaKontrol(dr, zipKlasorAdi);
                                }
                            }
                            else if (kontrolTuru == "-1")
                            {
                                time = haftalikTarih;
                                for (int i = 0; i <= 7; i++)
                                {
                                    if (i > 0)
                                        time = time.AddDays(1);
                                    zipKlasorAdi = dosyaAdi + "__" + time.ToString("d") + "__" + "*.zip";
                                    dosyaKontrol(dr, zipKlasorAdi);
                                }
                            }
                            dosyaKontrol(dr, zipKlasorAdi);
                            if (!kontrol)
                            {
                                if (ilkEkleme)
                                {
                                    raporYaz("Yedekleme Tekrar Oluşturma Zamanı:" + DateTime.Now);
                                    raporYaz("");
                                    ilkEkleme = false;
                                }
                                dosyaYedekle(metin);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        if (ilkEkleme)
                        {
                            raporYaz("Yedekleme Tekrar Oluşturma Zamanı:" + DateTime.Now);
                            raporYaz("");
                            ilkEkleme = false;
                        }
                        hataSayac += 1;
                        string hata = e.Message;
                        raporYaz(hata);
                    }
                }
                Oku.Close();
            }
            catch (FileNotFoundException e)
            {
                sl_Bilgi1Guncelle("Yedekleme yapılamadı. Yedeklenecekler dosyası bulunamadı.");
                hataSayac += 1;
                raporYaz("Yedekleme Tekrar Deneme Zamanı: " + DateTime.Now);
                raporYaz("");
                raporYaz(e.Message);
                if (btn_OtomatikYedekle.Text == "Otomatik Yedeklemeyi Durdur")
                {
                    DialogResult dialog = MessageBox.Show(e.Message + "\nYedekleme işlemini durdurmak istiyor musunuz?", "Hata! Yedeklenecekleri Kontrol Edilecek Dosya Bulunamadı", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dialog == DialogResult.Yes)
                    {
                        btn_OtomatikYedekle_Click(null, new EventArgs());
                    }
                }
                else
                {
                    DialogResult dialog = MessageBox.Show(e.Message + "\nYedekleme işlemini kontrol sırasında hata çıktı.", "Hata! Yedeklenecekleri Kontrol Edilecek Dosya Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            raporYaz("");
            raporYaz("Toplam Oluşan Hata Sayısı: " + hataSayac);
            raporYaz("");
            raporYaz("");
            sl_Bilgi1Guncelle("Yedek kontrolü bitti.");
            if (btn_OtomatikYedekle.Text == "Otomatik Yedeklemeyi Durdur")
                sl_Bilgi1Guncelle(sl_Bilgi1.Text + " Sonraki kontrol bekleniyor.");
            sl_Bilgi1Guncelle(sl_Bilgi1.Text + "Yedekleme kontrolü sırasında oluşan hatalar: " + hataSayac);
            if (hataSayac > 0)
                sl_Bilgi1Guncelle(sl_Bilgi1.Text + " . Raporu kontrol ediniz.");
            timer_spb_Durum.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        void yedeklemeKontrol()
        {
            if (rb_Saatlik.Checked)
            {
                string saatkac = DateTime.Now.Hour.ToString();
                if (saatlikSaat == saatkac)
                {
                    timerYedeklemeKontrol.Enabled = false;
                    timerYedekle.Enabled = true;
                    sl_Bilgi1Guncelle("Sonraki yedekleme zamanı geldiği için yedekleme kontrolü sonlandırıldı");
                }
                else
                {
                    yedeklemeKontrol2("");
                    timerYedeklemeKontrol.Enabled = true;
                }
            }
            else if (rb_Gunluk.Checked)
            {
                if (gunlukGun == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString() && gunlukSaat == DateTime.Now.Hour.ToString())
                {
                    timerYedeklemeKontrol.Enabled = false;
                    timerYedekle.Enabled = true;
                    sl_Bilgi1Guncelle("Sonraki yedekleme zamanı geldiği için yedekleme kontrolü sonlandırıldı");
                }
                else
                {
                    yedeklemeKontrol2(gunlukGun);
                    timerYedeklemeKontrol.Enabled = true;
                }
            }
            else if (rb_Haftalik.Checked)
            {
                string suankiHafta = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
                if (haftalikGun == ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString() && haftalikSaat == DateTime.Now.Hour.ToString() && haftalikHafta == suankiHafta)
                {
                    timerYedeklemeKontrol.Enabled = false;
                    timerYedekle.Enabled = true;
                    sl_Bilgi1Guncelle("Sonraki yedekleme zamanı geldiği için yedekleme kontrolü sonlandırıldı");
                }
                else
                {
                    yedeklemeKontrol2("-1");
                    timerYedeklemeKontrol.Enabled = true;
                }
            }
        }
        private void timerYedeklemeKontrol_Tick(object sender, EventArgs e)
        {
            timerYedeklemeKontrol.Enabled = false;
            yedeklemeKontrol();
        }
        private void btn_OtomatikYedekle_Click(object sender, EventArgs e)
        {
            bool yedekleme = false;
            if (btn_OtomatikYedekle.Text == "Otomatik Yedeklemeyi Durdur")
            {
                btn_OtomatikYedekle.Text = "Otomatik Yedeklemeyi Başlat";
                sl_Bilgi1Guncelle("Otomatik yedekleme işlemi iptal edildi.");
                rb_Saatlik.Enabled = true;
                rb_Gunluk.Enabled = true;
                rb_Haftalik.Enabled = true;
                timerYedekle.Stop();
                timerYedeklemeKontrol.Stop();
                if (rb_Gunluk.Checked)
                {
                    cb_GunlukSaat.Enabled = true;
                }
                else if (rb_Haftalik.Checked)
                {
                    cb_HaftalikGun.Enabled = true;
                    cb_HaftalikSaat.Enabled = true;
                }
            }
            else
            {
                if (rb_Gunluk.Checked)
                {
                    if (cb_GunlukSaat.SelectedIndex != -1)
                    {
                        cb_GunlukSaat.Enabled = false;
                        rb_Saatlik.Enabled = false;
                        rb_Gunluk.Enabled = false;
                        rb_Haftalik.Enabled = false;
                        yedekleme = true;
                        gunlukSaat = cb_GunlukSaat.SelectedItem.ToString();
                        gunlukGun = ((int)(DateTime.Now.DayOfWeek + 6) % 7).ToString();
                        yedeklemeTuruBilgisi = "Günlük; Ayarlanan Yedekleme Saati:" + gunlukSaat;
                    }
                    else
                    {
                        cb_GunlukSaat.Focus();
                        MessageBox.Show("Günlük yedekleme için saat girmediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rb_Haftalik.Checked)
                {
                    if (cb_HaftalikGun.SelectedIndex != -1 && cb_HaftalikSaat.SelectedIndex != -1)
                    {
                        cb_HaftalikGun.Enabled = false;
                        cb_HaftalikSaat.Enabled = false;
                        rb_Saatlik.Enabled = false;
                        rb_Gunluk.Enabled = false;
                        rb_Haftalik.Enabled = false;
                        yedekleme = true;
                        haftalikGun = cb_HaftalikGun.SelectedIndex.ToString();
                        haftalikSaat = cb_HaftalikSaat.SelectedItem.ToString();
                        haftalikHafta = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
                        yedeklemeTuruBilgisi = "Haftalık; Ayarlanan Yedekleme Zamanı Saat:" + haftalikSaat + " Gün: " + cb_HaftalikGun.SelectedItem;
                    }
                    else
                    {
                        if (cb_HaftalikGun.SelectedIndex == -1 && cb_HaftalikSaat.SelectedIndex == -1)
                        {
                            cb_HaftalikGun.Focus();
                            MessageBox.Show("Haftalık yedekleme için gün ve saat girmediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (cb_HaftalikGun.SelectedIndex == -1)
                        {
                            cb_HaftalikGun.Focus();
                            MessageBox.Show("Haftalık yedekleme için gün girmediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            cb_HaftalikSaat.Focus();
                            MessageBox.Show("Haftalık yedekleme için saat girmediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    yedekleme = true;
                    rb_Saatlik.Enabled = false;
                    rb_Gunluk.Enabled = false;
                    rb_Haftalik.Enabled = false;
                    saatlikSaat = DateTime.Now.Hour.ToString();
                    yedeklemeTuruBilgisi = "Saatlik";
                }
                if (yedekleme == true)
                {
                    timerYedekle.Enabled = true;
                    sl_Bilgi1Guncelle("Otomatik yedekleme işlemi zamanlandı. Yedekleme zamanı bekleniyor.");
                    btn_OtomatikYedekle.Text = "Otomatik Yedeklemeyi Durdur";
                }
            }
        }
        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            string dosyaKonumu = Path.Combine(Application.StartupPath, "yedekayar.txt");
            FileStream fs = new FileStream(dosyaKonumu, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            if (rb_Saatlik.Checked)
            {
                sw.Write("Saatlik");
            }
            else if (rb_Gunluk.Checked)
            {
                if (cb_GunlukSaat.SelectedIndex > -1)
                {
                    sw.WriteLine("Gunluk");
                    sw.Write(cb_GunlukSaat.SelectedIndex);
                }
                else
                {
                    cb_GunlukSaat.Focus();
                    MessageBox.Show("Günlük yedekleme için saat girmediniz. Ayar Kaydedilemedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (rb_Haftalik.Checked)
            {
                if (cb_HaftalikGun.SelectedIndex > -1 && cb_HaftalikSaat.SelectedIndex > -1)
                {
                    sw.WriteLine("Haftalik");
                    sw.WriteLine(cb_HaftalikGun.SelectedIndex);
                    sw.Write(cb_HaftalikSaat.SelectedIndex);
                }
                else
                {
                    if (cb_HaftalikGun.SelectedIndex == -1 && cb_HaftalikSaat.SelectedIndex == -1)
                    {
                        cb_HaftalikGun.Focus();
                        MessageBox.Show("Haftalık yedekleme için gün ve saat girmediniz. Ayar Kaydedilemedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (cb_HaftalikGun.SelectedIndex == -1)
                    {
                        cb_HaftalikGun.Focus();
                        MessageBox.Show("Haftalık yedekleme için gün girmediniz. Ayar Kaydedilemedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cb_HaftalikSaat.Focus();
                        MessageBox.Show("Haftalık yedekleme için saat girmediniz. Ayar Kaydedilemedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        private void btn_YedeklenecekleriSec_Click(object sender, EventArgs e)
        {
            FormYedeklenecekler formYedeklenecek = new FormYedeklenecekler();
            formYedeklenecek.ShowDialog();
        }
        private void timer_spb_Durum_Tick(object sender, EventArgs e)
        {
            ss_Progressbar.Visible = false;
            timer_spb_Durum.Enabled = false;
        }

        private void btn_Bilgi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arslan Backup veri yedekleme programına hoş geldiniz." + "\n\n" +
                "Programı kullanmak için yapmanız gereken yapılacak yedeklemenin ne kadar zamanla bir gerçekleşeceğini seçmek " +
                "veya el ile yedek almaktır. Otomatik yedekleme için yedekleme zamanını seçiniz. Her iki yedekleme içinde uygulamadaki üst butonlardan " +
                "düzenle simgeli butona tıklayıp yedeklenecekleri seçebilirsiniz. Değişiklik yaptıktan sonra kayıt etmeyi unutmayınız. " +
                "Verilerinizin yedekleneceği konumu seçmek için üst butonlardan ayarlar simgeli butona tıklayıp konumu seçebilirsiniz. " +
                "Değişiklik yaptıktan sonra kayıt etmeyi unutmayınız. Ana ekranda bulunan kayıt simgeli buton ile otomatik yedekleme için " +
                "seçtiğiniz zaman bilgileri kayıt edilir. Program açıldığında yedekleme zamanı seçili olarak gelir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_Ayarlar_Click(object sender, EventArgs e)
        {
            yedeklemeAyarlarınıAc();
        }
        private void btn_ManuelYedekle_Click(object sender, EventArgs e)
        {
            sl_Bilgi1Guncelle("El ile yedekleme başlıyor");
            yedeklemeTuruBilgisi = "El İle Yedekle";
            yedekle();
            yedeklemeKontrol2("");
            MessageBox.Show("Yedekleme ve yedek kontrolü yapılmaya çalışıldı. Detaylar için rapor adlı metin belgesini kontrol edebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_Kaydet_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_Kaydet, "Butona tıkladığınızda otomatik yedekleme yaptığınız ayarları kaydeder. Program açılışta kaydettiğiniz ayarı yükler.");
        }
        private void btn_Kaydet_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_Kaydet, "Butona tıkladığınızda otomatik yedekleme yaptığınız ayarları kaydeder. Program açılışta kaydettiğiniz ayarı yükler.");
        }
        private void FormAna_Shown(object sender, EventArgs e)
        {
            sl_Bilgi1Guncelle("Arslan Backup yedekleme programına hoş geldiniz. Yedekleme başlatılması bekleniyor.");
            yedeklemeKonumuGetir();
            string dosyaKonumu = Path.Combine(Application.StartupPath, "yedekayar.txt");
            if (File.Exists(dosyaKonumu))
            {
                FileStream fs = new FileStream(dosyaKonumu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                try
                {
                    string yedeklemeProgramı = sw.ReadLine();

                    if (yedeklemeProgramı == "Saatlik")
                    {
                        btn_OtomatikYedekle.Focus();
                    }
                    else if (yedeklemeProgramı == "Gunluk")
                    {
                        RadioButton rb = this.Controls.Find("rb_" + yedeklemeProgramı, true).First() as RadioButton;
                        rb.Checked = true;
                        int saatIndex = Convert.ToInt32(sw.ReadLine());
                        if (saatIndex > -1 && saatIndex <= cb_GunlukSaat.Items.Count - 1)
                        {
                            cb_GunlukSaat.SelectedIndex = saatIndex;
                            btn_OtomatikYedekle.Focus();
                        }
                    }
                    else if (yedeklemeProgramı == "Haftalik")
                    {
                        RadioButton rb = this.Controls.Find("rb_" + yedeklemeProgramı, true).First() as RadioButton;
                        rb.Checked = true;
                        int gunIndex = Convert.ToInt32(sw.ReadLine());
                        int saatIndex = Convert.ToInt32(sw.ReadLine());
                        if (gunIndex > -1 && gunIndex <= cb_HaftalikGun.Items.Count - 1 && saatIndex > -1 && saatIndex <= cb_HaftalikSaat.Items.Count - 1)
                        {
                            cb_HaftalikGun.SelectedIndex = gunIndex;
                            cb_HaftalikSaat.SelectedIndex = saatIndex;
                            btn_OtomatikYedekle.Focus();
                        }
                    }
                    sw.Close();
                    fs.Close();
                }
                catch (FormatException)
                {
                    sw.Close();
                    fs.Close();                    
                    fs = new FileStream(dosyaKonumu, FileMode.Create, FileAccess.Write);
                    fs.Close();
                }
            }
        }
    }
}
