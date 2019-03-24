using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace DevTestExample
{
    class LoadFile
    {
        static public List<Person> AddPeople(string path)
        {
            List<Person> people = new List<Person>();

            try
            {
                List<string> lines = File.ReadAllLines(path).ToList();

                //break line into strings and add person to people list
                foreach (string line in lines)
                {
                    Person newPerson = new Person(line);
                    people.Add(newPerson);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return people;
        }
    }
}
