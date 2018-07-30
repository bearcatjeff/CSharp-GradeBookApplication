using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        protected List<double> gradeAverages;

        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
            gradeAverages = new List<double>();
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students");
            }

            SortGrades();

            int percentileBreak = (int)Math.Truncate((double)Students.Count / 5);

            if (gradeAverages.IndexOf(averageGrade) > Students.Count - percentileBreak - 1)
            {
                return 'A';
            }
            if (gradeAverages.IndexOf(averageGrade) > Students.Count - 2 * percentileBreak - 1)
            {
                return 'B';
            }
            if (gradeAverages.IndexOf(averageGrade) > Students.Count - 3 * percentileBreak - 1)
            {
                return 'C';
            }
            if (gradeAverages.IndexOf(averageGrade) > Students.Count - 4 * percentileBreak - 1)
            {
                return 'D';
            }

            return 'F';
        }

        private void SortGrades()
        {            
            foreach (Student currStudent in Students)
            {
                gradeAverages.Add(currStudent.AverageGrade);
            }

            gradeAverages.Sort();            
        }


    }
}
