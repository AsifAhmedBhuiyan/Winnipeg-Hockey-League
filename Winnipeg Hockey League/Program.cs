using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Winnipeg_Hockey_League
{
    internal class Program 
    {
        // The entry point of the program.
        public static void Main()
        {
            // Call the PlaySeason method to simulate a hockey league season.
            PlaySeason();
        }

        // Method to simulate a hockey league season.
        public static void PlaySeason()
        {
            // Create a new instance of the League class to manage the league.
           // the program can leverage the capabilities provided by the League class
           // to handle the simulation of a hockey league season, organize teams, and
           // calculate results.
           League league = new League();

            // Create teams for the league.
            Team team1 = new Team("St. James Falcons");
            Team team2 = new Team("River Heights Rats");
            Team team3 = new Team("St. Louis Blues");
            Team team4 = new Team("Winnipeg Jets");

            // Add the teams to the league.
            league.AddTeam(team1);
            league.AddTeam(team2);
            league.AddTeam(team3);
            league.AddTeam(team4);

            // Create and add players and goalies to each team.
            CreatePlayersAndGoalies(team1);
            CreatePlayersAndGoalies(team2);
            CreatePlayersAndGoalies(team3);
            CreatePlayersAndGoalies(team4);

            // Retrieve the list of teams participating in the hockey league.
            List<Team> teams = league.Teams;

            // Define the required minimum number of games for each team.
            int minimumGames = 5;

            // Get the total number of teams in the league.
            int maxTeams = teams.Count;

            // Initialize the variable to track the total number of games played.
            int gamesPlayed = 0;

            // Continue the simulation until each team has played at least the
            // required minimum number of games.
            while (gamesPlayed < minimumGames * maxTeams)
            {
                // Loop through each team to schedule matches.
                for (int i = 0; i < maxTeams; i++)
                {
                    // For each team, schedule matches against other teams
                    // starting from the next index to avoid duplicate matches.
                    for (int j = i + 1; j < maxTeams; j++)
                    {
                        // Get the home team and away team for the match.
                        Team homeTeam = teams[i];
                        Team awayTeam = teams[j];

                        // Create a new game instance and simulate the match.
                        Game game = new Game(homeTeam, awayTeam);
                        game.Play();

                        // Increment the gamesPlayed count, as each game involves two teams.
                        gamesPlayed++;
                    }
                }
            }


            // Output season results.
            Console.WriteLine("Season Results:");
            Console.WriteLine("================");

            // Output game results for each played game.
            Console.WriteLine("Game Results:");
            foreach (Game game in Game.GameResults)
            {
                Console.WriteLine(game.Result);
            }
            Console.WriteLine();

            // Output league standings for each team.
            Console.WriteLine("League Standings:");
            Console.WriteLine("=================");

            foreach (Team team in teams)
            {
                Console.WriteLine($"{team.Name} - Games Played: {team.GamesPlayed}, " +
                    $"Wins: {team.Wins}, Losses: {team.Losses}, Ties: {team.Ties}, " +
                    $"Points: {team.Points}, Goals For: {team.GoalsFor}, " +
                    $"Goals Against: {team.GoalsAgainst}");
            }
            Console.WriteLine();

            // Output the league winner.
            Team leagueWinner = league.FindLeagueWinner();
            Console.WriteLine($"League Winner: {leagueWinner.Name}");

            // Output the league MVP (Most Valuable Player).
            Player leagueMVP = league.FindLeagueMVP();
            Console.WriteLine($"League MVP: {leagueMVP.Name}");

            // Output the league goalie MVP (Most Valuable Player).
            Goalie leagueGoalieMVP = league.FindLeagueGoalieMVP();
            Console.WriteLine($"League Goalie MVP: {leagueGoalieMVP.Name}");
        }

        // Method to create players and goalies for a given team and add them to
        // the team's Players list and Goalie property.
        static void CreatePlayersAndGoalies(Team team)
        {
            for (int i = 1; i <= 4; i++)
            {
                string playerName = $"Player{i} of {team.Name}";
                Player player = new Player(playerName);
                team.Players.Add(player);
            }

            string goalieName = $"Goalie of {team.Name}";
            Goalie goalie = new Goalie(goalieName);
            team.Goalie = goalie;
        }
    }
}

