using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotent_name_sort
{
    class person{
		public string firstName{get;set;}
		public string lastName{get;set;}
		public string fullName{get{return firstName + " " + lastName;}}  
		
		public person(string _firstName, string _lastName)
		{
			lastName = _lastName;
			firstName = _firstName;
		}
	};

    class Program
    {
        static List<person> personList = new List<person>();
        
        static string[] loadFile(string fileName) {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            string[] myText = File.ReadAllLines(path);
            return myText;
        }

        static void addNamesToList(string[] names){
            foreach (string name in names)
            {
                string[] arr = name.Split(' ',2);
                person newPerson = new person(arr[0], arr[1]);
                personList.Add(newPerson);
            }
        }

        static void writeOutput(List<person> list){
            string path = Path.Combine(Directory.GetCurrentDirectory(), "sorted-names.txt");
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                foreach (person sortedPerson in list)
                {
                    file.WriteLine(sortedPerson.fullName);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] names = loadFile("unsorted-names.txt");
            addNamesToList(names);
            List<person> newList = personList.OrderBy(p=> p.lastName).ToList();
            writeOutput(newList);
            
        }
    }
}
