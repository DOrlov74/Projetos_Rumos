using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloAcessos;

namespace TestModeloAcessos
{
    [TestClass]
    public class TestAcesso
    {
        // Prepare
        Acesso a = new Acesso();

        [TestMethod]
        public void TestValidaLogin()
        {  
            // Execute
            Utilizador u = a.ValidaLogin("Admin", "1234");
            // Assert
            Assert.IsNull(u);
            // Execute
            u = a.ValidaLogin("aaaa", "abcd1234");
            // Assert
            Assert.IsNull(u);
            // Execute
            u = a.ValidaLogin("admin", "abcd1234");
            // Assert
            Assert.IsNotNull(u);

        }

        [TestMethod]
        public void TestRegistaUtilizador()
        {
            // Execute
            bool sucesso = a.RegistaUtilizador
                (new Utilizador { UserName="admin", Password="abcd1234" } );
            // Assert
            Assert.IsFalse(sucesso);
            // Execute
            sucesso = a.RegistaUtilizador
                (new Utilizador { UserName = "Guest", Password = "abcd1234" });
            // Assert
            Assert.IsTrue(sucesso);
        }

        [TestMethod]
        public void TestRemoveUtilizador()
        {
            // Prepare
            a.RegistaUtilizador
                (new Utilizador { UserName = "Guest", Password = "abcd1234" });
            // Execute
            bool sucesso = a.RemoveUtilizador
                (new Utilizador { UserName = "admin", Password = "abcd1234" });
            // Assert
            Assert.IsFalse(sucesso);
            // Execute
            sucesso = a.RemoveUtilizador
                (new Utilizador { UserName = "NewGuest", Password = "1234" });
            // Assert
            Assert.IsFalse(sucesso);
            // Execute
            sucesso = a.RemoveUtilizador
                (new Utilizador { UserName = "Guest", Password = "abcd1234" });
            // Assert
            Assert.IsTrue(sucesso);
        }
    }
}
