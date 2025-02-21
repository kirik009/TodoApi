using Api;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Object = System.Object;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
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
    Object[] Объект = new Object[2];


    Объект[0] = todo.Склад;
    Объект[1] = todo.Автомобиль;

    string receivedJson = JsonSerializer.Serialize(todo);

    Object[] стр = new Object[1];

    стр[0] = receivedJson;
    Объект[0] = todo.Склад;
    Объект[1] = todo.Автомобиль;

  


    type.InvokeMember(@"Тест",
    flagsM, null, inst, стр);

    //inst.GetType().InvokeMember(@"ЗавершитьРаботуСистемы", flagsM, null, inst,
    //new object[] { 0});
    inst = null;
    db.Todos.Add(todo);
        GC.Collect();
        GC.WaitForPendingFinalizers();

        await db.SaveChangesAsync();


        return Results.Created($"/todoitems/{todo.Id}", todo);
    
});



app.Run();



