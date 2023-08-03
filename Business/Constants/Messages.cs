using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages /*Newlememek için static oluşturduk*/
    {
        public static string BlogAdded = "Ürün Eklendi";
        public static string BlogContentInvalid = "Ürün içeriği geçersiz...";
        public static string MaintenanceTime="Sistem bakımda";
        public static string BlogsListed="Ürünler listelendi";
        public static string AboutCountOfBlogError="Bir Blogda en fazla 10 hakkında yazısı olabilir";
        public static string AboutNameAlreadyExists="Bu isimde zaten bir kayıt var";
        public static string BlogLimitExceded="Blog limiti aşıldığı için yeni about eklenemiyor";
    }
}
