using ClinicSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly RSAHandler _rsa;

        public PasswordService()
        {
            _rsa = new RSAHandler();
        }

        public string Hash(string text)
        {
            return _rsa.Encrypt(text);
        }

        public bool IsHashEqual(string text, string hashedText)
        {
            var decryptedHash = _rsa.Decrypt(hashedText);
            return decryptedHash == text;
        }
    }
}
