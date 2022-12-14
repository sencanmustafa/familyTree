using System;
using CsvHelper.Configuration;

namespace Entities
{
    public class MapPersonToCsvReader : ClassMap<Person>
    {
        public MapPersonToCsvReader()
        {
            Map(m => m.id).Name("id");
            Map(m => m.İsim).Name("İsim");
            Map(m => m.Soyisim).Name("Soyisim");
            Map(m => m.Eşi).Name("Eşi");
            Map(m => m.AnneAdı).Name("AnneAdı");
            Map(m => m.BabaAdı).Name("BabaAdı");
            Map(m => m.KanGrubu).Name("KanGrubu");
            Map(m => m.Meslek).Name("Meslek");
            Map(m => m.MedeniHali).Name("MedeniHali");
            Map(m => m.KızlıkSoyismi).Name("KızlıkSoyismi");
            Map(m => m.Cinsiyet).Name("Cinsiyet");
        }
    }
}

