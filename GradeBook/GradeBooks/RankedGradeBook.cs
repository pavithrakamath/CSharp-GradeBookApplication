﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int low =  (int)Math.Ceiling(Students.Count * 0.2);
            var orderedGrades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            if(averageGrade >= orderedGrades[low - 1]){
                return 'A';
            }
            else if (averageGrade >= orderedGrades[low * 2 - 1])
            {
                return 'B';
            }
            else if (averageGrade >= orderedGrades[(low * 3) - 1])
            {
                return 'C';
             }
            else if (averageGrade >= orderedGrades[(low * 4) - 1])
            {
                return 'D';
            }

            
            return 'F';
        }
    }
}
