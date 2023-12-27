
using Data;
using Infrastructure.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;


var builder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", false, true)
    .AddJsonFile($"appsettings.Local.json", true, true);
IConfiguration configuration = builder.Build();

var services = new ServiceCollection();

services.AddSqlDbContext(configuration);

using var serviceProvider = services.BuildServiceProvider();

using var context = serviceProvider.GetService<FootballLeageDbContext>();

#region test query

//await GetAllTeams();
#region Raw SQL
async Task FromSqlRaw()
{
    Console.WriteLine("Enter name: ");
    var teamName = Console.ReadLine();
    var teamNameParam = new SqlParameter("teamName", teamName);
    var team = context.Teams.FromSqlRaw($"SELECT * FROM Teams WHERE name = @teamNameParam", teamNameParam);
}
async Task FromView()
{
    var details = await context.vw_TeamsAndLeagues.ToListAsync();
}
#endregion

//await GetAllTeams();

void MeasureQuery<T>(Func<List<T>> measureQuery)
{
    var stopwatch = Stopwatch.StartNew();
    var items = measureQuery();
    stopwatch.Stop();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Query executed in {stopwatch.ElapsedMilliseconds} ms for {items.Count} items");
    Console.ResetColor();
}
async Task MeasureQueryAsync<T>(Func<Task<List<T>>> measureQuery)
{
    var stopwatch = Stopwatch.StartNew();
    var items = await measureQuery();
    stopwatch.Stop();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Query ASYNC executed in {stopwatch.ElapsedMilliseconds} ms for {items.Count} items");
    Console.ResetColor();
}
async Task GetAllTeams()
{
    MeasureQuery(() =>
        context.Teams
        .AsNoTracking()
        .ToList()
    );
    MeasureQuery(() =>
        context.Teams
        .AsNoTracking()
        .ToList()
    );
    MeasureQuery(() =>
        context.Teams
        .ToList()
    );
    MeasureQuery(() =>
        context.Teams
        .ToList()
    );
    await Task.Delay(10);
    //await MeasureQueryAsync(() =>
    //     context.Teams
    //    .AsNoTracking()
    //    .ToListAsync()
    //);
    //await MeasureQueryAsync(async () =>
    //    await context.Teams
    //    .AsNoTracking()
    //    .ToListAsync()
    //);
}

#endregion

#region test 2

var firstTeam = context.Teams.AsTracking().First(x => x.Id == 1);
firstTeam.Name = "Team-updated" + DateTimeOffset.UtcNow.ToString();
context.SaveChanges();

#endregion