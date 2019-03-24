using System;
using System.Globalization;
using System.Linq;


namespace DevTestExample
{
    class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        char[] customSeparators = new char[] { ',', '|', ' ' };

        CultureInfo enUS = new CultureInfo("en-US");

        public Person(string line)
        {
            //break line into usable strings
            string[] entries = line.Split(customSeparators);

            //since we have space between separators and we have space as a separator, when spliting lines that use comma/pipe we get 
            //bunch of empty strings. This line of code removes empty strings and leave us only with data.
            entries = entries.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //Add first and second string as last and first name
            LastName = entries[0];
            FirstName = entries[1];

            //if we have 6 items in array take third to be middle name
            if (entries.Length == 6) MiddleName = entries[2];

            // check last three strings and add their value to corresponding property
            for (int i = entries.Length - 3; i < entries.Length; i++)
            {
                //check for birth date - if/else statement makes sure that we parsed both formats correctly
                if (IsDate(entries[i]))
                {

                    if (DateTime.TryParseExact(entries[i], "M/dd/yyyy", enUS, DateTimeStyles.None, out DateTime dateValue)) DateOfBirth = dateValue;

                    else DateOfBirth = DateTime.Parse(entries[i]);
                }
                else if (CheckGender(entries[i]) == Gender.Male) Gender = Gender.Male;

                else if (CheckGender(entries[i]) == Gender.Female) Gender = Gender.Female;

                else FavoriteColor = entries[i];
            }
        }

        Gender? CheckGender(string x)
        {
            if (x.ToLower() == "m" || x.ToLower() == "male") return Gender.Male;
            if (x.ToLower() == "f" || x.ToLower() == "female") return Gender.Female;
            return null;
        }

        bool IsDate(string x)
        {
            string[] dateFormats = { "M/dd/yyyy", "M-d-yyyy" };

            if (DateTime.TryParseExact(x, dateFormats, enUS, DateTimeStyles.None, out DateTime dateValue)) return true;
            return false;
        }
    }
}
