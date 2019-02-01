using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreDisplay : MonoBehaviour {

	public static int[] score = new int[10];

	public bool IsSpare { get; set; } = false;
	public bool IsStrike { get; set; } = false;

	[SerializeField] private Text[] bowls;
	[SerializeField] private Text[] frameScores;

	public void FillBowls(List<int> rolls) {
		string scoreString = FormatRolls(rolls);   
		for (int i = 0; i < scoreString.Length; i++){
			bowls[i].text = scoreString[i].ToString();
			var last = scoreString.Last();
			if (last.ToString() == " " || last.ToString() == "X"){
				IsStrike = true;
			}
			if (last.ToString() == "/") {
				IsSpare = true;
			}       
		}
	}

	public void FillFrameScores(List<int> frames){
		for (int i = 0; i < frames.Count; i++){
			frameScores[i].text = frames[i].ToString();
			score[i] = frames[i];
		}
	}

	public static string FormatRolls(List<int> rolls) {
		string output = "";
		for (int i = 0; i < rolls.Count; i++){
			int box = output.Length + 1;                                   //Score box 1 to 21

			if (box >= 20 && rolls[i - 1] + rolls[i] == 10){               //Spare frame 21
				output += "/";
			} else if (box % 2 == 0 && rolls[i - 1] + rolls[i] == 10){     //Spare
				output += "/";
			} else if (box >= 19 && rolls[i] == 10){                       //Strike in last frame
				output += "X";
			} else if (rolls[i] == 10){                                    //Strike in frame 1-9
				output += "X ";
			} else if (rolls[i] == 0) {                                    //Bowl 0 enter -
				output += "-";
			} else {                                                       //Normal 1-9 bowl
				output += rolls[i].ToString();
			}
		}
		return output;
	}
}
