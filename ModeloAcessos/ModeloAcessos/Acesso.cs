using System;
using System.Collections.Generic;

namespace ModeloAcessos
{
    public class Acesso
    {
        private readonly List<Utilizador> Utilizadores;
        public Acesso()
        {
            Utilizadores = new List<Utilizador>();
            Utilizadores.Add(new Utilizador { UserName = "admin", Password = "abcd1234", Role = "admin" });
        }

        public Utilizador ValidaLogin(string user, string pass)
        {
            foreach (var item in Utilizadores)
            {
                if (item.UserName == user && item.Password==pass)
                {
                    return item;
                }
                
            }
            return null;
        }
        public bool RegistaUtilizador(Utilizador user)
        {
            foreach (var item in Utilizadores)
            {
                if (item.UserName == user.UserName)
                {
                    return false;
                }
            }
            Utilizadores.Add(user);
            return true;
        }

        // Criar Metodo RemoveUtilizador(Utilizador user)
        // Caso o UserName==Admin nao permite a remocao
        // Criem o Test para Validar
        public bool RemoveUtilizador(Utilizador user)
        {
            if (user.UserName!="admin" && Utilizadores.Contains(user))
            {
                Utilizadores.Remove(user);
                return true;
            }
            return false;
        }
    }
}
