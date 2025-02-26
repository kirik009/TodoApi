using Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    bool ok = (bool)inst.GetType().InvokeMember("Initialize", flagsM, null, inst, arggs);

    if (!ok)
    {
        return Results.Problem("Ошибка инициализации соединения с 1С 7.7");

    }


   
    


    string receivedJson = JsonSerializer.Serialize(todo);
    Object[] str = new Object[1];
    str[0] = receivedJson;

        try
        {
        var spisok = inst.GetType().InvokeMember("CreateObject", flagsM, null, inst, new object[] {"СписокЗначений" });
        spisok.GetType().InvokeMember(@"Установить", flagsM, null, spisok, new object[] { "PostObject", receivedJson});
        inst.GetType().InvokeMember("OpenForm", flagsM, null, inst, new object[] { "Отчет", spisok, "D:\\wor\\UN_JSON_.ert" });
            
        }
        catch (Exception ex)
        {      
                return Results.Problem($"Ошибка записи в 1С");
           
        }


    inst = null;
    
    GC.Collect();
    GC.WaitForPendingFinalizers();

   
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.Run();
