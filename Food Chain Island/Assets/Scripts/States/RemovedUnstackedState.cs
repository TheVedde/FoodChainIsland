using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RemovedUnstackedState : State
{
    public RemovedUnstackedState() : base() { StateName = "removingUnstackedState"; }
    public int RemovableCards = 0;
    public override void OnStateEnter() {
        foreach (GameObject card in CardFactory.inst.CardList) {
            if ( card != null && card.GetComponent<Card>().Eaten > 0) {
                Debug.Log(card.GetComponent<Card>().name + " Card's collider should be disabled");
                card.GetComponent<Collider>().enabled = false;
            }

            else if(card != null && card.GetComponent<Card>().Eaten == 0)
            {
                RemovableCards++;
                card.transform.DOMove(
                    new Vector3(card.transform.position.x, card.transform.position.y + 1,
                        card.transform.position.z), 0.5f, false);
            }
        }
        if (RemovableCards == 0) { StateManager.ChangeState(new NeutralState()); }
    }

    public override void OnMouseDown(Card prey) {
        GameObject.Destroy(prey.gameObject);
        StateManager.ChangeState(new NeutralState());
    }

    public override void OnMouseEnter(Card card)
    {
        
    }

    public override void OnMouseExit(Card card)
    {
        
    }

    public override void OnStateExit() {
        foreach (GameObject card in CardFactory.inst.CardList) {
            if (card != null && card.GetComponent<Card>().Eaten > 0) {
                card.GetComponent<Collider>().enabled = true;

            }

            if (card != null)
            {
                card.transform.DOMove(new Vector3(card.transform.position.x, card.GetComponent<Card>().MyField.transform.position.y, card.GetComponent<Card>().MyField.transform.position.z), 0.5f, false);
            }
        }
        GUIManager.inst.RemoveAbilityText();
        
    }
}
