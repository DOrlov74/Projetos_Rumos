using System;

namespace ModeloAcessos
{
    public class Utilizador
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //public static bool operator==(Utilizador u1, Utilizador u2)
        //{
        //    return (string.Compare(u1.UserName, u2.UserName) == 0 && string.Compare(u1.Password, u2.Password) == 0);
        //}
        //public static bool operator!=(Utilizador u1, Utilizador u2)
        //{
        //    return (string.Compare(u1.UserName, u2.UserName) != 0 && string.Compare(u1.Password, u2.Password) != 0);
        //}
        public override bool Equals(Object obj)
        {
            // Perform an equality check on two Utilizadores
            if (obj == null || GetType() != obj.GetType())
                return false;
            Utilizador u = (Utilizador)obj;
            return (string.Compare(UserName, u.UserName) == 0 && string.Compare(Password, u.Password) == 0);
        }
    }
}