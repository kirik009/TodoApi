using Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
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

    bool ok = (bool)inst.GetType().InvokeMember("Initialize", flagsM, null, inst, arggs);

    if (!ok)
    {
        db.Todos.Add(todo);
        await db.SaveChangesAsync();
        return Results.Problem("Ошибка инициализации соединения с 1С 7.7");

    }


    while (db.Todos.Count() > 0)
    {
        db.Todos.ToList().ForEach(x => {
            string receivedJson = JsonSerializer.Serialize(x);
            Object[] str = new Object[1];
            str[0] = receivedJson;

            try
            {
                type.InvokeMember("Test", flagsM, null, inst, str);
                db.Todos.Remove(x);

            }
            catch (Exception ex)
            {
                
                 Results.Problem($"Ошибка записи в 1С: {ex}");

            }
        });
    }


    string receivedJson = JsonSerializer.Serialize(todo);
    Object[] str = new Object[1];
    str[0] = receivedJson;

        try
        {
            type.InvokeMember("Test", flagsM, null, inst, str);
            
        }
        catch (Exception ex)
        {      
                db.Todos.Add(todo);
                await db.SaveChangesAsync();
                return Results.Problem($"Ошибка записи в 1С");
           
        }


    inst = null;
    
    GC.Collect();
    GC.WaitForPendingFinalizers();

   
    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.Run();
