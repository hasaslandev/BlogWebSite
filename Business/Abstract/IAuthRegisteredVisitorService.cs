using CoreL.Concrete;
using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using CoreL.Utilities.Security.JWT;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthRegisteredVisitorService
    {
        IDataResult<RegisteredVisitor > Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<RegisteredVisitor> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(RegisteredVisitor registeredVisitor);
    }
}
