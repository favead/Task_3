using System.Security.Cryptography;
using System;

namespace KeyGen
{
    class Key
    {
        public string GetKey()
        {
            byte[] bytes = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            string HMACKey = Convert.ToHexString(bytes);
            return HMACKey;
        }

        public string GetTurnKey(string computerTurn, string key)
        {
            string fullKey = computerTurn + key;
            var rng = new RNGCryptoServiceProvider();
            byte[] keyBites = System.Text.Encoding.UTF8.GetBytes(fullKey);
            byte[] turnKeyBites;
            turnKeyBites = SHA256.HashData(keyBites);
            string turnKey = Convert.ToHexString(turnKeyBites);

            return turnKey;
        }
    }
}