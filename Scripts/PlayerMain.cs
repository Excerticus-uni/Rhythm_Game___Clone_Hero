using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Random;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

/*
____________________________________
Private variables:

- playerName: string
- totalGamesPlayed: int

- maxScoreEasy: int
- playedEasy: int

- maxScoreHard: int
- playedHard: int

____________________________________
Public methods:

- SetPlayerName(string name)
- GetPlayerName(): string

- SetMaxScore(int score, char level)
- GetMaxScore(char level): int

- IncrementGamesPlayed(char level)
- GetGamesPlayed(char level): int

- SetTotalGamesPlayed()
- GetTotalGamesPlayed(): int
____________________________________
*/
public partial class PlayerMain : Node
{
	#region Attributes
	public Random() Rand;

	private string playerName = "Player" + new Rand.Next(1000, 9999);
	private int totalGamesPlayed = 0;

	private int maxScoreEasy = 0;
	private int playedEasy = 0;

	private int maxScoreHard = 0;
	private int playedHard = 0;
	#endregion

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*
		if (playerName == null || playerName.Trim() == "")
		{
			playerName = "Player" + new Random().Next(1000, 9999);
		}
		else if (PastRuns.includes(playerName.Trim()))
		{
			maxScoreEasy = PastScore(playerName, 'E');
			maxScoreHard = PastScore(playerName, 'H');
			playedEasy = PastRuns(playerName, 'E');]
			playedHard = PastRuns(playerName, 'H');
		}
		*/
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta, int score)
	{
	}

	#region Player Name
	public void SetPlayerName(string name)
	{
		this.playerName = name;
	}
	
	public string GetPlayerName()
	{
		return this.playerName;
	}
	#endregion

	#region Max Score
	public void SetMaxScore(int score, char level)
	{
		if (level == 'E' && this.maxScoreEasy < score)
		{ 
			this.maxScoreEasy = score; 
		}
		else if (level == 'H' && this.maxScoreHard < score)
		{
			this.maxScoreHard = score;
		}
	}

	public int GetMaxScore()
	{
		if (level == 'E')
		{
			return this.playerMaxScore;
		}
		else if (level == 'H')
		{
			return this.playerMaxScore;
		}
	}
	#endregion

	#region Games Played
	public void IncrementGamesPlayed()
	{
		if (level == 'E')
		{
			this.playedEasy++;
		}
		else if (level == 'H')
		{
			this.playedHard++;
		}
	}

	public int GetGamesPlayed()
	{
		if (level == 'E')
		{
			return this.playedEasy;
		}
		else if (level == 'H')
		{
			return this.playedHard;
		}
	}

	public void SetTotalGamesPlayed()
	{
		this.totalGamesPlayed = this.playedEasy + this.playedHard;
	}

	public int GetTotalGamesPlayed()
	{
		return this.totalGamesPlayed; 
	}

	#endregion


}
