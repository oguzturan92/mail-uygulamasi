using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Entity.Concrete;

namespace Data.Concrete.EfCore
{
    public class MailDal : GenericDal<Mail>, IMailDal
    {
        
    }
}