using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class Student
    {
        public string StudentNumber { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Course { get; private set; }
        public string Year { get; private set; }
        public string AcademicStatus { get; private set; }
        public string Gmail { get; private set; }
        public string ContactNumber { get; private set; }

        public string GetDetails()
        {
            return $"{Name} | {Course} | {Year} | {AcademicStatus}";
        }
    }
}
