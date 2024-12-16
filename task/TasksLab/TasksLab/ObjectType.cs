namespace TasksLab;

public class ObjectType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public struct ValueType
{
    public ObjectType ObjectType { get; set; }
    public string StringType { get; set; }
}