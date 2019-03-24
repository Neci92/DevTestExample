using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DevTestExample
{
    class PrintResult
    {
        static public void ClearFile(string outputPath)
        {
            try
            {
                File.WriteAllText(outputPath, "");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            
        }

        static public void PrintToOutput(List<Person> people, SortBy x, string outputPath)
        {
            try
            {
                switch (x)
                {
                    case SortBy.Gender:
                        //sort by gender and last name and save result to output2.txt
                        File.AppendAllText(outputPath, "sorted by Gender (Females before Males) then LastName ascending: \n\n");
                        people = SortList.UseListSort(people, SortBy.Gender);
                        break;
                    case SortBy.LastName:
                        //sort by last name and save result to output2.txt
                        File.AppendAllText(outputPath, "sorted by last name, descending: \n\n");
                        people = SortList.UseListSort(people, SortBy.LastName);
                        break;
                    case SortBy.Date:
                        //sort by date and save result to output2.txt 
                        File.AppendAllText(outputPath, "\nsorted by Date, ascending: \n\n");
                        people = SortList.UseListSort(people, SortBy.Date);
                        break;
                    default:
                        Console.WriteLine("You cannot reach this option");
                        break;
                }
                SaveToOutput(people, outputPath);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            
        }

        public static void ShowResults(string outputPath)
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private static void SaveToOutput(List<Person> people, string outputPath)
        {
            string columnSize = "{0,-15}";
            string divider = "--------------------- \n\n";

            File.AppendAllText(outputPath, divider);

            foreach (var newPerson in people)
            {
                string textLine = $" { string.Format(columnSize, newPerson.LastName) }" +
                    $"{ string.Format(columnSize, newPerson.FirstName) }" +
                    $"{ string.Format(columnSize, newPerson.Gender) }" +
                    $"{ string.Format(columnSize, newPerson.DateOfBirth.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)) }" +
                    $"{ string.Format(columnSize, newPerson.FavoriteColor) } \n";

                File.AppendAllText(outputPath, textLine);
            }
            File.AppendAllText(outputPath, divider);
        }

    }
}
