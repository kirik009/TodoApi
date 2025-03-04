using Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using Object = System.Object;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using TodoApi;
using System.Diagnostics;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Urls.Add("http://192.168.201.39:1500");
string lastMessage = "Ожидание выполнения...";

app.MapPost("/todoitems", async (Todo todo) =>
{
    

    var v77 = Type.GetTypeFromProgID("V77S.Application");
    var inst = Activator.CreateInstance(v77);
    BindingFlags flagsM = BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Static;
    BindingFlags flagsP = BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Static;

    var type = inst.GetType();

    Object[] arggs = new Object[3];
    arggs[0] = type.InvokeMember("RMTrade", flagsM, null, inst, null);

    string v77base = "D:\\wor\\S";
    string user = "Кирилл";
    //string user = "Антон";
    //string v77base = "C:\\work\\S";
    string password = "";

    arggs[1] = @"/D" + v77base + " /N" + user + " /P" + password;
    arggs[2] = @"NO_SPLASH_SHOW";

    bool ok = (bool)inst.GetType().InvokeMember("Initialize", flagsM, null, inst, arggs);

    if (!ok)
    {
        return Results.Problem("Ошибка инициализации соединения с 1С 7.7");

    }
    
    
    string pushJson = JsonConvert.SerializeObject(todo, Formatting.Indented);
    try
        {
        var spisok = inst.GetType().InvokeMember("CreateObject", flagsM, null, inst, new object[] {"СписокЗначений" });
        spisok.GetType().InvokeMember(@"Установить", flagsM, null, spisok, new object[] { "PostObject", pushJson});
        //inst.GetType().InvokeMember("OpenForm", flagsM, null, inst, new object[] { "Отчет", spisok, "D:\\wor\\UN_JSON_.ert" });
        inst.GetType().InvokeMember("OpenForm", flagsM, null, inst, new object[] { "Отчет", spisok, "D:\\wor\\ser (3)\\ser\\TodoApi\\UN_JSON_.ert" });
        string result = (String)spisok.GetType().InvokeMember(@"Получить", flagsM, null, spisok, new object[] { "PostObject" });
        lastMessage +="\r\n" + result;
        Console.WriteLine(result);

    }
        catch (Exception ex)
        {      
                return Results.Problem("Ошибка записи в 1С 7.7");


        }


    //string processName = "1cv7s"; // Имя процесса без .exe

//var processes = Process.GetProcessesByName(processName);
//foreach (var process in Process.GetProcessesByName(processName))
//{
//    if (process.MainWindowHandle == IntPtr.Zero) // Проверяем, есть ли окно
//    {
//        Console.WriteLine($"Закрываем фоновый процесс ID: {process.Id}");
//        process.Kill();
//        process.WaitForExit();
//    }
//    else
//    {
//        Console.WriteLine($"Процесс с окном найден: {process.Id}, не закрываем.");
//    }
//}

 
//inst.GetType().InvokeMember("ЗавершитьРаботуСистемы", flagsM, null, inst, new object[] {0});

    Console.WriteLine(Marshal.AreComObjectsAvailableForCleanup());
    Marshal.FinalReleaseComObject(inst);
    inst = null;
    v77 = null;
    GC.Collect();
    GC.WaitForPendingFinalizers();


   
    return Results.Created($"/todoitems/cr", todo);
});
app.MapGet("", () => lastMessage);

app.Run();
