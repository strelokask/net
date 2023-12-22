namespace Domain;

public class Team: BaseEntity
{
    public string Name {get;set; }
    
    public int? LeagueId { get; set; }
    public League League { get; set; }

    public List<Match>? HomeMatches { get; set; }
    public List<Match>? AwayMatches { get; set; }
}