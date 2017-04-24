using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Encrypt
{
    public  class Program
    {
        public static string _privateKey = "<RSAKeyValue><Modulus>WP+tZymPWWS9vh4EJGYbermlC2X2gqsTHFVF2St6H1BtseAy0p2awdSfEQXMHWKK5sAo6hTfiddPbGLmpBK4rQ==</Modulus><Exponent>AQAB</Exponent><P>q+JMlnuY0Q/G4FRzxp2yfFI50tWYPjJOqCtWa1YnMg0=</P><Q>hI16iFa4w2g/p+PG4hV7EJ/bbRvjMEF2yMcJDbsqGSE=</Q><DP>Og+1g1e45VYI/hpJCZyXgDteYQPZ65iezVvmU1fE4bk=</DP><DQ>FEILGAso8bRdBiupmaPuyvujbWl1r0pR/R1uJMsWBAE=</DQ><InverseQ>oD4GalTKvBrW7g0uSAg4K0HyN1vxfDdUhkx0+n2A1ro=</InverseQ><D>OmTHaYCjRYwL0snu/dLhBMz5tVjZPTLx/w0UH0Gfhxt+nffGX8uB9Lr70pK2UeEjH31kDnje8hQXXQcSxc+UAQ==</D></RSAKeyValue>";
         public static string _publicKey = "<RSAKeyValue><Modulus>WP+tZymPWWS9vh4EJGYbermlC2X2gqsTHFVF2St6H1BtseAy0p2awdSfEQXMHWKK5sAo6hTfiddPbGLmpBK4rQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
         public static UnicodeEncoding _encoder = new UnicodeEncoding();
         public static string Decrypt(string data)
         {

             var rsa = new RSACryptoServiceProvider();
             var dataArray = data.Split(new char[] { ',' });
             byte[] dataByte = new byte[dataArray.Length];
             for (int i = 0; i < dataArray.Length; i++)
             {
                 dataByte[i] = Convert.ToByte(dataArray[i]);
             }

             rsa.FromXmlString(_privateKey);
             var decryptedByte = rsa.Decrypt(dataByte, false);
             return _encoder.GetString(decryptedByte);

         }

         public static string Encrypt(string data)
         {

             var rsa = new RSACryptoServiceProvider();
             rsa.FromXmlString(_publicKey);
             var dataToEncrypt = _encoder.GetBytes(data);
             var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
             var length = encryptedByteArray.Count();
             var item = 0;
             var sb = new StringBuilder();
             foreach (var x in encryptedByteArray)
             {
                 item++;
                 sb.Append(x);

                 if (item < length)
                     sb.Append(",");
             }

             return sb.ToString();

         }

        public static void Main(string[] args)
        {

            if (args == null)
            {
                Console.WriteLine("args is null"); // Check for null array
            }
            else
            {
                Encrypt("-M_R*;x3d&");
                Decrypt("5,176,95,88,38,118,105,151,139,73,1,69,168,205,113,187,124,190,72,72,53,2,135,230,165,137,143,38,41,213,28,192,153,132,57,201,18,252,24,26,106,25,58,142,171,162,172,65,67,118,58,138,30,167,201,110,236,99,184,135,25,48,163,117");
            }


  
     
        }
    }
}

