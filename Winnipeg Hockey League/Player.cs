using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winnipeg_Hockey_League
{
    internal class Player
    {
        public string Name { get; }   // The name of the player.
        public Team Team { get; }   // The team to which the player belongs.

        public int GoalsScored { get; protected set; }   // The number of goals scored by the player.
        public int Assists { get; protected set; }   // The number of assists made by the player.
        public int ShotsOnGoal { get; protected set; }   // The total number of shots on goal taken by the player.

        public int Points => (GoalsScored * 2) + Assists;   // Calculates and returns the total points earned by the player.

        public Player(string name)
        {
            Name = name;   // Initialize the player with the provided name.
        }

        // Method for scoring a goal with multiple assisting players.
        public void ScoreGoal(List<Player> assistingPlayers = null)
        {
            GoalsScored++;   // Increment the number of goals scored by the player.
            ShotsOnGoal++;   // Increment the number of shots on goal taken by the player.

            if (assistingPlayers != null)
            {
                int assistingPlayersCount = Math.Min(assistingPlayers.Count, 2);   // Determine the number of assisting players, limited to a maximum of 2.
                for (int i = 0; i < assistingPlayersCount; i++)
                {
                    assistingPlayers[i].Assists++;   // Increment the assists for each assisting player.
                }
            }
        }

        public void TakeShotOnGoal()
        {
            ShotsOnGoal++;   // Increment the number of shots on goal taken by the player.
        }
    }

    internal class Skater : Player
    {
        public Skater(string name) : base(name)
        {
        }
    }

    internal class Goalie : Player
    {
        public int Saves { get; private set; }   // The number of saves made by the goalie.
        public double SavePercentage => (double)Saves / ShotsOnGoal;   // Calculates and returns the save percentage of the goalie.

        public Goalie(string name) : base(name)
        {
        }

        public void ScoreGoal(List<Player> assistingPlayers = null)
        {
            // Goalie can also score goals.
            base.ScoreGoal(assistingPlayers);
        }

        public void Save()
        {
            Saves++;   // Increment the number of saves when the goalie makes a save.
        }
    }
}

