using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Gamal
    {
        public char Decrypt(int p, int x, int a, int b)
        {
            KeyGen key = new KeyGen();
            int buf = key.FastExponentiation((BigInteger)p, (BigInteger)a, (BigInteger)(p - 1 - x));
            char message = (char)(key.Mul(b, buf, p));

            return message;
        }

        public int[] Encrypt(int p, int g, int y, int src)
        {
            KeyGen key = new KeyGen();
            Random rnd = new Random();
            int k = rnd.Next(1, p - 1);
            while (!key.IsCoprime(k, p - 1))
            {
                k = rnd.Next(1, p - 1);
            }

            int m = src;
            int a = key.FastExponentiation((BigInteger)p, (BigInteger)g, (BigInteger)k);
            int b = key.FastExponentiation((BigInteger)p, (BigInteger)y, (BigInteger)k);
            b = key.Mul(b, m, p);

            int[] res = new int[2];
            res[0] = a;
            res[1] = b;

            return res;
        }

        
    }
}
