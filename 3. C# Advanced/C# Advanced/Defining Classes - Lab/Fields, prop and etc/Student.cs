using System;
using System.Collections.Generic;
using System.Text;

namespace Fields__prop_and_etc
{
    public class Student
    {
        private string firstName;

        public string FirstName 
        {
            get 
            { 
                return this.firstName; 
            }
            set 
            { 
                this.firstName = value; 
            }
        }


        public void Print()
        {
            Console.WriteLine(this.firstName);
        }
    }
}
