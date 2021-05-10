using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace IslemKatmani.Helper
{
    // Bu C# dosyası içerisinde SMTP (Simple Mail Transfer Protocol) ile mail atılma işleminin gerçekleştirilmesi kodlanmıştır.

    /*
     * ************************************************
     *           Örnek Web.Config bilgileri           *
     * ************************************************
     *   <add key="MailHost" value="smtp.gmail.com"/> *
     *   <add key="MailPort" value="587"/>            *
     *   <add key="MailUser" value="xxxx@gmail.com"/> *
     *   <add key="MailPass" value="1111"/>           *
     * ************************************************
     */
    public static class EmailHelper
    {
        private const string MailHost = "smtp.gmail.com";
        private const int MailPort = 587;
        private const string MailUser = "xxxx@gmail.com";
        private const string MailPass = "1111";

        /// <summary>
        ///     Mail gönderim işleminin gerçekleştiği metottur.
        /// </summary>
        /// <param name="body">Mail gövdesi. HTML kodları içerebilir.</param>
        /// <param name="to">Maili alacak adreslerin listesi. String tipindedir.</param>
        /// <param name="subject">Mailin Konusudur. Kullanıcılara bu başlık ile maili görüntülenir.</param>
        /// <param name="isHtml">Eğer ki gövdede(body) HTML kodları yer alıyorsa bu değeri True yapmak gerekmektedir.</param>
        /// <returns>Komutlarda kullanılmak üzere XXXParameter dizisi tipinde değer döndürür</returns>
        public static bool SendMail(string body, string to, string subject, bool isHtml = true)
        {
            return SendMail(body, new List<string> { to }, subject, isHtml);
        }

        /// <summary>
        ///     Mail gönderim işleminin gerçekleştiği metottur.
        /// </summary>
        /// <param name="body">Mail gövdesi. HTML kodları içerebilir.</param>
        /// <param name="to">Maili alacak adreslerin listesi. List tipindedir</param>
        /// <param name="subject">Mailin Konusudur. Kullanıcılara bu başlık ile maili görüntülenir.</param>
        /// <param name="isHtml">Eğer ki gövdede(body) HTML kodları yer alıyorsa bu değeri True yapmak gerekmektedir.</param>
        /// <returns>Komutlarda kullanılmak üzere XXXParameter dizisi tipinde değer döndürür</returns>
        public static bool SendMail(string body, List<string> to, string subject, bool isHtml = true)
        {
            bool result = false; // Geri dönüş değerimiz.

            try // Oluşabilecek herhangi bir istisna durumları için try-catch blokları kullanılması tavsiye edilir.
            {
                // MailMessage nesnesi kodlar üzerinde mail göndermemiz için kullanılır. System.Net.Mail ad uzayında yer almaktadır.
                var message = new MailMessage
                {
                    // MailAdress nesnesi gönderen için oluşturulur.
                    // Maili gönderecek adres bilgisi web.config'den alınıyor.
                    From = new MailAddress(MailUser)
                };

                // Mail gönderilecek adreslerin herbiri MailAdress nesnesi olarak oluşturuluyor.
                to.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x));
                });

                // Gelen Parametreler nesne içerisine yazılır.
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;

                // Bu metot SMTP(Simple Mail Transfer Protocol) ile mail gönderimini içermektedir. O yüzden SMTP Client nesnesi ile uzaktaki smtp host ve port değerleri alınır.
                using (var smtp = new SmtpClient(MailHost, MailPort))// Web.config dosyasından host ve port değerleri alınır.
                {
                    smtp.EnableSsl = true; // SSL etkinse true değeri verilmelidir.

                    // Aşağıda yorum satırı olarak eklenmiş olan iki satır Yandex.Mail kullanan geliştiriciler içindir.
                    // Yandex üzerinden mail işlemlerinde bu iki satıra ihtiyacınız olacaktır ve eklemezseniz mailler gönderilmez.
                    //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    //smtp.UseDefaultCredentials = false;

                    smtp.Credentials =
                    new NetworkCredential(
                        MailUser, // Maili gönderecek hesabın bilgileri alınır.
                        MailPass); // MailUser: E-Posta Adresi, MailPass: E-Posta adresinin şifresi

                    smtp.Send(message); // Mailin gönderilmesi bu metotla gerçekleşir. Geri dönüş tipi yoktur ve iletilmezse hata fırlatır.
                    result = true; // Hata oluşmaz ise mail gönderilmiştir ve bu metodun geri dönüşünün başarılı olduğu bildirilir.
                }
            }
            catch (Exception exp)
            {
                // Kendi özel istisna durumlarınızı yazabilirsiniz.
                // Örn: Hata oluşunca Mail gönderilmesi vb.
                Console.Write(exp.Message);
            }

            return result;
        }
    }
}
