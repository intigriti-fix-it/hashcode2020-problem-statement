using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace hashcode2020_problem_statement
{
    class Program
    {
        private static int RunCount = 0;
        static void Main(string[] args)
        {

            //var fileName = "a_example";
            //var fileName = "b_small";
            //var fileName = "c_medium";
            //var fileName = "e_also_big";
            var fileName = "d_quite_big";

            var reader = new Input();
            reader.ReadFile($"{fileName}.in");

            var maxSlices = reader.MaxSlices;
            var input = reader.ListOfSlices;

            var tuple = input.Select((x, i) => (Index: i, Value: x)).OrderBy(x => x.Value).ToList();

            Run(maxSlices, tuple, fileName);
        }

        private static void Run(int maxSlices, List<(int Index, int Value)> tuple, string fileName)
        {
            RunCount++;
            Console.WriteLine($"I run {RunCount}");
            var total = tuple.Sum(x => x.Value);
            var difference = total - maxSlices;
            if (difference <= 0)
            {
                // Take alles
                WriteResult(tuple, fileName);
            }

            var left = tuple.Where(x => x.Value <= difference).ToList();
            var right = tuple.Where(x => x.Value > difference).ToList();

            if (!right.Any())
            {
                (int Total, List<(int Index, int Value)> i) h = (0, new List<(int Index, int Value)>());
                for (int i = 0; i < 100000; i++)
                {
                    var result = Backup(left, maxSlices);
                    if (result.Total == maxSlices)
                    {
                        WriteResult(result.UsedIndexes, fileName);
                    }
                    else if (result.Total > h.Total)
                    {
                        Console.WriteLine("BETER");
                        h = result;
                    }
                    else
                    {
                        Console.WriteLine("SLECHTER");
                    }
                    left.Shuffle();
                }
                WriteResult(h.i, fileName);
            }

            var minValRight = right[0];

            if (minValRight.Value == difference)
            {
                WriteResult(tuple.Where(x => x.Index != minValRight.Index).ToList(), fileName);
            }

            var totalLeft = left.Sum(x => x.Value);

            if (totalLeft < difference)
            {
                WriteResult(tuple.Where(x => x.Index != minValRight.Index).ToList(), fileName);
            }

            if (totalLeft == difference)
            {
                WriteResult(right, fileName);
            }

            Run(difference, left, fileName);
        }



        private static (int Total, List<(int Index, int Value)> UsedIndexes) Backup(List<(int Index, int Value)> tuple, int maxSlices)
        {
            var usedIndexes = new List<(int Index, int Value)>();
            var accumulatorValue = 0;
            for (var i = 0; i < tuple.Count; i++)
            {
                var k = tuple[i];
                var potentialAccumulatorValue = accumulatorValue + k.Value;
                if (potentialAccumulatorValue == maxSlices)
                {
                    accumulatorValue = potentialAccumulatorValue;
                    usedIndexes.Add(k);
                    break;
                }

                if (potentialAccumulatorValue < maxSlices)
                {
                    accumulatorValue = potentialAccumulatorValue;
                    usedIndexes.Add(k);
                }
            }
            return (usedIndexes.Sum(x => x.Value), usedIndexes);
        }

        private static void WriteResult(List<(int Index, int Value)> tuple, string fileName)
        {
            var totalResult = tuple.Sum(x => x.Value);
            var ordered = tuple.OrderBy(x => x.Index).Select(x => x.Index).ToList();

            Console.WriteLine($"Total result {totalResult}");
            var output = new Output
            {
                ToWriteOrderedIndexes = ordered
            };
            output.WriteFile(fileName);
            throw new Exception("DONZO");
        }
    }

    public static class Extensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
