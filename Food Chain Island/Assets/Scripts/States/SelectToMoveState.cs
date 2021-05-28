using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class SelectToMoveState : State
{
    protected bool isMoveForced = false;
    protected int Moves;
    public SelectToMoveState(int moves, bool imf) : base()
    {
        StateName = "SelectToMoveState";
        Moves = moves;
        isMoveForced = imf;
    }
    

    public override void OnMouseDown(Card prey)
    {
        if (prey.name == "Whale" || prey.name == "shark")
        {
            prey.Ability();
        }
        StateManager.ChangeState(new MoveState(Moves, prey, isMoveForced));
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
}
