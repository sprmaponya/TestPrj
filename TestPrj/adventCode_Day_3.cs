using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPrj
{
    public class AdventCode_Day_3
    {

        public async static Task<int> Day_3_Part_1 (List<string> lines)
        {
            int totalSum = 0;
            int rows = lines.Count;
            int cols = lines[0].Length;

            List<int> dx = new List<int>() { 1, -1,  1, -1, 1, -1,  0, 0 };
            List<int> dy = new List<int>() { 0, -1, -1,  0, 1,  1, -1, 1 };


            // Iterate through each cell in the schematic
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (char.IsDigit(lines[i][j]))
                        {
                            // Extract the full number starting from this position
                            
                            string partNumberStr = ExtractPartNumber(lines, i, j, cols);
                            int partNumber = int.Parse(partNumberStr);

                            // Check all positions of the part number for adjacency to a symbol
                            bool isAdjacentToSymbol = false;
                            for (int k = 0; k < partNumberStr.Length; k++)
                            {
                                int currentCol = j + k;
                                for (int d = 0; d < 8; d++)
                                {
                                    int ni = i + dx.ElementAt(d);
                                    int nj = currentCol + dy.ElementAt(d);

                                    // Check if the adjacent cell is within bounds and is a symbol (not a digit or period)
                                    if (ni >= 0 && ni < rows && nj >= 0 && nj < cols && !char.IsDigit(lines[ni][nj]) && lines[ni][nj] != '.')
                                    {
                                        isAdjacentToSymbol = true;
                                        break;
                                    }
                                }
                                if (isAdjacentToSymbol)
                                {
                                    break;
                                }
                            }

                            // Add the number to the total sum if it is adjacent to a symbol
                            if (isAdjacentToSymbol)
                            {
                                totalSum += partNumber;
                            }

                            // Skip the rest of the digits in this part number
                            j += partNumberStr.Length - 1;
                        }
                    }
                }

                return totalSum;
            }
            catch (Exception)
            {

                throw;
            }

        }

        static Tuple<bool,bool,bool> checkForAdjacentValues(List<string> lines, int row, int col, int cols, List<int> dx,List<int> dy)
        {
            bool valueToRight = false;
            bool valueToLeft = false;
            bool valueInMiddle = false;


            try
            {

                if (char.IsDigit(lines[row][col + 1]))
                {
                    dy.RemoveAt(1);
                    dx.RemoveAt(1);
                    valueToRight = true;
                }

                if (char.IsDigit(lines[row][col - 1]))
                {
                    dy.RemoveAt(2);
                    dx.RemoveAt(2);
                    valueToLeft = true;
                }

                if (valueToRight && valueToLeft)
                {
                    valueInMiddle = true;
                }

                return new Tuple<bool, bool, bool>(valueToRight, valueToLeft, valueInMiddle);
            }
            catch (Exception)
            {

                throw;
            }
        }



        static string ExtractPartNumber(List<string> lines, int row, int col, int cols)
        {
            try
            {
                string partNumber = "";
            

               
                        while (col < cols && char.IsDigit(lines[row][col]))
                        {
                            partNumber += lines[row][col];
                            col++;
                        }
                  


                return partNumber;
            }
            catch (Exception)
            {

                throw;
            }
        }
                static string ExtractPartNumber(List<string> lines, int row, int col, int cols, char? star, ref List<int>? dx, ref List<int>? dy, int? d)
        {
            try
            {
                string partNumber = "";
                Tuple<bool, bool, bool> results = new Tuple<bool, bool, bool>(false, false, false);

                if (d != null)
                {
                    if (star != null && dy.ElementAt(d.Value) == 0 || dy.ElementAt(d.Value) == 3)
                    {
                        results = checkForAdjacentValues(lines, row, col, cols, dx, dy);
                    }
                }
                

                if (results.Item1 == false && results.Item2 ==false)
                {
                    if (dy.ElementAt(d.Value) == -1)
                    {
                        while (col < cols && col >= 0 && char.IsDigit(lines[row][col]))
                        {
                            partNumber += lines[row][col];
                            col--;
                            
                        }
                            char[] charArray = partNumber.ToCharArray();
                            Array.Reverse(charArray);
                            return new string(charArray);
                    }
                    else
                    {
                        while (col < cols && char.IsDigit(lines[row][col]))
                        {
                            partNumber += lines[row][col];
                            col++;
                        }
                        return partNumber;
                    }
                    
                }
                if (results.Item3 == true)
                {
                    col = col - 1;
                    while (col < cols && char.IsDigit(lines[row][col]))
                    {
                        partNumber += lines[row][col];
                        col++;
                    }

                    return partNumber;


                }

                if (results.Item1 == true)
                {
                    while (col < cols && char.IsDigit(lines[row][col]))
                    {
                        partNumber += lines[row][col];
                        col++;
                    }

                    return partNumber;
                }

                if (results.Item2 == true)
                {
                    while (col < cols && col >=0 && char.IsDigit(lines[row][col]))
                    {
                        partNumber += lines[row][col];
                        col--;
                    }
                    char[] charArray = partNumber.ToCharArray();
                    Array.Reverse(charArray);
                    return new string(charArray);
                }
                


                return partNumber;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async static Task<int> Day_3_Part_2(List<string> lines)
        {
            int totalGearRatioSum = 0;
            int rows = lines.Count;
            int cols = lines[0].Length;


            // Iterate through each cell in the schematic
            try
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (lines[i][j] == '*')
                        {
                            List<int> adjacentNumbers = new List<int>();
                            List<int> dx = new List<int>() { 1, 1, 1, -1, -1, -1, 0, 0 };
                            List<int> dy = new List<int>() { 0, 1, -1, 0, -1, 1, -1, 1 };
                            // Check all adjacent cells for part numbers
                            for (int d = 0; d < dy.Count; d++)
                            {
                                int ni = i + dx[d];
                                int nj = j + dy[d];

                                if (ni >= 0 && ni < rows && nj >= 0 && nj < cols && char.IsDigit(lines[ni][nj]))
                                {
                                    string partNumberStr = ExtractPartNumber(lines, ni, nj, cols, '*', ref dx, ref dy, d);
                                    int partNumber = int.Parse(partNumberStr);
                                    adjacentNumbers.Add(partNumber);
                                }
                            }

                            // If exactly two part numbers are adjacent, calculate the gear ratio
                            if (adjacentNumbers.Count == 2)
                            {
                                int gearRatio = adjacentNumbers[0] * adjacentNumbers[1];
                                totalGearRatioSum += gearRatio;
                            }
                        }
                    }
                }

                return totalGearRatioSum;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }


}
