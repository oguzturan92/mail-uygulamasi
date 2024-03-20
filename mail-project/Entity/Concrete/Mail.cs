using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
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
}