using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using CoreL.Utilities.Security.JWT;
using Entity.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Admin> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Admin> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Admin admin);
    }
}
