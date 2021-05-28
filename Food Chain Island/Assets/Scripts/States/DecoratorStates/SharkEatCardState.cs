using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SharkEatCardState : EatCardState
{
    public SharkEatCardState(Card card) : base(card)
    {
        StateName = "SharkEatCardState";
        preditor = card;
    }

    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRange(preditor.pos, prey.pos) && Utilities.CanPredEatPrayShark(preditor, prey))
        {
            preditor.MyField.Occupant = null;
            preditor.MoveAnim(prey.MyField);
            preditor.Eaten += 1;
            MonoBehaviour.Destroy(prey.gameObject);
            
            preditor.Ability();
        }  else {
            Debug.Log("Not in Range OR Cant eat");
            StateManager.ChangeState(new NeutralState());
        }
    }

    public override void OnStateExit()
    {
        GUIManager.inst.RemoveAbilityText();
        GUIManager.inst.RemoveImage("SecondImage");
    }

 
}
