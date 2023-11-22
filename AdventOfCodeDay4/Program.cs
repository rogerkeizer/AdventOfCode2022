using AdventOfCodeDay4;

internal class Program 
{
    private static void Main(string[] args)
    {
        using StreamReader reader = new("input.txt");

        List<SectionAssignment> sectionAssigmentsStar1 = new();
        List<SectionAssignment> sectionAssigmentsStar2 = new();

        while (reader != null && !reader.EndOfStream)
        {
            var r = reader.ReadLine();

            if (r != null)
            {
                var sectionAssignment = new SectionAssignment();

                sectionAssignment.AddToSectionAssignment(r);

                if (sectionAssignment.FindOverlapStar1())
                {
                    sectionAssigmentsStar1.Add(sectionAssignment);
                }

                if (sectionAssignment.FindOverlapStar2())
                {
                    sectionAssigmentsStar2.Add(sectionAssignment);
                }
            }
        }

        Console.WriteLine($"Star 1: {sectionAssigmentsStar1.Count}");

        Console.WriteLine($"Star 2: {sectionAssigmentsStar2.Count}");
    }
}
