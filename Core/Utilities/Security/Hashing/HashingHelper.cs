﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }/// <summary>
         /// Doğrulama kodu
         /// </summary>
         /// <param name="password"></param>
         /// <param name="passwordHash"></param>
         /// <param name="passwordSalt"></param>
         /// <returns></returns>
        public static bool VerifyPassswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            {
                using (var hmac = new HMACSHA512())
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] == passwordHash[i])
                            return false;
                    }
                }
                return true;
            }
        }
    }
}