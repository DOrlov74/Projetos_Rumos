using ModeloPOS;
using System;
using System.Collections.Generic;

namespace DataBase
{
    public static class DatabaseService
    {
        static List<Product> _products = new List<Product>();
        static List<Sale> _sales = new List<Sale>();
        public static bool AddProduct(Product product)
        {
            if (product != null && !_products.Contains(product))
            {
                _products.Add(product);
                return true;
            }
            return false;
        }
        public static bool AddSale(Sale sale)
        {
            if (sale != null && !_sales.Contains(sale))
            {
                _sales.Add(sale);
                return true;
            }
            return false;
        }
        public static IEnumerable<Product> GetAllProducts()
        {
            if (_products.Count > 0)
            {
                foreach (Product p in _products)
                yield return p;
            }
            //return null;
        }
        public static IEnumerable<Sale> GetAllSales()
        {
            if (_sales.Count > 0)
            {
                foreach (Sale s in _sales)
                    yield return s;
            }
            //return null;
        }
        public interface ISpecification<T>
        {
            bool IsSatisfied(T t);
        }
        public interface IFilter<T>
        {
            IEnumerable<T> Filter(ISpecification<T> spec);
        }
        public class ProductFilter:IFilter<Product>
        {
            public IEnumerable<Product> Filter(ISpecification<Product> spec)
            {
                foreach (Product p in _products)
                {
                    if (spec.IsSatisfied(p))
                    {
                        yield return p;
                    }
                };
            }
        }
        public class SaleFilter : IFilter<Sale>
        {
            public IEnumerable<Sale> Filter(ISpecification<Sale> spec)
            {
                foreach (Sale s in _sales)
                {
                    if (spec.IsSatisfied(s))
                    {
                        yield return s;
                    }
                };
            }
        }
        public class StoreSpecification : ISpecification<Product>
        {
            Store store;
            public StoreSpecification(Store s)
            {
                store = s;
            }
            public bool IsSatisfied(Product p)
            {
                return p.Store == store;
            }
        }
        public class NameSpecification : ISpecification<Product>
        {
            string name;
            public NameSpecification(string name)
            {
                this.name = name;
            }
            public bool IsSatisfied(Product p)
            {
                return p.Name == name;
            }
        }
        public class BrandSpecification : ISpecification<Product>
        {
            string brand;
            public BrandSpecification(string brand)
            {
                this.brand = brand;
            }
            public bool IsSatisfied(Product p)
            {
                return p.Brand == brand;
            }
        }
        public class CategorySpecification : ISpecification<Product>
        {
            string category;
            public CategorySpecification(string cat)
            {
                category = cat;
            }
            public bool IsSatisfied(Product p)
            {
                return p.Category == category;
            }
        }

        public class ClientSpecification : ISpecification<Sale>
        {
            Customer customer;
            public ClientSpecification(Customer cust)
            {
                customer = cust;
            }
            public bool IsSatisfied(Sale s)
            {
                return s.Customer == customer;
            }
        }
    }
}
