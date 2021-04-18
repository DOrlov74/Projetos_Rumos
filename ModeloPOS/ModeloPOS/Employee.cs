using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloPOS
{
    public class Employee:Auditable
    {
        static int numeracao = 0;   
        public int EmployeeId { get; }
        public string EmployeeName { get; set; }
        public Employee(string employeeName = "N/A")
        {
            numeracao++;
            EmployeeName = employeeName;
            EmployeeId = numeracao;
        }
    }
}
