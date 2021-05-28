using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GatorEatCardState : EatCardState
{
    public GatorEatCardState(Card card) : base(card)
    {
        StateName = "GatorEatCardState";
        preditor = card;
    }
    
    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRange(preditor.pos, prey.pos) && Utilities.CanPredEatPray(preditor, prey))
        {
            preditor.Eaten += 1;
            prey.faceObject.transform.DOMove(new Vector3(preditor.MyField.transform.position.x, preditor.MyField.transform.position.y, preditor.MyField.transform.position.z), 0.5f, false);
            MonoBehaviour.Destroy(prey.gameObject);
            preditor.Ability();
        }  else {
            Debug.Log("Not in Range OR Cant eat");
            StateManager.ChangeState(new NeutralState());
        }
    }

    public override void OnStateExit()
    {
        if (preditor != null)
        {
            preditor.faceObject.transform.DOMove(new Vector3(preditor.MyField.transform.position.x, preditor.MyField.transform.position.y, preditor.MyField.transform.position.z), 0.5f, false);
        }
        
        preditor.GetComponent<Collider>().enabled = true;
        GUIManager.inst.RemoveAbilityText();
        GUIManager.inst.RemoveImage("FirstImage");
        GUIManager.inst.RemoveImage("SecondImage");
    }

}
