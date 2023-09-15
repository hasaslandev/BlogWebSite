using Business.Abstract;
using CoreL.Concrete;
using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using CoreL.Utilities.Security.Hashing;
using CoreL.Utilities.Security.JWT;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthRegisteredVisitorManager : IAuthRegisteredVisitorService
    {
        private IRegisteredVisitorService _registeredVisitorService;
        private IRVisitorsTokenHelper _tokenHelper;

        public AuthRegisteredVisitorManager(IRegisteredVisitorService registeredVisitorService, IRVisitorsTokenHelper tokenHelper)
        {
            _registeredVisitorService = registeredVisitorService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<RegisteredVisitor> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var registeredVisitor = new RegisteredVisitor
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };
            _registeredVisitorService.Add(registeredVisitor);
            return new SuccessDataResult<RegisteredVisitor>(registeredVisitor,"Kayıt Oldu");
        }

        public IDataResult<RegisteredVisitor> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _registeredVisitorService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<RegisteredVisitor>("Kullanıcı Bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<RegisteredVisitor>("Parola Hatası");
            }

            return new SuccessDataResult<RegisteredVisitor>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_registeredVisitorService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(RegisteredVisitor registeredVisitor)
        {
            var claims = _registeredVisitorService.GetClaims(registeredVisitor);
            var accessToken = _tokenHelper.CreateToken(registeredVisitor, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Yaratıldı");
        }
    }

}
