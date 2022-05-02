namespace SNR.Common;

public class Encrypter : IEncrypter
{
    private string _key;
    private byte[] _bytes;

    public Encrypter(string key, byte[] salt)
    {
        if (!string.IsNullOrEmpty(key))
        {
            _key = key;
        }
        if (salt != null)
        {
            _bytes = salt;
        }
    }

    public Encrypter()
    {
        _key = "apaxx&b[m-u797B*YMe/L+YPhyKa#(g^g_@fO8Ai|*M:LY#q8>K+YijTItAI*-%a{s7(%]w9aS]22_z=34.L+'6Tg(vz{wBXBntFKyxBVU";
        _bytes = new byte[] { 0x61, 0x74, 0x65, 0x73, 0x20, 0x70, 0x61, 0x72, 0x73, 0x20, 0x61, 0x63, 0x61, 0x72 };
    }

    public string EncryptFile(byte[] file, string key, string salt)
    {
        if (string.IsNullOrEmpty(key))
        {
            key = _key;
        }

        byte[] _salt = _bytes;
        if (!string.IsNullOrEmpty(salt))
        {
            _salt = Encoding.Default.GetBytes(salt);
        }

        byte[] encryptedData = EncryptInternal(file, key, _salt);
        var encryptedStr = Convert.ToBase64String(encryptedData);
        return encryptedStr;
    }

    public byte[] EncryptFileByte(byte[] file, string key, string salt)
    {
        if (string.IsNullOrEmpty(key))
        {
            key = _key;
        }

        byte[] _salt = _bytes;
        if (!string.IsNullOrEmpty(salt))
        {
            _salt = Encoding.Default.GetBytes(salt);
        }

        byte[] encryptedData = EncryptInternal(file, key, _salt);
        return encryptedData;
    }

    public string DecryptFile(byte[] encryptedFile, string key, string salt)
    {
        if (string.IsNullOrEmpty(key))
        {
            key = _key;
        }

        byte[] _salt = _bytes;
        if (!string.IsNullOrEmpty(salt))
        {
            _salt = Encoding.Default.GetBytes(salt);
        }

        PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, _salt);
        byte[] decryptedData = Decrypt(encryptedFile, pdb.GetBytes(32), pdb.GetBytes(16));
        return System.Text.Encoding.Unicode.GetString(decryptedData);
    }

    public byte[] DecryptFileByte(byte[] encryptedFile, string key, string salt)
    {
        if (string.IsNullOrEmpty(key))
        {
            key = _key;
        }

        byte[] _salt = _bytes;
        if (!string.IsNullOrEmpty(salt))
        {
            _salt = Encoding.Default.GetBytes(salt);
        }

        PasswordDeriveBytes pdb = new PasswordDeriveBytes(key, _salt);
        byte[] decryptedData = Decrypt(encryptedFile, pdb.GetBytes(32), pdb.GetBytes(16));
        return decryptedData;
    }

    public string Encrypt(string openStr)
    {
        byte[] clearData = Encoding.Unicode.GetBytes(openStr);
        byte[] encryptedData = EncryptInternal(clearData, _key, _bytes);
        var encryptedStr = Convert.ToBase64String(encryptedData);
        return encryptedStr;
    }

    public string Decrypt(string encryptedString)
    {
        byte[] cipherBytes = Convert.FromBase64String(encryptedString);
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(_key, _bytes);
        byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
        return System.Text.Encoding.Unicode.GetString(decryptedData);
    }

    private byte[] EncryptInternal(byte[] clearData, string key, byte[] salt)
    {
        using (PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(key, salt))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var alg = Rijndael.Create())
                {
                    alg.Key = passwordDeriveBytes.GetBytes(32);
                    alg.IV = passwordDeriveBytes.GetBytes(16);

                    using (CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearData, 0, clearData.Length);
                        cs.Close();
                        byte[] encryptedData = ms.ToArray();
                        return encryptedData;
                    }
                }
            }
        }
    }

    public byte[] Decrypt(byte[] cipherData, byte[] key, byte[] salt)
    {
        MemoryStream ms = new MemoryStream();
        Rijndael alg = Rijndael.Create();
        alg.Key = key;
        alg.IV = salt;
        CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(cipherData, 0, cipherData.Length);
        cs.Close();
        byte[] decryptedData = ms.ToArray();
        return decryptedData;
    }

    public string UrlEncode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(Encrypt(plainText));
        return Convert.ToBase64String(plainTextBytes);
    }

    public string UrlDecode(string encryptedString)
    {
        var base64EncodedBytes = Convert.FromBase64String(encryptedString);
        return Decrypt(Encoding.UTF8.GetString(base64EncodedBytes));
    }

    /// <summary>
    /// Base64 Şifreleme için kullanılacak
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public string Base64Encrypt(string text)
    {
        byte[] clearData = Encoding.Unicode.GetBytes(text);
        byte[] encryptedData = EncryptInternal(clearData, _key, _bytes);
        var encryptedStr = Convert.ToBase64String(encryptedData);

        return Convert.ToBase64String(Encoding.ASCII.GetBytes(encryptedStr));
    }

    /// <summary>
    /// Base64 Şifreleme için kullanılacak
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public string Base64Decrypt(string text)
    {
        var str = Encoding.ASCII.GetString(Convert.FromBase64String(text));
        byte[] cipherBytes = Convert.FromBase64String(str);
        PasswordDeriveBytes pdb = new PasswordDeriveBytes(_key,
        new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

        return Encoding.Unicode.GetString(decryptedData);
    }
}