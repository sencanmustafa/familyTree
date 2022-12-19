using System;
using Entities;

namespace Business
{
    public class Problem
    {
        public List<Person> problem3(List<Person> personList)
        {
            List<Person> problem3List = new List<Person>();
            foreach (var person in personList)
            {
                if (person.KanGrubu.Contains("A") && !person.KanGrubu.Contains("B"))
                {
                    problem3List.Add(person);
                }
            }
            return problem3List;
        }

    }
}

