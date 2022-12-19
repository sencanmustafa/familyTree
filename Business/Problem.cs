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

        public List<Person> problem5(List<Person> personList)
        {
            List<Person> problem5List = new List<Person>();
            foreach (var person in personList)
            {
                foreach (var person2 in personList)
                {
                    if (person.id == person2.id)
                    {
                        continue;
                    }
                    if (person.Isim == person2.Isim)
                    {
                        problem5List.Add(person);
                    }
                }
            }
            return problem5List;
        }
        public int problem8(List<Person> personList)
        {
            Nodes nodes = new Nodes();
            List<int> lengths = new List<int>();
            List<int> lengths2 = new List<int>();
            List<Person> newPersonList = new List<Person>();
            newPersonList = personList;
            newPersonList.OrderBy(p => p.bornDate);

            foreach (var person in newPersonList)
            {
                int x = 0;
                int lenght = nodes.findLenghtFatherFamilyTree(person, x);
                lengths.Add(lenght);
            }
            foreach (var person in newPersonList)
            {
                int x = 0;
                int lenght = nodes.findLenghtMotherFamilyTree(person, x);
                lengths2.Add(lenght);
            }
            int a = lengths.Max();
            int b = lengths2.Max();
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    
        public List<Person> problem1(List<Person> personList)
        {
            List<Person> newList = new List<Person>();
            foreach (var person in personList)
            {
                if (person.childList.Count()==0)
                {
                    newList.Add(person);
                }
            }
            return newList;
        }

    }
}

