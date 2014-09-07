using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security;

namespace LPU_Crypt_API
{
    public class MixCrypt
    {
        public String encrypt(String plainText, String password)
        {
            // 3DES
            DESProvider des = new DESProvider();
            string des1 = des.EncryptString(plainText, password);
            string des2 = des.EncryptString(des1, password);
            string des3 = des.EncryptString(des2, password);

            // 3AES
            AESProvider aes = new AESProvider();
            string aes1 = aes.EncryptString(des3, password);
            string aes2 = aes.EncryptString(aes1, password);
            string aes3 = aes.EncryptString(aes2, password);

            return aes3;

            // Use Casts: aes(aes(aes(des(des(des($content))))));
        }

        public String decrypt(String Source, String password)
        {
            // string plain = testEncrypt.DecryptString(encText, password);

            // 3AES
            AESProvider aes = new AESProvider();
            string aes1 = aes.DecryptString(Source, password);
            string aes2 = aes.DecryptString(aes1, password);
            string aes3 = aes.DecryptString(aes2, password);

            // 3DES
            DESProvider des = new DESProvider();
            string des1 = des.DecryptString(aes3, password);
            string des2 = des.DecryptString(des1, password);
            string des3 = des.DecryptString(des2, password);

            return des3;
        }
    }
}
