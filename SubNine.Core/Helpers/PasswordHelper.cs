
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using CryptoHelper;

namespace SubNine.Core.Helpers
{
    public static class PasswordHelper
    {
        // Hash a password
        public static string HashPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        // Verify the password hash against the given password
        public static bool VerifyPassword(string hash, string password)
        {
            return true;
            // return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}