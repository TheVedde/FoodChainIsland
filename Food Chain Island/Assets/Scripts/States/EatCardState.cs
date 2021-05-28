using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using UnityEngine;

public class EatCardState : State
{
    public Card preditor;
    public EatCardState(Card crd) : base()
    {
        StateName = "EatCardState";
        preditor = crd;
    }
    public EatCardState() : base() { }
    public override void OnStateEnter() { preditor.GetComponent<Collider>().enabled = false; }

    public override void OnMouseEnter(Card card)
    {
        card.faceObject.transform.DOMove(new Vector3(card.MyField.transform.position.x, card.transform.position.y + 1, card.transform.position.z), 0.5f, false);
        GUIManager.inst.DisplaySecondImage(card);
    }

    public override void OnMouseExit(Card card)
    {
        card.faceObject.transform.DOMove(new Vector3(card.MyField.transform.position.x, card.MyField.transform.position.y, card.MyField.transform.position.z), 0.5f, false);
        GUIManager.inst.RemoveImage("SecondImage");
    }

    public override void GoBack() { StateManager.ChangeState(new NeutralState()); }

   
    public override void OnMouseDown(Card prey)
    {
        if (Utilities.IsWithinRange(preditor.pos, prey.pos) && Utilities.CanPredEatPray(preditor, prey))
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
        GUIManager.inst.firstImage.sprite = null;
        GUIManager.inst.firstImage.color = new Color(255, 255, 255, 0);
        GUIManager.inst.secondImage.sprite = null;
        GUIManager.inst.secondImage.color = new Color(255, 255, 255, 0);
        GUIManager.inst.KillPanel.SetActive(false);
        preditor.GetComponent<Collider>().enabled = true;
    }
}
