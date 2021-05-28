using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LynxEatCardState : EatCardState
{
    public LynxEatCardState(Card card) : base(card)
    {
        StateName = "LynxEatCardState";
        preditor = card;
    }

    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRangeLynx(preditor.pos, prey.pos) && Utilities.CanPredEatPray(preditor, prey))
        {
            preditor.MyField.Occupant = null;
            preditor.MoveAnim(prey.MyField);
            preditor.Eaten += 1;
            MonoBehaviour.Destroy(prey.gameObject);
            preditor.Ability();
        }else {
            Debug.Log("Not in Range OR Cant eat");
            StateManager.ChangeState(new NeutralState());
        }
    }
    public override void OnStateEnter()
    {
        GUIManager.inst.RemoveAbilityText();
    }

    public override void OnStateExit()
    {
        if (preditor != null)
        {
            preditor.faceObject.transform.DOMove(new Vector3(preditor.MyField.transform.position.x, preditor.MyField.transform.position.y, preditor.MyField.transform.position.z), 0.5f, false);
        }
        preditor.GetComponent<Collider>().enabled = true;
        GUIManager.inst.RemoveAbilityText();
        GUIManager.inst.RemoveImage("SecondImage");
    }
}
