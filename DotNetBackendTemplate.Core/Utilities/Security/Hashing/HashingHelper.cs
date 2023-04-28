﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace DotNetBackendTemplate.Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = RunComputeHash(hmac, password);
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = RunComputeHash(hmac, password);

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static byte[] RunComputeHash(HMAC hmac, string password)
        {
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}

