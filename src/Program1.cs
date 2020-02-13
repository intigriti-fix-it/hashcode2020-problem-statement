//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace hashcode2020_problem_statement
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var maxSlices = 17;
//            var input = new [] { 2, 5, 6, 8 };

//            var orderedInput = input.ToList();

//            var usedIndexes = new List<int>();
//            var accumulatorValue = 0;
//            for (var i = 0; i < orderedInput.Count; i++)
//            {
//                var potentialAccumulatorValue = accumulatorValue + input[i];
//                if (potentialAccumulatorValue == maxSlices)
//                {
//                    accumulatorValue = potentialAccumulatorValue;
//                    usedIndexes.Add(i);
//                    break;
//                }

//                if (potentialAccumulatorValue < maxSlices)
//                {
//                    accumulatorValue = potentialAccumulatorValue;
//                    usedIndexes.Add(i);
//                }
//            }
//        }
//    }
//}
