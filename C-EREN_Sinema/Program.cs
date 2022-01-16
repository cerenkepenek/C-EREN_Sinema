using System;

namespace C_EREN_Sinema
{
    public class Metotlar
    {
        public static int bilSayi = 0;
        public static void progKapa()
        {
            //Kısa bir süre bekleyip programı kapatır.
            System.Threading.Thread.Sleep(1300);
            Environment.Exit(0);
        }

        public static void biletYazdir(string[] dizi)
        {
            foreach (string element in dizi)
            {
                Console.WriteLine("Biletleriniz: " + element);
            }
        }

    }

    public class Ozellikler : Metotlar
    {
        public static int faturaEkleme
        {
            set
            {
                if (value < 0)
                {
                    bilSayi = 0;
                }
                else
                {
                    bilSayi = value;
                }
            }
            get
            {
                return 50 * bilSayi;
            }
        }
    }
    //Filmlerin adlarını içine yazıcağımız enum:
    enum filmAdlari
    {
        Venom,
        SpiderMan,
        Cruella,
        Eternals,
        Spencer
    }
    class Program
    {
        public static double fatura = 0;

        struct filmDetaylari
        {
            public string imdbPuani;
            public string filmOzeti;
            public string cErenPuani;
            public string tur;
            public double filmSure;
            public string filmSalonu;
        }

