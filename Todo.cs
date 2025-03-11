using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TodoApi;
namespace Api
{

    public class ТабличнаяЧасть
    {
        public string Товар_UID { get; set; }
        
        public Товар Товар { get; set; }

        public string ВидТовара { get; set; }

        public double Количество { get; set; }
        [JsonProperty("КолУпак")]
        public double КоличествоУпаковок { get; set; }

        public double Цена { get; set; }
       
        public string СтавкаНДС { get; set; }
        public double Сумма { get; set; }
        [JsonProperty("НДС")]
        public double СуммаНДС { get; set; }


        public double СуммаАвтоматическойСкидки { get; set; }
        public double СуммаРучнойСкидки { get; set; }

        public double ПроцентАвтоматическойСкидки { get; set; }
        public double ПроцентРучнойСкидки { get; set; }

        [Newtonsoft.Json.JsonIgnore] // Исключаем из JSON, но используем в C#
        public double СуммаСкидки => СуммаАвтоматическойСкидки + СуммаРучнойСкидки;

        [Newtonsoft.Json.JsonIgnore]
        public double ПроцентСкидки => ПроцентАвтоматическойСкидки + ПроцентРучнойСкидки;

        [JsonProperty("СуммаСкидки")]
        public double СуммаСкидкиJson => СуммаСкидки;

        [JsonProperty("ПроцентСкидки")]
        public double ПроцентСкидкиJson => ПроцентСкидки;
    }
    
    public class Товар
    {
        public string Наименование { get; set; }
      
        public string ВидОбъекта {get; set; }
        [Newtonsoft.Json.JsonConverter(typeof(BoolConvertor))]
        public  bool? Весовой { get; set; } //ю03_Блюда

        [JsonProperty("Код_Розница")]
        public string? Код { get; set; } //ю03_Продукты
        [JsonProperty("Страна_UID")]
        public string СтранаПроисхождения_UID { get; set; }

        [JsonProperty("Страна")]
        public СтранаПроисхождения?  СтранаПроисхождения{ get; set; } //ю03_Продукты
        
        
        [JsonProperty("ЕдИзм_UID")]
        public string ЕдиницаИзмерения_UID { get; set; }


        [JsonProperty("ЕдИзм", NullValueHandling = NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonIgnore] // Игнорируем это поле при сериализации
        public ЕдИзм? ЕдиницаИзмерения { get; set; }

        [Newtonsoft.Json.JsonIgnore] // Игнорируем это поле при сериализации
        public string? ЕдИзм { get; set; }

        // Виртуальное поле, сериализуемое в JSON
        [JsonProperty("ЕдИзм", NullValueHandling = NullValueHandling.Ignore)]
        public object ЕдиницаИзмеренияДляJson
        {
            get
            {
                if (ЕдиницаИзмерения != null)
                    return ЕдиницаИзмерения;

                return ЕдИзм;
            }
        }

        [JsonProperty("ПолноеНаименование")]
        public string? НаименованиеПолное { get; set; } //ю03_Продукты
        [JsonProperty("Группа_UID")]
        public string ТоварнаяГруппа_UID { get; set; }
        [JsonProperty("Группа")]
        public ТоварнаяГруппа? ТоварнаяГруппа { get; set; } //ю03_Продукты
        [JsonProperty("ТНВЭД_UID")]
        public string КодТНВЭД_UID { get; set; }
        [JsonProperty("ТНВЭД")]
        public ТНВЭД? КодТНВЭД { get; set; } //ю03_Продукты
    }
    public class ТНВЭД
    {
        public string Наименование { get; set; }

        public string ВидОбъекта { get; set; }
        [JsonProperty("ПолнНаименование")]
        public string НаименованиеПолное { get; set; }

        [JsonProperty("ЕдИзм")]
        public string ЕдиницаИзмерения { get; set; }

    }
    public class ТоварнаяГруппа
    {
        public string Наименование { get; set; }

        public string ВидОбъекта { get; set; }
        
    }
    public class ЕдИзм
    {
        public string Наименование { get; set; }

        public string ВидОбъекта { get; set; }
        [JsonProperty("ПолнНаименование")]
        public string НаименованиеПолное { get; set; }
        [JsonProperty("КодСт")]
        public string Код { get; set; }
    }

    public class СтранаПроисхождения
    {
        public string Наименование { get; set; }

        public string ВидОбъекта { get; set; }

        [JsonProperty("ИнострНаименование")]
        public string МеждународноеНаименование { get; set; } //ю03_Продукты

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
        [JsonProperty("Телефон_Стат")]
        public string НомерТелефонаБезКодов { get; set; }
        [JsonProperty("Телефоны")]
        public string НомерТелефона { get; set; }
        [JsonProperty("НасПункт_Стат")]
        public string Город { get; set; }
        [JsonProperty("ЭлектронынйАдрес")]
        public string АдресЭП { get; set; }


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

        [JsonProperty("Телефон_Стат")]
        public string НомерТелефонаБезКодов { get; set; }
        [JsonProperty("Телефоны")]
        public string НомерТелефона { get; set; }
        [JsonProperty("НасПункт_Стат")]
        public string Город { get; set; }
        [JsonProperty("ЭлектронныйАдрес")]
        public string АдресЭП { get; set; }
        [JsonProperty("GLN")]
        public string? Удалить_GLN { get; set; }
        //public string? ДокументНомер { get; set; }
        //public string? ДокументСерия { get; set; }
        //[JsonProperty("ДокументДатаВыдачи")]
        //public string? СвидетельствоДатаВыдачи { get; set; }
        

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

    public class Склад
    {
        public string Наименование { get; set; }
        public string ВидОбъекта { get; set; }

        //[JsonProperty("Контрагент")]
        //public Организация Организация { get; set; }

    }

    //public class Организация
    //{
    //    public string Наименование { get; set; }
    //    public string ВидОбъекта { get; set; }
    //    [JsonProperty("ПолнНаименование")]
    //    public string НаименованиеПолное { get; set; }
    //    public string КПП { get; set; }
    //    [JsonProperty("ОКПО")]
    //    public string КодПоОКПО { get; set; }
    //    public string НомерТелефона { get; set; }

    //}

    public class Todo
    {
       

          
            public string ВидОбъекта { get; set; }
            public string GUID_Retail { get; set; }
            [JsonProperty("НомерЭлНакл")]
            public string НомерЭлектроннойНакладной { get; set; }
            public string Прицеп { get; set; }

            public string ПереданыДокументы { get; set; }
            public string ПутевойЛист { get; set; }
            [JsonProperty("ДовДата")]
            public string ДоверенностьДата { get; set; }
            [JsonProperty("ДовНом")]
            public string ДоверенностьНомер { get; set; }
            [JsonProperty("ДовФИО")]
            public string ДоверенностьЛицо { get; set; }
            [JsonProperty("СерияБланка")]
            public string КодБланка { get; set; }

            public string ТипБСО { get; set; }
            public string НомерБСО { get; set; }
            public string СерияБСО { get; set; }
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


            [JsonProperty("МестоХранения_UID")]
            public string Склад_UID { get; set; }
            [JsonProperty("МестоХранения")]
            public Склад Склад { get; set; }


            [JsonProperty("ДатаПрибытияП")]
            public string ДатаПрибытияПогрузка { get; set; }
            [JsonProperty("СчетПолучателя_UID")]
            public string БанковскийСчетГрузополучателя_UID { get; set; }
            [JsonProperty("СчетПолучателя")]
            [JsonPropertyOrder(int.MaxValue)]
            public РасчетныйСчет БанковскийСчетГрузополучателя { get; set; }
        


    }
}


