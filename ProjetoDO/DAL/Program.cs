using StorePOS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcessoDados
{
    class Program
    {
        //string conn= @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = ProjetoDO_DB; Integrated Security = True";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var context = new AcessoDbContext())
            {
                //    tblUser user = new tblUser { Name="Admin", Password="1234", Phone="1"};
                //    context.tblUser.Add(user);

                //a.	Create a console application and add the following store:
                if (context.Stores.Count() == 0)
                {
                    tblStore newStore = new tblStore()
                    {
                        fldStoreID = "H01",
                        fldStore = "Hemsedal 01",
                        fldStoreAddress = "Fanitullen Postboks 80, 3561, Norway"
                    };
                    context.Stores.Add(newStore);
                    context.SaveChanges();
                }

                //c.	Update the migrations and test the component, and add the following data to tblPaymentType entity
                if (context.tblPaymentTypes.Count() == 0)
                {
                    tblPaymentType newPaymentType = new tblPaymentType() { fldPaymentType = "Cash" };
                    context.tblPaymentTypes.Add(newPaymentType);
                    context.SaveChanges();
                }

                // 8.	Use the code below to add some data to your database.
                if (context.tblFamily.Count() == 0)
                {
                    var Families = new List<tblFamily>
                    {
                        new   tblFamily {fldFamilyID="SECAL", fldFamily = "SECO ALIMENTAR"},
                        new   tblFamily {fldFamilyID="FRESC", fldFamily="FRESCOS"},
                        new   tblFamily { fldFamilyID="BEBID",fldFamily="BEBIDAS" },
                    };
                    Families.ForEach(f => context.tblFamily.Add(f));
                    context.SaveChanges();
                }
            }
        }
    }
}
