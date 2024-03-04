using CustomExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExceptions
{
    public class Student
    {
        private double averageGrade;

        public double AverageGrade 
        { 
            get { return averageGrade; }
            set
            {
                if(value < 2 || value > 6)
                {
                    throw new GradeException("Inavlid grade. Grade must be between 2 and 6!");
                }
                averageGrade = value;
            }
        }
    }
}
