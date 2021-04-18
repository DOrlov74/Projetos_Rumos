using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloPOS
{
    public class Sale:Auditable
    {
        static int numeracao = 0;
        int _id;
        Customer _customer;
        List<SaleLine> _lines;
        decimal _totalPrice = 0;
        public decimal TotalPrice { get { return _totalPrice; } }
        public int SaleId { get { return _id; } }
        public Customer Customer { get { return _customer; } }
        public List<SaleLine> Lines { get { return _lines; } }
        public bool Paid { get; set; }
        public Sale(Customer customer)
        {
            numeracao++;
            _id = numeracao;
            _customer = customer;
            _lines = new List<SaleLine>();
            CreatedBy = customer.CustomerName;
        }
        public void AddLine(SaleLine line)
        {
            if (Paid)
            {
                return;
            }
            if (Lines.Count > 0)
            {
                foreach (SaleLine item in Lines)
                {
                    if (item.Product == line.Product)
                    {
                        item.Product.Stock += line.Quantity;
                        _totalPrice -= item.TotalPrice;
                        item.IncreaseQuantity(line.Quantity);
                        _totalPrice += item.TotalPrice;
                        UpdatedBy = Customer.CustomerName;
                        UpdatedAt = DateTime.Now;
                        return;
                    }
                }
            }
            Lines.Add(line);
            _totalPrice += line.TotalPrice;
            UpdatedBy = Customer.CustomerName;
            UpdatedAt = DateTime.Now;
        }
        public void RemoveLine(SaleLine line)
        {
            if (Paid)
            {
                return;
            }
            if (line != null && Lines.Contains(line))
            {
                _totalPrice -= line.TotalPrice;
                Lines.Remove(line);
                UpdatedBy = Customer.CustomerName;
                UpdatedAt = DateTime.Now;
            }
        }
        public bool IncreaseQuantity (SaleLine line)
        {
            if (Paid)
            {
                return false;
            }
            if (line != null)
            {
                foreach (SaleLine item in Lines)
                {
                    if (item.Product == line.Product)
                    {
                        _totalPrice -= item.TotalPrice;
                        bool sucess=item.IncreaseQuantity(1);
                        _totalPrice += item.TotalPrice;
                        UpdatedBy = Customer.CustomerName;
                        UpdatedAt = DateTime.Now;
                        return sucess;
                    }
                }
            }
            return false;
        }
        public bool DecreaseQuantity(SaleLine line)
        {
            if (Paid)
            {
                return false;
            }
            if (line != null)
            {
                foreach (SaleLine item in Lines)
                {
                    if (item.Product == line.Product)
                    {
                        _totalPrice -= item.TotalPrice;
                        bool sucess=item.DecreaseQuantity(1);
                        if (item.Quantity == 0)
                        {
                            Lines.Remove(item);
                        } else { 
                            _totalPrice += item.TotalPrice;
                        }
                        UpdatedBy = Customer.CustomerName;
                        UpdatedAt = DateTime.Now;
                        return sucess;
                    }
                }
            }
            return false;
        }
        public void Pay()
        {
            Paid = true;
            UpdatedBy = Customer.CustomerName;
            UpdatedAt = DateTime.Now;
        }
        public void PrintRecept()
        {
            if (Paid)
            {
                Console.WriteLine("Recept:");
                Console.WriteLine($"Customer: { UpdatedBy}, NIF: {Customer.NIF}, Date: {UpdatedAt.Date}");
                Console.WriteLine("Products:");
                Console.WriteLine(String.Format("{0,-5}{1,10}{2,10}{3,10}{4,10}{5,10}\n",
                          "N", "Store", "Product Name", "Price", "Quantity", "Total Price"));
                int lineNum = 0;
                foreach (SaleLine line in _lines)
                {
                    ++lineNum;
                    Console.WriteLine(String.Format("{0,-5}{1,10}{2,10}{3,10:C}{4,10}{5,10:C}\n",
                        lineNum, line.Product.Store, line.Product.Name, line.Product.Price, line.Quantity, line.TotalPrice));
                }
                Console.WriteLine("Total:");
                Console.WriteLine(TotalPrice);
            }
        }
    }
    public class SaleLine
    {
        Product _product;
        int _quantity;
        decimal _totalPrice;
        public decimal TotalPrice { get { return _totalPrice; } }
        public Product Product { get { return _product; } }
        public int Quantity { 
            get { return _quantity; } 
        }
        public SaleLine(Product product, int quantity = 0)
        {
            _product = product;
            IncreaseQuantity(quantity);
        }
        public bool IncreaseQuantity(int val)
        {
            if (val != 0 && Product?.Stock >= val)
            {
                _quantity += val;
                Product.Stock -= val;
                _totalPrice += (Product.Price ?? 0) * val;
                return true;
            }
            return false;
        }
        public bool DecreaseQuantity(int val)
        {
            if (val != 0 && Quantity >= val)
            {
                _quantity -= val;
                Product.Stock += val;
                _totalPrice -= (Product.Price ?? 0) * val;
                return true;
            }
            return false;
        }
    }
}
