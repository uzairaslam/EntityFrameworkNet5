// See https://aka.ms/new-console-template for more information
using EntityFrameworkNet6.Data;

public partial class Program
{

    private static readonly FootballLeagueDbContext _context = new FootballLeagueDbContext();
    // Main Method
    static public void Main(String[] args)
    {
        _context.Leagues.Add(new EntityFrameworkNet6.Domain.League() { Name = "PSL" });
        _context.SaveChanges();
        Console.WriteLine("Main Method");
    }
}
