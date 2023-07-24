using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winnipeg_Hockey_League
{
    internal class Team
    {
        public readonly string Name;       // The name of the team.
        public int GamesPlayed;            // The total number of games played by the team.
        public int Wins;                   // The number of games won by the team.
        public int Losses;                 // The number of games lost by the team.
        public int Ties;                   // The number of games tied by the team.
        public int Points;                 // The total points earned by the team.
        public int GoalsFor;               // The total number of goals scored by the team.
        public int GoalsAgainst;           // The total number of goals conceded by the team.
        public Goalie Goalie;              // The goalie representing the team.
        public List<Player> Players;       // The list of players who belong to the team.
        public Team(string name)
        {
            Name = name;                   // Initialize the team with the provided name.
            Players = new List<Player>();  // Create an empty list to store the players.
        }
    }
}

