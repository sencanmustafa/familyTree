using System;
using CsvHelper.Configuration;

namespace Entities
{
    public class MapPersonToCsvReader : ClassMap<Person>
    {
        public MapPersonToCsvReader()
        {
            Map(m => m.id).Name("id");
            Map(m => m.Isim).Name("İsim");
            Map(m => m.Soyisim).Name("Soyisim");
            Map(m => m.DogumTarihiOld).Name("Doğum Tarihi");
            Map(m => m.Esi).Name("Eşi");
            //Map(m => m.EsId).Name("EsId");
            Map(m => m.AnneAdi).Name("Anne Adı");
            Map(m => m.BabaAdi).Name("Baba Adı");
            Map(m => m.KanGrubu).Name("Kan Grubu");
            Map(m => m.Meslek).Name("Meslek");
            Map(m => m.MedeniHali).Name("Medeni Hali");
            Map(m => m.KizlikSoyismi).Name("Kızlık Soyismi");
            Map(m => m.Cinsiyet).Name("Cinsiyet");
        }
    }
}

