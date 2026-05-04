using System.Security.Cryptography;

namespace OnChat.Shared.Encryption;

// ReSharper disable once InconsistentNaming
public static class ECDHEncryption
{
    // HKDF
    public static ECDiffieHellman GetKeys() => ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
}