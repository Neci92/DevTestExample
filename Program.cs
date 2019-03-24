using System;
using System.Collections.Generic;

namespace DevTestExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // create list of paths
            List<string> paths = new List<string>() { @"comma.txt", @"pipe.txt", @"space.txt" };
            string outputPath = @"output.txt";

            Console.WriteLine("DEMO SORTING PROGRAM\n\n" +
                "Reads data from txt files(comma.txt, pipe.txt, space.txt) that are located in test folder.\n" +
                "Sorts data:\n\n" +
                "1) by Gender (Females before Males) then LastName ascending\n" +
                "2) then sorted by Date, ascending\n" +
                "3) finally by last name, descending.\n\n" +
                "Sorted data is saved to output.txt that is also located in test folder.\n" +
                "After data is saved, output file is loaded into console.\n\n" +
                "Press Enter to continue.");
            Console.ReadLine();

            //********
            //if we want to expand this app we can ask user to manually add files for sorting or for output
            //********

            //init list of people
            List<Person> people = new List<Person>();

            foreach (var path in paths)
            {
                people.AddRange(LoadFile.AddPeople(path));
            }

            //clear file for better visibility
            PrintResult.ClearFile(outputPath);

            //append sorted files to output 
            PrintResult.PrintToOutput(people, SortBy.Gender, outputPath);
            PrintResult.PrintToOutput(people, SortBy.Date, outputPath);
            PrintResult.PrintToOutput(people, SortBy.LastName, outputPath);

            //read results from output.txt
            PrintResult.ShowResults(outputPath);

            Console.WriteLine("All valid data is sorted and saved in output.txt that is located in test folder.");
            Console.WriteLine("\nPress Enter to exit.\n");
            Console.ReadLine();
        }
    }
    public enum SortBy
    {
        Gender,
        LastName,
        Date
    }

    public enum Gender
    {
        Female,
        Male
    }

    public enum SortType
    {
        Ascending,
        Descending
    }

}
