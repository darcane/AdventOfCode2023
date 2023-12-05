// See https://aka.ms/new-console-template for more information

using AdventOfCode2023;

var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
    .Where(p => typeof(IPuzzleSolver).IsAssignableFrom(p) && p.IsClass);

foreach (var type in types.OrderBy(x=>x.Name))
{
    var instance = Activator.CreateInstance(type);
    if (instance is IPuzzleSolver solver)
    {
        Console.WriteLine($"Solution: {instance.GetType().Name} :");
        solver.Solve();
    }
}