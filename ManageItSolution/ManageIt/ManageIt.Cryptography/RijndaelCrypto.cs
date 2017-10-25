using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ManageIt.Cryptography
{
    public class RijndaelCrypto
    {
        public RijndaelCrypto(string password)
        {
            _password = password;
            _bKey = Convert.FromBase64String("Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=");
            _bIV = new byte[] { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

            _rijndael = new RijndaelManaged
            {
                KeySize = 256
            };
        }
        private readonly string _password;
        private readonly byte[] _bKey;
        private readonly byte[] _bIV;
        private Rijndael _rijndael;

        public string Encrypt()
        {
            try
            {
                var bText = new UTF8Encoding().GetBytes(_password);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream encryptor =
                        new CryptoStream(mStream, _rijndael.CreateEncryptor(_bKey, _bIV), CryptoStreamMode.Write))
                    {
                        encryptor.Write(bText, 0, bText.Length);
                        encryptor.FlushFinalBlock();
                        return Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        public string Decrypt()
        {
            try
            {
                var bText = Convert.FromBase64String(_password);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream decryptor =
                        new CryptoStream(mStream, _rijndael.CreateDecryptor(_bKey, _bIV), CryptoStreamMode.Write))
                    {
                        decryptor.Write(bText, 0, bText.Length);
                        decryptor.FlushFinalBlock();
                        UTF8Encoding utf8 = new UTF8Encoding();
                        return utf8.GetString(mStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao descriptografar", ex);
            }
        }
    }
}
