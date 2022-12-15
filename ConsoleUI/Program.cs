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