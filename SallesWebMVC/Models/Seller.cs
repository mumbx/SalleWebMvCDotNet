using System;
using System.Collections.Generic;
using System.Linq;

namespace SallesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double baseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller( string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
           
            Name = name;
            Email = email;
            BirthDate = birthDate;
            this.baseSalary = baseSalary;            
            Department = department;
        }

        public void addSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double totalSales(DateTime inital, DateTime final)
        {
            return Sales.Where(s => s.Date >= inital && s.Date <= final).Sum(s => s.Amount);
        }

    }
}
