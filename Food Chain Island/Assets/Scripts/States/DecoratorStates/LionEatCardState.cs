using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionEatCardState : EatCardState
{
    public LionEatCardState(Card card) : base(card)
    {
        StateName = "LionEatCardState";
        preditor = card;
    }
    public LionEatCardState() : base()
    {
     
    }

    
    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRange(preditor.pos, prey.pos) && Utilities.CanPredEatPrayLion(preditor, prey))
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
        preditor.GetComponent<Collider>().enabled = true;
        GUIManager.inst.RemoveAbilityText();
        GUIManager.inst.RemoveImage("SecondImage");
    }
}
