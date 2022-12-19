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
                Console.WriteLine(person.id + " " + person.Isim + " " + person.Soyisim );

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

                if (person.childList.Count() != 0)
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
                if (person.kardesList.Count() != 0)
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
                if (person.torunList.Count()!=0)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +--  TORUNLAR:");

                    foreach (Person torun in person.torunList)
                    {
                        if (torun.uvey == true)
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + torun.id + " " + torun.Isim + " " + torun.Soyisim + " " + "UVEY COCUK");
                        }
                        else
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + torun.id + " " + torun.Isim + " " + torun.Soyisim);
                        }
                    }
                }
                if (person.ataList.Count() != 0)
                {
                    Console.WriteLine("  |");
                    Console.WriteLine("  +--  GRANDFATHER And GRANDMOTHER:");

                    foreach (Person ata in person.ataList)
                    {
                        if (ata.uvey == true)
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + ata.id + " " + ata.Isim + " " + ata.Soyisim + " " + "UVEY COCUK");
                        }
                        else
                        {
                            Console.WriteLine("      |");
                            Console.WriteLine("      +-- " + ata.id + " " + ata.Isim + " " + ata.Soyisim);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public void printProblem3(List<Person> familyTree)
        {
            foreach (var item in familyTree)
            {
                Console.WriteLine(item.Isim + " " + item.Soyisim + " " + item.KanGrubu);
            }
        }


        public List<Person> buildFamilyTree(List<Person> personList)
        {
            //List<Person> personList = new List<Person>();
            //personList2 = personList;
            foreach (var person in personList)
            {
                foreach (var otherPerson in personList)
                {
                    if (person.id == otherPerson.id)
                    {
                        continue;
                    }

                    if ((person.MedeniHali == "Evli" && otherPerson.MedeniHali == "Evli") && (person.Esi == otherPerson.Isim + otherPerson.Soyisim))
                    {
                        person.Spouse = otherPerson;

                    }
                    if ((person.MedeniHali == "Evli" && otherPerson.MedeniHali == "Evli") && (person.KizlikSoyismi == otherPerson.Soyisim) && (person.bornDate < otherPerson.bornDate))
                    {
                        person.childList.Add(otherPerson);
                        otherPerson.Anne = person;
                        if (person.Spouse != null)
                        {
                            person.Spouse.childList.Add(otherPerson);
                        }
                    }
                    if ((person.Soyisim == otherPerson.Soyisim || person.Soyisim == otherPerson.KizlikSoyismi || person.KizlikSoyismi == otherPerson.Soyisim) && (person.bornDate < otherPerson.bornDate) && (otherPerson.BabaAdi == person.Isim))
                    {
                        person.childList.Add(otherPerson);
                        if (person.Spouse != null)
                        {
                            person.Spouse.childList.Add(otherPerson);
                        }
                        otherPerson.Anne = person.Spouse;
                        otherPerson.Baba = person;
                    }
                    if (person.AnneAdi == otherPerson.AnneAdi && person.BabaAdi == otherPerson.BabaAdi)
                    {
                        person.kardesList.Add(otherPerson);

                    }
                    if (otherPerson.Anne!=null)
                    {
                        if (person.Isim + person.Soyisim == otherPerson.Anne.AnneAdi || person.Isim == otherPerson.Anne.AnneAdi)
                        {
                            person.torunList.Add(otherPerson);
                            otherPerson.ataList.Add(person);
                        }
                    }
                    if (otherPerson.Baba != null)
                    {
                        if (person.Isim + person.Soyisim == otherPerson.Baba.BabaAdi || person.Isim == otherPerson.Baba.BabaAdi)
                        {
                            person.torunList.Add(otherPerson);
                            otherPerson.ataList.Add(person);
                        }
                    }
                    /*
                    if (otherPerson.Baba.Baba == null)
                    {
                        Console.WriteLine("deneme");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("DENEME");
                        if (person.Isim + person.Soyisim == otherPerson.Baba.Baba.BabaAdi || person.Isim == otherPerson.Baba.Baba.BabaAdi)
                        {
                            person.torunList.Add(otherPerson);
                            otherPerson.ataList.Add(person);
                        }
                    }
                    if (otherPerson.Anne.Anne!=null)
                    {
                        if (person.Isim + person.Soyisim == otherPerson.Anne.Anne.AnneAdi || person.Isim == otherPerson.Anne.Anne.AnneAdi)
                        {
                            person.torunList.Add(otherPerson);
                            otherPerson.ataList.Add(person);
                        }
                    }
                    */
                }
            }

            return personList;
        }


    }
}

