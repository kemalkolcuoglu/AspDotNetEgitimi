using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IslemKatmani.Helper
{
    public static class SMSHelper
    {
        private const string usercode = "kullaniciadi";
        private const string password = "sifreniz";

        public static bool SMSGonder(string gsmno, string mesajBasligi, string mesaj)
        {
            string html = string.Empty;
            string url = @$"https://api.netgsm.com.tr/sms/send/get/?usercode={usercode}&password={password}&gsmno={gsmno}&message={mesaj}&msgheader={mesajBasligi}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            int sonuc = Convert.ToInt32(html);

            if (sonuc < 3)
                return true;
            return false;
        }
    }
}
