using MedicalCenters.Identity.Basics;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NetTopologySuite.Algorithm;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Classes
{
    public class PasswordHasher
    {
        private int _hashAlgorithmType, _peaperType;
        public PasswordHasher(int hashAlgorithmType, int peaperType)
        {
            _peaperType = peaperType;
            _hashAlgorithmType = hashAlgorithmType;
        }
        public byte[] Hash(string password, byte[] salt)
        {
            byte[] finialSalt = PeaperBasic.GetPeaperData(_peaperType).Concat(salt).ToArray(); ;
            byte[] hashed = KeyDerivation.Pbkdf2(
                            password: password!,
                            salt: finialSalt,
                            prf: _GetAlgorithm(),
                            iterationCount: 100000,
                            numBytesRequested: 512 / 8);
            
            return hashed;
        }

        private KeyDerivationPrf _GetAlgorithm() => _hashAlgorithmType switch
        {
            0 => KeyDerivationPrf.HMACSHA512,
        };

        public byte[] GenerateNewSalt()
        {
            const int keySize = 64;
            var salt = RandomNumberGenerator.GetBytes(keySize);
            return (byte[])salt;
        }
    }
}
