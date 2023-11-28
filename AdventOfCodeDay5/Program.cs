/*
 * https://adventofcode.com/2022/day/5
 * 
 */

using AdventOfCodeDay5;

internal static class Program
{
    private static void Main(string[] args)
    {
        SolveStarOne();

        SolveStarTwo();
    }

    private static void SolveStarOne()
    {
        var crane = new Crane(new Cargo("cargo.txt"));

        crane.GetRearrangementProcedure("input.txt");

        crane.MoveCargo();

        Console.WriteLine(crane.GetCratesOnTopOfStack());
    }

    private static void SolveStarTwo()
    { 
    }
}