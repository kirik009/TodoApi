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


    string receivedJson = JsonSerializer.Serialize(todo);

    Object[] ��� = new Object[1];

    ���[0] = receivedJson;
  
  


    type.InvokeMember(@"����",
    flagsM, null, inst, ���);

    inst = null;
  
    GC.Collect();
    GC.WaitForPendingFinalizers();


        return Results.Created($"/todoitems/{todo.Id}", todo);
    
});



app.Run();



