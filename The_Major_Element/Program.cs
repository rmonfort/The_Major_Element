using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace The_Major_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if command line argument exists, otherwise ask user for input file
            string input_file;
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter the path to your input file: ");
                input_file = Console.ReadLine();
            }
            else
            {
                input_file = args[0];
            }

            string[] lines = System.IO.File.ReadAllLines(input_file);

            foreach (var line in lines)
            {
                // Print None by default if line is empty
                if (line == "")
                {
                    Console.WriteLine("None");
                    continue;
                }
                string[] numbers = line.Split(','); // Split line up by comma
                int sequence_length = numbers.Length; // Obtain length of sequence
                string[] unique_numbers = numbers.Distinct().ToArray(); // A array of unique numbers to make the search faster
                string major_element = ""; // Set default major element

                foreach (var number in unique_numbers)
                {
                    int number_of_occurences = numbers.Count(element => element == number); // Count number of occurences 

                    // Compare number of occurences to sequence length/2 and set major element accordingly
                    if (number_of_occurences > (sequence_length/2)) 
                    {
                        major_element = number;
                        break; // Break once major element is found
                    }
                }

                if (major_element == "") // If no major element found print none
                {
                    Console.WriteLine("None");
                }
                else
                {
                    Console.WriteLine(major_element); // Print major element if it was found
                }
            }
        }
    }
}
