//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace hashcode2020_problem_statement
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var fileName = "b_small";

//            var reader = new Input();
//            reader.ReadFile($"{fileName}.in");


//            var maxSlices = reader.MaxSlices;
//            var input = reader.ListOfSlices;

//            var total = input.Sum();

//            var difference = total - maxSlices;

//            var usedIndex = -1;

//            // negative or max we zien wel.
//            var compareValue = Int32.MaxValue;

//            for (var i = 0; i < input.Length; i++)
//            {
//                var currentValue = input[i];

//                if (currentValue >= difference && currentValue < compareValue)
//                {
//                    usedIndex = i;
//                    compareValue = currentValue;
//                }
//            }

//            var usedIndexes = new List<int>();
//            var totalResult = 0;
//            for (var i = 0; i < input.Length; i++)
//            {
//                if (i != usedIndex)
//                {
//                    totalResult = totalResult + input[i];
//                    usedIndexes.Add(i);
//                }
//            }

//            Console.WriteLine($"Total result {totalResult}");
//            var output = new Output
//            {
//                ToWriteOrderedIndexes = usedIndexes
//            };
//            output.WriteFile(fileName);
//        }
//    }
//}
