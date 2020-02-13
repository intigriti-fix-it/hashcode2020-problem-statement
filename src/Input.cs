using System.IO;
using System.Linq;

namespace hashcode2020_problem_statement
{
    public class Input
    {
        public int MaxSlices { get; set; }
        public int TypesOfPizza { get; set; }
        public int[] ListOfSlices { get; set; }

        public void ReadFile(string path)
        {
            // Read the file and display it line by line.  
            string line;
            var counter = 0;
            using var file = new StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    var values = line.Split(' ');
                    MaxSlices = int.Parse(values[0]);
                    TypesOfPizza = int.Parse(values[1]);
                    counter++;
                }
                else if (counter == 1)
                {
                    var values = line.Split(' ').Select(int.Parse);
                    ListOfSlices = values.ToArray();
                    counter++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}