using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RacoonRemovedUnstackedState : RemovedUnstackedState
{
    private Card preditor = null;
    public RacoonRemovedUnstackedState(Card card)
    {
        StateName = "RacoonRemoveUnstacked";
        preditor = card;
    }
    public override void OnMouseDown(Card prey) {
        GameObject.Destroy(prey.gameObject);
        preditor.Ability();
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
