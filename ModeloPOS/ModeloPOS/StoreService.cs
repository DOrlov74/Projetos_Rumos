using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloPOS
{
    public class StoreService
    {
        //Singleton
        private readonly List<Store> _stores = new List<Store>();
        private readonly List<Customer> _customers = new List<Customer>();
        private readonly List<Employee> _employees = new List<Employee>();
        public StoreService() { _employees.Add(new Employee("admin")); }
        public Store AddStore(string name, string city)
        {
            foreach (var item in _stores)
            {
                if (item.StoreName==name && item.City==city)
                {
                    return null;
                }
            }
            Store s = new Store { StoreName = name, City = city };
            _stores.Add(s);
            return s;
        }
        public Customer AddCustomer(string name, string nif="N/A")
        {
            if (_customers.Count > 0)
            foreach (Customer cust in _customers)
            {
                    if (cust.CustomerName == name && cust.NIF == nif)
                    {
                        return null;
                    }
            }
            Customer c = new Customer(name, nif);
            _customers.Add(c);
            return c;
        }
        public Employee AddEmployee(string name)
        {
            if (_employees.Count > 0)
                foreach (Employee empl in _employees)
                {
                    if (empl.EmployeeName == name)
                    {
                        return null;
                    }
                }
            Employee emp = new Employee(name);
            _employees.Add(emp);
            return emp;
        }
        public Customer GetCustomer(string name)
        {
            if (_customers.Count > 0)
                foreach (Customer cust in _customers)
                {
                    if (cust.CustomerName == name)
                    {
                        return cust;
                    }
                }
            return null;
        }
        public Employee GetEmployee(string name)
        {
            if (_employees.Count > 0)
                foreach (Employee empl in _employees)
                {
                    if (empl.EmployeeName == name)
                    {
                        return empl;
                    }
                }
            return null;
        }
        public Store GetStore(string name)
        {
            if (_stores.Count > 0)
                foreach (Store store in _stores)
                {
                    if (store.StoreName == name)
                    {
                        return store;
                    }
                }
            return null;
        }

    }
}
