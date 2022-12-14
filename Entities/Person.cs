using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
namespace Entities;



public class Person
{
    public string? id { get; set; }

    public string? İsim { get; set; }

    public string? Soyisim { get; set; }


    public string? Eşi { get; set; }

    public string? AnneAdı { get; set; }

    public string? BabaAdı { get; set; }

    public string? KanGrubu { get; set; }


    public string? Meslek { get; set; }

    public string? MedeniHali { get; set; }

    public string? KızlıkSoyismi { get; set; }

    public string? Cinsiyet { get; set; }

    public List<Person>? childList { get; set; }

    public Person? Anne { get; set; }
    public Person? Baba { get; set; }
    public Person()
    {
        this.childList = new List<Person>();
    }
}