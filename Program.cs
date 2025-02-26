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
    string user = "������";
    string password = "";

    arggs[1] = @"/D" + v77base + " /N" + user + " /P" + password;
    arggs[2] = @"NO_SPLASH_SHOW";

    bool ok = (bool)inst.GetType().InvokeMember("Initialize", flagsM, null, inst, arggs);

    if (!ok)
    {
        return Results.Problem("������ ������������� ���������� � 1� 7.7");

    }


   
    


    string receivedJson = JsonSerializer.Serialize(todo);
    Object[] str = new Object[1];
    str[0] = receivedJson;

        try
        {
        var spisok = inst.GetType().InvokeMember("CreateObject", flagsM, null, inst, new object[] {"��������������" });
        spisok.GetType().InvokeMember(@"����������", flagsM, null, spisok, new object[] { "PostObject", receivedJson});
        inst.GetType().InvokeMember("OpenForm", flagsM, null, inst, new object[] { "�����", spisok, "D:\\wor\\UN_JSON_.ert" });
            
        }
        catch (Exception ex)
        {      
                return Results.Problem($"������ ������ � 1�");
           
        }


    inst = null;
    
    GC.Collect();
    GC.WaitForPendingFinalizers();

   
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.Run();
