using System.Collections.Generic;
using System.Linq;
using System;

namespace SallesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(string name)
        {
       
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime inital, DateTime final)
        {
            return Sellers.Sum(s => s.totalSales(inital, final));
        }
    }
}
