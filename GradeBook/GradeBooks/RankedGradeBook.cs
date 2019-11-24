using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook 
    {
        public RankedGradeBook (string name) : base(name) 
        {
            Type = GradeBookType.Ranked; 
        }


        // override BaseGradeBook GetLetterGrade() 
        public override char GetLetterGrade(double averageGrade)
        {

            // we need at least 5 students to perform ranked grading 
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2); // 20% of the total number of students 
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); // take all student grades and put them in descending order 

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else 
                return 'F'; 
                       
        }
    }
}
