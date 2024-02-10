using MedicalCenters.Identity.Basics;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NetTopologySuite.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Identity.Classes
{
    internal class PasswordHasher
    {
        private int _hashAlgorithmType, _peaperType;
        internal PasswordHasher(int hashAlgorithmType, int peaperType)
        {
            _peaperType = peaperType;
            _hashAlgorithmType = hashAlgorithmType;
        }
        internal string Hash(string password, byte[] salt)
        {
            byte[] finialSalt = PeaperBasic.GetPeaperData(_peaperType).Concat(salt).ToArray(); ;
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password!,
                            salt: finialSalt,
                            prf: _GetAlgorithm(),
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));
            return hashed;
        }

        private KeyDerivationPrf _GetAlgorithm() => _hashAlgorithmType switch
        {
            0 => KeyDerivationPrf.HMACSHA512,
        };
    }
}
