using System;
using Xunit;
using ClinicSystem.Services;
using ClinicSystem.Helpers;

namespace ClinicSystem.Tests
{
    public class RSATest
    {
        [Theory]
        [InlineData("lekarz2", "lekarz2", true)]
        [InlineData("test123", "test321", false)]
        public void IsPasswordCorrect(string password, string verified, bool isEqual)
        {
            var passwordService = new PasswordService();
            var hash = passwordService.Hash(verified);
            Assert.Equal(isEqual, passwordService.IsHashEqual(password, hash));
        }

        [Fact]
        public void EncryptText()
        {
            var passwordService = new PasswordService();
            var rsaHandler = new RSAHandler();
            var text = "Najmniejszy przezuwacz swiata";
            var hash = passwordService.Hash(text);
            var decryptedHash = rsaHandler.Decrypt(hash);
            Assert.Equal(text, decryptedHash);
        }
    }
}
