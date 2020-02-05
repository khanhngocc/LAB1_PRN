using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Core_CSharp
{
    class Tester : Employee
    {
        private int exp;

        public int Exp { get => exp; set => exp = value; }

        public override double GetSalary()
        {
            return base.GetSalary() * (12+(Exp*0.2));
        }

        public override string ToString()
        {
            return base.Id + "|" + base.Name + "|" + GetSalary() + "|" + Exp;
        }
    }
}
