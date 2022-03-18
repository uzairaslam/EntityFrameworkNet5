// See https://aka.ms/new-console-template for more information
using EntityFrameworkNet6.Data;
using EntityFrameworkNet6.Domain;

class Program
{

    private static readonly FootballLeagueDbContext _context = new FootballLeagueDbContext();
    // Main Method
    static async Task Main(String[] args)
    {

        #region Simple Insert Operations
        #region insert in one table
        //_context.Leagues.Add(new EntityFrameworkNet6.Domain.League() { Name = "PSL" });
        //_context.SaveChanges();
        #endregion

        #region insert in table and its child tables
        //var league = new League() { Name = "La Liga" };
        //await _context.Leagues.AddAsync(league);
        //await _context.SaveChangesAsync();
        //await AddTeamsWitLeague(league);
        //await _context.SaveChangesAsync();
        #endregion

        #region insert in table also in parent table
        ////Note///////
        //First and second way will create new entry in League
        //

        //// First Way
        //var league = new League() { Name = "Bundesliga" };
        //var team = new Team() { Name = "Bayern Munich", League = league };
        //await _context.AddAsync(team);
        //await _context.SaveChangesAsync();

        //// Second Way
        //var league = new League() { Name = "Armenian Premier League (Armenian)" };
        //var team = new Team() { Name = "Ararat", League = league };
        //await _context.Teams.AddAsync(team);
        //await _context.SaveChangesAsync();

        //// Third Way
        var team = new Team() { Name = "Pyunik", LeagueId = 5 };
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        #endregion
        #endregion

        Console.WriteLine("Main Method");
    }

    static async Task AddTeamsWitLeague(League league)
    {
        var teams = new List<Team>()
        {
            new Team() { Name = "Real Madrid", LeagueId = league.Id },
            new Team() { Name = "Barcelona", LeagueId = league.Id },
            new Team() { Name = "Atlético Madrid", League = league }
        };
       await _context.Teams.AddRangeAsync(teams);
    }
}
