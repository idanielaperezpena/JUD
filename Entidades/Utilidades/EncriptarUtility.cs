using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilidades
{
    public class EncriptarUtility
    {
        private byte[] _secretKey;
        private byte[] _iv;
        private byte[] _salt;

        public EncriptarUtility() : this(ConfigurationManager.AppSettings["aes:secretkey"], ConfigurationManager.AppSettings["aes:iv"], ConfigurationManager.AppSettings["aes:salt"])
        {
        }

        public EncriptarUtility(string secretKey, string iv, string salt)
        {
            _secretKey = Convert.FromBase64String(secretKey);
            _iv = Convert.FromBase64String(iv);
            _salt = Convert.FromBase64String(salt);
        }

        public string Encriptar(object input)
        {
            if (input == null)
                input = string.Empty;

            byte[] key = null;
            string cipherText;

            using (var sha256 = SHA256.Create())
            {
                var passwordHash = sha256.ComputeHash(_secretKey);

                using (var rfc = new Rfc2898DeriveBytes(passwordHash, _salt, 1024))
                {
                    key = rfc.GetBytes(passwordHash.Length);
                }
            }

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor(key, _iv))
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                        {
                            using (var writer = new StreamWriter(cryptoStream))
                            {
                                writer.Write(input);
                            }

                            cipherText = Convert.ToBase64String(stream.ToArray());
                        }
                    }
                }
            }

            key = null;

            return cipherText;
        }

        public string Desencriptar(string cipherText)
        {
            byte[] key = null;
            string plainText;

            using (var sha256 = SHA256.Create())
            {
                var passwordHash = sha256.ComputeHash(_secretKey);

                using (var rfc = new Rfc2898DeriveBytes(passwordHash, _salt, 1024))
                {
                    key = rfc.GetBytes(passwordHash.Length);
                }
            }

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor(key, _iv))
                {
                    using (var stream = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                        {
                            using (var reader = new StreamReader(cryptoStream))
                            {
                                plainText = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }

            key = null;

            return plainText;
        }

        public string GenerarSalt(int maxLength = 32)
        {
            var salt = new byte[maxLength];

            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string GenerarSecretKey(CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            using (var aes = Aes.Create())
            {
                aes.Mode = cipherMode;
                aes.Padding = paddingMode;

                aes.GenerateKey();

                return Convert.ToBase64String(aes.Key);
            }
        }

        public string GenerarIV(CipherMode cipherMode = CipherMode.ECB, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            using (var aes = Aes.Create())
            {
                aes.Mode = cipherMode;
                aes.Padding = paddingMode;

                aes.GenerateIV();

                return Convert.ToBase64String(aes.IV);
            }
        }

        public string Encode(object input, bool safeUrl = true)
        {
            var _cipher = Encriptar(input);

            if (safeUrl)
                return _cipher.Replace("/", "_").Replace("+", "-");

            return _cipher;
        }

        public T Decode<T>(object input, bool safeUrl = true)
        {
            var _input = input.ParseTo<string>();

            if (string.IsNullOrWhiteSpace(_input))
                return default(T);

            if (safeUrl)
                _input = _input.Replace("_", "/").Replace("-", "+");

            var _plain = Desencriptar(_input);

            return _plain.ParseTo<T>();
        }
    }
}
