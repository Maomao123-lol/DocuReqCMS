using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Login(string inputUsername, string inputPassword)
        {
            return Username == inputUsername && Password == inputPassword;
        }
    }
}
