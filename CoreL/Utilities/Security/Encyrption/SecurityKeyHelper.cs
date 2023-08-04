using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Utilities.Security.Encyrption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey/*appsetting.json*/)
        {
            /*Simetrik ve olamyanı araştır...*/
            return new SymmetricSecurityKey( Encoding.UTF8.GetBytes(securityKey));

        }
    }
}
