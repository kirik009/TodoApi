using Newtonsoft.Json;

using TodoApi;
namespace Api
{

    //[JsonConverter(typeof(SumConverter), "ПроцентАвтоматизированнойСкидки", "ПроцентРучнойСкидки", "ПроцентСкидки")]
    //public class Процент
    //{
    //    public double ПроцентАвтоматизированнойСкидки { get; set; }
    //    public double ПроцентРучнойСкидки { get; set; }
    //    public double ПроцентСкидки { get; set; } // Будет автоматически вычисляться
    //}


    //[JsonConverter(typeof(SumConverter), "СуммаАвтоматизированнойСкидки", "СуммаРучнойСкидки", "СуммаСкидки")]
    //public class Сумма
    //{
    //    public double СуммаАвтоматизированнойСкидки { get; set; }
    //    public double СуммаРучнойСкидки { get; set; }
    //    public double СуммаСкидки { get; set; } // Будет автоматически вычисляться
    //}

    public class ТабличнаяЧасть
    {

       
        public double Количество { get; set; }
        [JsonProperty("КолУпак")]
        public double КоличествоУпаковок { get; set; }
        public double Цена { get; set; }
        [JsonConverter(typeof(NDSConvertor))]
        public string СтавкаНДС { get; set; }
        public double Сумма { get; set; }


        public double СуммаАвтоматизированнойСкидки { get; set; }
        public double СуммаРучнойСкидки { get; set; }

        public double ПроцентАвтоматизированнойСкидки { get; set; }
        public double ПроцентРучнойСкидки { get; set; }

        [JsonIgnore] // Исключаем из JSON, но используем в C#
        public double СуммаСкидки => СуммаАвтоматизированнойСкидки + СуммаРучнойСкидки;

        [JsonIgnore]
        public double ПроцентСкидки => ПроцентАвтоматизированнойСкидки + ПроцентРучнойСкидки;

        [JsonProperty("СуммаСкидки")]
        public double СуммаСкидкиJson => СуммаСкидки;

        [JsonProperty("ПроцентСкидки")]
        public double ПроцентСкидкиJson => ПроцентСкидки;
    }
    public class Контрагент
    {

        
        public string Наименование { get; set; }
        public string ВидОбъекта { get; set; }
        [JsonProperty("ПолнНаименование")]
        public string НаименованиеПолное { get; set; }
        public string КПП { get; set; }
        [JsonProperty("ОКПО")]
        public string КодПоОКПО { get; set; }


         
    }
   
    public class Todo
    {
       

          
            public string ВидОбъекта { get; set; }
            public string GUID_Retail { get; set; }
            [JsonProperty("НомерЭлНакл")]
            public string НомерЭлектроннойНакладной { get; set; }
            public string Прицеп { get; set; }
            [JsonProperty("ДовДата")]
            public string ДоверенностьДата { get; set; }
            [JsonProperty("ДовНом")]
            public string ДоверенностьНомер { get; set; }
            [JsonProperty("ДовФИО")]
            public string ДоверенностьЛицо { get; set; }
            [JsonProperty("СерияБланка")]
            public string КодБланка { get; set; }
            public string Основание { get; set; }
            public List<ТабличнаяЧасть> ТабличнаяЧасть { get; set; } = new List<ТабличнаяЧасть>();

            public Контрагент Контрагент { get; set; }
            
            public string Автомобиль { get; set; }
            
            
            
    }
}
