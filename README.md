# Hockey Stats Tracking App

Welcome to the Hockey Stats Tracking App, an Object Oriented Programming project designed to help me manage and analyze hockey game statistics.

## Project Overview

 The task is to create an app that tracks and calculates various statistics for hockey teams, players, and goalies. The app should handle games, shots on goal, wins, losses, and points. Here's an overview of the specifications:

### Statistics for Teams

- Wins
- Losses
- Ties
- Points
- Goals For (cumulative goals scored)
- Goals Against (cumulative goals conceded)

### Statistics for Players

- Points (from goals and assists)
- Shots on Goal

### Statistics for Goalies

- Save Percentage (saves divided by total shots on goal)

## System Design

Your hockey stats tracking app must include the following classes:

- `League`
- `Team`
- `Player`
- `Goalie`
- `Game`

### Example of Concepts

- OOP Inheritance

## Gameplay

A game consists of teams taking shots on goal, with the outcome of each shot being random. The team with the most goals wins the game. In case of a tie, the game is considered a draw.

## Testing

To test the application, created a method named `PlaySeason` in your `Program` class. This method should:

- Create a league of 4 teams
- Add 4 players and 1 goalie to each team
- Ensure that every team plays against each other at least once
- Simulate games where teams take random shots on goal
- Calculate wins, losses, and points
- Output game results, shots on goal, and season statistics

## Output

At the end of the season, my `Main` method run the `PlaySeason` method and display the following information:

- Each game's outcome: "Team 1 Name vs Team 2 Name", "Team Name Wins! With a score of (Winning Score) to (Losing Score)"
- Each shot on goal: "Player Name takes a shot! (Scores! / Saved!)"
- League winner: Team Name with the highest points
- League MVP: Player Name with the most points
- League Goalie MVP: Goalie Name with the highest save percentage


## Example Output

```plaintext
Home Team - St. James Falcons
Player1 of St. James Falcons takes a shot! Scores!
Assisted by: Player1 of St. James Falcons
...

League Standings:
=================
St. James Falcons - Games Played: 12, Wins: 5, Losses: 7, Ties: 0, Points: 10, Goals For: 55, Goals Against: 58
River Heights Rats - Games Played: 12, Wins: 5, Losses: 5, Ties: 2, Points: 12, Goals For: 66, Goals Against: 65
St. Louis Blues - Games Played: 12, Wins: 7, Losses: 3, Ties: 2, Points: 16, Goals For: 66, Goals Against: 62
Winnipeg Jets - Games Played: 12, Wins: 4, Losses: 6, Ties: 2, Points: 10, Goals For: 64, Goals Against: 66

League Winner: St. Louis Blues
League MVP: Player3 of St. Louis Blues
League Goalie MVP: Goalie of River Heights Rats

