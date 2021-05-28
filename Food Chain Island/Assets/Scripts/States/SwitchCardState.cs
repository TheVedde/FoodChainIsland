using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchCardState : State
{
    private Card selectedCard;   
    public SwitchCardState(Card crd) : base() {
        StateName = "Switch Card State";
        selectedCard = crd;
    }

    public override void GoBack()
    {
        StateManager.ChangeState(new SnakeSelectToMoveState(0, false));
    }
    
    public override void OnMouseEnter(Card card) 
    {
        GUIManager.inst.DisplaySecondImage(card);
    }

    public override void OnMouseExit(Card card)
    {
        GUIManager.inst.RemoveImage("SecondImage");
    }

    public override void OnMouseDown(Card prey)
    {
        if (selectedCard != prey)
        {
            //assigns empty field into the chosen card field'
            Field filler = selectedCard.MyField;
            //the chosen card field is now the second chosen card field
            selectedCard.MyField = prey.MyField;
            //the chosen card occupant moves to the selected pos
            selectedCard.MyField.Occupant = selectedCard;
            //assigns pos
            selectedCard.pos = selectedCard.MyField.position;
            //assigns physical transform
            selectedCard.transform.DOMove(selectedCard.MyField.transform.position, 1f, false);
            //selectedCard.transform.position = selectedCard.MyField.transform.position;

            //does the same but for the other card
            prey.MyField = filler;
            prey.MyField.Occupant = prey;
            prey.pos = prey.MyField.position;
            //card.transform.position = card.MyField.transform.position;
            prey.transform.DOMove(prey.MyField.transform.position, 1f, false);
            //change States to new NeutralState
            StateManager.ChangeState(new NeutralState());
        }
        else
        {
            Debug.Log("Cannot move same card");
            StateManager.ChangeState(new SnakeSelectToMoveState(0, false));
        }
       
    }

    public override void OnStateExit()
    {
        GUIManager.inst.RemoveImage("SecondImage");
        GUIManager.inst.RemoveAbilityText();
    }
}
