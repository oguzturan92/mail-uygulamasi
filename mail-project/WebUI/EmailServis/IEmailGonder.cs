using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.EmailServis
{
    public interface IEmailGonder
    {
        // Email göndermek için 3 seçenek var
        // smtp ile gönderim : gmail'in ya da hotmail'in servsileri ile gönderim
        // smtp ile gönderim : aldığımız hosting içinde bulunan smtp ayarlarını kullanarak gönderim
        // api ile gönderim : ücretli ya da ücretsiz apiler aracılığıyla gönderim

        // NOT : Yukarıdaki gönderim şekillerinden hangileri ile çalışacaksak, appsettings.json dosyası içindeki mail ayarlarını da ona göre güncellememiz gerekecek.

        Task SendEmailAsync(string email, string subject, string htmlMessage); // Oluşturduğumuz bu metot ile parantez içindeki bilgileri göndereceğiz.
    }
}