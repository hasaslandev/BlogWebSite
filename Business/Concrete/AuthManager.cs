using Business.Abstract;
using Business.Constants;
using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using CoreL.Utilities.Security.Hashing;
using CoreL.Utilities.Security.JWT;
using Entity.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAdminService _adminService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IAdminService adminService, ITokenHelper tokenHelper)
        {
            _adminService = adminService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Admin> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                Birthday = DateTime.Now,
                City = "seydi",
                FreelanceEnable = true,
                Degree = "Lisans",
                Phone = "1124412421",
            };
            _adminService.Add(admin);
            return new SuccessDataResult<Admin>(admin, /*Messages.UserRegistered*/"Kayıt Oldu");
        }

        public IDataResult<Admin> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _adminService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Admin>(/*Messages.UserNotFound*/"Kullanıcı Bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Admin>(/*Messages.PasswordError*/"Parola Hatası");
            }

            return new SuccessDataResult<Admin>(userToCheck, /*Messages.SuccessfulLogin*/ "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_adminService.GetByMail(email) != null)
            {
                return new ErrorResult(/*Messages.UserAlreadyExists*/"Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Admin admin)
        {
            var claims = _adminService.GetClaims(admin);
            var accessToken = _tokenHelper.CreateToken(admin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, /*Messages.AccessTokenCreated*/"Token Yaratıldı");
        }
    }
}
