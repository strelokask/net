namespace Domain;

public abstract class BaseEntity<T>
{
    public T Id {get;set;}
    public DateTimeOffset CreatedDate {get;set;}
    public DateTimeOffset LastModifiedDate {get;set;}
}

public abstract class BaseEntity : BaseEntity<int>{}