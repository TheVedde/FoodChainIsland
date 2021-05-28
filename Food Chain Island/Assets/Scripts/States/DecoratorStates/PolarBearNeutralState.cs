using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PolarBearNeutralState : NeutralState
{

    public PolarBearNeutralState() : base()
    {
        StateName = "PolarBearNeutralState";
    }
    public override void OnStateEnter()
    {
        CardFactory.inst.CardList.Find(o => o.GetComponent<Card>().name == "Polar Bear").GetComponent<BoxCollider>().enabled = false;
    }
    public override void OnMouseEnter(Card card)
    {
        
        card.faceObject.transform.DOMove(new Vector3(card.MyField.transform.position.x, card.transform.position.y + 1, card.transform.position.z), 0.5f, false);
        GUIManager.inst.DisplayFirstImage(card);
    }

    public override void OnMouseExit(Card card)
    {
       
        card.faceObject.transform.DOMove(new Vector3(card.MyField.transform.position.x, card.MyField.transform.position.y, card.MyField.transform.position.z), 0.5f, false);
        GUIManager.inst.RemoveImage("FirstImage");
    }
    
    public override void OnMouseDown(Card card)
    {
        
        //TODO: checking via name needs a better method to check
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
                StateManager.ChangeState(new EatCardState(selectedCard));
                break;
        }
    }


    public override void OnStateExit()
    {
        GUIManager.inst.RemoveAbilityText();
        CardFactory.inst.CardList.Find(o => o.GetComponent<Card>().name == "Polar Bear").GetComponent<BoxCollider>().enabled = true;
        
    }
}
