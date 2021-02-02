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
        public int money = 10000;
        public double taninma = 0;
        public int ay = 1;
        public bool baskanlik = false;
        public double askeri = 35;
        public double saglik = 40;
        public int hak = 2;
        public int maxTaninma = 100;
        public int maxSaglik = 100;
        public int maxAskeri = 100;
        public bool cokus = false;
        public bool istifa = false;



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
            lblAy.Text = Convert.ToString(ay);

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
                            ay = 1;
                        }
                        else
                        {
                            MessageBox.Show("Yaşaşın başkan! Halk sizi seviyor, seçimi kazandınız!");
                            ParaKazan(6000);
                            ay = 1;
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
                            ay = 1;
                            Goster();
                        }
                        if (ay == 12)
                        {
                            if (taninma < 50 && taninma > 35)
                            {
                                MessageBox.Show("Kazanmanıza az kalmıştı! Halk rekabetinizden ötürü çok memnun! 2000TL promosyon kazandınız");
                                TaninmaKazan(4.65);
                                ParaKazan(2000);
                                ay = 1;
                                Goster();
                            }
                        }
                        if (ay == 12)
                        {
                            if (taninma > 50)
                            {
                                MessageBox.Show("Seçimi kazandınız! Önümüzdeki 12 ay siz başkansınız! 15000TL Devlet hazinesine eklendi.");
                                baskanlik = true;
                                hak = 2;
                                ay = 1;
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
                                ParaKazan(15000);
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
            if (money < 7000)
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
                    MessageBox.Show("Bağış yapıldı, 8000TL kaybettiniz ama %5 tanınma oranı sağladınız.");
                    ParaHarca(7000);
                    TaninmaKazan(5.20);
                    Goster();
                }
            }
        }

        private void btnMiting_Click(object sender, EventArgs e)
        {
            if (money < 2000)
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
                    MessageBox.Show("Miting yapıldı, 2000TL kaybettiniz ama %3 tanınma oranı sağladınız.");
                    ParaHarca(2000);
                    TaninmaKazan(3.50);
                    Goster();
                }
            }
        }

        private void btnReklam_Click(object sender, EventArgs e)
        {
            if (money < 6500)
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
                    MessageBox.Show("Reklam filminiz yapıldı, 6500TL kaybettiniz ama %6 tanınma oranı sağladınız.");
                    ParaHarca(6500);
                    TaninmaKazan(6.40);
                    Goster();
                }
            }
        }

        private void btnTv_Click(object sender, EventArgs e)
        {
            if (money < 10000)
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
                    MessageBox.Show("Televizyon röportajı yaptınız, 10000TL kaybettiniz ama %6 tanınma oranı sağladınız.");
                    ParaHarca(10000);
                    TaninmaKazan(6.30);
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
                                    if (ay == 12)
                                    {
                                        if (baskanlik == true)
                                        {
                                            MessageBox.Show("Bu seçim günü! Katılmak zorundasın.");
                                            Secim();
                                        }
                                        ParaKazan(5000);
                                        ay = 1;
                                        Goster();
                                    }
                                    else
                                    {
                                        ay += 1;
                                        if (baskanlik == true)
                                        {
                                            MessageBox.Show("Tur atlandı. (1 Ay) 8000TL hazineye eklendi.");
                                            TaninmaKaybet(3.20);
                                            ParaKazan(8000);
                                            AskeriKaybet(3);
                                            SaglikAzalt(4.20);
                                            Goster();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Tur atlandı. (1 Ay) 5000TL kasana eklendi.");
                                            ParaKazan(5000);
                                            TaninmaKaybet(2);
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
    }
}