        static void Main(string[] args)
        {
            //<-----------------|DEGISKEN TANIMLAMA KISMI|----------------->
            filmAdlari filmadi;
            byte i = 0;
            byte a = 0;
            byte menu;
            byte tercih;
            byte popcornTercih;
            byte icicekTercih;
            //FilmDetay adinda Struct Dizi olusturdum:
            filmDetaylari[] filmDetay = new filmDetaylari[5];
            byte istenenFilm;
            //Random kullanimi:
            Random rnd = new Random();
            //Kodun her yerinde kullanabilicegimiz gecici bir int muhim bir sey degil. Silmeyi unuttuysam bile silebilirsin.
            int temp = 0;
            //Yine bilet alma kismi icin sira belirleme:
            string harfSira;
            byte harfSiraSayi = 0;
            //Bilet alma kismi icin siralari belirleme:
            string sayiSira;
            byte sayiSirasiSayisi = 0;
            //Bilet alma kismi icin sayac:
            byte sayac = 0;
            //Split Kullanimi:
            string sira = "A,B,C,D,E,F,G,H,I,J";
            string[] siralar = sira.Split(',');
            //Cift Boyutlu Dizi Kullanimi:
            //Bilet alma kismindaki salon koltuklarini belirliyoruz.
            int[,] salon = new int[10, 10];
            //Popcorn Fiyatlari:
            const double buyukBoy = 32.99;
            const double ortaBoy = 27.99;
            const double kucukBoy = 22.99;
            //Icecek Fiyatlari:
            const double kola = 23.95;
            const double sprite = 22.95;
            const double iceTea = 20.95;
            const double su = 20.99;
            //Bilet Ucreti:
            const int tamKisi = 50;
            //<-----------------|DEGISKEN TANIMLAMA KISMI|----------------->

            //<-----------------|BILET ALMA DEGISKENLERI|----------------->
            //Actigimiz cift boyutlu dizinin icini dolduruyoruz, 0 ve 1 ile.
            //Boylelikle dolu ve bos koltuklari elde ediyoruz.
            for (byte iop = 0; iop < salon.GetLength(0); iop++)
            {
                for (byte j = 0; j < salon.GetLength(1); j++)
                {
                    //Random Kullanimi 2:
                    salon[iop, j] = rnd.Next(0, 2);
                }
            }
            //<-----------------|BILET ALMA DEGISKENLERI|----------------->

            //<-----------------|FILM DETAYLARI TANIMALAMA KISMI|----------------->
            filmDetay[0].imdbPuani = "6.7/10";
            filmDetay[0].cErenPuani = "8/10";
            filmDetay[0].filmOzeti = "Eddie Brock hırslı bir muhabirdir. Sevgilisinin çalıştığı araştırma firmasının sahibi de peşinde olduğu hikayelerden biridir. Kötü niyetli ve kendi amaçları doğrultusunda hareket eden bu adamın hikayesinin peşinde koşarken, Eddie, sadece simbiyoz hâlinde yaşayabilen ve adrenalinle beslenen uzaylı bir organizmanın firma tarafından keşfedildiğini ve insan deneklerle birleştirilmeye çalışıldığını öğrenir. Ancak araştırmasında fazla ilerleyen Eddie, Venom adı verilen bu organizmanın sıradaki taşıyıcısı olur. Bir yandan vücudunu ve zihnini kontrol altına alan organizmayla mücadele eden Eddie, bir yandan da firma sahibinin kendisini öldürmesi için gönderdiği kişilerden kaçmalıdır...";
            filmDetay[0].tur = "Aksiyon";
            filmDetay[0].filmSure = 1.52;
            filmDetay[0].filmSalonu = "Salon 2";
            //<------------>
            filmDetay[1].imdbPuani = "8.8/10";
            filmDetay[1].cErenPuani = "9.9/10";
            filmDetay[1].filmOzeti = "Örümcek-Adam Eve Dönüş Yok, kimliği açığa Örümcek-Adam'ın, sırrını geri vermesi için Doktor Strange'den yardım istemesiyle birlikte yaşananları konu ediyor. Örümcek-Adam'ın kimliği ifşa edilerek onun ve sevdiklerinin hayatı, halkın gözü önüne serilir. Kendisini büyük bir kaosun ortasında bulan Peter, aynı zamanda suç ortakları olarak lanse edilen MJ ve Ned'in hayatının da olumsuz etkilenmesine şahit olur. Arkadaşların üniversiteye girme şanslarının yok olmasına seyirci kalmak istemeyen Peter, sırrını geri vermesi için Doktor Strange'den yardım ister. Peter'ın yakarışından etkilenip ona yardım etmeyi kabul eden Strange, Unutma Büyüsü'nü yapmaya başlar. Ancak bu büyü, MJ, Ned, May ve Happy'nin de Örümcek-Adam'ın kim olduğunu unutmasına neden olacaktır. Arkadaşlarının kim olduğunu hatırlamasını, diğer kişilerin unutmasını isteyen Peter, Strange büyüyü yaparken parametreleri değiştirir. Ancak bu durum beklenmedik olaylara neden olur.";
            filmDetay[1].tur = "Aksiyon/Macera";
            filmDetay[1].filmSure = 2.29;
            filmDetay[1].filmSalonu = "Salon 4";
            //<------------>
            filmDetay[2].imdbPuani = "7.4/10";
            filmDetay[2].cErenPuani = "7.6/10";
            filmDetay[2].filmOzeti = "Cruella, yaptığı tasarımlarla adını duyurmaya çalışan, yetenekli bir kız ve genç bir dolandırıcı olan Estella'nın hikayesini konu ediyor. Zeki ve yaratıcı bir kız olan Estella'nın hayatı, onun haylazlık hevesini takdir eden iki hırsızla arkadaş olmasıyla bambaşka bir hal alır. Genç kız, arkadaşlarıyla birlikte kendisine Londra'nın sokaklarında bir hayat kurar. Moda konusunda oldukça yetenekli olan Estella, bir moda efsanesi olan korkutucu Barones von Hellman'ın dikkatini çekmeyi başarır. Ancak ikisinin kurduğu ilişki, Estella'nın kötü tarafını kabullenip Cruella’ya dönüşmesine neden olur.";
            filmDetay[2].tur = "Komedi/Suç";
            filmDetay[2].filmSure = 2.14;
            filmDetay[2].filmSalonu = "Salon 7";
            //<------------>
            filmDetay[3].imdbPuani = "6.7/10";
            filmDetay[3].cErenPuani = "5.3/10";
            filmDetay[3].filmOzeti = "“The Eternals”, insanlığın varoluşundan beri dünyayı koruyan, olağanüstü güçlere sahip bir grup kahramanın hikayesini konu ediyor. Deviantlar'ın artık tarihe karıştığı düşünülmektedir. Ancak insanlığın en eski düşmanı olan Deviantlar, beklenmedik bir şekilde geri döner. Bu durum insanlık için büyük bir tehlike oluşturur. Eternallar, insanlığı bir kez daha kurtarmak için yeniden bir araya gelmek zorunda kalırlar.";
            filmDetay[3].tur = "Macera/Aksiyon";
            filmDetay[3].filmSure = 2.37;
            filmDetay[3].filmSalonu = "Salon 1";
            //<------------>
            filmDetay[4].imdbPuani = "6.8/10";
            filmDetay[4].cErenPuani = "5.8/10";
            filmDetay[4].filmOzeti = "Spencer, 1981 yılında Prens Charles ile evlenen Diana Frances Spencer’ın hayat hikayesini konu ediyor. 1991 yılında İngiltere Kraliyer ailesi Noel tatilini Sandringham Köşkü'nde geçirmeye karar verir. Her şey yolunda gözükür ancak Lady Diana mutsuzluğunu saklamaya çalışır. Dışarıdan gözüken şaşalı yaşamın içine hapsolan Diana, Prens Charles ile olan evliliğinin artık sonuna geldiğini düşünür ve 1991 Noel tatilini Kraliyet içinde geçirmek istediği son günleri olmasına karar verir.";
            filmDetay[4].tur = "Dram";
            filmDetay[4].filmSure = 1.51;
            filmDetay[4].filmSalonu = "Salon 3";
            //<-----------------|FILM DETAYLARI TANIMALAMA KISMI|----------------->

            Console.WriteLine("<===============| Sinema C-EREN'e Hoş Geldiniz |===============>");
            Console.WriteLine();
            Console.WriteLine("                     Vizyondaki Filmler: ");
            Console.WriteLine();
            Console.WriteLine("     ----------------------------------------------------------------");
            Console.Write("     -+- ");
            //Ekranda filmlerin adını yazdıracak döngü:
            while (i < 5)
            {
                filmadi = (filmAdlari)i;
                Console.Write(filmadi + " -+- ");
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("     ----------------------------------------------------------------");

            Console.WriteLine();
            Console.WriteLine("Ne yapmak isterdiniz?");
            //Bütün kodun gidişatını belirleyecek sonsuz döngü:
            for (; ; )
            {
                //Menu kısmı:
                Console.WriteLine("-->1-Filmler Hakkında Bilgi\n-->2-Yiyecek, İçecek Alışverişi\n-->3-Bilet Alma\n-->4-Çıkış Yap");
                Console.WriteLine();
                Console.Write("-->");
                menu = Byte.Parse(Console.ReadLine());
                //Menu sonu.

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Hangi filmin detaylarını öğrenmek istersiniz? ");
                        Console.Write("-+- ");
                        while (a < 5)
                        {
                            filmadi = (filmAdlari)a;
                            Console.Write((a + 1) + " = " + filmadi + " -+- ");
                            a++;
                        }
                        a = 0;
                        Console.WriteLine();
                        Console.WriteLine("Filmlerin yanlarında bulunan kodunu giriniz.");
                        Console.Write("-->");
                        istenenFilm = Byte.Parse(Console.ReadLine());
                        switch (istenenFilm)
                        {
                            case 1:
                                Console.WriteLine("C-EREN Puanı: {0}\n", filmDetay[0].cErenPuani);
                                Console.WriteLine("IMDB Puanı: {0}\n", filmDetay[0].imdbPuani);
                                Console.WriteLine("Filmin Türü: {0}\n", filmDetay[0].tur);
                                Console.WriteLine("Film Özeti: {0}\n", filmDetay[0].filmOzeti);
                                Console.WriteLine("Filmin Süresi: {0} saat\n", filmDetay[0].filmSure);
                                break;
                            case 2:
                                Console.WriteLine("C-EREN Puanı: {0}\n", filmDetay[1].cErenPuani);
                                Console.WriteLine("IMDB Puanı: {0}\n", filmDetay[1].imdbPuani);
                                Console.WriteLine("Filmin Türü: {0}\n", filmDetay[1].tur);
                                Console.WriteLine("Film Özeti: {0}\n", filmDetay[1].filmOzeti);
                                Console.WriteLine("Filmin Süresi: {0} saat\n", filmDetay[1].filmSure);
                                break;
                            case 3:
                                Console.WriteLine("C-EREN Puanı: {0}\n", filmDetay[2].cErenPuani);
                                Console.WriteLine("IMDB Puanı: {0}\n", filmDetay[2].imdbPuani);
                                Console.WriteLine("Filmin Türü: {0}\n", filmDetay[2].tur);
                                Console.WriteLine("Film Özeti: {0}\n", filmDetay[2].filmOzeti);
                                Console.WriteLine("Filmin Süresi: {0} saat\n", filmDetay[2].filmSure);
                                break;
                            case 4:
                                Console.WriteLine("C-EREN Puanı: {0}\n", filmDetay[3].cErenPuani);
                                Console.WriteLine("IMDB Puanı: {0}\n", filmDetay[3].imdbPuani);
                                Console.WriteLine("Filmin Türü: {0}\n", filmDetay[3].tur);
                                Console.WriteLine("Film Özeti: {0}\n", filmDetay[3].filmOzeti);
                                Console.WriteLine("Filmin Süresi: {0} saat\n", filmDetay[3].filmSure);
                                break;
                            case 5:
                                Console.WriteLine("C-EREN Puanı: {0}\n", filmDetay[4].cErenPuani);
                                Console.WriteLine("IMDB Puanı: {0}\n", filmDetay[4].imdbPuani);
                                Console.WriteLine("Filmin Türü: {0}\n", filmDetay[4].tur);
                                Console.WriteLine("Film Özeti: {0}\n", filmDetay[4].filmOzeti);
                                Console.WriteLine("Filmin Süresi: {0} saat\n", filmDetay[4].filmSure);
                                break;
                        }


                        break;
                    case 2:
                        Console.WriteLine("Ne almak istersiniz?");
                        Console.WriteLine("-->1-Popcorn\n-->2-İçecek");
                        tercih = Convert.ToByte(Console.ReadLine());
                        switch (tercih)
                        {
                            case 1:
                                Console.WriteLine("-->1-Büyük Boy\t-->2-Orta Boy\t-->3-Küçük Boy");
                                popcornTercih = Convert.ToByte(Console.ReadLine());
                                switch (popcornTercih)
                                {
                                    case 1:
                                        fatura += buyukBoy;
                                        break;
                                    case 2:
                                        fatura += ortaBoy;
                                        break;
                                    case 3:
                                        fatura += kucukBoy;
                                        break;
                                    default:
                                        Console.WriteLine("Lütfen listeden deger giriniz.");
                                        break;
                                }
                                break;
                            case 2:
                                Console.WriteLine("-->1-Kola\t-->2-Ice Tea\t-->3-Sprite\t-->4-Su");
                                icicekTercih = Convert.ToByte(Console.ReadLine());
                                switch (icicekTercih)
                                {
                                    case 1:
                                        fatura += kola;
                                        break;
                                    case 2:
                                        fatura += iceTea;
                                        break;
                                    case 3:
                                        fatura += sprite;
                                        break;
                                    case 4:
                                        fatura += su;
                                        break;
                                    default:
                                        Console.WriteLine("Lütfen listeden deger giriniz.");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Lütfen listeden değer giriniz.");
                                break;
                        }


                        break;
                    case 3:
                        //Ekranin ustundeki guzel duran kisim.
                        Console.WriteLine();
                        Console.WriteLine("  " + "<=============|KOLTUKLAR|==============>" + "\n");
                        Console.WriteLine("    " + "1 - 2 - 3 - 4 - 5 - 6 - 7 - 8 - 9 - 10");
                        Console.WriteLine("  " + "----------------------------------------");

                        //Bu kisim ise dolu ve bos koltuklari ekranda gostermemizi saglayan kisim.
                        for (byte g = 0; g < salon.GetLength(0); g++)
                        {
                            Console.Write(siralar[g] + " - ");
                            for (byte j = 0; j < salon.GetLength(1); j++)
                            {
                                //Dolu koltuklar icin "if" kismi calisicak ve "D" yazicak.
                                if (salon[g, j] == 1)
                                {
                                    Console.Write("D   ");
                                }
                                //Bos koltuklar icin "else" kismi calisicak ve "B" yazicak.
                                else
                                {
                                    Console.Write("B   ");
                                }
                                //Console.Write("{0}   ", salon[i, j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.Write("-->Kac bilet alacaksiniz? ");
                        //Bilet sayisini aliyorum.
                        Metotlar.bilSayi = Byte.Parse(Console.ReadLine());
                        Ozellikler.faturaEkleme = Metotlar.bilSayi;
                        fatura += Ozellikler.faturaEkleme;
                        //Alinicak bilet sayisi uzunlugunda bir dizi olusturuyorum ki biletleri hafizada tutabileyim.
                        string[] biletlerDizisi = new string[Metotlar.bilSayi];

                        //Bilet alma islemini gerceklestiricegim sonsuz for'u actim.
                        for (; ; )
                        {
                            //Harf sirasini belirliyorum ve bu siraya denk gelen iki boyutlu dizi degerini hafizada tutuyorum ki ilerde dolu mu bos mu bu koltuk kontrol edebileyim.
                            Console.WriteLine("A,B,C,D,E,F,G,H,I,J arasından seçiniz ve sadece büyük harf ile giriniz!");
                            Console.Write("Koltuğun harf sırasını giriniz: ");
                            harfSira = Convert.ToString(Console.ReadLine());
                            switch (harfSira)
                            {
                                case "A":
                                    harfSiraSayi = 0;
                                    break;
                                case "B":
                                    harfSiraSayi = 1;
                                    break;
                                case "C":
                                    harfSiraSayi = 2;
                                    break;
                                case "D":
                                    harfSiraSayi = 3;
                                    break;
                                case "E":
                                    harfSiraSayi = 4;
                                    break;
                                case "F":
                                    harfSiraSayi = 5;
                                    break;
                                case "G":
                                    harfSiraSayi = 6;
                                    break;
                                case "H":
                                    harfSiraSayi = 7;
                                    break;
                                case "I":
                                    harfSiraSayi = 8;
                                    break;
                                case "J":
                                    harfSiraSayi = 9;
                                    break;

                            }

                            //Burda da ayni seyi yapıyorum ama sayi sirasi ile.
                            Console.Write("Koltuğun sayı sırasını giriniz: ");
                            sayiSira = Convert.ToString(Console.ReadLine());
                            switch (sayiSira)
                            {
                                case "1":
                                    sayiSirasiSayisi = 0;
                                    break;
                                case "2":
                                    sayiSirasiSayisi = 1;
                                    break;
                                case "3":
                                    sayiSirasiSayisi = 2;
                                    break;
                                case "4":
                                    sayiSirasiSayisi = 3;
                                    break;
                                case "5":
                                    sayiSirasiSayisi = 4;
                                    break;
                                case "6":
                                    sayiSirasiSayisi = 5;
                                    break;
                                case "7":
                                    sayiSirasiSayisi = 6;
                                    break;
                                case "8":
                                    sayiSirasiSayisi = 7;
                                    break;
                                case "9":
                                    sayiSirasiSayisi = 8;
                                    break;
                                case "10":
                                    sayiSirasiSayisi = 9;
                                    break;

                            }

                            //Eger secilen koltuk dolu ise bu if calisiyor ve tekrar koltuk sectiriyor.
                            if (salon[harfSiraSayi, sayiSirasiSayisi] == 1)
                            {
                                Console.WriteLine("-->Dolu koltukları seçemezsiniz!!!!");
                            }
                            //Eger secilen koltuk dolu degil ISE buraya giriyor.
                            else
                            {
                                //Once girilen bileti hafizaya aliyorum.
                                biletlerDizisi[sayac] = harfSira + sayiSira;
                                //Sonra sayaci arttiriyorum ki istenilen kadar bilet alindiginda sonsuz donguden cikayim.
                                sayac++;
                                if (sayac == Metotlar.bilSayi)
                                {
                                    //Istenilen kadar bilet alindiginda bu if'e giriyor ve for'u kapatiyor.
                                    break;
                                }
                            }
                        }
                        Console.WriteLine();

                        //Bu metot ise biletleri yazdiriyor.
                        Metotlar.biletYazdir(biletlerDizisi);

                        Console.WriteLine();
                        break;
                    case 4:
                        //Programı kapatıyor.
                        Console.WriteLine("Program kapatılıyor.");
                        //System.Threading.Thread.Sleep(800);
                        //Environment.Exit(0);
                        Console.WriteLine("Faturanız: " + fatura + " TL");
                        Metotlar.progKapa();
                        break;
                    default:
                        Console.WriteLine("Lütfen listeden değer giriniz.");
                        break;
                }
            }

            Console.ReadKey();

        }
    }
}
