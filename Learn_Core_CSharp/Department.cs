using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Learn_Core_CSharp
{

    class Department<T, G> : ICanDisplay
    {
        public delegate int Compare(G o1, G o2);
        private T code;
        private String name;
        private G manager;
        private List<G> member;
        public event EventHandler NumberOfMembersChanged;
       
        public T Code { get => code; set => code = value; }
        public G Manager { get => manager; set => manager = value; }
        public List<G> Member { get => member; set => member = value; }
        public string Name { get => name; set => name = value; }
        
        
        public Department()
        {
            Member = new List<G>();
       
        }

        public void ReadFromFile(int no)
        {
            if (no == 1)
                Console.WriteLine("Read file successfully");
            else
                Console.WriteLine("Read file fail");

        }
        public String GetListMember()
        {
            String temp = null;

            foreach (G member in Member)
            {
                temp += member.ToString()+"\n";
                
            }

            return temp;
        }
        public void WriteToFile(String Filename)
        {
            String path = @"..\..\FileData\" + Filename;
            String list_member = GetListMember();

            if (list_member == null)
                list_member = "empty member";

            String code;

            if (Code == null)
                code = "empty code";
            else
                code = Code.ToString();
            
            if (Name == null)
                Name = "empty name";

            if (File.Exists(path))
            {
                String[] lines = { code, Name, list_member };
                System.IO.File.WriteAllLines(path, lines);
                Console.WriteLine("write to file successfully");
            }
            else
            {
                Console.WriteLine("Can't find file text");
            }

        }

        public void AddMember(G Item)
        {
            if (null != NumberOfMembersChanged)
            {
                NumberOfMembersChanged(this, null);
            }
           
            Member.Add(Item);
            
        }

        public void RemoveMemeber(Compare compare,G Item)
        {
            int count = 0;
            for (int i = 0; i < Member.Count; i++)
            {   

                if (compare(Item, Member.ElementAt(i)) == 0)
                {
                    if (null != NumberOfMembersChanged)
                    {
                        NumberOfMembersChanged(this, null);
                    }
                    Member.RemoveAt(i);
                   
                    count++;
                    break;
                }

               
            }

            if (count == 0)
                Console.WriteLine("remove fail");
        }
        public void Display()
        {

            Console.WriteLine(Code);
            Console.WriteLine(Name);
            foreach (G member in Member)
                Console.WriteLine(member);
        }

         public void AVGSalary(double money)
        {
            Console.WriteLine("AVG Salary : " + money);
        }


    }
}
