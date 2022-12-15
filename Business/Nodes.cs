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
        public  void PrintFamilyTree(List<Person> familyTree)
        {
            foreach (Person person in familyTree)
            {
                Console.WriteLine(person.id +  " " + person.İsim + " " + person.Soyisim);

                if (person.Anne != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- ANNE ->  " + person.Anne.İsim + " " + person.Anne.Soyisim);
                }

                if (person.Baba != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- BABA ->  " + person.Baba.İsim + " " + person.Baba.Soyisim);
                }

                if (person.Spouse != null) 
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +--  ES -> " + person.Spouse.İsim + " " +  person.Spouse.Soyisim); ;
                }

                if (person.childList != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +--  Children:");

                    foreach (Person child in person.childList)
                    {
                        if (child.uvey==true)
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + child.İsim + " " + child.Soyisim + " " + "UVEY COCUK");
                        }
                        else
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + child.İsim + " " + child.Soyisim);
                        }
                    }
                }

                Console.WriteLine();
            }
        }
        public void PrintFamilyTree2(List<Person> familyTree)
        {
            foreach (Person person in familyTree)
            {
                Console.WriteLine(person.İsim + " " + person.Soyisim);

                if (person.Anne != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- " + person.AnneAdı );
                }

                if (person.Baba != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- " + person.BabaAdı );
                }

                if (person.Eşi != null) // Eşi listele
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- " + person.Eşi); ;
                }

                if (person.childList.Count !=0)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- Children:");

                    foreach (Person child in person.childList)
                    {
                        Console.WriteLine("      |");
                        Console.WriteLine("      +-- " + child.İsim + " " + child.Soyisim);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

