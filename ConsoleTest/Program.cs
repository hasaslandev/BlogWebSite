using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlogManager blogManager = new BlogManager(new EfBlogDal());
            var result = blogManager.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.BlogTitle);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}