
namespace AdventOfCode2023
{
    internal class Program {
        static void Main(string[] args) {
            var d1 = new Day1Part1();
            Console.WriteLine($"{nameof(Day1Part1)}, { d1.GetResult()}");

            var d2 = new Day1Part2();
            Console.WriteLine($"{nameof(Day1Part2)}, {d2.GetResult()}");


        }
    }
}