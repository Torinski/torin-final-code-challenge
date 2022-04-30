using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class QuestionClass
    {
        static List<string> NamesList = new List<string>()
         {
             "Jimmy",
             "Jeffrey",
             "John",
         };
        
        // Use recursion to iterate through NamesList
        public static void ListRecursion(int i)
        {
            if (i == NamesList.Count - 1) { 
                Console.WriteLine(NamesList[i]);
                return;
            }

            Console.WriteLine(NamesList[i]);
            ListRecursion(i + 1);
        }
    }
}
