using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreL.Utilities.Helpers;
using CoreL.Utilities.Helpers.GuidHelper;

namespace CoreL.Utilities.Helpers.FileHelper
{
    public class FileHeplerManager:IFileHelper
    {
        public string Upload(IFormFile file, string root)
        {
            //Dosya Uzunluğu 0 ise boş değeri döndür

            if (file != null)
            {
                if (file.Length > 0)
                {
                    //dizinin olup olmadığını kontrol ediyor, yolu oluşturacak.
                    if (!Directory.Exists(root))
                    {

                        Directory.CreateDirectory(root);
                    }
                    //uzantı, uzantı değişkenleri dosya adı olarak tanımlanır
                    string extension = Path.GetExtension(file.FileName);

                    //oluşturduğumuz rastgele dosya yolunun sistemi hangi yönde kullanacağı bu şekilde safe.ve guid için jpeg de bu rasgele sayılar tanımlandı.
                    string guid = GuidHelper.GuidHelper.CreateGuid();
                    //daha sonra filepath, toplam ad ve hangi yol olarak tanımlandı
                    string filePath = guid + extension;

                    //IDısposable pattern ile oluşturulan root ve filepath
                    //bu, bunu yaptıktan sonra çöp toplayıcı ile silineceği anlamına gelir
                    using (FileStream fileStream = File.Create(root + filePath))
                    {

                        file.CopyTo(fileStream);

                        fileStream.Flush();

                        return filePath;
                    }
                }

            }
            return null;
        }
        //dosya yolu ICarImageManager'dan geliyor
        public void Delete(string filePath)
        {//filepath yolu aynı dosyaya sahipse filePath'i silebiliriz
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public string Update(IFormFile file, string filePath, string root)
        {
            //öncelikle dosyanın var olup olmadığını kontrol ediyoruz, önce onu sildiyse sonra yeni dosyayı yol(root) ile yükleyin
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }
    }
}
