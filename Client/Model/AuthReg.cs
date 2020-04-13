using ClientWPF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Model
{
    class AuthReg //авторизация/регистрация
    {
        public static bool Authorization(string Login, string Password)
        {
            if (ValidData(Login, Password))
            {
                var id = AuthClient.client.Authorization(Login, Password);
                if (id != Guid.Empty)
                    return true;
                else
                    return false;
            }
            else
                return false;
            
        }
        public static bool Registration(string Login, string Password)
        {
            if (ValidData(Login, Password))
            {
                var id = AuthClient.client.Registration(Login, Password);
                if (id != Guid.Empty)
                    return true;
                else
                    return false;
            }
            else
                return false;
            
        }
        public static bool AvailabilityLogin(string login)
        {
            var result = AuthClient.client.AvailabilityLogin(login.ToLower());
            return result;
        }
        private static bool ValidData(string login, string password)
        {
            if (login.Length < 1 || password.Length < 1)
                return false;
            else
                return true;
        }
    }
}
