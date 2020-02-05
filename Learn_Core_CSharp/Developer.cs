using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Core_CSharp
{
   
    class Developer : Employee
    {
        private String major;
        public event OnChange InforChanged;
        public string Major { get => major;
            set
            {
                if (major != value)
                {
                    
                    if (InforChanged != null)
                        InforChanged();
                    major = value;
                }  
             
                }
}

        public override double GetSalary()
        {
            int bonus = 1;
            
            if (Major.Equals("C#"))
                bonus = 3;
            else if (Major.Equals("Java"))
                bonus = 2;

            return (base.GetSalary())*(12+bonus);
        }

        public override string ToString()
        {
            return base.Id+"|"+base.Name+"|"+GetSalary()+"|"+Major;
        }
    }
    
}
