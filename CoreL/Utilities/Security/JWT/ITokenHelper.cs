using CoreL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Admin admin, List<OperationClaim> operationClaims);
    }
}
/*
Eğer doğruysa bu operasyon çalışacak ilgili kullan ıcı için veritabanına gidecek
bu kullanıcının CLaimlerini buluşturacak orda bir JWT üretecek onları buraya vercek 
 
*/
