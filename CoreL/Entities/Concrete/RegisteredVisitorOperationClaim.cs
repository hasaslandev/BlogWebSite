using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Entities.Concrete
{
    public class RegisteredVisitorOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int RegisteredVisitorId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
