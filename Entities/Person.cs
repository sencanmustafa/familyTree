using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
namespace Entities;



public class Person
{
    public int id { get; set; }

    public string? Isim { get; set; }

    public string? Soyisim { get; set; }

    public string? DogumTarihiOld { get; set; }
    public DateOnly? bornDate { get; set; }

    public string? Esi { get; set; }
    //public string? EsId { get; set; }

    public string? AnneAdi { get; set; }

    public string? BabaAdi { get; set; }

    public string? KanGrubu { get; set; }

    public string? Meslek { get; set; }

    public string? MedeniHali { get; set; }

    public string? KizlikSoyismi { get; set; }

    public string? Cinsiyet { get; set; }
    public bool? uvey { get; set; }

    public List<Person>? childList { get; set; }

    public Person? Anne { get; set; }
    public Person? Baba { get; set; }
    public Person? Spouse { get; set; }   
    public List<Person>? kardesList { get; set; }
    public List<Person>? torunList { get; set; }
    public List<Person>? ataList { get; set; }
    public Person()
    {
        this.childList = new List<Person>();
        this.kardesList = new List<Person>();
        this.torunList = new List<Person>();
        this.ataList = new List<Person>();

    }
}