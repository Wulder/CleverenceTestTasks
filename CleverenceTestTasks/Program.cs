
using CleverenceTestTasks;


#region Task1
string rawString = "aaaabbbbffdcccgggaaabbb";
string compressedString = TestTask1.Compress(rawString);

Console.WriteLine(new string('-', 25) + "Task 1" + new string('-', 25));
Console.WriteLine($"raw: {rawString};");
Console.WriteLine($"compressed:{compressedString};");
Console.WriteLine($"decompressed:{TestTask1.Decompress(compressedString)};");
Console.WriteLine(new string('-', 56));
#endregion

#region Task2
Console.WriteLine(new string('-', 25) + "Task 2" + new string('-', 25));

int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }};
var resultArray = TestTask2.GetSpiralArray(matrix);
Console.WriteLine($"[{string.Join(',',resultArray)}]");

matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
resultArray = TestTask2.GetSpiralArray(matrix);
Console.WriteLine($"[{string.Join(',', resultArray)}]");

matrix = new int[5, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 }, { 17, 18, 19, 20 } };
resultArray = TestTask2.GetSpiralArray(matrix);
Console.WriteLine($"[{string.Join(',', resultArray)}]");

Console.WriteLine(new string('-', 56));
#endregion

#region Task3

Console.WriteLine("\n\n\n"+new string('-', 25) + "Task 1" + new string('-', 25));
TestTask3 t3 = new TestTask3(1, 5, 0);

//t3.StartSimulation(); запуск симуляции клиентов


#endregion