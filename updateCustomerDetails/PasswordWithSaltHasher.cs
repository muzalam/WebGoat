﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace updateCustomerDetails
{
    public class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password, int saltLength, HashAlgorithm hashAlgo, string providedSalt=null)
        {
            RNG rng = new RNG();
            if (providedSalt!=null)
            {
                byte[] saltBytes = Encoding.UTF8.GetBytes(providedSalt);
                byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
                List<byte> passwordWithSaltBytes = new List<byte>();
                passwordWithSaltBytes.AddRange(passwordAsBytes);
                passwordWithSaltBytes.AddRange(saltBytes);
                byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
                return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
            }
            else
            {
                byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
                byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
                List<byte> passwordWithSaltBytes = new List<byte>();
                passwordWithSaltBytes.AddRange(passwordAsBytes);
                passwordWithSaltBytes.AddRange(saltBytes);
                byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
                return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
            }
            
        }
    }
}
