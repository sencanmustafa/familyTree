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
                Console.WriteLine(person.id +  " " + person.Isim + " " + person.Soyisim);

                if (person.Anne != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- ANNE ->  " + person.Anne.id+ " "+person.Anne.Isim + " " + person.Anne.Soyisim);
                }

                if (person.Baba != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- BABA ->  " + person.Baba.id + " " + person.Baba.Isim + " " + person.Baba.Soyisim);
                }

                if (person.Spouse != null) 
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +--  ES -> " + person.Spouse.id + " " + person.Spouse.Isim + " " +  person.Spouse.Soyisim); ;
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
                            Console.WriteLine("      +-- " + child.id +" "+ child.Isim + " " + child.Soyisim + " " + "UVEY COCUK");
                        }
                        else
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + child.id +" "+ child.Isim + " " + child.Soyisim);
                        }
                    }
                }
                if (person.kardesList != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +--  Sisters And Brothers:");

                    foreach (Person kardes in person.kardesList)
                    {
                        if (kardes.uvey == true)
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + kardes.id + " " + kardes.Isim + " " + kardes.Soyisim + " " + "UVEY COCUK");
                        }
                        else
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + kardes.id + " " + kardes.Isim + " " + kardes.Soyisim);
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
                Console.WriteLine(person.Isim + " " + person.Soyisim);

                if (person.Anne != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- " + person.AnneAdi );
                }

                if (person.Baba != null)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- " + person.BabaAdi );
                }

                if (person.Esi != null) // Eşi listele
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- " + person.Esi); ;
                }

                if (person.childList.Count !=0)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +-- Children:");

                    foreach (Person child in person.childList)
                    {
                        Console.WriteLine("      |");
                        Console.WriteLine("      +-- " + child.Isim + " " + child.Soyisim);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

