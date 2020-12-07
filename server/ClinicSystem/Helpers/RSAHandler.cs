using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ClinicSystem.Helpers
{
    public class RSAHandler
    {
        private readonly string _privateKeyPath = "private_key.xml";
        private readonly string _publicKeyPath = "public_key.xml";
        private readonly RSAParameters _publicKey, _privateKey;
        private static RSACryptoServiceProvider _cryptoServiceProvider = new RSACryptoServiceProvider(2048);
        public RSAHandler()
        {
            _publicKey = GetKey(_publicKeyPath);
            _privateKey = GetKey(_privateKeyPath);
        }

        private RSAParameters GetKey(string path)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(RSAParameters));
                XmlReader xmlReader = new XmlNodeReader(xmlDocument.DocumentElement);
                var key = (RSAParameters)xmlSerializer.Deserialize(xmlReader);
                return key;
            }
            catch
            {

                using (var stringWriter = new StringWriter())
                {
                    var key = _cryptoServiceProvider.ExportParameters(true);
                    var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
                    xmlSerializer.Serialize(stringWriter, key);
                    SaveKey(stringWriter.ToString(), path);
                    return key;
                }

            }
        }

        private void SaveKey(string key, string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(key);
            xmlDocument.Save(path);
        }

        public string Encrypt(string text)
        {
            _cryptoServiceProvider = new RSACryptoServiceProvider();
            _cryptoServiceProvider.ImportParameters(_publicKey);
            var bytes = Encoding.UTF8.GetBytes(text);
            var encryptedData = _cryptoServiceProvider.Encrypt(bytes, true);
            return Convert.ToBase64String(encryptedData);

        }

        public string Decrypt(string cipher)
        {
            var bytes = Convert.FromBase64String(cipher);
            _cryptoServiceProvider.ImportParameters(_privateKey);
            var textBytes = _cryptoServiceProvider.Decrypt(bytes, true);
            return Encoding.UTF8.GetString(textBytes);

        }
    }
}
