using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerEatCardState : EatCardState
{
    public TigerEatCardState(Card card) : base(card)
    {
        StateName = "TigerEatCardState";
        preditor = card;
    }
    
    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRangeTiger(preditor.pos, prey.pos) && Utilities.CanPredEatPray(preditor, prey))
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
        GUIManager.inst.RemoveImage("FirstImage");
        GUIManager.inst.RemoveImage("SecondImage");
    }
}
