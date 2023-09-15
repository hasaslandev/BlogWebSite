using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Concrete
{
    public class RegisteredVisitor:IEntity
    {
        public int RegisteredVisitorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
