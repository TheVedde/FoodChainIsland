using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonEatCardState : EatCardState
{
    public RacoonEatCardState(Card card) : base(card)
    {
        StateName = "RacoonEatCardState";
        preditor = card;
    }

    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRange(preditor.pos, prey.pos) && Utilities.CanPredEatPray(preditor, prey))
        {
            preditor.MyField.Occupant = null;
            preditor.MoveAnim(prey.MyField);
            preditor.Eaten += 1;
            if (preditor.number - prey.number == 1)
            {
                MonoBehaviour.Destroy(prey.gameObject);
                StateManager.ChangeState(new RacoonRemovedUnstackedState(preditor));
            }
            else {
                preditor.Ability();
            }
        }  else {
            Debug.Log("Not in Range OR Cant eat");
            StateManager.ChangeState(new NeutralState());
        }
    }

    public override void OnStateExit()
    {
        preditor.GetComponent<Collider>().enabled = true;
        GUIManager.inst.RemoveImage("SecondImage");
    }
}
