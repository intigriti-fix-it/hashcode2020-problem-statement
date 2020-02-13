//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace hashcode2020_problem_statement
//{
//    class Program
//    {
//        private static int RunCount = 0;
//        static void Main(string[] args)
//        {

//            //var fileName = "a_example";
//            var fileName = "b_small";
//            //var fileName = "c_medium";
//            //var fileName = "e_also_big";
//            //var fileName = "d_quite_big";

//            var reader = new Input();
//            reader.ReadFile($"{fileName}.in");

//            var maxSlices = reader.MaxSlices;
//            var input = reader.ListOfSlices;

//            var tuple = input.Select((x, i) => (Index: i, Value: x)).OrderBy(x => x.Value).ToList();

//            Run(maxSlices, tuple, fileName);
//        }

//        private static void Run(int maxSlices, List<(int Index, int Value)> tuple, string fileName)
//        {
//            RunCount++;
//            Console.WriteLine($"I run {RunCount}");
//            var total = tuple.Sum(x => x.Value);
//            var difference = total - maxSlices;
//            if (difference <= 0)
//            {
//                // Take alles
//                WriteResult(tuple, fileName);
//            }

//            var left = tuple.Where(x => x.Value <= difference).ToList();
//            var right = tuple.Where(x => x.Value > difference).ToList();

//            if (!right.Any())
//            {
//                Backup(left, maxSlices, fileName);
//            }

//            var minValRight = right[0];

//            if (minValRight.Value == difference)
//            {
//                WriteResult(tuple.Where(x => x.Index != minValRight.Index).ToList(), fileName);
//            }

//            var totalLeft = left.Sum(x => x.Value);

//            if (totalLeft < difference)
//            {
//                WriteResult(tuple.Where(x => x.Index != minValRight.Index).ToList(), fileName);
//            }

//            if (totalLeft == difference)
//            {
//                WriteResult(right, fileName);
//            }

//            Run(difference, left, fileName);
//        }

//        private static void Backup(List<(int Index, int Value)> tuple, int maxSlices, string fileName)
//        {
//            var usedIndexes = new List<(int Index, int Value)>();
//            var accumulatorValue = 0;
//            for (var i = 0; i < tuple.Count; i++)
//            {
//                var k = tuple[i];
//                var potentialAccumulatorValue = accumulatorValue + k.Value;
//                if (potentialAccumulatorValue == maxSlices)
//                {
//                    accumulatorValue = potentialAccumulatorValue;
//                    usedIndexes.Add(k);
//                    break;
//                }

//                if (potentialAccumulatorValue < maxSlices)
//                {
//                    accumulatorValue = potentialAccumulatorValue;
//                    usedIndexes.Add(k);
//                }
//            }
//            WriteResult(usedIndexes, fileName);
//        }

//        private static void WriteResult(List<(int Index, int Value)> tuple, string fileName)
//        {
//            var totalResult = tuple.Sum(x => x.Value);
//            var ordered = tuple.OrderBy(x => x.Index).Select(x => x.Index).ToList();

//            Console.WriteLine($"Total result {totalResult}");
//            var output = new Output
//            {
//                ToWriteOrderedIndexes = ordered
//            };
//            output.WriteFile(fileName);
//            throw new Exception("DONZO");
//        }
//    }
//}
