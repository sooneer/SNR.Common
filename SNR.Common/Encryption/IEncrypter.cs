namespace SNR.Common;

public interface IEncrypter
{
    string Encrypt(string openStr);

    string Decrypt(string encryptedString);

    string UrlEncode(string plainText);

    string UrlDecode(string encryptedString);

    string Base64Encrypt(string text);

    string Base64Decrypt(string text);

    string EncryptFile(byte[] file, string key, string salt);

    byte[] EncryptFileByte(byte[] file, string key, string salt);

    string DecryptFile(byte[] encryptedFile, string key, string salt);

    byte[] DecryptFileByte(byte[] encryptedData, string key, string salt);
}