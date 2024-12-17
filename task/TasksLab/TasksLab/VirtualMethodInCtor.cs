namespace TasksLab;

public class BaseClass
{
    private readonly string name; 
    public BaseClass()
    {
        Console.WriteLine("BaseClass Constructor");
        name = "BaseClass";
        Print();
    }

    public virtual void Print()
    {
        Console.WriteLine("BaseClass Print" + name);
    }
}

public class DerivedClass : BaseClass
{
    private readonly string name;
    public DerivedClass() : base()
    {
        Console.WriteLine("DerivedClass Constructor");
        name = "DerivedClass";
        Print();
    }

    public override void Print()
    {
        Console.WriteLine("DerivedClass Print: " + name);
    }
}