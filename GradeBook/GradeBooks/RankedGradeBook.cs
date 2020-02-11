using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var sortedStudents = Students.OrderByDescending(s => s.AverageGrade).ToList();

            var index = sortedStudents.FindIndex(s => averageGrade >= s.AverageGrade);
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
