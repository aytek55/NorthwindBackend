using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Messages
{
    public static class AuthenticationMessage
    {
        public static string UserNotFound = "Kullanıcı bulunamadı.";

        public static string PasswordError = "Parola hatalı.";

        public static string UserAlreadyExists = "Email zaten sistemde kayıtlı.";

        public static string UserRegistired = "Kullanıcı kayıt edildi.";

        public static string UnAuthorize = "Yetkisiz Erişim.";
    }
}
