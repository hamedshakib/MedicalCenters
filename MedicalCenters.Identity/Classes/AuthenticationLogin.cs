using MedicalCenters.Identity.Contracts;
using MedicalCenters.Identity.Models.Domains;
using MedicalCenters.Identity.Models.DTOs;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Classes
{
    public class AuthenticationLogin(IIdentityUnitOfWork identityUnitOfWork)
    {
        public async Task<LoginResultDto> LoginValidate(LoginDto loginDto)
        {
            LoginResultDto loginResultDto = null;
            User? user = await identityUnitOfWork.AthenticationRepository.FindUser(loginDto.Username);
            if (user == null)
            {
                loginResultDto= new LoginResultDto { IsFindUser = false ,LoginUser = null};
                return loginResultDto;
            }

            if(PasswordValidate(loginDto.Password,user))
            {
                LoginUserModel loginUserModel = new LoginUserModel(user.Id, user.UserName);
                loginResultDto = new LoginResultDto { IsFindUser = true, LoginUser = loginUserModel };
                return loginResultDto;
            }
            loginResultDto = new LoginResultDto { IsFindUser = true, LoginUser = null };
            return loginResultDto;
        }

        private bool PasswordValidate(string loginPassword,User user)
        {
            var hasher = new PasswordHasher(user.HashAlgorithmType,user.PeaperType);
            string loginHashedPassword = hasher.Hash(loginPassword, user.Salt);

            return loginHashedPassword.Equals(user.HashedPassword);
        }


    }
}
