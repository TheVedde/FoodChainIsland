using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveState : State
{
    protected Card SelectedCard = null;
    protected int Moves;
    protected bool IsMoveForced = false;

    public MoveState(int moves, Card card, bool imf)
    {
        StateName = "MoveState";
        Moves = moves;
        SelectedCard = card;
        IsMoveForced = imf;
    }
    
    //TODO This method is bloated with if statements, needs fixing
    public override void OnMouseDown(Field field)
    {
        if (IsMoveForced)
        {
            if (field.Occupant == null)
            {
                //Debug.Log(Mathf.Abs(field.position.x - SelectedCard.pos.x) + Mathf.Abs(field.position.y - SelectedCard.pos.y));
                if (IsMoveValidToAssigned(field)) {
                    SelectedCard.MoveAnim(field);
                    StateManager.ChangeState(new NeutralState());
                }else {
                    Debug.Log("Incorrect Amount of spaces");
                }
            }
        }else {
            if (field.Occupant == null) {
                //Debug.Log(Mathf.Abs(field.position.x - SelectedCard.pos.x) + Mathf.Abs(field.position.y - SelectedCard.pos.y));
                
                if (IsMoveValidBelowAssigned(field)) {
                    SelectedCard.MoveAnim(field);
                    StateManager.ChangeState(new NeutralState());
                }else {
                    Debug.Log("Incorrect Amount of spaces");
                }
            }
        }
    }
    protected bool IsMoveValidToAssigned(Field field) {
        if (Mathf.Abs(field.position.x - SelectedCard.pos.x) + 
            Mathf.Abs(field.position.y - SelectedCard.pos.y) == Moves) 
        { return true; } 
        else { return false; }
    }

    private bool IsMoveValidBelowAssigned(Field field) {
        if (Mathf.Abs(field.position.x - SelectedCard.pos.x) +
            Mathf.Abs(field.position.y - SelectedCard.pos.y) <= Moves)
        { return true; }
        else { return false; }
    }

    public override void OnStateEnter()
    {
    }
}
