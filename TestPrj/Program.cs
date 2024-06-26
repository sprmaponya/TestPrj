

using System.Text.RegularExpressions;
using TestPrj;



var day_1_part_1_list = await Service.ReadLinesFromFile("InputOfDay_1.txt");
var day_1_part_1_answer = await Service.SumCalibrationValues(AdventCode_Day_1.Day_1_Part_1, day_1_part_1_list);
Service.DisplayAnswer(day_1_part_1_answer);

var day_1_part_2_answer = await Service.SumCalibrationValues(AdventCode_Day_1.Day_1_Part_2, day_1_part_1_list);
Service.DisplayAnswer(day_1_part_2_answer);


//var day_3_part_1_list = new List<string>()
//{
//    "467..114..",
//    "...*......",
//    "..35..633.",
//    "......#...",
//    "617*......",
//    ".....+.58.",
//    "..592.....",
//    "......755.",
//    "...$.*....",
//    ".664.598..",

//};
var day_3_part_1_list = await Service.ReadLinesFromFile("InputOfDay_3.txt");
var day_3_part_1_answer = await Service.GearRatios(AdventCode_Day_3.Day_3_Part_1, day_3_part_1_list);
Service.DisplayAnswer(day_3_part_1_answer);

var day_3_part_2_answer = await Service.GearRatios(AdventCode_Day_3.Day_3_Part_2, day_3_part_1_list);
Service.DisplayAnswer(day_3_part_2_answer);








