
using Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using var context = new FootballLeageDbContext();

await GetAllTeams();

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

