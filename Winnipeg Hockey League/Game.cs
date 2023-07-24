using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winnipeg_Hockey_League
{
    internal class Game
    {
        private Team homeTeam;  // The home team playing the game.
        private Team awayTeam;  // The away team playing the game.
        private Random random;  // Random number generator for simulating shots.

        public static List<Game> GameResults = new List<Game>();   // List to store game results.

        public Game(Team homeTeam, Team awayTeam)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            random = new Random();    // Initialize the random number generator.
        }

        public string Result { get; private set; }   // The result of the game.

        public void Play()
        {
            int homeGoals = TakeShots(homeTeam);    // Simulate shots for the home team.
            int awayGoals = TakeShots(awayTeam);    // Simulate shots for the away team.

            Result = $"{homeTeam.Name} vs {awayTeam.Name}\n";

            // Determine the winner or if it's a tie, and update team stats accordingly.
            if (homeGoals > awayGoals)
            {
                Result += $"{homeTeam.Name} Wins! With a score of {homeGoals} to {awayGoals}.";
                homeTeam.Wins++;
                awayTeam.Losses++;
                homeTeam.Points += 2;   // Update points for the winning team.
            }
            else if (homeGoals < awayGoals)
            {
                Result += $"{awayTeam.Name} Wins! With a score of {awayGoals} to {homeGoals}.";
                homeTeam.Losses++;
                awayTeam.Wins++;
                awayTeam.Points += 2;   // Update points for the winning team.
            }
            else
            {
                Result += "The game ends in a tie!";
                homeTeam.Ties++;
                awayTeam.Ties++;
                homeTeam.Points++;      // Update points for tying teams. Both team receive 1 points each.
                awayTeam.Points++;
            }

            homeTeam.GamesPlayed++;   // Increment games played for both teams.
            awayTeam.GamesPlayed++;

            // Update goals scored and goals against for each team.
            homeTeam.GoalsFor += homeGoals;
            homeTeam.GoalsAgainst += awayGoals;
            awayTeam.GoalsFor += awayGoals;
            awayTeam.GoalsAgainst += homeGoals;

            GameResults.Add(this);    // Add this game to the list of game results.
        }

        private int TakeShots(Team team)
        {
            int goals = 0;
            Random random = new Random();

            // Calculate the total number of shots for the team (at least one for each player and the goalie)
            int totalShots = team.Players.Count + 1;

            // Determine if the team is the home team or away team
            string teamType = team == homeTeam ? "Home Team" : "Away Team";

            Console.WriteLine($"{teamType} - {team.Name}");

            // Loop through each player on the team and simulate their shots.
            for (int playerIndex = 0; playerIndex < team.Players.Count; playerIndex++)
            {
                Player player = team.Players[playerIndex];
                int playerShots = random.Next(1, 5); // Random number of shots between 1 and 4
                totalShots -= playerShots;

                // Simulate each shot for the player.
                for (int shot = 0; shot < playerShots; shot++)
                {
                    // "Next" method idea: https://www.geeksforgeeks.org/c-sharp-random-next-method/
                    // Next method is being used to simulate various random events during the game,
                    // such as the outcome of shots and whether there are assisting players.
                    if (random.Next(0, 2) == 1)
                    {
                        List<Player> assistingPlayers = new List<Player>();
                        if (random.Next(0, 2) == 1) // Check if there is an assist
                        {
                            int assistingPlayersCount = random.Next(0, 3); // Random number of assisting players (0, 1, or 2)
                            for (int assist = 0; assist < assistingPlayersCount; assist++)
                            {
                                int randomPlayerIndex = random.Next(0, team.Players.Count);
                                Player randomPlayer = team.Players[randomPlayerIndex];
                                assistingPlayers.Add(randomPlayer);
                            }
                        }

                        player.ScoreGoal(assistingPlayers);
                        Console.WriteLine($"{player.Name} takes a shot! Scores!");

                        // Display assists in the output
                        if (assistingPlayers.Count > 0)
                        {
                            Console.Write("Assisted by: ");
                            foreach (var assistingPlayer in assistingPlayers)
                            {
                                Console.Write($"{assistingPlayer.Name} ");
                            }
                            Console.WriteLine();
                        }

                        goals++;
                    }
                    else
                    {
                        Console.WriteLine($"{player.Name} takes a shot! Saved!");
                    }
                    player.TakeShotOnGoal();
                }
            }

            // Simulate shots for the goalie
            int goalieShots = random.Next(1, 6); // Random number of shots between 1 and 5
            totalShots -= goalieShots;

            for (int i = 0; i < goalieShots; i++)
            {
                if (random.Next(0, 2) == 1)
                {
                    team.Goalie.Save();
                    Console.WriteLine($"{team.Goalie.Name} takes a shot! Saved!");
                }
                else
                {
                    Console.WriteLine($"{team.Goalie.Name} takes a shot! Scores!");
                }
                team.Goalie.TakeShotOnGoal();
            }

            // If there are remaining shots, distribute them randomly among players and the goalie
            for (int i = 0; i < totalShots; i++)
            {
                int randomPlayerIndex = random.Next(0, team.Players.Count);
                Player randomPlayer = team.Players[randomPlayerIndex];

                if (random.Next(0, 2) == 1)
                {
                    List<Player> assistingPlayers = new List<Player>();
                    if (random.Next(0, 2) == 1) // Check if there is an assist
                    {
                        int assistingPlayersCount = random.Next(0, 3); // Random number of assisting players (0, 1, or 2)
                        for (int j = 0; j < assistingPlayersCount; j++)
                        {
                            int randomAssistIndex = random.Next(0, team.Players.Count);
                            Player randomAssistPlayer = team.Players[randomAssistIndex];
                            assistingPlayers.Add(randomAssistPlayer);
                        }
                    }

                    randomPlayer.ScoreGoal(assistingPlayers);
                    Console.WriteLine($"{randomPlayer.Name} takes a shot! Scores!");
                    goals++;
                }
                else
                {
                    Console.WriteLine($"{randomPlayer.Name} takes a shot! Saved!");
                }
                randomPlayer.TakeShotOnGoal();
            }

            return goals;
        }
    }
}
