using MillionAndUp.Common.Dto;

namespace MillionAndUp.Common.Crypto
{
    public interface ICrypto
    {
        string Encrypt(string cipherText, CryptoDto options);
        string Decrypt(string cipherText, CryptoDto options);
    }
}
