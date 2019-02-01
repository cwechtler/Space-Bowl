using System.Collections.Generic;

public static class ScoreMaster{

	//Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative(List<int> rolls){
		List<int> cumulativeScore = new List<int>();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames (rolls)){
			runningTotal += frameScore;
			cumulativeScore.Add(runningTotal);
		}
		return cumulativeScore;       
	}

	//Returns a list of individual frame scores.
	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frames = new List<int>();

		// Index i points to 2nd bowl of the frame
		for (int i = 1; i < rolls.Count; i += 2){
			if (frames.Count == 10) { break; }                  // Prevents 11th frame score

			if (rolls[i - 1] + rolls[i] < 10){                  // Normal "Open" frame
				frames.Add(rolls[i - 1] + rolls[i]);
			}

			if (rolls.Count - i <= 1) { break; }                // Insufficient Look-ahead for Strike/Spare

			if (rolls[i - 1] == 10){                            // Calculate Strike
				i--;                                            // Strike Frame only has one bowl
				frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
			} else if (rolls[i - 1] + rolls[i] == 10){          // Calculate Spare bonus
				frames.Add(10 + rolls[i + 1]);
			}
		}
		return frames;
	}
}
