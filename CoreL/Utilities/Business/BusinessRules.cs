using CoreL.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params verdiğiniz zaman istediğiniz kadar IResult verebiliriz(istediğiniz kadar parametreyi gönderebiliriz array haline getirir)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic; //başarısız olanları business'a bu logic hatalı diye haber ediyoruz
                }
            }
            return null;

        }
    }
}
