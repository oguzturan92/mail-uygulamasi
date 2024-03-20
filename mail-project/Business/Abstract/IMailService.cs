using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IMailService
    {
        Mail GetById(int id);
        List<Mail> GetAll();
        void Create(Mail entity);
        void Update(Mail entity);
        void Delete(Mail entity);
    }
}