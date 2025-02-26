namespace Api
{

    public class Склад
    {
        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }

    }

    public class ТабличнаяЧасть
    {

        public int Id { get; set; }
        public double Количество { get; set; }
        public double КоличествоУпаковок { get; set; }
        public double Цена { get; set; }
        public double Сумма { get; set; }



    }
    public class Контрагент
    {

        public int Id { get; set; }
        public string Наименование { get; set; }
        public string НаименованиеПолное { get; set; }
        public string КПП { get; set; }
        public string КодПоОКПО { get; set; }



    }
    public class Todo
    {
       
            public int Id { get; set; }
            public string ВидОбъекта { get; set; }
            public string GUID_Retail { get; set; }
            public string НомерЭлектроннойНакладной { get; set; }
            public string Прицеп { get; set; }
            public string ДоверенностьДата { get; set; }
            public string ДоверенностьНомер { get; set; }
            public string ДоверенностьЛицо { get; set; }
            public string КодБланка { get; set; }
            public string Основание { get; set; }
            public List<ТабличнаяЧасть> ТабличнаяЧасть { get; set; } = new List<ТабличнаяЧасть>();

            public Контрагент Контрагент { get; set; }
            public Склад Склад { get; set; }
            public string Автомобиль { get; set; }
            
            
            
    }
}
