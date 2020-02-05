using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_Core_CSharp
{
    class Program
    {
        public delegate double GetAVGSalary(List<Developer> list);
        public delegate int ReadFile(String Filename,Department<String, Developer> depart);
        public static double Money(List<Developer> list)
        {
            double total_money = 0;

            foreach(Developer dev in list)
            {
                total_money += dev.GetSalary();
            }

            return (total_money / list.Count);
        }
        public static int LoadFile(String Filename,Department<String,Developer> depart)
        {

            String path = @"..\..\FileData\" + Filename;
            String[] lines;
            int count = 0;
           
            if (File.Exists(path))
            {
                lines = System.IO.File.ReadAllLines(@"..\..\FileData\" + Filename);
                depart.Code = lines[0];
                depart.Name = lines[1];
                
                foreach(String line in lines)
                {
                    count++;
                   
                    if (count > 2)
                    {

                        string[] temp = line.Split('|');
                        
                        Developer temp_dev = new Developer();

                        try
                        {
                            temp_dev.Id = Int32.Parse(temp[0]);
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Can't parse int number");
                        }
                       
                        temp_dev.Name = temp[1];

                        try
                        {
                            temp_dev.Salary = Double.Parse(temp[2]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Can't parse double number");
                        }

                        temp_dev.Major = temp[3];

                        depart.Member.Add(temp_dev);

                        
                    }
                }

                return 1;

            }
            else
            {
                return 0;
            }
        }
        static void member_OnChange(object sender, EventArgs e)
        {
            Console.WriteLine("Number of member is changed");
        }
        public static void manager_OnChange()
        {
            Console.WriteLine("Information of manager is changed");
        }
        static void Main(string[] args)
        {
         

            /* Employee a = new Employee();
             a.Id = 1;
             a.Name = "Nam";
             a.Salary = 3.0;
             a.Display();
             Developer c = new Developer();
             c.Id = 2;
             c.Name = "Zane";
             c.Salary=1;
             c.Major = "C";
             Console.WriteLine(c.ToString());

             Tester t = new Tester();
             t.Id = 3;
             t.Name = "Rainee";
             t.Salary = 2;
             t.Exp = 2;
             Console.WriteLine(t.ToString());*/

            Department<String, Developer> list_dev = new Department<String, Developer>();
            list_dev.NumberOfMembersChanged += new EventHandler(member_OnChange);
            list_dev.AddMember(new Developer() { 
                  Id = 1,
                  Name = "Nam"
            });
          
            Developer temp = new Developer();
            
            temp.InforChanged += manager_OnChange;
            temp.InforChanged_father += manager_OnChange;

            list_dev.Manager = temp;
            list_dev.Manager.Major = "C$";
            list_dev.Manager.Id = 22;
            list_dev.Manager.Salary = 44;
            list_dev.Manager.Name = "A";

            
            /*  ReadFile read_file = new ReadFile(LoadFile);
              list_dev.ReadFromFile(read_file("lab1.txt", list_dev));
              list_dev.Display();
              GetAVGSalary money = Money;
              list_dev.AVGSalary(money(list_dev.Member));*/


           list_dev.RemoveMemeber(
                
             delegate (Developer d1, Developer d2)
            { return d1.Id.CompareTo(d2.Id);}
            
            ,new Developer() { 
               Id=1
            });


            /*  list_dev.Member.Sort(delegate (Developer x, Developer y)
              {
                  if (x.Name == null && y.Name == null) 
                           return 0;
                  else if (x.Name == null) 
                          return -1;
                  else if (y.Name == null) 
                      return 1;
                  else return x.Name.CompareTo(y.Name);
              });*/
            /*  list_dev.Member.Sort(delegate (Developer x, Developer y)
              {
                  if (x.Salary == 0 && y.Salary == 0)
                      return 0;
                  else if (x.Salary == 0)
                      return -1;
                  else if (y.Salary == 0)
                      return 1;
                  else return x.Salary.CompareTo(y.Salary);
              });*/





            System.Console.ReadKey();
        }
    }
}
