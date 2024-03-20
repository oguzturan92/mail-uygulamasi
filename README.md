# Mail Uygulaması
Bu mail uygulaması, login işlemi gerektirir. Kayıt olunan e-mail adresi ile, mail modülü kullanılabilir. 
Uygulama içinde mailleşmeyi sağlar.
Sayfalama yapıldı.
Mail gelen kutusu, giden kutusu, önemli mailleri işaretleme, mailleri taslak olarak kaydetme ve daha sonra gönderebilme, silinen kutusuna taşıma ve silinen kutusundan silme ya da geri yükleme gibi özellikleri içerir.
Sisteme giriş yapmış kullanıcıya gelen ve bu kullanıcının gönderdiği mailler görüntülenir.
Kullanıcı ve mail tablosu mevcuttur.
Mail işlemleri için başka bir tablo kullanılmamış olup, gelen kutusu, gönderilen vs kategorize etmek için, mail'e property tanımlamaları yapılmıştır.

# Mail Tablosu
    public class Mail
    {
        public int MailId { get; set; }
        public int MailKimdenMailId { get; set; }
        public string MailKimeMailName { get; set; }
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public DateTime MailDate { get; set; }
        public bool MailRead { get; set; }
        public bool MailImportant { get; set; }
        public bool MailDraft { get; set; }
        public bool MailTrash { get; set; }
    }

# Örnek Sorgular
Gelen mailleri almak için örnek linq sorgusu : Mails = _mailService.GetAll().Where(i => i.MailKimeMailName.ToLower() == user.Email.ToLower() && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList();

Önemli olarak işaretlenmiş mailleri almak için örnek linq sorgusu : Mails = _mailService.GetAll().Where(i => (i.MailKimeMailName.ToLower() == user.Email.ToLower() || i.MailKimdenMailId == user.Id) && i.MailImportant && !i.MailTrash).OrderByDescending(i => i.MailDate).ToList();

# Giriş
![Ekran görüntüsü 2024-03-20 131942](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/3313aa8a-b32f-461e-a0f6-8c4911be4dcd)

# Gelen Kutusu
![Ekran görüntüsü 2024-03-20 132034](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/25c4713e-cbcd-4970-a179-e516a4f45e16)

# Giden Kutusu
![Ekran görüntüsü 2024-03-20 132042](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/1841abfd-963c-4ca7-88ae-2195bbb040cb)

# Önemli Kutusu
![Ekran görüntüsü 2024-03-20 132050](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/73cff74b-9e02-491b-8e6d-2a3257f56cb3)

# Taslaklar
![Ekran görüntüsü 2024-03-20 132056](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/7baef635-9434-48a3-871b-35eb661e4dac)

# Silinmiş Kutusu
![Ekran görüntüsü 2024-03-20 132103](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/7070378c-66c6-49c3-b401-2f6de30dd84d)

# Yeni Mail
![Ekran görüntüsü 2024-03-20 132113](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/478763df-188c-43d6-a8f4-5d2b8fccb74d)

# Mail Detay
![Ekran görüntüsü 2024-03-20 132127](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/f0fc407b-9692-468c-a728-f0702530835c)

# Maili Silinmiş Kutusundan Geri Yükleme
![Ekran görüntüsü 2024-03-20 132137](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/68b39a8d-faff-4026-9ce4-8874727e1197)

# Silinmiş Kutusundan Maili Tamamen Silme
![Ekran görüntüsü 2024-03-20 132151](https://github.com/oguzturan92/mail-uygulamasi/assets/157590022/4cab8433-f294-48b3-99b2-8f7250527820)
