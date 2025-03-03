using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TodoApi;
namespace Api
{

    public class ТабличнаяЧасть
    {
        public string Товар_UID { get; set; }
        public Товар Товар { get; set; }
       
        public double Количество { get; set; }
        [JsonProperty("КолУпак")]
        public double КоличествоУпаковок { get; set; }
        public double Цена { get; set; }
       
        public string СтавкаНДС { get; set; }
        public double Сумма { get; set; }


        public double СуммаАвтоматизированнойСкидки { get; set; }
        public double СуммаРучнойСкидки { get; set; }

        public double ПроцентАвтоматизированнойСкидки { get; set; }
        public double ПроцентРучнойСкидки { get; set; }

        [Newtonsoft.Json.JsonIgnore] // Исключаем из JSON, но используем в C#
        public double СуммаСкидки => СуммаАвтоматизированнойСкидки + СуммаРучнойСкидки;

        [Newtonsoft.Json.JsonIgnore]
        public double ПроцентСкидки => ПроцентАвтоматизированнойСкидки + ПроцентРучнойСкидки;

        [JsonProperty("СуммаСкидки")]
        public double СуммаСкидкиJson => СуммаСкидки;

        [JsonProperty("ПроцентСкидки")]
        public double ПроцентСкидкиJson => ПроцентСкидки;
    }

    public class Товар
    {
        public string Наименование { get; set; }
        public string ВидОбъекта { get; set; }
 

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

    public class Заказчик
    {
        public string Наименование { get; set; }
        public string ВидОбъекта { get; set; }
        [JsonProperty("ПолнНаименование")]
        public string НаименованиеПолное { get; set; }
        public string КПП { get; set; }
        [JsonProperty("ОКПО")]
        public string КодПоОКПО { get; set; }

    }

    public class РасчетныйСчет
    {
        public string Наименование { get; set; }
        public string ВидОбъекта { get; set; }
        public string ГородБанка { get; set; }
        [JsonProperty("КодБанка")]
        public string БикБанка { get; set; }
        [JsonProperty("РасчетныйСчет")]
        public string НомерСчета { get; set; }
        [JsonProperty("РасчетныйСчетКорр")]
        public string КоррСчетБанка { get; set; }

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
            public string Контрагент_UID { get; set; }

            public Контрагент Контрагент { get; set; }
            
            public string Автомобиль { get; set; }
            [Newtonsoft.Json.JsonConverter(typeof(BoolConvertor))]

            [JsonProperty("флЭлНакл")]
            public bool ЭтоЭлектроннаяНакладная { get; set; }

            [JsonProperty("НомерДокРозницы")]
            public string Номер { get; set; }
            public string Погрузка { get; set; }
            public string Заказчик_UID { get; set; }
            public Заказчик Заказчик { get; set; }

            public string Экспедитор { get; set; }
            [JsonProperty("ДатаПрибытияП")]
            public string ДатаПрибытияПогрузка { get; set; }
            [JsonProperty("СчетПолучателя_UID")]
            public string БанковскийСчетГрузополучателя_UID { get; set; }
            [JsonProperty("СчетПолучателя")]
            [JsonPropertyOrder(int.MaxValue)]
            public РасчетныйСчет БанковскийСчетГрузополучателя { get; set; }
        


    }
}


