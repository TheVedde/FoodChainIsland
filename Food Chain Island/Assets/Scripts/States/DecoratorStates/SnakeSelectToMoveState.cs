using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSelectToMoveState : SelectToMoveState
{
    public SnakeSelectToMoveState(int moves, bool imf) : base(moves, imf)
    {
        StateName = "SelectToMoveState";
        Moves = moves;
        isMoveForced = imf;
    }

    public override void OnStateEnter()
    {
        GUIManager.inst.DisplayAbilityText("Snake Ability");
    }
    public override void OnMouseEnter(Card card) 
    {
        GUIManager.inst.DisplayFirstImage(card);
    }

    public override void OnMouseExit(Card card)
    {
        GUIManager.inst.RemoveImage("FirstImage");
    }

    public override void OnMouseDown(Card prey)
    {
        StateManager.ChangeState(new SwitchCardState(prey));
    }
}
