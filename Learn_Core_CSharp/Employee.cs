using System;

namespace Learn_Core_CSharp
{
    public delegate void OnChange();

    public class Employee : ICanDisplay
    {
       
        private int id;
        private String name;
        private double salary;
        public event OnChange InforChanged_father;
        public double Salary { get => salary * 12;
            set
            {
                if (salary != value)
                {

                    if (InforChanged_father != null)
                        InforChanged_father();
                    salary = value;
                }

            }
        }

        public virtual double GetSalary() {
            return 12 * salary;
        }

        public int Id { get => id;
            set
            {
                if (id != value)
                {

                    if (InforChanged_father != null)
                        InforChanged_father();
                    id = value;
                }

            }
        }
        public string Name { get => name;
            set
            {
                if (name != value)
                {

                    if (InforChanged_father != null)
                        InforChanged_father();
                    name = value;
                }

            }
        }

        public override string ToString()
        {
            return Id + "|" + Name + "|" + Salary;
        }
        public void Display()
        {
            Console.WriteLine("ID: " + Id + "| Name: " + Name + "| Salary: " + Salary);
        }

        
    }
}
