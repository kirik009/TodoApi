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
    

    string receivedJson = JsonSerializer.Serialize(todo);

    Object[] str = new Object[1];

    str[0] = receivedJson;
  
   


    type.InvokeMember("Test",
    flagsM, null, inst, str);

    inst = null;
  
    GC.Collect();
    GC.WaitForPendingFinalizers();


        return Results.Created($"/todoitems/{todo.Id}", todo);
    
});



app.Run();



