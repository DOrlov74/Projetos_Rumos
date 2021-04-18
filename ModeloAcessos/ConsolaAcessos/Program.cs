using ModeloAcessos;
using ModeloPOS;
using System;
using System.Collections.Generic;
using System.Linq;
using static DataBase.DatabaseService;

namespace ConsolaAcessos
{
    static class Program
    {
        public static Acesso acesso = new Acesso();
        static StoreService service = new StoreService();

        static void Main(string[] args)
        {
            
            Console.WriteLine("Bem vindo ao POS V1");
            MainMenu();
        }
        private static void MainMenu()
        {
            string answer;
            int option;
            bool sucess;
            do
            {
                Console.WriteLine("Enter option:");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Register");
                Console.WriteLine("0 - Exit");
                answer = Console.ReadLine();
                sucess = int.TryParse(answer, out option);
                if (option < 0 || option > 2)
                {
                    sucess = false;
                    Console.WriteLine("number should be from 0 till 2");
                }
            } while (!sucess);
            switch (option)
            {
                case 1:
                    LoginMenu();
                    break;
                case 2:
                    RegisterClientMenu();
                    break;
            }
        }
        public static void RegisterClientMenu()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.Write("Enter your password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter your NIF: ");
            string nif = Console.ReadLine();
            Utilizador u = new Utilizador {UserName = name, Password = pass, Role = "client" };
            if (acesso.RegistaUtilizador(u))
            { 
                Customer c = service.AddCustomer(name, nif);
                ClientMenu(c);
            }
            else { 
                Console.WriteLine("Error in registration"); 
                MainMenu(); 
            }

        }
        private static void LoginMenu() 
        {
            Console.Write("User Name : ");
            string name = Console.ReadLine();
            Console.Write("Password  : ");
            string pass = Console.ReadLine();
            Utilizador u = acesso.ValidaLogin(name, pass);
            if (u!= null)
            {
                Console.Write(" ** Acesso Permitido ** ");
                if (u.Role == "client")
                {
                    Customer c = service.GetCustomer(name);
                    ClientMenu(c);
                } else
                {
                    Employee empl = service.GetEmployee(name);
                    EmployeeMenu(empl);
                }
            }
            else
            {
                Console.Write(" ** Acesso Recusado ** ");
                MainMenu();
            }
        }

        private static void ClientMenu(Customer cust)
        {
            string answer;
            int option;
            bool sucess;
            do
            {
                Console.WriteLine("1 - List and add products to cart");
                Console.WriteLine("2 - List your sales");
                Console.WriteLine("0 - Exit");
                answer = Console.ReadLine();
                sucess = int.TryParse(answer, out option);
                if (option < 0 || option > 2)
                {
                    sucess = false;
                    Console.WriteLine("number should be from 0 till 2");
                }
            } while (!sucess);
            switch (option)
            {
                case 1:
                    ListProductsMenu(cust);
                    break;
                case 2:
                    ListSalesMenu(cust);
                    break;
                case 0:
                    MainMenu();
                    break;
            }
        }
        private static void EmployeeMenu(Employee empl)
        {
            string answer;
            int option;
            bool sucess;
            do
            {
                Console.WriteLine("1 - List products");   
                Console.WriteLine("2 - List sales");
                Console.WriteLine("3 - Add store to service");
                Console.WriteLine("4 - Add product to database");
                    if (empl.EmployeeName == "admin")
                    {
                        Console.WriteLine("5 - Add employee to store service");
                    }
                Console.WriteLine("0 - Exit");
                answer = Console.ReadLine();
                sucess = int.TryParse(answer, out option);
                if (option < 0 || option > 5)
                {
                    sucess = false;
                    Console.WriteLine($"number should be from 0 till {(empl.EmployeeName == "admin"?"5":"4")}");
                }
            } while (!sucess);
            switch (option)
            {
                case 1: ListProductsMenu(empl);
                    break;
                case 2: ListSalesMenu(empl);
                    break;
                case 3: AddStoreMenu(empl);
                    break;
                case 4: AddProductMenu(empl);
                    break;
                case 5:
                    if (empl.EmployeeName == "admin")
                    {
                        AddEmployeeMenu(empl);
                    } else
                    {
                        Console.WriteLine("Sorry, only admin can add employee");
                    }
                    break;
                case 0:
                    MainMenu();
                    break;
            }
        }

