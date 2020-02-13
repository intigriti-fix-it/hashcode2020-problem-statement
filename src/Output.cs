using System.Collections.Generic;
using System.IO;

namespace hashcode2020_problem_statement
{
    public class Output
    {
        public List<int> ToWriteOrderedIndexes { get; set; }

        public void WriteFile(string outFileName)
        {
            using TextWriter fileTw = new StreamWriter($"{outFileName}.out");
            fileTw.NewLine = "\n";
            fileTw.WriteLine($"{ToWriteOrderedIndexes.Count}");
            var toWrite = string.Join(' ', ToWriteOrderedIndexes);
            fileTw.Write(toWrite);
        }
    }
}