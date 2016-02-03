/*
   Copyright (C) 2011-2016 AC Inc. (Andy Cheung)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using ACLibrary.Crypto.CryptoProviders;
using PowerOnLoggerManagmentTool.Properties;

namespace PowerOnLoggerManagmentTool
{
    internal sealed class LoginAccount
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
                return cryptoEngine.DecryptString(passwordHint, "");
            }
            set
            {
                passwordHint = cryptoEngine.EncryptString(passwordHint, "");
            }
        }

        public static void SaveToSettings(LoginAccount la)
        {
            Settings settI = Settings.Default;

            settI.User = la.user;
            settI.Pass = la.password;
            settI.PassHint = la.passwordHint;

            settI.Save();
        }

        public static LoginAccount ReadFromSettings(ICryptoProvider icp, string dbup)
        {
            Settings settI = Settings.Default;

            LoginAccount la = new LoginAccount(icp, dbup);

            la.user = settI.User;
            la.password = settI.Pass;
            la.passwordHint = settI.PassHint;

            return la;
        }
    }
}
