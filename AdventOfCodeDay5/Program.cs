/*
 * https://adventofcode.com/2022/day/5
 * 
 */

using AdventOfCodeDay5;

internal static class Program
{
    private static void Main(string[] args)
    {
        var crane9000 = new Crane(new Cargo("cargo.txt"));

        var crane9001 = new Crane(new Cargo("cargo.txt"));

        SolveStarOne(crane9000);

        SolveStarTwo(crane9001);
    }

    private static void SolveStarOne(Crane crane)
    {
        crane.GetRearrangementProcedure("input.txt");

        crane.MoveCargo9000();

        Console.WriteLine(crane.GetCratesOnTopOfStack());
    }

    private static void SolveStarTwo(Crane crane)
    {
        crane.GetRearrangementProcedure("input.txt");

        crane.MoveCargo9001();

        Console.WriteLine(crane.GetCratesOnTopOfStack());
    }
}