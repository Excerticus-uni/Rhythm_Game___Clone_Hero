using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

GameSave.SaveGame("Player6", 0, 80);
GameSave.SaveGame("Player1", 10, 0);

public partial class GameSave : Node
{

	/*
	 ____________________________________
	 Private variables:
	 - nada


	 ____________________________________
	 Public methods:
	 - SaveGame(string name, int maxEasy, int maxHard)
	 - AddOrUpdateScore(Dictionary<string, Dictionary<string, int>> playerScores, string playerName, string gameMode, int score)
	 ____________________________________
	 */


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}




	#region Save Game
	public static void SaveGame(string name, int maxEasy, int maxHard)
	{
		string filePath = "Leaderboard.json";


		// Dictionary: PlayerName -> (GameMode -> Score)
		Dictionary<string, Dictionary<string, int>> playerScores;


		try
		{

			#region Reading File
			// Load existing data if file exists
			if (File.Exists(filePath))
			{
				string json = File.ReadAllText(filePath);
				playerScores = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(json)
							   ?? new Dictionary<string, Dictionary<string, int>>();
			}
			else
			{
				playerScores = new Dictionary<string, Dictionary<string, int>>();
			}
			#endregion

			#region Updating Scores
			// Updating score for gamemode based on var values
			if (maxEasy > 0 && maxHard == 0)
			{
				AddOrUpdateScore(playerScores, name, "Easy", maxEasy);
			}
			else if (maxHard > 0 && maxEasy == 0)
			{
				AddOrUpdateScore(playerScores, name, "Hard", maxHard);
			}
			#endregion

			#region Saving Data
			// Save updated data back to JSON file
			string updatedJson = JsonSerializer.Serialize(playerScores, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(filePath, updatedJson);
			File.WriteAllText(filePath, updatedJson);

			Console.WriteLine("Player scores updated successfully!");
			#endregion
		}
		#region Error Handling
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
		#endregion
	}

	#region Update Scores
	// Adds or updates a score for a given player and game mode.
	public static void AddOrUpdateScore(Dictionary<string, Dictionary<string, int>> playerScores, string playerName, string gameMode, int score)
	{
		if (!playerScores.ContainsKey(playerName))
		{
			playerScores[playerName] = new Dictionary<string, int>();
		}

		else if (playerScores[playerName].ContainsKey(gameMode))
		{
			playerScores[playerName][gameMode] = score; // Change existing score
		}
		else
		{
			playerScores[playerName][gameMode] = score; // Add new game score
		}
	}
	#endregion

	#endregion
}
