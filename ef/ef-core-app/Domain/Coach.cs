﻿namespace Domain;

public class Coach : BaseEntity
{
    public string Name {get;set;}

    public Team? Team { get; set; }
}
