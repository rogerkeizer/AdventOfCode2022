/*
 * https://adventofcode.com/2022/day/2
 * 
 * You
 * A for Rock 
 * B for Paper
 * C for Scissors
 * 
 * Me - 1 star
 * X for Rock
 * Y for Paper
 * Z for Scissors
 * 
 * Rock defeats Scissors: A defeats C
 * Scissors defeats Paper: C defeats B
 * Paper defeats Rock: B defeats A
 * 
 * Me - 2 stars
 * X for lose
 * Y for draw
 * Z for won
 * 
 */

int rock = 1;
int paper = 2;
int scissors = 3;
int won = 6;
int lose = 0;
int draw = 3;

int totalScoreStar1 = 0;
int totalScoreStar2 = 0;

using StreamReader reader = new("input.txt");

while (reader != null && !reader.EndOfStream)
{
    var r = reader.ReadLine();

    if (r != null)
    {
        switch (r)
        {
            case "A X":
                totalScoreStar1 += (rock + draw);
                totalScoreStar2 += (scissors + lose);
                break;
            case "A Y":
                totalScoreStar1 += (paper + won);
                totalScoreStar2 += (rock + draw);
                break;
            case "A Z":
                totalScoreStar1 += (scissors + lose);
                totalScoreStar2 += (paper + won);
                break;
            case "B X":
                totalScoreStar1 += (rock + lose);
                totalScoreStar2 += (rock + lose);
                break;
            case "B Y":
                totalScoreStar1 += (paper + draw);
                totalScoreStar2 += (paper + draw);
                break;
            case "B Z":
                totalScoreStar1 += (scissors + won);
                totalScoreStar2 += (scissors + won);
                break;
            case "C X":
                totalScoreStar1 += (rock + won);
                totalScoreStar2 += (paper + lose);
                break;
            case "C Y":
                totalScoreStar1 += (paper + lose);
                totalScoreStar2 += (scissors + draw);
                break;
            case "C Z":
                totalScoreStar1 += (scissors + draw);
                totalScoreStar2 += (rock + won);
                break;
            default:
                totalScoreStar1 += 0;
                totalScoreStar2 += 0;
                break;
        }
    }
}

Console.WriteLine($"star 1: {totalScoreStar1}");

Console.WriteLine($"\nstar 2: {totalScoreStar2}");
