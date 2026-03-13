using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public partial class GameLeaderboard : Node
{

	#region Attributes
	public static Dictionary<string, int> scoresEasy = new Dictionary<string, int>
	{

	};
	public static Dictionary<string, int> scoresHard = new Dictionary<string, int>
	{

	};
	#endregion

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}



	#region Save Game
	public static void SaveGame(string name, int totalPlayed, int maxEasy, int maxHard)
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

			#region Parsing to Display
			foreach (string player in playerScores.Keys)
			{
				foreach (var innerDict in playerScores[key].Select(k => k.Value))
				{

					if (innerDict.key == "easy")
					{
						scoresEasy.Add(player, innerDict.Value);
					}
					else if (innerDict.key == "hard")
					{
						scoresHard.Add(player, innerDict.Value);
					} 
				}
			}
			#endregion
		}
		#region Error Handling
		catch (Exception ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
		#endregion
	}
	#endregion
}
