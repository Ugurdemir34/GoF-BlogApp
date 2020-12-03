using GoF.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Admin admin, List<OperationClaim> operationClaims);
    }
}
