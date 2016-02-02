using System;
using System.Runtime.Serialization;
using ACLibrary.Crypto.CryptoProviders;

namespace PowerOnLoggerManagmentTool
{
    internal sealed class LoginAccount : ISerializable
    {
        private string user;
        private string password;
        private string passwordHint;
        private ICryptoProvider cryptoEngine;
        private string DBUnlockingPassword;

        public LoginAccount(ICryptoProvider ce, string DBUP)
        {
            DBUnlockingPassword = DBUP;
            cryptoEngine = ce;
        }

        public string User
        {
            get
            {
                return cryptoEngine.DecryptString(user, DBUnlockingPassword);
            }
            set
            {
                user = cryptoEngine.EncryptString(value, DBUnlockingPassword);
            }
        }

        public string Password
        {
            get
            {
                return cryptoEngine.DecryptString(password, DBUnlockingPassword);
            }
            set
            {
                password = cryptoEngine.EncryptString(value, DBUnlockingPassword);
            }
        }

        public string PasswordHint
        {
            get
            {
                return cryptoEngine.DecryptString(passwordHint, DBUnlockingPassword);
            }
            set
            {
                passwordHint = cryptoEngine.EncryptString(passwordHint, DBUnlockingPassword);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            throw new NotImplementedException();
        }
    }
}
