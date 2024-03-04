using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;


        public Family()
        {
            people = new List<Person>();
        }


        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person GetOldestMember()
        {
            //Person oldestMember = new Person(null, 0);
            //if (people.Count == 0)
            //{
            //    throw new ArgumentNullException();
            //}
            //foreach (Person person in people)
            //{
            //    if(person.Age >= oldestMember.Age)
            //    {
            //        oldestMember = person;
            //    }
            //}
            //
            //return oldestMember;
            

            return this.people.OrderByDescending(v => v.Age).FirstOrDefault();
        }

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }
    }
}
