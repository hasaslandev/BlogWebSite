using Business.Abstract;
using Business.Constants;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContackService
    {
        IContactDal _contactDal;
        private readonly IConfiguration _config;

        public ContactManager(IContactDal contactDal,IConfiguration config)
        {
            _contactDal = contactDal;
            _config = config;
        }

        public IResult Add(Contact c)
        {
            _contactDal.AddAsync(c);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(int contactId)
        {
            Contact contact = _contactDal.Find(x => x.ContactID == contactId);
            _contactDal.DeleteAsync(contact);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(), Messages.BlogsListed);

        }
        public IDataResult<Contact> GetContactDetails(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(p => p.ContactID == id));

        }

        public IResult SendEmail(Contact request)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Hasan", "aslanlar531@gmail.com"));
            email.To.Add(new MailboxAddress("Aslan",request.MailTo));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Message };
            using var smtp = new SmtpClient()
            {
                CheckCertificateRevocation = false
            };
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailName").Value,_config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            return new SuccessResult("Mail Başarılı Bir Şekilde Gönderildi");
        }

        public IResult Update(Contact contact)
        {
            Contact updateIsContact =_contactDal.Find(x=>x.ContactID == contact.ContactID);
            updateIsContact.Subject = contact.Subject;
            updateIsContact.SurName = contact.SurName;
            updateIsContact.Name = contact.Name;
            updateIsContact.Message = contact.Message;
            updateIsContact.MessageDate = contact.MessageDate;
            updateIsContact.MailTo = contact.MailTo;
            updateIsContact.Mail = contact.Mail;
            _contactDal.UpdateAsync(contact);
            return new SuccessResult(Messages.ContactUpdate);

        }
    }
}
