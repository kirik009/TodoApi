using System.Text.Json.Serialization;
namespace Api
{


    public class ТабличнаяЧасть
    {

        public int Id { get; set; }
        public double Количество { get; set; }
        [JsonPropertyName("КоличествоУпаковок")]
        public double КолУпак { get; set; }
        public double Цена { get; set; }
        public double Сумма { get; set; }



    }
    public class Контрагент
    {

        public int Id { get; set; }
        public string Наименование { get; set; }
        [JsonPropertyName("НаименованиеПолное")]
        public string ПолнНаименование { get; set; }
        public string КПП { get; set; }
        [JsonPropertyName("КодПоОКПО")]
        public string ОКПО { get; set; }


         
    }
   
    public class Todo
    {
       

            public int Id { get; set; }
            public string ВидОбъекта { get; set; }
            public string GUID_Retail { get; set; }
            [JsonPropertyName("НомерЭлектроннойНакладной")]
            public string НомерЭлНакл { get; set; }
            public string Прицеп { get; set; }
            [JsonPropertyName("ДоверенностьДата")]
            public string ДовДата { get; set; }
            [JsonPropertyName("ДоверенностьНомер")]
            public string ДовНом { get; set; }
            [JsonPropertyName("ДоверенностьЛицо")]
            public string ДовФИО { get; set; }
            [JsonPropertyName("КодБланка")]
            public string СерияБланка { get; set; }
            public string Основание { get; set; }
            public List<ТабличнаяЧасть> ТабличнаяЧасть { get; set; } = new List<ТабличнаяЧасть>();

            public Контрагент Контрагент { get; set; }
            
            public string Автомобиль { get; set; }
            
            
            
    }
}
