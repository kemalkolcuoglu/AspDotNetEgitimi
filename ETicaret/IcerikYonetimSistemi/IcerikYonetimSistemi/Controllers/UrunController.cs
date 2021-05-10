using IcerikYonetimSistemi.Models;
using IslemKatmani;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Controllers
{
    public class UrunController : Controller
    {
        private readonly ILogger<UrunController> _logger;
        private readonly UrunService _urunIslemleri;
        private readonly FavoriListesiService _favoriIslemleri;
        private readonly KategoriService _kategoriIslemleri;
        private readonly SepetService _sepetIslemleri;
        private readonly UrunYorumService _urunYorumIslemleri;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOptions<IyzicoModel> _configuration;
        private Iyzipay.Options _options;

        public UrunController(
            ILogger<UrunController> logger,
            IOptions<IyzicoModel> configuration,
            UrunService urunIslemleri,
            FavoriListesiService favoriIslemleri,
            KategoriService kategoriIslemleri,
            SepetService sepetIslemleri,
            UrunYorumService urunYorumIslemleri,
            UserManager<IdentityUser> userManager
        )
        {
            _logger = logger;
            _configuration = configuration;
            _urunIslemleri = urunIslemleri;
            _urunYorumIslemleri = urunYorumIslemleri;
            _favoriIslemleri = favoriIslemleri;
            _sepetIslemleri = sepetIslemleri;
            _userManager = userManager;
            _kategoriIslemleri = kategoriIslemleri;

            _options = new Iyzipay.Options
            {
                ApiKey = _configuration.Value.ApiKey,
                BaseUrl = _configuration.Value.BaseUrl,
                SecretKey = _configuration.Value.SecretKey
            };
        }

        public string FakeData()
        {
            Random rnd = new Random();
            var userID = _userManager.GetUserId(this.User);
            Kategori kategori = new Kategori()
            {
                Baslik = "Erkek Giyim",
                Parent = 0,
                Renk = "ff0000",
                EkAlan = null
            };
            _kategoriIslemleri.KuyrugaEkle(kategori);
            for (int i = 0; i < 20; i++)
            {
                Urun urun = new Urun()
                {
                    Baslik = Faker.StringFaker.Alpha(15),
                    Beden = VarlikKatmani.Tanimlama.Beden.M,
                    Birim = VarlikKatmani.Tanimlama.Birim.Adet,
                    KisaAciklama = Faker.TextFaker.Sentence(),
                    Detay = Faker.TextFaker.Sentences(2),
                    Etkin = true,
                    Fiyat = rnd.Next(25, 400),
                    Gorsel = "urun.jpg",
                    IndirimliFiyat = rnd.Next(25, 300),
                    Kategori = kategori,
                    Marka = Faker.CompanyFaker.Name(),
                    Miktar = rnd.Next(20, 120),
                    SEODescription = Faker.StringFaker.Alpha(45),
                    SEOTitle = Faker.StringFaker.Alpha(15),
                    EkAlan = null,
                };
                _urunIslemleri.KuyrugaEkle(urun);
                for (int j = 0; j < 10; j++)
                {
                    UrunYorum urunYorum = new UrunYorum()
                    {
                        KullaniciId = userID,
                        Metin = Faker.TextFaker.Sentence(),
                        Puan = Convert.ToSByte(rnd.Next(1, 5)),
                        Tarih = DateTime.Now,
                        Urun = urun
                    };
                    _urunYorumIslemleri.KuyrugaEkle(urunYorum);
                }
            }

            int sonuc = _urunIslemleri.Kaydet();
            return "İşlem Gerçekleşti";
        }

        public IActionResult Liste()
        {
            List<Urun> urunler = _urunIslemleri.ListeFiltre(x => x.Etkin);
            return View(urunler);
        }

        public IActionResult Urun(int id)
        {
            Urun urun = _urunIslemleri.Sorgu()
                                 .Include(x => x.UrunYorum).ThenInclude(y => y.Kullanici)
                                 .Include(x => x.UrunGaleri)
                                 .FirstOrDefault(x => x.Etkin && x.ID == id);

            if (urun.UrunYorum != null && urun.UrunYorum.Count != 0)
                ViewData["Skor"] = urun.UrunYorum.Average(x => x.Puan);

            List<Urun> urunler = _urunIslemleri.Sorgu()
                                               .Include(x => x.UrunYorum)
                                               .OrderByDescending(x => x.UrunYorum.Max(y => y.Puan))
                                               .Take(3).ToList();
            ViewData["Onerilenler"] = urunler;
            ViewData["UrunID"] = urun.ID;

            return View(urun);
        }

        [HttpPost]
        public IActionResult YorumEkle(UrunYorum yorum)
        {
            try
            {
                var userID = _userManager.GetUserId(this.User);
                yorum.KullaniciId = userID;
                yorum.Tarih = DateTime.Now;

                int sonuc = _urunYorumIslemleri.Ekle(yorum);
            }
            catch (Exception)
            {
            }
            return RedirectToAction(nameof(Urun), new { id = yorum.UrunId });
        }

        [HttpPost]
        public IActionResult FavoriEkle(int id)
        {
            int sonuc = 0;
            var userID = _userManager.GetUserId(this.User);
            FavoriListesi _fl = _favoriIslemleri.Bul(x => x.UrunId == id && x.KullaniciId == userID);
            if (_fl == null)
            {
                FavoriListesi fl = new FavoriListesi()
                {
                    UrunId = id,
                    KullaniciId = userID
                };
                sonuc = _favoriIslemleri.Ekle(fl);
                if (sonuc >= 1)
                    return Json(true);
            }
            sonuc = _favoriIslemleri.Sil(_fl);
            return Json(false);
        }

        [HttpPost]
        public IActionResult SepeteEkle(int id, [FromBody] int miktar)
        {
            bool deger = false;
            int sonuc = 0;
            var userID = _userManager.GetUserId(this.User);
            try
            {
                Sepet sepet = _sepetIslemleri.Bul(x => x.UrunId == id && x.KullaniciId == userID);
                if (sepet == null)
                {
                    Sepet _sepet = new Sepet()
                    {
                        KullaniciId = userID,
                        UrunId = id,
                        Miktar = miktar
                    };
                    sonuc = _sepetIslemleri.Ekle(_sepet);
                    if (sonuc >= 1)
                        deger = true;
                }
                else
                {
                    sepet.Miktar += miktar;
                    sonuc = _sepetIslemleri.Guncele(sepet);
                    if (sonuc >= 1)
                        deger = true;
                }
            }
            catch (Exception)
            {

            }
            return Json(deger);
        }

        public IActionResult OdemeYap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OdemeYap(OdemeVM odemeVM)
        {
            IdentityUser user = await _userManager.GetUserAsync(this.User);
            List<Sepet> sepet = await _sepetIslemleri.Sorgu()
                                                     .Include(x => x.Urun)
                                                     .ThenInclude(y => y.Kategori)
                                                     .Where(x => x.KullaniciId == user.Id).ToListAsync();

            decimal toplamTutar = sepet.Sum(x => x.Tutar);
            int basketId = sepet.Max(x => x.Id);

            CreatePaymentRequest createPaymenRequest = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                Price = toplamTutar.ToString(),
                PaidPrice = toplamTutar.ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = $"SPT-{basketId}",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = odemeVM.KartBilgileri.KartSahibi,
                CardNumber = odemeVM.KartBilgileri.KartNumarasi,
                ExpireMonth = odemeVM.KartBilgileri.SonTarihAy.ToString(),
                ExpireYear = odemeVM.KartBilgileri.SonTarihYil.ToString(),
                Cvc = odemeVM.KartBilgileri.GuvenlikKodu,
                RegisterCard = 0
            };
            createPaymenRequest.PaymentCard = paymentCard;

            Buyer buyer = new Buyer
            {
                Id = user.Id,
                Name = odemeVM.Kisi.Ad,
                Surname = odemeVM.Kisi.Soyad,
                GsmNumber = odemeVM.Kisi.TelefonNo,
                Email = odemeVM.Kisi.Email,
                IdentityNumber = odemeVM.Kisi.TCKNO,
                RegistrationAddress = odemeVM.FaturaAdresi.Adres,
                Ip = HttpContext.Connection.RemoteIpAddress.ToString(),
                City = odemeVM.FaturaAdresi.Il,
                Country = "Turkey",
                ZipCode = odemeVM.FaturaAdresi.PostaKodu
            };
            createPaymenRequest.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = odemeVM.Kisi.Ad,
                City = odemeVM.FaturaAdresi.Il,
                Country = "Turkey",
                Description = odemeVM.FaturaAdresi.Adres,
                ZipCode = odemeVM.FaturaAdresi.PostaKodu
            };
            createPaymenRequest.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = $"{odemeVM.Kisi.Ad} {odemeVM.Kisi.Soyad}",
                City = odemeVM.FaturaAdresi.Il,
                Country = "Turkey",
                Description = odemeVM.FaturaAdresi.Adres,
                ZipCode = odemeVM.FaturaAdresi.PostaKodu
            };
            createPaymenRequest.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var item in sepet)
            {
                BasketItem firstBasketItem = new BasketItem
                {
                    Id = $"URN-{item.Urun.ID}",
                    Name = item.Urun.Baslik,
                    Category1 = item.Urun.Kategori.Baslik,
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = item.Urun.IndirimliFiyat.ToString()
                };
                basketItems.Add(firstBasketItem);
            }
            createPaymenRequest.BasketItems = basketItems;
            createPaymenRequest.CallbackUrl = "https://localhost:4545/Urun/Sonuc";
            ViewData["Request"] = createPaymenRequest;
            Payment payment = Payment.Create(createPaymenRequest, _options);

            return View(odemeVM);
        }

        public IActionResult Sonuc()
        {
            // Veritabanına Kayıt İşlemleri
            // Kargo Hareket bilgisi ekleme
            // Kullanıcıya SMS ve Email gönderilmesi
            var createPaymenRequest = ViewData["Request"] as CreatePaymentRequest;
            return null;
        }
    }
}
