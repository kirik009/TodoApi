using Api;
using System.Reflection;
using System.Text.Json;
using Object = System.Object;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/todoitems", async (Todo todo) =>
{
    var v77 = Type.GetTypeFromProgID("V77S.Application", true);
    var inst = Activator.CreateInstance(v77);
    BindingFlags flagsM = BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static;
    BindingFlags flagsP = BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Static;

    var type = inst.GetType();

    Object[] arggs = new Object[3];
    arggs[0] = type.InvokeMember("RMTrade", flagsM, null, inst, null);

    string v77base = "D:\\wor\\S";
    string user = "Кирилл";
    string password = "";

    arggs[1] = @"/D" + v77base + " /N" + user + " /P" + password;

    arggs[2] = @"NO_SPLASH_SHOW";

    bool ok =
    (System.Boolean)inst.GetType().InvokeMember("Initialize", flagsM, null, inst,
    arggs);
    

    //Object[] obj = new Object[] { todo.Name }; // Замените на свои свойства

    ////"{\"name\":\"walk anton\",\"isComplete\":true}"
    //Object[] Строчка = new Object[1];


    //Строчка[0] = "{\"name\":\"walk anton\",\"isComplete\":\"1\"}";

    //Object[] Объект = new Object[2];


    //Объект[0] = todo.Склад;
    //Объект[1] = todo.Автомобиль;



    //Object[] Отчет = new Object[3];


    //Отчет[0] = "Отчет";
    //Отчет[1] = Объект;
    //Отчет[2] = "D:\\wor\\UN_JSON_.ert";

    //object form =
    //type.InvokeMember(@"Тест",
    //flagsM, null, inst, Отчет);
    //if (ok)
    //{
    //    Object[] Обьект = new Object[2];


    //    Обьект[0] = todo.Склад;
    //    Обьект[1] = todo.Автомобиль;

    //}
    //ДокПроверка.GetType().InvokeMember(@"Новый", flagsM, null, ДокПроверка, new object[] { null });
    //ДокПроверка.GetType().InvokeMember(@"УстановитьАтрибут", flagsM, null, ДокПроверка, new object[] { "Реквизит", "С# сила" });
    //ДокПроверка.GetType().InvokeMember(@"Записать", flagsM, null, ДокПроверка, new object[] { null });

    //Object[] Проверка = new Object[1];

    //Проверка[0] = @"Документ.Проверка";


    string receivedJson = JsonSerializer.Serialize(todo);

    Object[] стр = new Object[1];

    стр[0] = receivedJson;
  
  


    type.InvokeMember(@"Тест",
    flagsM, null, inst, стр);

    inst = null;
  
    GC.Collect();
    GC.WaitForPendingFinalizers();


        return Results.Created($"/todoitems/{todo.Id}", todo);
    
});



app.Run();



