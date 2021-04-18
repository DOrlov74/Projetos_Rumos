using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloPOS
{
    public class Customer:Auditable
    {
        static int numeracao = 0;   //Todas as instáncias partilham o mesmo endereço de memória
        public int CustomerId { get; }
        public string CustomerName { get; set; }
        public string NIF { get; set; } // PT1234 ES1234
        public Customer(string customerName="N/A", string nif="N/A")
        {
            numeracao++;
            CustomerName = customerName;
            NIF = nif;
            CustomerId = numeracao;
        }
    }
}
