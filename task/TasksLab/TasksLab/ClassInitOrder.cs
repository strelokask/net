namespace TasksLab;

public class ClassInitOrder
{
    //1
    static string staticValue = "staticValue";
    //3
    string instanceValue = "instanceValue";

    //2
    static ClassInitOrder()
    {
        Console.WriteLine("static ctor");
    }

    //4
    public ClassInitOrder()
    {
        Console.WriteLine("instance ctor");
    }
}