using System;

public enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

public class Cihaz
{
    public int Kimlik { get; private set; }
    public string Ad { get; set; }
    public CihazTuru Tur { get; private set; }
    public bool AcikMi { get; private set; }

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }

    public void Ac()
    {
        AcikMi = true;
    }
    public void Kapali()
    {
        AcikMi = false;
    }
    public void BilgileriGoster()
    {
        string durum = AcikMi ? "Açık" : "Kapalı";
        Console.WriteLine($"ID: {Kimlik}, Ad: {Ad}, Tür: {Tur}, Durum: {durum}");
    }
}

class program
{
    static void Main() 
    {
        List<Cihaz> cihazlar = new List<Cihaz>
      {
          new Cihaz(1, "Salon Lambası",CihazTuru.Lamba),
          new Cihaz(2,"Salon Kliması", CihazTuru.Klima),
          new Cihaz(3,"Giriş Kamerası", CihazTuru.GuvenlikSistemi)
      };

        while (true)
        {
            Console.WriteLine("\n--- AKILLI EV CİHAZ YÖNETİMİ ---");
            Console.WriteLine("1. Cihazları Listele");
            Console.WriteLine("2. Yeni Cihaz Ekle");
            Console.WriteLine("3. Cihaz Aç");
            Console.WriteLine("4. Cihaz Kapat");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "0") break;

            switch (secim)
            {
                case "1":
                    Console.WriteLine("\n--- Kayıtlı Cihazlar ---");
                    foreach (Cihaz cihaz in cihazlar)
                    {
                        cihaz.BilgileriGoster();
                    }
                    break;

                case "2":
                    Console.Write("Cihaz Kimliği (ID): ");
                    if (!int.TryParse(Console.ReadLine(), out int yeniId))
                    {
                        Console.WriteLine("Hata: Geçerli bir sayısal kimlik giriniz.");
                        break;
                    }

                    
                    bool idVarMi = false;
                    foreach (Cihaz cihaz in cihazlar)
                    {
                        if (cihaz.Kimlik == yeniId)
                        {
                            idVarMi = true;
                            break;
                        }
                    }

                    if (idVarMi)
                    {
                        Console.WriteLine("Hata: Bu kimliğe sahip bir cihaz zaten mevcut");
                        break;
                    }

                    Console.Write("Cihaz Adı: ");
                    string yeniAd = Console.ReadLine();

                    Console.WriteLine("Cihaz Türü Seçin (0: Lamba, 1: Klima, 2: GuvenlikSistemi): ");
                    if (!int.TryParse(Console.ReadLine(), out int turSecim) || !Enum.IsDefined(typeof(CihazTuru), turSecim))
                    {
                        Console.WriteLine("Hata: Geçersiz cihaz türü seçimi!");
                        break;
                    }

                    CihazTuru secilenTur = (CihazTuru)turSecim;
                    cihazlar.Add(new Cihaz(yeniId, yeniAd, secilenTur));
                    Console.WriteLine("Cihaz başarıyla eklendi.");
                    break;

                case "3":
                    Console.Write("Açılacak Cihazın Kimliği (ID): ");
                    if (int.TryParse(Console.ReadLine(), out int acilacakId))
                    {
                        
                        Cihaz bulunacakCihaz = null;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == acilacakId)
                            {
                                bulunacakCihaz = cihaz;
                                break;
                            }
                        }

                        if (bulunacakCihaz == null)
                        {
                            Console.WriteLine("Hata: Belirtilen kimlikte bir cihaz bulunamadı!");
                        }
                        else
                        {
                            bulunacakCihaz.Ac();
                            Console.WriteLine($"{bulunacakCihaz.Ad} açıldı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hata: Geçersiz kimlik formatı.");
                    }
                    break;

                case "4":
                    Console.Write("Kapatılacak Cihazın Kimliği (ID): ");
                    if (int.TryParse(Console.ReadLine(), out int kapanacakId))
                    {
                       
                        Cihaz bulunacakCihaz = null;
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            if (cihaz.Kimlik == kapanacakId)
                            {
                                bulunacakCihaz = cihaz;
                                break;
                            }
                        }

                        if (bulunacakCihaz == null)
                        {
                            Console.WriteLine("Hata: Belirtilen kimlikte bir cihaz bulunamadı!");
                        }
                        else
                        {
                            bulunacakCihaz.Kapali();
                            Console.WriteLine($"{bulunacakCihaz.Ad} kapatıldı.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hata: Geçersiz kimlik formatı.");
                    }
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        }

    }
}
