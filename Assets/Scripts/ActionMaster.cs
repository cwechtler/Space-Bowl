using System.Collections.Generic;

public static class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	public static Action NextAction (List<int> rolls) {
		Action nextAction = Action.Undefined;
		List<int> newRolls = new List<int>(rolls);
		for (int i = 0; i < newRolls.Count; i++) { // Step through rolls
			
			if (i == 20) {
				nextAction = Action.EndGame;
			} else if ( i >= 18 && newRolls[i] == 10 ){ // Handle last-frame special cases
				nextAction = Action.Reset;
			} else if ( i == 19 ) {
				if (newRolls[18]==10 && newRolls[19]==0) {
					nextAction = Action.Tidy;
				} else if (newRolls[18] + newRolls[19] == 10) {
					nextAction = Action.Reset;
				} else if (newRolls [18] + newRolls[19] >= 10) {  // Roll 21 awarded
					nextAction = Action.Tidy;
				} else {
					nextAction = Action.EndGame;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (newRolls[i] == 10) {
					newRolls.Insert (i+1, 0); // Insert virtual 0 after strike
					nextAction = Action.EndTurn;
				} else {
					nextAction = Action.Tidy;
				}
			} else { // Second bowl of frame
				nextAction = Action.EndTurn;
			}
		}
		
		return nextAction;
	}
}