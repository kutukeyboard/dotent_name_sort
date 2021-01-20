using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sort
{
  

  public class Person
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get { return FirstName + ' ' + LastName; } }

    public Person(string _firstName, string _lastName)
    {
      FirstName = _firstName;
      LastName = _lastName;
    }
  }
  public class Program
  {
    public static List<Person> listPerson = new List<Person>();

    public static string getPath(string fileName)
    { 
      return Path.Combine(Directory.GetCurrentDirectory(), fileName);
    }
    public static string[] loadFile(string fileName)
    { 
      string[] names = File.ReadAllLines(getPath(fileName));
      return names;
    }

    public static void addNameToPerson(string[] names)
    {
      foreach (string name in names)
      {
        string[] splitedName = name.Split(' ', 2);
        listPerson.Add(new Person(splitedName[0],splitedName[1]));
      }
    }

    public static  void sortNames(List<Person> listPerson)
    {
      List<Person> sortedPersons = listPerson.OrderBy(p => p.LastName).ToList();

      using (StreamWriter file =
            new StreamWriter(getPath("sorted-names-list.txt")))
      {
        foreach (var person in sortedPersons)
        {
          Console.WriteLine(person.FullName);
          file.WriteLine(person.FullName);
        }
      }
    }
    public static void Main(string[] args)
    {
      string[] names = loadFile("unsorted-names-list.txt");
      addNameToPerson(names);
      sortNames(listPerson);
      
    }
  }
}
