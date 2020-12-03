using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Core.Entities.Concrete
{
    public class AdminOperationClaim
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
