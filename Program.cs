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
    string user = "������";
    string password = "";

    arggs[1] = @"/D" + v77base + " /N" + user + " /P" + password;

    arggs[2] = @"NO_SPLASH_SHOW";

    bool ok =
    (System.Boolean)inst.GetType().InvokeMember("Initialize", flagsM, null, inst,
    arggs);
    

    //Object[] obj = new Object[] { todo.Name }; // �������� �� ���� ��������

    ////"{\"name\":\"walk anton\",\"isComplete\":true}"
    //Object[] ������� = new Object[1];


    //�������[0] = "{\"name\":\"walk anton\",\"isComplete\":\"1\"}";

    //Object[] ������ = new Object[2];


    //������[0] = todo.�����;
    //������[1] = todo.����������;



    //Object[] ����� = new Object[3];


    //�����[0] = "�����";
    //�����[1] = ������;
    //�����[2] = "D:\\wor\\UN_JSON_.ert";

    //object form =
    //type.InvokeMember(@"����",
    //flagsM, null, inst, �����);
    //if (ok)
    //{
    //    Object[] ������ = new Object[2];


    //    ������[0] = todo.�����;
    //    ������[1] = todo.����������;

    //}
    //�����������.GetType().InvokeMember(@"�����", flagsM, null, �����������, new object[] { null });
    //�����������.GetType().InvokeMember(@"�����������������", flagsM, null, �����������, new object[] { "��������", "�# ����" });
    //�����������.GetType().InvokeMember(@"��������", flagsM, null, �����������, new object[] { null });

    //Object[] �������� = new Object[1];

    //��������[0] = @"��������.��������";
    Object[] ������ = new Object[2];


    ������[0] = todo.�����;
    ������[1] = todo.����������;

    string receivedJson = JsonSerializer.Serialize(todo);

    Object[] ��� = new Object[1];

    ���[0] = receivedJson;
    ������[0] = todo.�����;
    ������[1] = todo.����������;

  


    type.InvokeMember(@"����",
    flagsM, null, inst, ���);

    //inst.GetType().InvokeMember(@"����������������������", flagsM, null, inst,
    //new object[] { 0});
    inst = null;
    db.Todos.Add(todo);
        GC.Collect();
        GC.WaitForPendingFinalizers();

        await db.SaveChangesAsync();


        return Results.Created($"/todoitems/{todo.Id}", todo);
    
});



app.Run();



