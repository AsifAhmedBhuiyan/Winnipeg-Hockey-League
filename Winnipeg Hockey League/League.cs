using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winnipeg_Hockey_League
{
    internal class League
    {
        private List<Team> teams;   // The list of teams participating in the league.

        // Public property to get the list of teams.
        // This allows external code to read the list of teams
        // without direct access to the private field.
        public List<Team> Teams
        {
            get { return teams; } 
        }

        // Constructor to initialize the league with an empty list of teams.
        // This ensures that every time a new League object is created,
        // it starts with an empty list of teams.
        public League()
        {
            teams = new List<Team>();
        }

        // Method to add a team to the league if it's not already present.
        public void AddTeam(Team team)
        {
            if (!teams.Contains(team))
            {
                teams.Add(team);
            }
        }

        // Method to find the Most Valuable Player (MVP) in the entire league based on points scored.
        public Player FindLeagueMVP()
        {
            Player mvp = null;             // The Most Valuable Player to be determined.
            int highestPoints = 0;         // The highest points scored by any player so far.

            // Iterate through each team and each player to find the player with the highest points.
            for (int i = 0; i < teams.Count; i++)
            {
                Team team = teams[i];
                for (int j = 0; j < team.Players.Count; j++)
                {
                    Player player = team.Players[j];
                    if (player.Points > highestPoints)
                    {
                        highestPoints = player.Points;
                        mvp = player;
                    }
                }
            }

            return mvp;
        }

        // Method to find the Most Valuable Player (Goalie)  in the entire league based on save percentage.
        public Goalie FindLeagueGoalieMVP()
        {
            Goalie mvp = null;                     // The Most Valuable Goalie to be determined.
            double highestSavePercentage = 0;      // The highest save percentage achieved so far.

            // Iterate through each team and check if they have a goalie to find the MVP.
            for (int i = 0; i < teams.Count; i++)
            {
                Team team = teams[i];
                if (team.Goalie != null)
                {
                    double savePercentage = team.Goalie.SavePercentage;
                    if (savePercentage > highestSavePercentage)
                    {
                        highestSavePercentage = savePercentage;
                        mvp = team.Goalie;
                    }
                }
            }

            return mvp;
        }

        // Method to find the league winner based on total points earned by each team.
        public Team FindLeagueWinner()
        {
            // Return the team with the highest points 
            // OrderByDescending and FirstOrDefault methods.
            return teams.OrderByDescending(team => team.Points).FirstOrDefault();
        }
    }
}



