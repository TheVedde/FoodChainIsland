using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SpecialNeutralState: NeutralState
{
    public EatCardState state;
    public SpecialNeutralState(EatCardState t) : base()
    {
        StateName = "SpecialNeutralState";
        state = t;
    }

    public override void OnMouseDown(Card card)
    {
        selectedCard = card;
        switch (selectedCard.name) {
            case "Shark":
                selectedCard.Ability();
                GameObject.Destroy(selectedCard.gameObject);
                break;
            case "Whale":
                selectedCard.Ability();
                GameObject.Destroy(selectedCard.gameObject);
                break;
               
            default:
                state.preditor = selectedCard;
                StateManager.ChangeState(state);
                break;
        }
    } 
}
