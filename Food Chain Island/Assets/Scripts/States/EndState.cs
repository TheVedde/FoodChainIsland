using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{
    private int cardsScore = 0;
    public EndState(int cardsleft) : base()
    {
        cardsScore = cardsleft;
        WriteScore();
    }

    public void WriteScore()
    {
        
        GUIManager.inst.ScoText.text += cardsScore.ToString();

        switch (cardsScore)
        {
            case 1:
                GUIManager.inst.FinishedMessage.text = "Flawless";
                break;
            case 2: 
                GUIManager.inst.FinishedMessage.text = "Well Done";
                break;
            case 3: 
                GUIManager.inst.FinishedMessage.text = "Nice Done";
                break;
            default:
                GUIManager.inst.FinishedMessage.text = "Try Again";
                break;
        }

        GUIManager.inst.ShowScore();
    }
}
