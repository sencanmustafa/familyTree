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
            Map(m => m.DogumTarihiOld).Name("DogumTarihi");
            Map(m => m.Esi).Name("Eşi");
            //Map(m => m.EsId).Name("EsId");
            Map(m => m.AnneAdi).Name("AnneAdı");
            Map(m => m.BabaAdi).Name("BabaAdı");
            Map(m => m.KanGrubu).Name("KanGrubu");
            Map(m => m.Meslek).Name("Meslek");
            Map(m => m.MedeniHali).Name("MedeniHali");
            Map(m => m.KizlikSoyismi).Name("KızlıkSoyismi");
            Map(m => m.Cinsiyet).Name("Cinsiyet");
        }
    }
}

