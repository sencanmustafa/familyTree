using Entities;
using Business;

namespace ConsoleUI
{
    class Program
    {
        public class Node
        {
            public int id; // Bireyin benzersiz bir kimlik numarası
            public string ad; // Bireyin adı
            public string soyad; // Bireyin soyadı
            public Node eş; // Bireyin eşi (eğer varsa)
            public Node anne; // Bireyin annesi (eğer varsa)
            public Node baba; // Bireyin babası (eğer varsa)

            // Yeni bir düğüm oluşturmak için bir yapıcı fonksiyon
            public Node(Person person)
            {
                this.id = person.id;
                this.ad = person.İsim;
                this.soyad = person.Soyisim;
            }
        }
        static void Main(string[] args)
        {
            Nodes nodes = new Nodes();

            ReadCsv readCsv = new ReadCsv();
            List<Person> personList = new List<Person>();
            personList = readCsv.readExcelReturnPersonList();



            
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
                    if (
                        selectedPerson.id != personList[j].id && 
                        selectedPerson.Soyisim == personList[j].Soyisim && 
                        selectedPerson.Eşi == personList[j].İsim + " " + personList[j].Soyisim
                        )
                    {
                        selectedPerson.Spouse = personList[j];
                        personList[j].Spouse = selectedPerson;
                    }
                    if (
                        selectedPerson.id != personList[j].id &&
                        selectedPerson.Soyisim == personList[j].Soyisim &&
                        selectedPerson.BabaAdı == personList[j].İsim
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson.Baba = personList[j];
                        personList[j].childList.Add(selectedPerson);
                    }
                    if (
                        selectedPerson.id != personList[j].id &&
                        selectedPerson.Soyisim == personList[j].Soyisim &&
                        selectedPerson.AnneAdı == personList[j].İsim
                        )
                    {
                        selectedPerson.uvey = false;
                        selectedPerson.Anne = personList[j];
                        personList[j].childList.Add(selectedPerson);
                    }
                    /*
                    if (
                        selectedPerson.id != personList[j].id &&
                        selectedPerson.AnneAdı == personList[j].İsim
                        )
                    {
                        selectedPerson.uvey = true;
                        selectedPerson.Anne = personList[j];
                        personList[j].childList.Add(selectedPerson);
                    }
                    /*
                    if (
                        selectedPerson.id != personList[j].id &&
                        selectedPerson.BabaAdı == personList[j].İsim
                        )
                    {
                        selectedPerson.uvey = true;
                        selectedPerson.Baba = personList[j];
                        personList[j].childList.Add(selectedPerson);
                    }
                    */

                }
            }
            

            nodes.PrintFamilyTree(personList);
         
        }
    }
}