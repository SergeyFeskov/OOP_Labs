using System.Numerics;
using System.Text;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;

namespace Lab5_6
{
    public class RabinCrypterPluginAdapter : IPlugin
    {
        private IRabinCrypter adaptee;

        private readonly BigInteger publicKeyN = 1857;
        private readonly BigInteger publicKeyB = 100;
        private readonly BigInteger privateKeyQ = 619;
        private readonly BigInteger privateKeyP = 3;        
            
        public RabinCrypterPluginAdapter(IRabinCrypter rabinCrypter)
        {
            adaptee = rabinCrypter;
        }

        public string Name 
        { 
            get { return adaptee.Name; } 
        }
        public string Description
        {
            get { return "encrypts/decrypts strings using Rabin crypting algorithm"; }
        }
        public string ParseIn(string input)
        {
            byte[] crypted_bytes = adaptee.Encrypt(publicKeyN, publicKeyB, Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(crypted_bytes);
        }
        public string ParseOut(string input)
        {
            byte[] decrypted_bytes = adaptee.Decrypt(privateKeyQ, privateKeyP, publicKeyB, Convert.FromBase64String(input));
            return Encoding.UTF8.GetString(decrypted_bytes);
        }
    }
}