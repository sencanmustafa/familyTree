using System.Collections.Generic;
using Entities;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using CsvHelper.Configuration;
using System.Globalization;
using Newtonsoft.Json;
using System.Formats.Asn1;
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
           
           

        }
    }
}