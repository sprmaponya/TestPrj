using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrj
{
    public class Service
    {
        public delegate Task<int> AdventCodeMethodDelegate(string lines);
        public delegate Task<int> AdventCodeMethodDelegate2(List<string> lines);

        public async static Task<List<string>> ReadLinesFromFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }

            return lines;
        }

        public async static Task DisplayAnswer (dynamic answer)
        {
           Console.WriteLine(answer);
        }

        public async static Task<int> SumCalibrationValues(AdventCodeMethodDelegate adventCodeMethodDelegate, List<string> lines)
        {
            int totalSum = 0;

            foreach (string line in lines)
            {
                totalSum += await adventCodeMethodDelegate(line);
            }

            return totalSum;
        }


        public async static Task<int> GearRatios(AdventCodeMethodDelegate2 adventCodeMethodDelegate, List<string> lines)
        {
              return await adventCodeMethodDelegate(lines);
        }


    }
}
