using System;
using System.Collections.Generic;

namespace DevTestExample
{
    class SortList
    {
        static public List<Person> UseListSort(List<Person> list, SortBy x)
        {
            switch (x)
            {
                //by gender
                case SortBy.Gender:
                    List<Person> completeList = new List<Person>();
                    List<Person> males = new List<Person>();
                    List<Person> females = new List<Person>();

                    //create two different lists
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Gender == Gender.Male)
                        {
                            males.Add(list[i]);
                        }
                        else
                        {
                            females.Add(list[i]);
                        }
                    }

                    //sort males
                    BubbleSort(males, SortBy.LastName, SortType.Descending);

                    //sort females
                    BubbleSort(females, SortBy.LastName, SortType.Descending);

                    //merge female and male into one list
                    completeList.AddRange(females);
                    completeList.AddRange(males);

                    return completeList;

                //by last name
                case SortBy.LastName:
                    BubbleSort(list, x, SortType.Descending);
                    return list;

                //default is used for date sorting
                default:
                    BubbleSort(list, x, SortType.Ascending);
                    return list;
            }

            void BubbleSort(List<Person> list1, SortBy x1, SortType asc)
            {
                int ascending = 1;
                if (asc != SortType.Ascending) ascending = -1;

                if (x1 == SortBy.Date)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = 0; j < list.Count - i - 1; j++)
                        {
                            DateTime a = list[j].DateOfBirth;
                            DateTime b = list[j + 1].DateOfBirth;

                            if (asc == SortType.Ascending)
                            {
                                if (a > b)
                                {
                                    Swap(list, j, j + 1);
                                }
                            }
                            else
                            {
                                if (a < b)
                                {
                                    Swap(list, j, j + 1);
                                }
                            }
                        }
                    }
                }
                else if (x1 == SortBy.LastName)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        for (int j = 0; j < list.Count - i - 1; j++)
                        {
                            string a = list[j].LastName;
                            string b = list[j + 1].LastName;

                            if (a.CompareTo(b) == ascending)
                            {
                                Swap(list, j, j + 1);
                            }
                        }
                    }
                }
            }

            void Swap(List<Person> swapList, int a, int b)
            {
                Person temp = list[a];
                list[a] = list[b];
                list[b] = temp;
            }
        }
    }
}
