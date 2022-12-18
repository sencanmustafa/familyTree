using Entities;
using Business;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodes nodes = new Nodes();

            ReadCsv readCsv = new ReadCsv();
            List<Person> personList = new List<Person>();
            personList = readCsv.readExcelReturnPersonList();

            //List<Person> personList = new List<Person>();

            //var personList2 = personListOld.OrderBy(p => p.bornDate);

            
            /*
            foreach (var item in personList2)
            {
                personList.Add(item);
            }
            */

           

            /*
            Person AtaAnne = personList[1];
            Person AtaBaba = personList[0];
            for (int i = 2; i < personList.Count(); i++)
            {
                Person seletedPerson = personList[i];
                if (seletedPerson.Cinsiyet == "Erkek")
                {
                    if (seletedPerson.AnneAdı == AtaAnne.İsim && AtaAnne.Soyisim == seletedPerson.Soyisim && seletedPerson.BabaAdı == AtaBaba.İsim && seletedPerson.Soyisim == AtaBaba.Soyisim)
                    {
                        AtaBaba.childList.Add(personList[i]);
                        AtaAnne.childList.Add(personList[i]);
                        nodes.AssignFamilyPerson(personList[i], AtaAnne, AtaBaba);
                    }
                }
                else
                {
                    if (seletedPerson.AnneAdı == AtaAnne.İsim && AtaAnne.Soyisim == seletedPerson.KızlıkSoyismi && seletedPerson.BabaAdı == AtaBaba.İsim && seletedPerson.KızlıkSoyismi == AtaBaba.Soyisim)
                    {
                        AtaBaba.childList.Add(seletedPerson);
                        AtaAnne.childList.Add(seletedPerson);
                        nodes.AssignFamilyPerson(seletedPerson, AtaAnne, AtaBaba);
                    }
                }
                
            }     
            for (int i = 0; i < personList.Count(); i++)
            {
                Person selectedPerson = personList[i];
                for (int j = 0; j < personList.Count(); j++)
                {
                    Person selectedPerson2 = personList[j];
                    if (
                        selectedPerson.id != selectedPerson2.id && 
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        (selectedPerson.Eşi == selectedPerson2.İsim + selectedPerson2.Soyisim || 
                        selectedPerson.Eşi == selectedPerson2.İsim)
                        )
                    {
                        selectedPerson.Spouse = selectedPerson2;
                        selectedPerson2.Spouse = selectedPerson;
                    }
                    else if (
                        selectedPerson.id != selectedPerson2.id &&
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        (selectedPerson2.Eşi == selectedPerson.İsim + selectedPerson.Soyisim ||
                        selectedPerson2.Eşi == selectedPerson.İsim)
                        )
                    {
                        selectedPerson2.Spouse = selectedPerson;
                        selectedPerson.Spouse = selectedPerson2;
                    }
                    else if (
                        selectedPerson.id != selectedPerson2.id &&
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        selectedPerson.BabaAdı == selectedPerson2.İsim
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson.Baba = selectedPerson2;
                        selectedPerson2.childList.Add(selectedPerson);
                    }
                    else if(
                        selectedPerson.id != selectedPerson2.id &&
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        selectedPerson.AnneAdı == selectedPerson2.İsim
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson.Anne = selectedPerson2;
                        selectedPerson2.childList.Add(selectedPerson);
                    }
                    else if (
                        selectedPerson.id != selectedPerson2.id &&
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        selectedPerson.İsim == selectedPerson2.AnneAdı
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson2.Anne = selectedPerson;
                        selectedPerson.childList.Add(selectedPerson2);
                    }
                    else if (
                        selectedPerson.id != selectedPerson2.id &&
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        selectedPerson.İsim == selectedPerson2.BabaAdı
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson2.Baba = selectedPerson;
                        selectedPerson.childList.Add(selectedPerson2);
                    }
                    else if (
                        selectedPerson2.Cinsiyet=="Erkek"&&
                        selectedPerson.id != selectedPerson2.id &&
                        selectedPerson.Soyisim == selectedPerson2.Soyisim &&
                        selectedPerson.KızlıkSoyismi == selectedPerson2.Soyisim
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson.Baba = selectedPerson2;
                        selectedPerson2.childList.Add(selectedPerson);
                    }
                    else if (
                        selectedPerson.Cinsiyet == "Kadın" &&
                        selectedPerson.id != selectedPerson2.id &&(
                        selectedPerson.Soyisim == selectedPerson2.Soyisim ||
                        selectedPerson.KızlıkSoyismi == selectedPerson2.Soyisim)
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson.Anne = selectedPerson2;
                        selectedPerson2.childList.Add(selectedPerson);
                    }

                    
                    if (
                        selectedPerson.id != personList[j].id &&
                        selectedPerson.AnneAdı == personList[j].İsim
                        )
                    {
                        selectedPerson.uvey = true;
                        selectedPerson.Anne = personList[j];
                        personList[j].childList.Add(selectedPerson);
                    }
                    
                    if (
                        selectedPerson.id != personList[j].id &&
                        selectedPerson.BabaAdı == personList[j].İsim
                        )
                    {
                        selectedPerson.uvey = true;
                        selectedPerson.Baba = personList[j];
                        personList[j].childList.Add(selectedPerson);
                    }
                    

                }
            }
            
            */



            foreach (var person in personList)
            {
                foreach (var otherPerson in personList)
                {
                    if (person.id == otherPerson.id)
                    {
                        continue;
                    }

                    if ((person.MedeniHali=="Evli" && otherPerson.MedeniHali=="Evli")&&(person.Esi == otherPerson.Isim+otherPerson.Soyisim))
                    {
                        person.Spouse = otherPerson;
                        
                    }
                    if ((person.MedeniHali == "Evli" && otherPerson.MedeniHali == "Evli") &&(person.KizlikSoyismi == otherPerson.Soyisim) &&(person.bornDate<otherPerson.bornDate))
                    {
                        person.childList.Add(otherPerson);
                        otherPerson.Anne = person;
                        if (person.Spouse!=null)
                        {
                            person.Spouse.childList.Add(otherPerson);
                        }
                    }
                    if ((person.Soyisim == otherPerson.Soyisim || person.Soyisim==otherPerson.KizlikSoyismi || person.KizlikSoyismi ==otherPerson.Soyisim) && (person.bornDate<otherPerson.bornDate)&&(otherPerson.BabaAdi == person.Isim))
                    {
                        person.childList.Add(otherPerson);
                        if (person.Spouse!=null)
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





                }
            }     
                 


            nodes.PrintFamilyTree(personList);

        }
    }
}