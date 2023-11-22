namespace AdventOfCodeDay4
{
    internal class SectionAssignment
    {
        public List<Section> sections = new();

        public bool FindOverlapStar1()
        { 
            var section1 = sections[0];
            var section2 = sections[1];

            if (section1 != null && section2 != null)
            {
                var overlaps = section1.range.Intersect(section2.range).Count();

                if (overlaps == section1.range.Count || overlaps == section2.range.Count)
                {
                    return true;
                }
            }

            return false;
        }

        public bool FindOverlapStar2()
        {
            var section1 = sections[0];
            var section2 = sections[1];

            if (section1 != null && section2 != null)
            {
                var overlaps = section1.range.Intersect(section2.range).Count();

                if (overlaps > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddToSectionAssignment(string line)
        {
            string[] input = line.Split(',');

            foreach (var s in input)
            {
                string[] sectionRange = s.Split("-");

                Section section = new();

                section.AddToRange(Convert.ToInt32(sectionRange[0]), Convert.ToInt32(sectionRange[1]));

                sections.Add(section);
            }
        }
    }
}
