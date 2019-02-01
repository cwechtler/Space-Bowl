using System.Collections.Generic;
using UnityEngine;

public class ActionMasterOld{

    public enum Action { Tidy, Reset, EndTurn, EndGame };

    private int[] bowls = new int[21];
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls) {
        ActionMasterOld am = new ActionMasterOld();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls){
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }

    private Action Bowl(int pins){ 
        if (pins < 0 || pins > 10) { throw new UnityException("Invalid Pin count");}

        bowls[bowl - 1] = pins;

        if (bowl == 21){
            return Action.EndGame;
        }

        //Handle last frame cases
        #region
        if (bowl == 19 && Bowl21Awarded()){ //Strike Bowl 19
            bowl += 1;
            return Action.Reset;
        }
        if(bowl == 20 && Bowl21Awarded()){
            bowl += 1;
            if (pins == 0){ //Gutter ball bowl 20 after strike in 19
                return Action.Tidy;
            }else if ((bowls[19 - 1] + bowls[20 - 1]) % 10 != 0){ //first bowl in 20 after strike in 19
                return Action.Tidy;
            }else{ //Spare or strike frame 20
                return Action.Reset;
            }
        }           
        if (bowl == 20 && !Bowl21Awarded()){ //No bowl 21
                return Action.EndGame;
        }
        #endregion

        //Pre last frame cases
        if (bowl % 2 != 0){ //First bowl of frame
            if (pins == 10){// Strike
                bowl += 2;
                return Action.EndTurn;
            }else{
                bowl += 1;
                return Action.Tidy;
            }         
        }else if (bowl % 2 == 0){ //Second bowl of frame
            bowl += 1;
            return Action.EndTurn;
        }
        throw new UnityException("Not sure what action to return");
    }

    private bool Bowl21Awarded(){
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}