        private static void AddEmployeeMenu(Employee empl)
        {
            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine();
            Console.Write("Enter your password: ");
            string pass = Console.ReadLine();
            Employee employee = service.AddEmployee(name);
            Utilizador u = new Utilizador { UserName = name, Password = pass, Role = "employee" };
            if (acesso.RegistaUtilizador(u) && employee != null)
            {
                Console.WriteLine("Employee added to service sucessfully");
            }
            else { Console.WriteLine("Error in adding employee"); }
            EmployeeMenu(empl);
        }

        private static void ListProductsMenu(Auditable cust, Sale sale = null)
        {
            string answer;
            int option;
            bool sucess;
            do
            {
                Console.WriteLine("1 - List all products");
                Console.WriteLine("2 - List products by store");
                Console.WriteLine("3 - List products by Name");
                Console.WriteLine("4 - List products by Brand");
                Console.WriteLine("5 - List products by Category");
                if (sale != null)
                {
                    Console.WriteLine("6 - Finalize your buy");
                }
                Console.WriteLine("0 - Exit");
                answer = Console.ReadLine();
                sucess = int.TryParse(answer, out option);
                if (option < 0 || option > 6)
                {
                    sucess = false;
                    Console.WriteLine("number should be from 0 till 5");
                }
            } while (!sucess);
            string name;
            switch (option)
            {
                case 1:
                    ListAllProducts(cust, sale);
                    break;
                case 2:
                    Console.WriteLine("Enter store name: ");
                    name = Console.ReadLine();
                    ListStoreProducts(cust, name, sale);
                    break;
                case 3:
                    Console.WriteLine("Enter product name: ");
                    name = Console.ReadLine();
                    ListNameProducts(cust, name, sale);
                    break;
                case 4:
                    Console.WriteLine("Enter product brand: ");
                    name = Console.ReadLine();
                    ListBrandProducts(cust, name, sale);
                    break;
                case 5:
                    Console.WriteLine("Enter product category: ");
                    name = Console.ReadLine();
                    ListCategoryProducts(cust, name, sale);
                    break;
                case 6:
                    if (sale != null)
                    {
                        FinalizeSale(cust as Customer, sale);
                    }
                    else { Console.WriteLine("your current cart is empty"); }
                    break;
                case 0:
                    if (cust is Customer)
                    {
                        ClientMenu(cust as Customer);
                    } else
                    {
                        EmployeeMenu(cust as Employee);
                    }
                    
                    break;
            }
        }
        private static void ListAllProducts(Auditable cust, Sale sale)
        {
            IEnumerable<Product> products= GetAllProducts();
            if (products.Count() > 0)
            {
                PrintProductList(products);
                if (cust is Customer)
                {
                    AddToCartMenu(cust as Customer, products, sale);
                } else
                {
                    ListProductsMenu(cust as Employee);
                }
            } else
            {
                Console.WriteLine("No products in database");
                if (cust is Customer)
                {
                    ListProductsMenu(cust as Customer, sale);
                }
                else
                {
                    ListProductsMenu(cust as Employee);
                }
            }  
        }
        private static void ListStoreProducts(Auditable cust, string name, Sale sale)
        {
            ProductFilter pf = new ProductFilter();
            Store store = service.GetStore(name);
            if (store != null)
            {
                StoreSpecification storeSpec = new StoreSpecification(store);
                IEnumerable<Product> storeProducts = pf.Filter(storeSpec);
                if (storeProducts.Count() > 0)
                {
                    PrintProductList(storeProducts);
                    if (cust is Customer)
                    {
                        AddToCartMenu(cust as Customer, storeProducts, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
                else
                {
                    Console.WriteLine("No such products in database");
                    if (cust is Customer)
                    {
                        ListProductsMenu(cust as Customer, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
            } else
            {
                Console.WriteLine("No such store found");
                if (cust is Customer)
                {
                    ListProductsMenu(cust as Customer, sale);
                }
                else
                {
                    ListProductsMenu(cust as Employee);
                }
            }
        }
        private static void ListNameProducts(Auditable cust, string name, Sale sale)
        {
            ProductFilter pf = new ProductFilter();
            if (name != null)
            {
                NameSpecification nameSpec = new NameSpecification(name);
                IEnumerable<Product> nameProducts = pf.Filter(nameSpec);
                if (nameProducts.Count() > 0)
                {
                    PrintProductList(nameProducts);
                    if (cust is Customer)
                    {
                        AddToCartMenu(cust as Customer, nameProducts, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
                else
                {
                    Console.WriteLine("No such products in database");
                    if (cust is Customer)
                    {
                        ListProductsMenu(cust as Customer, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("No such name found");
                if (cust is Customer)
                {
                    ListProductsMenu(cust as Customer, sale);
                }
                else
                {
                    ListProductsMenu(cust as Employee);
                }
            }
        }
        private static void ListBrandProducts(Auditable cust, string name, Sale sale)
        {
            ProductFilter pf = new ProductFilter();
            if (name != null)
            {
                BrandSpecification brandSpec = new BrandSpecification(name);
                IEnumerable<Product> brandProducts = pf.Filter(brandSpec);
                if (brandProducts.Count() > 0)
                {
                    PrintProductList(brandProducts);
                    if (cust is Customer)
                    {
                        AddToCartMenu(cust as Customer, brandProducts, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
                else
                {
                    Console.WriteLine("No such products in database");
                    if (cust is Customer)
                    {
                        ListProductsMenu(cust as Customer, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("No such brand found");
                if (cust is Customer)
                {
                    ListProductsMenu(cust as Customer, sale);
                }
                else
                {
                    ListProductsMenu(cust as Employee);
                }
            }
        }
        private static void ListCategoryProducts(Auditable cust, string name, Sale sale)
        {
            ProductFilter pf = new ProductFilter();
            if (name != null)
            {
                CategorySpecification catSpec = new CategorySpecification(name);
                IEnumerable<Product> catProducts = pf.Filter(catSpec);
                if (catProducts.Count() > 0)
                {
                    PrintProductList(catProducts);
                    if (cust is Customer)
                    {
                        AddToCartMenu(cust as Customer, catProducts, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
                else
                {
                    Console.WriteLine("No such products in database");
                    if (cust is Customer)
                    {
                        ListProductsMenu(cust as Customer, sale);
                    }
                    else
                    {
                        ListProductsMenu(cust as Employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("No such category found");
                if (cust is Customer)
                {
                    ListProductsMenu(cust as Customer, sale);
                }
                else
                {
                    ListProductsMenu(cust as Employee);
                }
            }
        }
        private static void ListSalesMenu(Auditable cust)
        {
            if (cust is Customer)
            {
                Customer c = cust as Customer;
                SaleFilter sf = new SaleFilter();
                if (c.CustomerName != null)
                {
                    ClientSpecification clientSpec = new ClientSpecification(c);
                    IEnumerable<Sale> clientSales = sf.Filter(clientSpec);
                    if (clientSales.Count() > 0)
                    {
                        PrintSaleList(clientSales);
                        SelectSaleMenu(cust as Customer, clientSales);
                    }
                    else
                    {
                        Console.WriteLine($"No sales of {c.CustomerName} in database");
                        ClientMenu(c);
                    }
                }
                else
                {
                    Console.WriteLine("No such sale found");
                    ClientMenu(c);
                }
            } else {
                Employee e = cust as Employee;
                string answer;
                int option;
                bool sucess;
                do
                {
                    Console.WriteLine("1 - List all sales");
                    Console.WriteLine("2 - List sales by client");
                    Console.WriteLine("0 - Exit");
                    answer = Console.ReadLine();
                    sucess = int.TryParse(answer, out option);
                    if (option < 0 || option > 2)
                    {
                        sucess = false;
                        Console.WriteLine("number should be from 0 till 2");
                    }
                } while (!sucess);
                string name;
                switch (option)
                {
                    case 1:
                        ListAllSales(e);
                        break;
                    case 2:
                        Console.WriteLine("Enter client name: ");
                        name = Console.ReadLine();
                        ListClientSales(e, name);
                        break;
                    case 0:
                        EmployeeMenu(e);
                        break;
                }
            }
        }
        private static void ListAllSales(Employee empl)
        {
            IEnumerable<Sale> sales = GetAllSales();
            if (sales.Count() > 0)
            {
                PrintSaleList(sales);
            }
            else
            {
                Console.WriteLine("No sales in database");
                EmployeeMenu(empl);
            }
        }
        private static void ListClientSales(Employee empl, string name)
        {
            SaleFilter sf = new SaleFilter();
            Customer cust = service.GetCustomer(name);
            if (cust != null)
            {
                ClientSpecification clientSpec = new ClientSpecification(cust);
                IEnumerable<Sale> clientSales = sf.Filter(clientSpec);
                if (clientSales.Count() > 0)
                {
                    PrintSaleList(clientSales);
                }
                else
                {
                    Console.WriteLine($"No sales of {cust.CustomerName} in database");
                    EmployeeMenu(empl);
                }
            }
            else
            {
                Console.WriteLine("No such customer found");
                EmployeeMenu(empl);
            }
        }
        private static void AddStoreMenu(Employee empl)
        {
            Console.WriteLine("Enter store name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter store city: ");
            string city = Console.ReadLine();
            Store store = service.AddStore(name, city);
            if (store != null)
            {
                Console.WriteLine("Store added sucessfully");
            }
            else 
            {
                Console.WriteLine("Store is already exists");
            }
            EmployeeMenu(empl);
        }

        private static void AddProductMenu(Employee empl)
        {
            bool sucess = false;
            string opcao="";
            Store store;
            do
            {
                Console.WriteLine("Enter store name: ");
                string storeName = Console.ReadLine();
                store = service.GetStore(storeName);
                if (store == null)
                {
                    Console.WriteLine("No such store in service");
                    Console.WriteLine("Return to previos menu? Y / N");
                    opcao = Console.ReadLine();
                    if (opcao == "y" || opcao == "Y") break;
                }
                else { sucess = true; }
            } while (!sucess);
            if (opcao != "y" || opcao != "Y")
            {
                Console.WriteLine("Enter product name: ");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter brand: ");
                string brand = Console.ReadLine();
                Console.WriteLine("Enter category: ");
                string category = Console.ReadLine();
                Console.WriteLine("Enter description: ");
                string description = Console.ReadLine();
                Console.WriteLine("Enter Price: ");
                decimal? price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter quantity in stock: ");
                int stock = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter URL of an image: ");
                string imageURL = Console.ReadLine();
                sucess = AddProduct(new Product(store, productName, brand, category, description, stock, price, imageURL, empl.EmployeeName));
                if (sucess)
                {
                    Console.WriteLine("Product was added sucessfully");
                }
                else { Console.WriteLine("Error in adding a product"); }
            }
            EmployeeMenu(empl);
        }
        private static void PrintProductList(IEnumerable<Product> products)
        {
            Console.WriteLine("Products in store:");
            string header = String.Format("{0,-5}{1,8}{2,10}{3,10}{4,10}{5,10}{6,8}\n",
                          "N", "Name", "Brand", "Category", "Store", "Price", "in stock");
            Console.WriteLine(header);
            int num = 0;
            foreach (Product p in products)
            {
                ++num;
                Console.WriteLine(String.Format("{0,-5}{1,8}{2,10}{3,10}{4,10}{5,10:C}{6,8}",
                          num, p.Name, p.Brand, p.Category, p.Store.StoreName, p.Price, p.Stock));
            }
        }
        private static void PrintSaleList(IEnumerable<Sale> sales)
        {
            Console.WriteLine("Sales in store:");
            string header = String.Format("{0,-5}{1,10}{2,10}{3,10}{4,10}{5,10}\n",
                          "N", "Store", "Product Name", "Price", "Quantity", "Total Price");
            int saleNum = 0;
            int lineNum = 0;
            foreach (Sale s in sales)
            {
                ++saleNum;
                Console.WriteLine($"N {saleNum} Name: {s.Customer.CustomerName} NIF: {s.Customer.NIF} Date: {s.UpdatedAt.ToShortDateString()}");
                Console.WriteLine(header);
                foreach (SaleLine line in s.Lines)
                {
                    ++lineNum;
                    Console.WriteLine(String.Format("{0,-5}{1,10}{2,10}{3,10}{4,10}{5,10}\n",
                          lineNum, line.Product.Store.StoreName, line.Product.Name, line.Product.Price, line.Quantity, line.TotalPrice));
                }
            }
        }
        private static void AddToCartMenu(Customer cust, IEnumerable<Product> products, Sale sale = null)
        {
            Console.WriteLine("To add product to cart enter it's Number in list: ");
            Console.WriteLine("0 - Exit: ");
            int option;
            bool sucess;
            do {
                sucess = int.TryParse(Console.ReadLine(), out option);
                if (option < 0 || option > products.Count() || sucess == false)
                {
                    Console.WriteLine($"Product with N {option} was not found");
                    sucess = false;
                }
            }
            while (!sucess);
            if (option == 0)
            {
                ListProductsMenu(cust, sale);
            } else { 
                Product product = products.ElementAt(option-1);
                if (sale == null)
                {
                    sale = new Sale(cust);
                    AddSale(sale);
                }
                SaleLine line = new SaleLine(product, 1);
                sale.AddLine(line);
                Console.WriteLine($"Product {product.Name} added to cart, quantity = {line.Quantity}, total price: {line.TotalPrice}");
                do { sucess = EditQuantityMenu(sale, line); }
                while (!sucess);
                Console.WriteLine("1 - to finalize you buy");
                Console.WriteLine("0 - Return: ");
                do 
                {
                    sucess = int.TryParse(Console.ReadLine(), out option);
                    if (option < 0 || option > 1 || sucess == false)
                    {
                        Console.WriteLine($"Enter 1 or 0 please");
                        sucess = false;
                    }
                } while (!sucess);
                if (option==1)
                {   
                    FinalizeSale(cust, sale);
                    ClientMenu(cust);
                } else
                {
                    ListProductsMenu(cust, sale);
                }
            }
        }
        private static bool EditQuantityMenu(Sale sale, SaleLine line)
        {
            Console.WriteLine("To increase quantity enter +, to decreese enter -");
            Console.WriteLine("0 - Return: ");
            string answer;
            bool sucess = false;
            do
            {
                answer = Console.ReadLine();
                if (answer == "+" || answer == "-" || answer == "0")
                {
                    sucess = true;
                }
                else { Console.WriteLine("Enter \"+\" or \"-\" or \"0\""); }
            }
            while (!sucess);
            switch (answer)
            {
                case "+":
                    if (sale.IncreaseQuantity(line))
                    {
                        Console.WriteLine($"Product {line.Product.Name} added to cart, quantity = {line.Quantity}, total price: {line.TotalPrice}");
                    }
                    else { 
                        Console.WriteLine("Unsufficient number of products in stock"); 
                    }
                    return false;
                case "-":
                    if (sale.DecreaseQuantity(line))
                    {
                        if (line == null)
                        {
                            Console.WriteLine("Product was removed from your cart");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Product {line.Product.Name} removed from cart, quantity = {line.Quantity}, total price: {line.TotalPrice}");
                            return false;
                        }
                    }
                    else { 
                        Console.WriteLine("Unsufficient number of products in cart");
                        return false;
                    }
            }
            return true;
        }
        private static void FinalizeSale(Customer cust, Sale sale)
        {
            if (!sale.Paid)
            {
                sale.Pay();
                sale.PrintRecept();
            } else { Console.WriteLine("You order is already paid"); }
            ClientMenu(cust);
        }
        private static void SelectSaleMenu(Customer cust, IEnumerable<Sale> clientSales)
        {
            Console.WriteLine("To select your sale enter it's Number in list: ");
            Console.WriteLine("0 - Exit: ");
            int option;
            bool sucess;
            do
            {
                sucess = int.TryParse(Console.ReadLine(), out option);
                if (option < 0 || option > clientSales.Count() || sucess == false)
                {
                    Console.WriteLine($"Sale with N {option} was not found");
                    sucess = false;
                }
            }
            while (!sucess);
            if (option == 0)
            {
                ClientMenu(cust);
            }
            else
            {
                Sale sale = clientSales.ElementAt(option - 1);
                if (sale.Paid)
                {
                    Console.WriteLine("Unable to edit your sale, it's already finalized");
                    ListSalesMenu(cust);
                } else
                {
                    do
                    {
                        sucess = EditSaleMenu(sale);
                    }
                    while (!sucess);
                    Console.WriteLine("1 - to finalize you buy");
                    Console.WriteLine("2 - to add another products");
                    Console.WriteLine("0 - Exit: ");
                    do
                    {
                        sucess = int.TryParse(Console.ReadLine(), out option);
                        if (option < 0 || option > 2 || sucess == false)
                        {
                            Console.WriteLine($"Enter 1 or 0 please");
                            sucess = false;
                        }
                    } while (!sucess);
                    if (option == 1)
                    {
                        FinalizeSale(cust, sale);
                        ClientMenu(cust);
                    }
                    else if (option == 2)
                    {
                        ListProductsMenu(cust, sale);
                    } else {
                        ListSalesMenu(cust);
                    }
                }
            }
        }
        private static bool EditSaleMenu(Sale sale)
        {
            string header = String.Format("{0,-5}{1,10}{2,10}{3,10}{4,10}{5,10}\n",
                          "N", "Store", "Product Name", "Price", "Quantity", "Total Price");
            int lineNum = 0;
            Console.WriteLine($"Name: {sale.Customer.CustomerName}, NIF: {sale.Customer.NIF}, Date: {sale.UpdatedAt}");
            Console.WriteLine(header);
            foreach (SaleLine line in sale.Lines)
            {
                ++lineNum;
                Console.WriteLine(String.Format("{0,-5}{1,10}{2,10}{3,10}{4,10}{5,10}\n",
                      lineNum, line.Product.Store.StoreName, line.Product.Name, line.Product.Price, line.Quantity, line.TotalPrice));
            }
            Console.WriteLine("Enter product Number in list to remove from your cart");
            Console.WriteLine("0 - Exit: ");
            int option;
            bool sucess;
            do
            {
                sucess = int.TryParse(Console.ReadLine(), out option);
                if (option < 0 || option > sale.Lines.Count() || sucess == false)
                {
                    Console.WriteLine($"Product with N {option} was not found. Try again");
                    sucess = false;
                }
            }
            while (!sucess);
            if (option == 0)
            {
                return true;
            }
            else
            {
                SaleLine line = sale.Lines.ElementAt(lineNum-1);
                string name = line.Product.Name;
                sale.RemoveLine(line);
                Console.WriteLine($"Product {name} was removed from your cart");
                return true;
            }
        }
    }
}
