using RestApiCleanArch.Common;
using System;
using System.Security.Cryptography;

namespace RestApiCleanArch.Infraestructure
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random r;
        public RandomGenerator()
        {
            r = new Random();
        }

        public string Guid()
        {
            return System.Guid.NewGuid().ToString();
        }

        public int Next()
        {
            return r.Next();
        }

        public int Next(int maxValue)
        {
            return r.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return r.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return r.NextDouble();
        }

        public string SecureRandomString(int len)
        {
            // Generate a random salt
            byte[] salt = new byte[len];
            using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
            {
                csprng.GetBytes(salt);
            }
            string parts = Convert.ToBase64String(salt);
            return parts.Substring(0, len);

        }
    }
}
