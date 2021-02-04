using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaskanlikTEST
{
    public partial class Form1 : Form
    {
        Button btn = new Button();
        Button btn2 = new Button();
        Button btn3 = new Button();
        public int money = 15000;
        public double taninma = 0;
        public bool baskanlik = false;
        public double askeri = 35;
        public double saglik = 40;
        public int hak = 2;
        public int maxTaninma = 100;
        public int maxSaglik = 100;
        public int maxAskeri = 100;
        public bool cokus = false;
        public bool istifa = false;
        public int gun = 1;
        public int ay = 1;
        public int yil = 1980;



        public Form1()
        {
            InitializeComponent();
            Goster();
        }

        private void Goster()
        {
            if (baskanlik != true)
            {
                Paralbl.Text = "Para : ";
                Taninmalbl.Text = "Tanınma : ";
                btn.Hide();
                btn2.Hide();
                btn3.Hide();
                lblAskeri.Hide();
                lblMilitary.Hide();
                lblSaglik.Hide();
                lblHealth.Hide();
            }
            lblMoney.Text = Convert.ToString(money);
            lblTaninma.Text = Convert.ToString(taninma) + "%";
            lblMilitary.Text = Convert.ToString(askeri) + "%";
            lblHealth.Text = Convert.ToString(saglik) + "%";
            lblGun.Text = Convert.ToString(gun);
            lblAy.Text = Convert.ToString(ay);
            lblYil.Text = " / " + Convert.ToString(yil);

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            if (money < 5000)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (taninma >= maxTaninma)
                {
                    MessageBox.Show("Maksimum sevilme değerine ulaştınız! Daha fazla sevilme değeriniz artamaz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Sıkı çalıştınız! 5000TL kaybettiniz ve %5 sevilmeniz arttı.");
                    ParaHarca(5000);
                    TaninmaKazan(5.80);
                    Goster();
                }
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (money < 8000)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (saglik >= maxSaglik)
                {
                    MessageBox.Show("Maksimum sağlık geliştirme değerine ulaştınız! Daha fazla sağlık sektörünü geliştiremezsiniz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Sağlık sektörünü 4% oranında geliştirdiniz! 8000TL kaybettiniz.");
                    ParaHarca(8000);
                    SaglikArttir(4.65);
                    Goster();
                }
            }
        }


        public void ParaKazan(int kazanilacak)
        {
            money += kazanilacak;
            Goster();
        }
        public void ParaHarca(int kaybedilecek)
        {
            money -= kaybedilecek;
            Goster();
        }
        public void TaninmaKazan(double kazanilacak)
        {
            taninma += kazanilacak;
            Goster();

        }
        public void AskeriArttir(double arttiralacak)
        {
            askeri += arttiralacak;
            Goster();
        }
        public void AskeriKaybet(double kaybedilecek)
        {
            askeri -= kaybedilecek;
            Goster();
        }
        public void SaglikArttir(double arttirilacak)
        {
            saglik += arttirilacak;
            Goster();
        }
        public void SaglikAzalt(double azaltilacak)
        {
            saglik -= azaltilacak;
            Goster();
        }
        public void Secim()
        {
            if (ay == 12)
            {
                hak -= 1;
                if (hak < 0)
                {
                    MessageBox.Show("Seçime katılma hakkınız tükendi! Bir daha asla seçime katılamayacaksınız. Böylece artık başkan olamazsınız, oyun bitti.");
                    this.Close();
                }
                else
                {
                    if (baskanlik == true)
                    {
                        MessageBox.Show("İyi şanslar sayın başkan...");
                        if (taninma < 50)
                        {
                            MessageBox.Show("Olamaz Başkan! Seçimi kaybettik...");
                            baskanlik = false;
                            TaninmaKazan(10);
                            saglik = 40;
                            askeri = 35;
                            hak = 2;
                            gun = 1;
                            ay = 1;
                            yil += 1;
                        }
                        else
                        {
                            MessageBox.Show("Yaşaşın başkan! Halk sizi seviyor, seçimi kazandınız!");
                            ParaKazan(6000);
                            hak = 2;
                            gun = 1;
                            ay = 1;
                            yil += 1;
                            Goster();
                        }
                    } // BAŞKAN TRUE İSE BİTİŞİ
                    else // BAŞKAN FALSE İSE
                    {
                        MessageBox.Show("Seçime katıldınız, oylar sonuçlanıyor...");
                        if (taninma < 35)
                        {
                            MessageBox.Show("Ezici bir farkla seçimi kazanamadınız! Ama artık halk sizi daha çok tanıyor. 4000TL promosyon kazandınız.");
                            TaninmaKazan(2.20);
                            ParaKazan(4000);
                            gun = 1;
                            ay = 1;
                            yil += 1;
                            Goster();
                        }
                        if (ay == 12)
                        {
                            if (taninma < 50 && taninma > 35)
                            {
                                MessageBox.Show("Kazanmanıza az kalmıştı! Halk rekabetinizden ötürü çok memnun! 2000TL promosyon kazandınız");
                                TaninmaKazan(4.65);
                                ParaKazan(2000);
                                gun = 1;
                                ay = 1;
                                yil += 1;
                                Goster();
                            }
                        }
                        if (ay == 12)
                        {
                            if (taninma > 50)
                            {
                                MessageBox.Show("Seçimi kazandınız! Önümüzdeki 12 ay siz başkansınız! 25000TL Devlet hazinesine eklendi.");
                                baskanlik = true;
                                hak = 2;
                                gun = 1;
                                ay = 1;
                                yil += 1;
                                Paralbl.Text = "Hazine : ";
                                Taninmalbl.Text = "Sevilme : ";

                                btn.Text = "Sıkı Çalış (-5000)";
                                btn.Name = "btnCalis";
                                btn.Size = new Size(126, 28);
                                btn.Location = new Point(24, 187);
                                btn.Click += Btn_Click;

                                btn2.Text = "Sağlık sektöründe geliş (-7000)";
                                btn2.Name = "btnSaglik";
                                btn2.Size = new Size(146, 35);
                                btn2.Location = new Point(24, 220);
                                btn2.Click += Btn2_Click;

                                btn3.Text = "Askeri gücü arttır (-8000)";
                                btn3.Name = "btnAskeri";
                                btn3.Size = new Size(146, 35);
                                btn3.Location = new Point(24, 260);
                                btn3.Click += Btn3_Click;

                                Controls.Add(btn);
                                Controls.Add(btn2);
                                Controls.Add(btn3);
                                btn.Show();
                                btn2.Show();
                                btn3.Show();
                                lblAskeri.Show();
                                lblMilitary.Show();
                                lblSaglik.Show();
                                lblHealth.Show();
                                TaninmaKazan(8.15);
                                ParaKazan(25000);
                                ay = 1;
                                Goster();
                            }
                        }
                    } // ELSE BİTİŞİ
                }
            } // IF AY 12'NİN BİTİŞİ
            else
            {
                MessageBox.Show("Seçimler 12. ayda başlar.");
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            if (money < 10000)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (askeri >= maxAskeri)
                {
                    MessageBox.Show("Maksimum askeri geliştirme değerine ulaştınız! Daha fazla askeriyi geliştiremezsiniz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Askeri birlikler 5% güçlendirildi, hazineden 10000 harcandı ve sevilme oranı 4% oranında arttı.");
                    ParaHarca(10000);
                    AskeriArttir(5.25);
                    Goster();
                }
            }
        }

        public void TaninmaKaybet(double kaybedilecek)
        {
            taninma -= kaybedilecek;
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            if (money < 3500)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (taninma >= maxTaninma)
                {
                    MessageBox.Show("Maksimum tanınma değerine ulaştınız! Daha fazla tanınma değerini geliştiremezsiniz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Bağış yapıldı, 3500TL kaybettiniz ama %2 tanınma oranı sağladınız.");
                    ParaHarca(3500);
                    TaninmaKazan(2.60);
                    Goster();
                }
            }
        }

        private void btnMiting_Click(object sender, EventArgs e)
        {
            if (money < 1000)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (taninma >= maxTaninma)
                {
                    MessageBox.Show("Maksimum tanınma değerine ulaştınız! Daha fazla tanınma değerini geliştiremezsiniz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Miting yapıldı, 1000TL kaybettiniz ama %1 tanınma oranı sağladınız.");
                    ParaHarca(1000);
                    TaninmaKazan(1.25);
                    Goster();
                }
            }
        }

        private void btnReklam_Click(object sender, EventArgs e)
        {
            if (money < 3250)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (taninma >= maxTaninma)
                {
                    MessageBox.Show("Maksimum tanınma değerine ulaştınız! Daha fazla tanınma değerini geliştiremezsiniz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Reklam filminiz yapıldı, 3250TL kaybettiniz ama %3 tanınma oranı sağladınız.");
                    ParaHarca(3250);
                    TaninmaKazan(3.20);
                    Goster();
                }
            }
        }

        private void btnTv_Click(object sender, EventArgs e)
        {
            if (money < 5000)
            {
                MessageBox.Show("Sayın Başkan, paran buna yetmez!");
            }
            else
            {
                if (taninma >= maxTaninma)
                {
                    MessageBox.Show("Maksimum tanınma değerine ulaştınız! Daha fazla tanınma değerini geliştiremezsiniz.");
                    Goster();
                }
                else
                {
                    MessageBox.Show("Televizyon röportajı yaptınız, 5000TL kaybettiniz ama %3 tanınma oranı sağladınız.");
                    ParaHarca(5000);
                    TaninmaKazan(3.15);
                    Goster();
                }
            }
        }

        private void btnTur_Click(object sender, EventArgs e)
        {
            if (cokus == true)
            {
                MessageBox.Show("Devletinin çöküşünden dolayı oyun bitti.");
                this.Close();
            }
            else
            {
                if (istifa == true)
                {
                    MessageBox.Show("İsitfa ettin, oyun bitti.");
                    this.Close();
                }
                else
                {
                    if (hak < 0)
                    {
                        MessageBox.Show("Seçime katılma hakkınız tükendi! Bir daha asla seçime katılamayacaksınız. Böylece artık başkan olamazsınız, oyun bitti.");
                        this.Close();
                    }
                    else
                    {
                        if (baskanlik == true && askeri < -10 || saglik < -10)
                        {
                            MessageBox.Show("Devlet çöktü! Her şey senin yüzünden bir bataklık haline geldi! Devletin artık yok, her yer kaos halinde. Oyun bitti.");
                            cokus = true;
                        }
                        else
                        {
                            if (baskanlik == true && taninma < -15)
                            {
                                MessageBox.Show("Halk isyan etmiş durumda. Herkes istifanı istiyor. Zorla istifa ettin, oyun bitti.");
                                istifa = true;
                            }
                            else
                            {
                                if (baskanlik == false && taninma < -20)
                                {
                                    MessageBox.Show("Milletvekilliğinden istifan isteniyor! Halk seni hiç umursamıyor. Partinden atıldın! Oyun bitti.");
                                    istifa = true;
                                }
                                else
                                {
                                    if (gun == 31)
                                    {
                                        if (ay == 12)
                                        {
                                            ay = 1;
                                            gun = 1;
                                            yil += 1;
                                            Goster();
                                        }
                                        else
                                        {
                                            gun = 1;
                                            ay += 1;
                                            Goster();
                                        }
                                    }
                                    if (ay == 12)
                                    {
                                        if (baskanlik == true)
                                        {
                                            MessageBox.Show("Bu seçim günü! Katılmak zorundasın.");
                                            Secim();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tur atlandı. (15 Gün) 2500TL kasana eklendi.");
                                            gun += 15;
                                            Goster();
                                        }
                                    }
                                    else
                                    {
                                        gun += 15;
                                        if (baskanlik == true)
                                        {
                                            MessageBox.Show("Tur atlandı. (15 Gün) 4000TL hazineye eklendi.");
                                            TaninmaKaybet(2);
                                            ParaKazan(4000);
                                            AskeriKaybet(1.50);
                                            SaglikAzalt(2.10);
                                            Goster();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tur atlandı. (15 Gün) 2500TL kasana eklendi.");
                                            ParaKazan(2500);
                                            TaninmaKaybet(1);
                                            Goster();
                                        }
                                    }
                                }
                            }
                        }
                    } // ELSE BİTİŞİ

                }
            }
        }

        private void btnSecim_Click(object sender, EventArgs e)
        {
            Secim();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lblDeneme_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NASIL OYANANIR - REHBER");
            MessageBox.Show("Oyuncu başlangıçta 15000 para ile başlar ve oyunun asıl amacı sahip olduğu para ile birlikte" +
            "Tanınma seviyesini olabildiğince yukarıda tutarak başkan olmak. Tanınma seviyesi %50 nin üstüne çıkarsa seçimden sonra başkan olur." +
            "Para her tur atlandığında 2500 artar (Oyuncu başkan değilse) eğer başkansa hazineye 4000 eklenir.");
            MessageBox.Show("Oyuncu elindeki para ile birlikte tanınma seviyesini farklı yollarla yükseltmeye çalışır. Başkan değilken" +
            "seçimi kazanana kadar en fazla 2 defa seçime girme hakkı var. %50 nin üstünde tanınma seviyesiyle seçime girilirse seçim kazanılır.");
            MessageBox.Show("Her tur atlandığında tanınma seviyesi ayrıyeten -1% düşer. Eğer oyuncu başkan ise tanınma -2% düşer.");
            MessageBox.Show("Oyuncu başkan olunca farklı yönetim seviyeleri de açılır. Başkan olduğunda işler daha zorlaşır ve devletin sorumluluğu üstlenilmiş olur" +
            "Eğer tanınma seviyesi başkanken -15% Altına düşerse halk isyan eder. Eğer oyuncu başkan değilse -20% tanınma seviyesinin altına düştüğü an zorla istifa edilir.");
            MessageBox.Show("Oyuncu başkenken Askeri güç veya Sağlık sektörü -10% oranının altına giderse devlet çöker ve oyun biter.");
            MessageBox.Show("İyi şanslar, oyunda her hangi bir hata, mantıksal çelişki ve BUG görürseniz bildirmenizden mutluluk duyarım.");
            MessageBox.Show("İletişim bilgileri YAPIMCI bölümünde.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YAPIMCI Bilgileri");
            MessageBox.Show("Programlayıcı : MURATCAN YANIK \nProgramlama aşamasında yardımından ayrıyeten teşekkürler : AHMET AĞAÇÇAVDIRAN");
            MessageBox.Show("MURATCAN YANIK DC : muratcanyanik#0500 \nAHMET AĞAÇÇAVDIRAN DC : ahmetagaccavdiran#0034");
        }

        private void btnGuncellemeler_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gelmesi olası güncellemeler ve bir sonraki sürüm bilgisi");
            MessageBox.Show("Bir Sonraki Sürüm : ALPHA sürümü geliyor!");
            MessageBox.Show("Savaşlar geliyor! Oyuna savaş özelliği eklenecek.");
            MessageBox.Show("Oynanışa önem verilecek ve oyun daha fazla oynanabilir hale gelecek, oyunun zorluğuna göz atılacak ve oynanış çok daha iyi bir hale getirilerek detaylandırılacak");
            MessageBox.Show("Oyun rehberi kısmı ve güncellemeler kısımı farklı yerlere taşınılacak, oyunun oynama alanı genişletilecek.");
            MessageBox.Show("Oyundaki gördüğünüz tüm hataları bildirirseniz sevinirim.");
            MessageBox.Show("ALPHA sürümünü 10 Şubat tarihinden sonra görebiliriz!");
        }
    }
}
