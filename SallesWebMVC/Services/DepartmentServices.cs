using SallesWebMVC.Data;
using SallesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SallesWebMVC.Services
{
    public class DepartmentServices
    {

        private readonly SallesWebMVCContext _context;

        public DepartmentServices(SallesWebMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
