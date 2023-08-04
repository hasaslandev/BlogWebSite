using CoreL.Utilities.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Entities.Concrete
{
    public class Admin : IEntity
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Degree { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public bool FreelanceEnable { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
