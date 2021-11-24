using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Common
{
    public class Constants
    {
        public const string IncorrectNameMessage = "Username is Incorrect.";
        public const string incorrectPasswordMessage = "Password is Incorrect.";

        #region Image Path
        public const string DefaultUserImage = "/Images/Profile/Default.png";
        public const string profileImagePath = "/Images/Profile/";
        public const string productImagePath = "/Images/Product/";
        #endregion

        #region SMTP Configuration
        public const string SmtpClient = "smtp.gmail.com";
        public const string SmtpUserName = "tbs.dharvi@gmail.com";
        public const string SmtpPassword = "Dharvi@01234";
        public const string SmtpSystemUserName = "system@adminlte.com";
        public const string SmtpForgorPasswordSubject = "Your AdminLTE Password";
        public const string SmtpLoginAttemptSubject = "LoginAttempt warning.";
        #endregion

        public const int BlockedHours = 24;
        public const int CookiesExpirationNoOfDays = 15;
        public const string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZdharvi";
    }
}
