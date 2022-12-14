using System;
using Entities;

namespace Business
{
    public class Nodes
    {
        public void AssignFamilyPerson(Person person, Person mother, Person father)
        {
            person.Anne = mother;
            person.Baba = father;
        }
    }
}

