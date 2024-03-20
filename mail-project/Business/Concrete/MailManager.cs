using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class MailManager : IMailService
    {
        private IMailDal _mailDal;
        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        // METOTLAR
        public void Create(Mail entity)
        {
            _mailDal.Create(entity);
        }

        public void Delete(Mail entity)
        {
            _mailDal.Delete(entity);
        }

        public List<Mail> GetAll()
        {
            return _mailDal.GetAll().ToList();
        }

        public Mail GetById(int id)
        {
            return _mailDal.GetById(id);
        }

        public void Update(Mail entity)
        {
            _mailDal.Update(entity);
        }
    }
}