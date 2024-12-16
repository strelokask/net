using TasksLab;
using ValueType = TasksLab.ValueType;


// await TaskCancel.Run();


var valueType = new ValueType()
{
    StringType = "string",
    ObjectType = new ObjectType()
    {
        Id = 123,
        Name = "original"
    }
};

var copyType = valueType;

valueType.StringType = "updated";
valueType.ObjectType.Id = 999;
valueType.ObjectType.Name = "updatedName";
//StringType изменится, т.к. создается новая строка
//ObjectType НЕ изменится, т.к. хранит ССЫЛКУ на объект
Console.WriteLine($"{valueType.StringType} : {valueType.ObjectType.Id}, {valueType.ObjectType.Name}");
Console.WriteLine($"{copyType.StringType} : {copyType.ObjectType.Id}, {copyType.ObjectType.Name}");
