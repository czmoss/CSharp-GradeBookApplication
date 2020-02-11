using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            // Sort from high to low (cf. s2 - s1).
            Students.Sort((s1, s2) => (int)Math.Round(s2.AverageGrade - s1.AverageGrade, 0, MidpointRounding.AwayFromZero));

            var index = Students.FindIndex(s => averageGrade >= s.AverageGrade);
            var ordinal = (double)(index + 1);
            var percent = ordinal / (double)Students.Count;
            if (percent <= 0.2)
            {
                return 'A';
            }

            if (percent <= 0.4)
            {
                return 'B';
            }

            if (percent <= 0.6)
            {
                return 'C';
            }

            if (percent <= 0.8)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
